using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;

namespace Ideas.Google.GCM
{
    
    public class Server
    {  
        public string ApiKey { get; set; }
        public string DeviceKey { get; set; }
        
        public Server()
        {
            ApiKey = IdeasConfig.Default.GoogleGcmApiKey;
            DeviceKey = IdeasConfig.Default.GoogleGcmDeviceKey;
        }

        /// <summary>
        /// Envia a mensagem para o servidor GCM
        /// </summary>
        /// <param name="notificacao"></param>
        /// <param name="devices"></param>
        /// <returns></returns>
        public ResponseContract Send<N, RN>(N notificacao, List<RN> devices)where N:INotificacao where RN:IReceberNotificacao
        {

            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);
            
            NotificationContract notifContract = new NotificationContract();
            ResponseContract result = new ResponseContract();
            // cria a lista de devices
            notifContract.registration_ids = new List<string>();
            // pega os devices na lista
            for (int i = 0; i < devices.Count; i++)
            {
                // coloca na lista de devices
                notifContract.registration_ids.Add(devices[i].Id);
            }
            //notifContract.registration_ids = new List<string>() { DeviceKey };
            notifContract.TimeToLive = (60 * 60 * 24);
            notifContract.DelayWhileIdle = false;
            notifContract.DryRun = false;
            
            notifContract.data = new ContentContract();
            notifContract.data.id = notificacao.Id;
            notifContract.data.title = notificacao.Title != null ? notificacao.Title : "Notificação GCM";
            notifContract.data.message = notificacao.Title;
            notifContract.data.conteudo = notificacao.Content;
            notifContract.data.image = notificacao.Image;
            notifContract.data.icon = notificacao.Icon;
            notifContract.data.sound = notificacao.Sound;
            notifContract.data.count = notificacao.Count.ToString();
            
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(NotificationContract));
            MemoryStream stream = new MemoryStream();
            ser.WriteObject(stream, notifContract);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            string postJsonData = sr.ReadToEnd();            

            //"{ \"registration_ids\": [ \"" + DeviceKey + "\" ], " +
            //"\"data\": {\"tickerText\":\"" + notificacao.Anuncio != null ? notificacao.Anuncio.Titulo : "Não vinculado" + "\", " +
            //             "\"contentTitle\":\"" + notificacao.Titulo + "\", " +
            //             "\"message\": \"" + notificacao.Conteudo + "\"}}";

            //  MESSAGE CONTENT
            byte[] byteArray = Encoding.UTF8.GetBytes(postJsonData);

            //
            //  CREATE REQUEST
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://android.googleapis.com/gcm/send");
            Request.Method = Types.eMetodoHTTP.POST.ToString();
            Request.KeepAlive = false;
            Request.ContentType = "application/json";
            Request.Headers.Add(string.Format("Authorization: key={0}", ApiKey));
            Request.ContentLength = byteArray.Length;

            using (Stream dataStream = Request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            //  SEND MESSAGE
            try
            {
                WebResponse Response = Request.GetResponse();
                HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
                string responseLine = string.Empty;
                if (ResponseCode.Equals(HttpStatusCode.OK))
                {
                    using (StreamReader Reader = new StreamReader(Response.GetResponseStream()))
                    {
                        //responseLine = Reader.ReadToEnd();
                        ser = new DataContractJsonSerializer(typeof(ResponseContract));
                        result = (ResponseContract)ser.ReadObject(Reader.BaseStream);
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate,  X509Chain chain,  SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
