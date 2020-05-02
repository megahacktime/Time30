using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ideas.Google.GCM
{
    
    [DataContract]
    public class ContentContract
    {
        [DataMember]
        public string title { get; set; }
        /// <summary>
        /// Simples texto descritivo para a notificação
        /// </summary>
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public string image { get; set; }
        [DataMember]
        public string icon { get; set; }
        [DataMember]
        public string sound { get; set; }
        /// <summary>
        /// Numero de msg que seráexibido no app
        /// </summary>
        [DataMember]
        public string count { get; set; }
        [DataMember]
        public bool foreground { get; set; }

        #region "aditionalData"
        /// <summary>
        /// texto com html e links
        /// </summary>
        [DataMember]
        public string conteudo { get; set; }


        [DataMember]
        public int? id { get; set; }
        #endregion
    }
}
