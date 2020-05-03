using Ideas.Dao.MySQL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp
{
    public class BuscaTabelas : Ideas.Dao.MySQL.Table
    {
        [Ideas.Attr(eChavePrimaria = true)]
        public int id { get; set; }
        public string tabela { get; set; }
        public string Descricao { get; set; }
        public string condicao { get; set; }
        public string condicaoComplemento { get; set; }

        public BuscaTabelas(Dbo dbo) : this()
        {
            Dbo = dbo;
        }

        public BuscaTabelas()
        {

            setNomeDaTabela("Tbbuscatabelas");
            setPKautoIncremento(true);
            setPrefixo("BuscaTabela_");
            ChaveEstrageira.Add("BuscaTabela_Perfil_Id", 0);
        }

        public BuscaTabelas Obter(int id)
        {
            BuscaTabelas obj = null;
            var Objts = getDbo().Select<BuscaTabelas>("C", "C._deleted_ = 0 AND C.BuscaTabela_id = @id", new List<MySqlParameter>() {
                new MySqlParameter(){ ParameterName = "@id", Value = id}
            });
            if (Objts != null && Objts.Count > 0) obj = Objts[0];
            return obj;
        }

        public List<BuscaTabelas> Listar(List<int> ids)
        {
            Dbo dbo = getDbo();
            var menus = dbo.Select<BuscaTabelas>("U", "U._deleted_ = 0  " , null);
            return menus;

        }


        public List<BuscaTabelas> Listar(bool SomentePrincipal = false)
        {
            Dbo dbo = getDbo();
            var menus = dbo.Select<BuscaTabelas>("U", "U._deleted_ = 0  " + (SomentePrincipal ? " and U.Menu_Principal = 1" : ""), null);

            if (menus != null)
            {
                //List<int> ids = new List<int>();
                //for (int i = 0; i < menus.Count; i++)
                //{
                //    ids.Add(menus[i].ChaveEstrageira["Menu_Menu_id"]);
                //    ids.Add(menus[i].ChaveEstrageira["Menu_BuscaTabela_id"]);
                //}
                //var ListaSubMenus = new Menu().Listar(ids);
                //for (int i = 0; i < menus.Count; i++)
                //{
                //    menus[i].SubMenus = ListaSubMenus.Find(p => p. == usuarios[i].ChaveEstrageira["usuario_perfil_id"]);
                //}

            }
            return menus;
        }

    }
}
