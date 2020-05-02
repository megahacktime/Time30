using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using Ideas.Types;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Ideas.Factory
{
    /// <summary>
    /// Classe reponsável por requitar URLs JSON e enviar informações para 
    /// URLs JSON
    /// </summary>
    public static class JSONFactory
    {

        /// <summary>
        /// GET: faz uma requisição GET na url passada
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param">chave=valor&chave=valor</param>
        /// <returns></returns>
        public static string Get(string url, string param = null, WebHeaderCollection headers = null)
        {
            HttpWebRequest request = null;
            WebResponse response = null;
            string strResponse = null;
            
            try
            {
                // se tem parâmentros
                if (param != null)
                {
                    url += string.Format("?{0}", param);
                }

                request = (HttpWebRequest)WebRequest.Create(url);
                if(headers != null) request.Headers = headers;
                request.Method = eMetodoHTTP.GET.ToString();
                request.UserAgent = "curl -H";
                request.ContentType = "application/json";
                response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    strResponse = reader.ReadToEnd();
                }
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    using (Stream stream = wex.Response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                        strResponse = reader.ReadToEnd();
                    }
                }
            }
            return strResponse;
        }

        /// <summary>
        /// POST: faz um POST na url passada
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static string Post(string url, string param = null, WebHeaderCollection headers = null)
        {            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers = headers;
            request.Method = eMetodoHTTP.POST.ToString();
            request.UserAgent = "curl -H";
            request.ContentType = "application/json";
            // se recebeu parâmetros
            if (param != null)
            {
                string postData = param;
                byte[] byteData = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = byteData.Length;
                // escreve os parâmetros na url 
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteData, 0, byteData.Length);
                }
            }
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }
        

        /// <summary>
        /// Recebe uma string JSON e retorna um objeto
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="json">string JSON</param>
        /// <returns></returns>
        public static T GetObjectFromJSONString<T>( string json) where T : new() 
        {             
            return JsonConvert.DeserializeObject<T>(json);            
        } 

        /// <summary>
        /// Recebe uma string e retorna um array de objeto
        /// </summary>
        /// <typeparam name="T">tipo do objeto</typeparam>
        /// <param name="json">string JSON</param>
        /// <returns></returns>
        public static T[] GetArrayFromJSONString<T>( string json) where T: new() 
        {
            return JsonConvert.DeserializeObject<T[]>(json);
        }


    }
}
