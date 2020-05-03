using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ideas
{
    public static class Util
    {

        public static class Pattern
        {
            // expressão que verifica o formato de e-mail
            public const string Email = "^[A-Za-z0-9](([_.-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([.-]?[a-zA-Z0-9]+)*)([.][A-Za-z]{2,4})$";

            public static char[] CaracteresEspeciais = new char[] { '@', '#', '%', '&', '*', '!' };

            /// <summary>
            /// Cria uma chave única
            /// </summary>
            /// <returns></returns>
            public static string GerarChaveComplexa()
            {
                Random rdn = new Random();
                string temp = Convert.ToChar(rdn.Next(65, 90)).ToString();
                temp += Convert.ToChar(rdn.Next(97, 122)).ToString();
                temp += Util.Pattern.CaracteresEspeciais[rdn.Next(0, 5)].ToString();
                var er = DateTime.Now.Ticks.ToString();
                string re = "";
                for (int i = er.Length - 1; i > 0; i--)
                {
                    re += er[i];
                }
                temp += re;
                return temp;
            }

            /// <summary>
            /// retorna um MD5 dos dados passados
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>
            public static string GerarMD5(string data)
            {
                using (MD5 md5 = MD5.Create())
                {
                    byte[] buffer = md5.ComputeHash(Encoding.UTF8.GetBytes(data));
                    StringBuilder sB = new StringBuilder();
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        sB.Append(buffer[i].ToString("x2"));
                    }
                    return sB.ToString();
                }
            }
        }

        /// <summary>
        /// retorna a string passada sem acentos
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string RemoveAcentos(this string data)
        {
            StringBuilder ab = new StringBuilder();
            var arrayText = data.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char l in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(l) != UnicodeCategory.NonSpacingMark)
                {
                    ab.Append(l);
                }
            }
            return ab.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="caracter">o caracter</param>
        /// <param name="ncaracter">novo caracter</param>
        /// <returns></returns>
        public static string Substituir(string data, char caracter, char ncaracter)
        {
            return data.Replace(caracter, ncaracter);
        }

        /// <summary>
        /// remove acentos e substitue espaços por traços
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string PreparaTituloURL(string data)
        {
            string r = RemoveAcentos(data);
            r = Substituir(r, ' ', '-');
            return r.ToLower();
        }

        /// <summary>
        /// retorna um string de um valor ou uma string de valores separados pelo seprador
        /// </summary>
        /// <typeparam name="T">Tipo</typeparam>
        /// <param name="itens">lista de itens</param>
        /// <param name="property">Nome da propriedade ou NULL</param>
        /// <param name="separador">o seprador (, ' ', ';' etc)</param>
        /// <returns></returns>
        public static string ToString<T>(List<T> itens, string property, char separador)
        {
            string result = string.Empty;
            PropertyInfo pinfo = null;
            if (property != null)
            {
                pinfo = typeof(T).GetProperty(property);
            }

            if (itens != null)
            {
                for (int i = 0; i < itens.Count; i++)
                {
                    // se for uma propriedade de um objeto
                    if (pinfo != null)
                    {
                        result += string.Format("{0}{1}", (i == 0) ? ' ' : separador, pinfo.GetValue(itens[i]));
                    }
                    else // senão
                    {
                        result += string.Format("{0}{1}", (i == 0) ? ' ' : separador, itens[i]);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Valida um cadeia dado a expressão desejada
        /// </summary>
        /// <param name="cont">o conteúdo a ser validado</param>
        /// <param name="pattern">a expressão de validação</param>
        /// <returns>vardadeiro ou falso</returns>
        public static bool Validar(string cont, string pattern)
        {
            Regex exp = new Regex(pattern);
            Match mch = exp.Match(cont);
            return mch.Success;
        }

        /// <summary>
        /// retorna o tipo de um documento (CPF/CNPJ) 
        /// </summary>
        /// <param name="numero">um cpf ou cnpj</param>
        /// <returns></returns>
        public static TipoDeDocumento GetTipoDocumento(string numero)
        {
            TipoDeDocumento tp = TipoDeDocumento.CPF;
            string doc = RemoveFormatoCpfOuCnpj(numero);
            if (doc.Length > 11)
            {
                tp = TipoDeDocumento.CNPJ;
            }
            return tp;
        }

        public static string FormataCPF(string numero)
        {
            return Convert.ToUInt64(numero).ToString(@"000\.000\.000\-00");
        }

        public static string FormataCNPJ(string numero)
        {
            return Convert.ToUInt64(null).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string RemoveFormatoCpfOuCnpj(string numero)
        {
            return numero.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);
        }

        public enum TipoDeDocumento
        {
            CPF, CNPJ
        }

        /// <summary>
        /// Lista das unidades federativas do Brasil
        /// </summary>
        /// <returns></returns>
        public static List<string> GetUFs()
        {
            return new List<string>()
            {
                "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA", "MG", "MS", "MT", "PA",
                "PB", "PE", "PI", "PR", "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SP", "TO"
            };
        }




        public static string RequisicaoPOST(string url, string parametros)
        {
            string retorno = "";
            string dadosPOST = parametros;
            var dados = Encoding.UTF8.GetBytes(dadosPOST);
            var requisicaoWeb = WebRequest.CreateHttp(url);
            requisicaoWeb.Method = "POST";
            //requisicaoWeb.ContentType = "application/x-www-form-urlencoded";
            requisicaoWeb.ContentType = "application/json;";
            requisicaoWeb.ContentLength = dados.Length;
            //requisicaoWeb.UserAgent = "RequisicaoWebDemo";
            //precisamos escrever os dados post para o stream
            using (var stream = requisicaoWeb.GetRequestStream())
            {
                stream.Write(dados, 0, dados.Length);
                stream.Close();
            }
            //ler e exibir a resposta
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                retorno = objResponse.ToString();
                streamDados.Close();
                resposta.Close();
            }

            return retorno;
        }

        public static bool ClasseToXML<T>(String PathXML, T obj) where T : class
        {
            try
            {
                //----
                string sCaminho = PathXML;

                System.IO.StreamWriter writer = new System.IO.StreamWriter(sCaminho);
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                serializer.Serialize(writer, obj);
                writer.Close();
                //---
            }
            catch (Exception ex)
            {
                string testo = ex.Message;
                return false;
            }
            return true;
        }

        public static T XMLToClasse<T>(String PathXML) where T : class
        {
            object o = new object();
            try
            {
                if (System.IO.File.Exists(PathXML) == true)
                {
                    System.IO.StreamReader objStreamReader = new System.IO.StreamReader(PathXML);
                    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    o = x.Deserialize(objStreamReader);
                    objStreamReader.Close();
                }
                else
                {
                    o = null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            return (T)o;
        }

        public static string ClassToJSOn<T>(T obj) where T : class
        {
            return JsonConvert.SerializeObject(obj); ;
        }

        public static T JSOnToClasse<T>(String json) where T : class
        {
            object o = new object();

            o = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);

            return (T)o;
        }




        public static List<T> DadosParaObjetoLista<T>(DataTable dados)
        {
            List<T> retorno = new List<T>();

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (DataRow linha in dados.Rows)
            {
                T dadosSc = (T)Activator.CreateInstance(typeof(T));
                foreach (var propertyInfo in properties)
                {
                    if (dados.Columns.IndexOf(propertyInfo.Name) > -1)
                    {
                        if (linha[propertyInfo.Name] != DBNull.Value)
                            propertyInfo.SetValue(dadosSc, Convert.ChangeType(linha[propertyInfo.Name], propertyInfo.PropertyType), null);
                    }
                }

                retorno.Add(dadosSc);
            }

            return retorno;
        }

        public static T DadosParaObjeto<T>(DataTable dados)
        {
            T retorno = (T)Activator.CreateInstance(typeof(T));

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (DataRow linha in dados.Rows)
            {
                T dadosSc = (T)Activator.CreateInstance(typeof(T));
                foreach (var propertyInfo in properties)
                {

                    if (dados.Columns.IndexOf(propertyInfo.Name) > -1)
                    {
                        if (linha[propertyInfo.Name] != DBNull.Value)
                            propertyInfo.SetValue(dadosSc, Convert.ChangeType(linha[propertyInfo.Name], propertyInfo.PropertyType), null);
                    }

                }

                retorno = dadosSc;
            }

            return retorno;
        }



    }
}
