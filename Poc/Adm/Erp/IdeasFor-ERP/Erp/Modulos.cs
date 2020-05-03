using Ideas.Dao.MySQL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp
{
    public class Modulos : Ideas.Dao.MySQL.Table
    {
        [Ideas.Attr(eChavePrimaria = true)]
        public int id { get; set; }
        public string nome { get; set; }

        public Modulos(Dbo dbo) : this()
        {
            Dbo = dbo;
        }

        public Modulos()
        {

            setNomeDaTabela("TbModulos");
            setPKautoIncremento(true);
            setPrefixo("Modulo_");
 
        }

        public List<Modulos> Listar(List<int> ids)
        {
            Dbo dbo = getDbo();
            var menus = dbo.Select<Modulos>("U", "U._deleted_ = 0  " , null);
            return menus;

        }
        public Modulos Obter(int id)
        {
            Modulos obj = null;
            var Objts = getDbo().Select<Modulos>("C", "C._deleted_ = 0 AND C.Modulo_id = @id", new List<MySqlParameter>() {
                new MySqlParameter(){ ParameterName = "@id", Value = id}
            });
            if (Objts != null && Objts.Count > 0) obj = Objts[0];
            return obj;
        }


    }
}
