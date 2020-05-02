using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ideas.Google.GCM
{
    [DataContract]
    public class MessageResultContract
    {
        private string error;

        [DataMember(Name = "message_id")]
        public string MessageId { get; set; }

        [DataMember(Name = "registration_id")]
        public string RegistratinId { get; set; }
        
        public ResponseStatus Status { get; set; }

        [DataMember(Name = "error")]
        public string Error 
        { 
            get{
                return error;
            } set
            {
                error = value;
                Status = (ResponseStatus)Enum.Parse(typeof(ResponseStatus), value);
            } 
        }
    }
}
