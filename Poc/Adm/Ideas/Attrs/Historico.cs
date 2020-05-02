using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideas.Attrs
{
    public class Historico: Attribute
    {
        /// <summary>
        /// define se um método (action) deve ser adicionada no histórico de navegação
        /// </summary>
        /// <param name="add"></param>
        public Historico(bool add = true)
        {
            AdicionaNoHistorico = add;
        }
        public bool AdicionaNoHistorico { get; set; } 
    }
}
