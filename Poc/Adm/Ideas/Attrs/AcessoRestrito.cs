using Ideas.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideas.Attrs
{
    public class AcessoRestrito :Attribute
    {
        public string SessaoRequerida { get; set; }

        public eAcao Acao { get; set; }

        public eOperacao Operacao { get; set; }
    }
   
}
