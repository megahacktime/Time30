using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ideas.Google.GCM
{
    [DataContract]
    class NotificationContract
    {
        [DataMember]
        public List<string> registration_ids { get; set; }

        [DataMember(Name="time_to_live")]
        public int TimeToLive { get; set; }

        [DataMember(Name="delay_while_idle")]
        public bool DelayWhileIdle { get; set; }

        [DataMember(Name="dry_run")]
        public bool DryRun { get; set; }
        
        [DataMember]
        public ContentContract data { get; set; }
    }
}
