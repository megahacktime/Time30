using Ideas.Dao.MySQL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp
{
    public class Configuracoes : Ideas.Dao.MySQL.Table
    {
        [Ideas.Attr(eChavePrimaria = true)]
        public int id { get; set; }
        public string valor{ get; set; }
        public string chave { get; set; }

        public Configuracoes(Dbo dbo) : this()
        {
            Dbo = dbo;
        }

        public Configuracoes()
        {

            setNomeDaTabela("TbConfiguracoes");
            setPKautoIncremento(true);
            setPrefixo("Configuracao_");
 
        }
 
        public Configuracoes Obter(int id)
        {
            Configuracoes obj = null;
            var Objts = getDbo().Select<Configuracoes>("C", "C._deleted_ = 0 AND C.Configuracao_id = @id", new List<MySqlParameter>() {
                new MySqlParameter(){ ParameterName = "@id", Value = id}
            });
            if (Objts != null && Objts.Count > 0) obj = Objts[0];
            return obj;
        }

        public Configuracoes Obter(string chave)
        {
            Configuracoes obj = null;
            var Objts = getDbo().Select<Configuracoes>("C", "C._deleted_ = 0 AND C.Configuracao_chave = @id", new List<MySqlParameter>() {
                new MySqlParameter(){ ParameterName = "@id", Value = chave}
            });
            if (Objts != null && Objts.Count > 0) obj = Objts[0];
            return obj;
        }


        public List<Configuracoes> Lista()
        {
            List<Configuracoes> Objts = getDbo().Select<Configuracoes>("C", "C._deleted_ = 0 ", null);
            return Objts;
        }

    }
}
