using Erp;
using ErpWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ErpWeb.Controllers
{
    public class FormularioController : Controller
    {
        //private readonly int _registrosPorPagina = 3;

        private DataTable getDataTable()
        {
            DataTable tb = new DataTable("Cliente");
            tb.Columns.Add(new DataColumn() { ColumnName = "Cliente_Id", DataType = typeof(int), Caption = "Código" });
            tb.Columns.Add(new DataColumn() { ColumnName = "Cliente_Nome", DataType = typeof(string), Caption = "Nome" });
            tb.Columns.Add(new DataColumn() { ColumnName = "Cliente_DataNascimento", DataType = typeof(DateTime), Caption = "Data de nascimento" });
            tb.Rows.Add(1, "Pedro 1", "1983-05-17 00:00:00");
            tb.Rows.Add(2, "Pedro 2", "1983-05-17 00:00:00");
            tb.Rows.Add(3, "Pedro 3", "1983-05-17 00:00:00");
            return tb;
        }

        // GET: ~/formulario/cadastro
        //[HttpGet]
        //public ActionResult Cadastro(int? id)
        //{
        //    Session["id"] = id;
        //    ControleListaDePaginas pagina = CarregaFormulario(id.ToString(), "", "");
        //    return View(pagina);
        //}

        [HttpGet]
        public ActionResult Cadastro(string id)
        {
            Session["id"] = id;
            string Tabela = "";
            string IdChave = "";
            if (id != null && id.IndexOf("-") > 0)
            {
                Tabela = id.Split('-')[0];
                IdChave = id.Split('-')[1];
            }
            else
            {
                Tabela = id;
            }
            ControleListaDePaginas pagina = CarregaFormulario(Tabela, IdChave, "", "");
            return View(pagina);
        }

        //[HttpPost]
        //public ActionResult Cadastro(object data)
        //{
        //    DataTable tb = getDataTable();

        //    return View();
        //}

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Cadastro(DataTable data)
        {
            List<string> ListaValores = new List<string>();
            List<string> ListaCampos = new List<string>();

            if (Session["id"] != null)
            {

                string tabelaEId = Session["id"].ToString();
                string Tabela = "";
                string Id = "";
                if (tabelaEId != null && tabelaEId.IndexOf("-") > 0)
                {
                    Tabela = tabelaEId.Split('-')[0];
                    Id = tabelaEId.Split('-')[1];
                }
                else
                {
                    Tabela = tabelaEId;
                }

                ControleListaDePaginas pagina = CarregaFormulario(Tabela, Id, "", "");

                foreach (System.Data.DataRow coluna in pagina.Listagem.DadosColunas.Rows)
                {
                    if (coluna["BuscaCampo_Echave"].ToString() == "0")
                    {
                        //Colunas += (Colunas.Length > 0 ? "," : "") + coluna["BuscaCampo_NomeCampo"].ToString();
                        //Valores += (Valores.Length > 0 ? "," : "") + "'" + valor + "'";

                        ListaCampos.Add(coluna["BuscaCampo_NomeCampo"].ToString());
                        string valor = Request.Form[coluna["BuscaCampo_NomeCampo"].ToString()];
                        if (coluna["ControleHTML_id"].ToString() == "5")//Checkbox
                        {
                            if (valor == null)
                            {
                                valor = "0";
                            }
                            else if (valor == "on")
                            {
                                valor = "1";
                            }
                        }
                        ListaValores.Add(valor);
                    }

                }
                int? IdPassado = null;
                if (!string.IsNullOrEmpty(Id))
                {
                    IdPassado = int.Parse(Id);
                }
                pagina.SalvaNoBaco(pagina.Listagem.Dados, pagina.Listagem.TabelaBanco, pagina.Listagem.CampoChave, ListaCampos, ListaValores, IdPassado);
                pagina = CarregaFormulario(Tabela, Id, "", "");
                if(Session["ulr"] != null)
                Response.Redirect(Session["ulr"].ToString());
                else
                return View(pagina);
                //pagina.Listagem.DadosColunas
            }



            return View();
        }


        //public ActionResult Index(int pagina = 1)
        //{
        //    //metodo generico de busca
        //    Buscar(pagina);
        //    return View();
        //}

        //private readonly int _registrosPorPagina = 10;
        //private void Buscar(int pagina)
        //{
        //    int totalRegistros;

        //    //Realizar o seu método de busca com o parametro de paginação

        //    //instanciar sua paginação, colocando a action e controller desejada
        //    PaginacaoModel paginacao = new PaginacaoModel(pagina, totalRegistros, _registrosPorPagina, Url.Action("Action", "Controller"));
        //    ViewBag.Paginacao = paginacao;
        //}



        //public ActionResult Listar(int id)
        //{
        //    DataTable tb = getDataTable();
        //    return View(tb);
        //}

        public ActionResult Listar(string id)
        {
            
            
            string URL = this.Request.Url.AbsoluteUri;
            Session["ulr"] = URL;

            string CampoPesquisa = "";
            string ValorBusca = "";
            Configuracoes configura = new Configuracoes().Obter("QtdItensPorPaginas");
            int _registrosPorPagina = 3;
            if (configura != null)
            {
                int.TryParse(configura.valor, out _registrosPorPagina);
            }

            if (Request.Form["comboPesquisa"] != null && Request.Form["txtFiltro"] != null)
            {
                CampoPesquisa = Request.Form["comboPesquisa"].ToString();
                ValorBusca = Request.Form["txtFiltro"].ToString();

            }
            string codigo = "0";
            int IntPg = 1;
            if (id != null && id.IndexOf("-") > -1)
            {
                codigo = id.Split('-')[0];
                int.TryParse(id.Split('-')[1], out IntPg);
            }
            else
            {
                codigo = id;
            }

            int PerfilLogado = -1;

            if (Session["login"] != null && Session["login"] is Login)
            {
                Login lg = (Login)Session["login"];
                if( lg.Perfil_id  != 0)
                {
                    PerfilLogado = lg.Perfil_id;
                }
            }

            ControleListaDePaginas pagina = CarregaPagina(codigo, CampoPesquisa, ValorBusca, _registrosPorPagina, IntPg, PerfilLogado);
            pagina.Listagem.ValorBusca = ValorBusca;
            pagina.Listagem.CampoPesquisa = CampoPesquisa;





            int totalRegistros = 0;

            if (pagina.Listagem.DadosApresentacao != null)
            {
                totalRegistros = pagina.Listagem.QtDRegistrosOriginal;  // pagina.Listagem.DadosApresentacao.Rows.Count; 
            }

            //~/Formulario/listar/
            //~/Formulario/listar/
            //Url.Action("Action", "Controller")
            //Realizar o seu método de busca com o parametro de paginação
            //instanciar sua paginação, colocando a action e controller desejada
            PaginacaoModel paginacao = new PaginacaoModel(IntPg, totalRegistros, _registrosPorPagina, codigo);
            ViewBag.Paginacao = paginacao;


            return View(pagina);
        }


        public ControleListaDePaginas CarregaFormulario(string Tabela, string IdLinha, string ColunaFiltro, string ValorFiltro)
        {
            DataTable retorno = new DataTable();

            ControleListaDePaginas clpaginas = new ControleListaDePaginas();
            clpaginas = new ControleListaDePaginas(Tabela, IdLinha, "");


            string titulo = clpaginas.Listagem.Titulo;
            string Formulario = clpaginas.Listagem.Formulario;
            retorno = clpaginas.Listagem.DadosApresentacao;

            //Session["Procura"] = retorno;

            return clpaginas;
        }


        public ControleListaDePaginas CarregaPagina(string Tabela, string ColunaFiltro, string ValorFiltro, int RegistrosPorPagina, int PaginaAtual, int PerfilAtual)
        {
            DataTable retorno = new DataTable();

            ControleListaDePaginas clpaginas = new ControleListaDePaginas();
            clpaginas = new ControleListaDePaginas(Tabela, "", RegistrosPorPagina, PaginaAtual, PerfilAtual);


            string titulo = clpaginas.Listagem.Titulo;
            string Formulario = clpaginas.Listagem.Formulario;
            clpaginas.Listagem.TabelaBanco = Tabela;



            retorno = clpaginas.Listagem.DadosApresentacao;




            if (ColunaFiltro != "" && ValorFiltro != "")
            {
                //
                DataTable Dados = new DataTable();

                string Tipo = clpaginas.Listagem.DadosApresentacao.Columns[ColunaFiltro].DataType.Name;

                try
                {
                    if (Tipo == "String")
                    {
                        clpaginas.Listagem.DadosApresentacao.DefaultView.RowFilter = ColunaFiltro + " like '%" + ValorFiltro + "%'";
                    }
                    else
                    {
                        clpaginas.Listagem.DadosApresentacao.DefaultView.RowFilter = ColunaFiltro + " = '" + ValorFiltro + "'";
                    }
                }
                catch
                {
                }

                Dados = clpaginas.Listagem.DadosApresentacao.DefaultView.ToTable();
                clpaginas.Listagem.DadosApresentacao = Dados;
                retorno = Dados;

            }

            Session["Procura"] = retorno;

            return clpaginas;

        }

        public ActionResult whatsApp()
        {
            WhatsAppModel model = new WhatsAppModel();
            model.Titulo = "BOT DO WHATS APP";
            model.URLWhatsAPP = "https://web.whatsapp.com/";

            HttpContext.Response.Headers.Remove("X-Frame-Options");
            HttpContext.Response.AddHeader("X-Frame-Options", "ALLOW-FROM " + model.URLWhatsAPP);
            return View(model);
        }



        //public ActionResult Listar()
        //{
        //    DataTable tb = getDataTable();
        //    return View(tb);
        //}
    }
}