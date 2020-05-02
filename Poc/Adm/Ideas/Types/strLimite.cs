using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideas.Types
{
    /// <summary>
    /// representa a estrutura do limit do MySql
    /// </summary>
    public struct strLimite
    {
        public int Inicio { get; set; }
        public int Qtd { get; set; }

        /// <summary>
        /// Retorna o limite no formatao inicio, fim ex.: 1, 5
        /// </summary>
        public string Get() { return string.Format("{0},{1}", Inicio, Qtd); }
    }
}
