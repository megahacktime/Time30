using Ideas.Dao.MySQL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp
{
    public class Menu : Ideas.Dao.MySQL.Table
    {
        [Ideas.Attr(eChavePrimaria = true)]
        public int id { get; set; }
        public string Descricao { get; set; }
        public bool Principal { get; set; }

        public int Ordem { get; set; }
        public string ClasseIcone { get; set; }
        public string UrlDestino { get; set; }

        public List<Menu> SubMenus { get; set; }

        public BuscaTabelas BuscaTabela { get; set; }


        //public int? Menu_id { get; set; }

        //public int? Menu_id { get; set; } Menu_BuscaTabela_id


        public Menu(Dbo dbo) : this()
        {
            Dbo = dbo;
        }

        public Menu()
        {

            setNomeDaTabela("TbMenu");
            setPKautoIncremento(true);
            setPrefixo("Menu_");
            ChaveEstrageira.Add("Menu_Menu_id", 0);
            ChaveEstrageira.Add("Menu_BuscaTabela_id", 0);
            ChaveEstrageira.Add("Menu_Perfil_Id", 0);

        }



        public Menu Obter(int id)
        {
            Menu obj = null;
            Dbo dbo = getDbo();
            var Objts = getDbo().Select<Menu>("C", "C._deleted_ = 0 AND C.Modulo_id = @id", new List<MySqlParameter>() {
                new MySqlParameter(){ ParameterName = "@id", Value = id}
            });
            if (Objts != null && Objts.Count > 0)
            {
                obj = Objts[0];
                obj.SubMenus = new Menu(dbo).Listar(id);
                obj.BuscaTabela = new BuscaTabelas(dbo).Obter(id);
                // new Menu(dbo).Obter(Objts[0].ChaveEstrageira["Acao_Modulo_id"]);
            }

            return obj;
        }

        //public List<Menu> Listar(List<int> ids)
        //{
        //    Dbo dbo = getDbo();
        //    var menus = dbo.Select<Menu>("U", "U._deleted_ = 0  ", null);
        //    return menus;

        //}

        public List<Menu> Listar(int idMenuPrincipal)
        {
            Dbo dbo = getDbo();
            var menus = dbo.Select<Menu>("U", "U._deleted_ = 0  and U.Menu_Menu_id =" + idMenuPrincipal.ToString(), null);
            if (menus != null && menus.Count > 0)
            {
                for (int i = 0; i < menus.Count; i++)
                {
                    menus[i].BuscaTabela = new BuscaTabelas(dbo).Obter(menus[i].ChaveEstrageira["Menu_BuscaTabela_id"]);
                }

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


        public List<Menu> Listar(int PerfilLogado, bool SomentePrincipal = false)
        {
            Dbo dbo = getDbo();

            string sqlBuscaMenu = "";

            switch (PerfilLogado)
            {
                case -1:// Não Logado
                    sqlBuscaMenu += " and U.Menu_Perfil_Id!= 1 ";
                    break;

                case 1:// // Administrador Geral
                
                    break;

                case 2:
                default:
                    sqlBuscaMenu += " and    U.Menu_Perfil_Id=" + PerfilLogado.ToString();
                    break;


            }



            var menus = dbo.Select<Menu>("U", "U._deleted_ = 0  " + (SomentePrincipal ? " and U.Menu_Principal = 1 " : "") + sqlBuscaMenu, null);

            if (menus != null)
            {
                for (int i = 0; i < menus.Count; i++)
                {
                    menus[i].BuscaTabela = new BuscaTabelas(dbo).Obter(menus[i].id);
                    menus[i].SubMenus = new Menu(dbo).Listar(menus[i].id);
                }

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
