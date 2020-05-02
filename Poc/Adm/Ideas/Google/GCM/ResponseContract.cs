using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Ideas.Google.GCM
{
    [DataContract]
    public class ResponseContract
    {        

        [DataMember(Name = "multicast_id")]
        public long MulticastId { get; set; }

        [DataMember(Name="success")]
        public long NumberOfSuccesses { get; set; }

        [DataMember(Name="failure")]
        public long NumberOfFailures { get; set; }

        [DataMember(Name = "canonical_ids")]
        public long NumberOfCanonicalIds { get; set; }


        [DataMember(Name = "results")]
        public List<MessageResultContract> Results { get; set; }

        public ResponseCode ResponseCode { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public ResponseContract()
        {
            MulticastId = -1;
            NumberOfSuccesses = 0;
            NumberOfFailures = 0;
            NumberOfCanonicalIds = 0;
            Results = new List<MessageResultContract>();
            ResponseCode = ResponseCode.Ok;
        }
    }   
}