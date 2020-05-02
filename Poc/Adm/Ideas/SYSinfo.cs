using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Ideas
{
    /// <summary>
    /// Classe estatica que dispôe métodos globais do sistema.
    /// </summary>
    public static class SYSinfo
    {
        /// <summary>
        /// Método que retorna o caminho absoluto de diretório
        /// </summary>
        /// <param name="nomeDiretorio">nome do diretório</param>
        /// <param name="criar">TRUE = cria o diretório se não existir</param>
        /// <returns></returns>
        public static string pegarCaminho(string nomeDiretorio, bool criar = false)
        {
            DirectoryInfo dir = new DirectoryInfo(nomeDiretorio);
            if (!Directory.Exists(dir.FullName) && criar)
            {
                dir = Directory.CreateDirectory(nomeDiretorio);
            }
            return dir.FullName;
        }

        public static bool EumTipoPrimitivo(Type tp)
        {
            // tp == typeof(string) || tp == typeof(int) || tp == typeof(decimal) || tp == typeof(double) || tp == typeof(bool) || tp == typeof(char) || tp == typeof(DateTime) || tp == typeof(long);
            bool r = false;
            r = tp == typeof(string) || tp == typeof(int) || tp == typeof(decimal);
            r = r || tp == typeof(double) || tp == typeof(bool) || tp == typeof(char);
            r = r || tp == typeof(DateTime) || tp == typeof(Nullable<DateTime>) || tp == typeof(long);
            r = r || tp == typeof(Enum); 
            return r;
        }        
    }
}
