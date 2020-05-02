using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideas
{
    public class Global
    {
        private static Global _global = null;
        /// <summary>
        /// Dispõe a chave compartilhada 
        /// </summary>
        public string SharedKey
        {
            get
            {
               return IdeasConfig.Default.SharedKey;
            }
        }

        /// <summary>
        /// Singleton dispõe um único objeto Global
        /// </summary>
        public static Global getInstancia
        {
            get
            {
                if (_global == null) _global = new Global();
                return _global;
            }
        }
        
    }
}
