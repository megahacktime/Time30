using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Ideas.Google.GCM
{
    public enum ResponseStatus
    {
        [EnumMember(Value = "Ok")]
        Ok,

        [EnumMember(Value = "Error")]
        Error,

        [EnumMember(Value = "QuotaExceeded")]
        QuotaExceeded,

        [EnumMember(Value = "DeviceQuotaExceeded")]
        DeviceQuotaExceeded,

        [EnumMember(Value = "InvalidRegistration")]
        InvalidRegistration,

        [EnumMember(Value = "NotRegistered")]
        NotRegistered,

        [EnumMember(Value = "MessageTooBig")]
        MessageTooBig,

        [EnumMember(Value = "MissingCollapseKey")]
        MissingCollapseKey,

        [EnumMember(Value = "MissingRegistration")]
        MissingRegistrationId,

        [EnumMember(Value = "Unavailable")]
        Unavailable,

        [EnumMember(Value = "MismatchSenderId")]
        MismatchSenderId,

        [EnumMember(Value = "CanonicalRegistrationId")]
        CanonicalRegistrationId,

        [EnumMember(Value = "InvalidDataKey")]
        InvalidDataKey,

        [EnumMember(Value = "InvalidTtl")]
        InvalidTtl,

        [EnumMember(Value = "InternalServerError")]
        InternalServerError,

        [EnumMember(Value = "InvalidPackageName")]
        InvalidPackageName
    }
}
