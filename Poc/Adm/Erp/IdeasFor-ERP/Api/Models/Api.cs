using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Api
    {
        /// <summary>
        /// Strutura de resposta da API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ResponseMessage<T> {
            public int Status { get; set; }
            public T Data { get; set; }
            public string Message { get; set; }
        }
    }
}
