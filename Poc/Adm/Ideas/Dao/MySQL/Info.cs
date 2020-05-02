using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideas.Dao.MySQL
{
    public class Info
    {
        /// <summary>
        /// Retorna o Host de conexão dado o seu tipo
        /// </summary>
        public static string Host(TIPO tipo)
        {
            
            string host = "Não definido";
            switch (tipo)
            {
                case TIPO.MySQL:
                    host  = IdeasConfig.Default.MySQL.ToString();
                    break;
                case TIPO.MsSQL:
                    host = IdeasConfig.Default.MsSQL.ToString();
                    break;
            }
            return host;            
        }
    }
}
