using Ideas.Dao.MySQL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp
{
    public class Acoes : Ideas.Dao.MySQL.Table
    {
        [Ideas.Attr(eChavePrimaria = true)]
        public int id { get; set; }
        public string Descricao { get; set; }
        public string Chave { get; set; }
        public Modulos Modulo { get; set; }

        public Acoes(Dbo dbo) : this()
        {
            Dbo = dbo;
        }

        public Acoes()
        {
            setNomeDaTabela("TbAcoes");
            setPKautoIncremento(true);
            setPrefixo("Acao_");
            ChaveEstrageira.Add("Acao_Modulo_id", 0);
        }

        public Acoes Obter(int id)
        {
            Acoes obj = null;
            Dbo dbo = getDbo();
            var Objts = dbo.Select<Acoes>("C", "C._deleted_ = 0 AND C.Acao_id = @id", new List<MySqlParameter>() {
                new MySqlParameter(){ ParameterName = "@id", Value = id}
            });
            if (Objts != null && Objts.Count > 0)
            {
                obj = Objts[0];
                obj.Modulo = new Modulos(dbo).Obter(Objts[0].ChaveEstrageira["Acao_Modulo_id"]);
            }
              
            return obj;
        }

        public List<Acoes> Listar(List<int> ids)
        {
            Dbo dbo = getDbo();
            var menus = dbo.Select<Acoes>("U", "U._deleted_ = 0  " , null);
            return menus;

        }


        public List<Acoes> Listar(bool SomentePrincipal = false)
        {
            Dbo dbo = getDbo();
            var menus = dbo.Select<Acoes>("U", "U._deleted_ = 0  " + (SomentePrincipal ? " and U.Menu_Principal = 1" : ""), null);

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
