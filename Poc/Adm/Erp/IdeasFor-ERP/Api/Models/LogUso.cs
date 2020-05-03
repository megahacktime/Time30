using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class LogUso 
    {
        public int LogUso_id { get; set; }
        public int LogUso_Usuario_id { get; set; }
        public int? LogUso_Conteudo_id { get; set; }
        public int? LogUso_Produto_id { get; set; }
        public int? LogUso_Categoria_id { get; set; }

    }
}