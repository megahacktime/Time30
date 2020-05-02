using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ideas.Google.GCM
{
    public enum ResponseCode
    {
        Ok,
        Error,
        BadRequest,
        ServiceUnavailable,
        InvalidAuthToken,
        InternalServiceError
    }
}
