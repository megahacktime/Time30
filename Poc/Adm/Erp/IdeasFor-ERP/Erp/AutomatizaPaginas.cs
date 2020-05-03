using Ideas.Dao.MySQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp
{
    public class AutomatizaPaginas : Ideas.Dao.MySQL.Table
    {
        public DataTable ExecutaConsulta(string SQL)
        {
            Dbo dbo = getDbo();

            return Dbo.ExecutarQuery(SQL);
        }

        public int ExecuteNoQuery(string SQL, bool fecharConexao = true)
        {
            Dbo dbo = getDbo();

            return Dbo.ExecuteNoQuery(SQL, fecharConexao);
        }


        public bool ExcluirPagina(string IdPgProcura, string codigoAExcluir)
        {
            Dbo dbo = getDbo();
            bool Retorno = true;

            try
            {

                DataTable RetornoPagina = dbo.ExecutarQuery("select * from tbbuscatabelas, tbbuscacampos  where BuscaTabela_id=BuscaCampo_BuscaTabela_id and  tbbuscatabelas._deleted_=0 and  tbbuscacampos._deleted_=0  and BuscaTabela_id=" + IdPgProcura);


                if (RetornoPagina.Rows.Count > 0)
                {
                    string MontagemDeQueryAExecutar = "";
                    string tabela = "";
                    string NomeCampo = "";
                    if (RetornoPagina.Rows[0]["BuscaTabela_tabela"].ToString().IndexOf(",") == -1 && RetornoPagina.Rows[0]["BuscaTabela_tabela"].ToString().IndexOf("left") == -1)
                    {
                        tabela = RetornoPagina.Rows[0]["BuscaTabela_tabela"].ToString();
                    }
                    else
                    {
                        int posicao = 0;

                        if (RetornoPagina.Rows[0]["BuscaTabela_tabela"].ToString().IndexOf(",") > -1)
                        {
                            posicao = RetornoPagina.Rows[0]["BuscaTabela_tabela"].ToString().IndexOf(",");
                        }
                        else
                        {
                            posicao = RetornoPagina.Rows[0]["BuscaTabela_tabela"].ToString().IndexOf("left");
                        }


                        tabela = RetornoPagina.Rows[0]["BuscaTabela_tabela"].ToString().Substring(0, posicao - 1).Replace(" cart", ""); ;
                    }
                    MontagemDeQueryAExecutar += " update  " + tabela + " set _deleted_='true' where ";

                    for (int x = 0; x < RetornoPagina.Rows.Count; x++)
                    {
                        if (x == 0)
                        {
                            NomeCampo = RetornoPagina.Rows[x]["BuscaCampo_NomeCampo"].ToString().ToLower();
                            break;
                        }
                    }

                    MontagemDeQueryAExecutar += NomeCampo + "=" + codigoAExcluir;

                    dbo.ExecutarQuery(MontagemDeQueryAExecutar);

                }

            }
            catch
            {
                Retorno = true;
            }

            return Retorno;




        }



        public ListaDePaginas RetornaFormulario(string IdPgProcura, string IdLinha)
        {
            ListaDePaginas Retorno = new ListaDePaginas();
            Retorno.Titulo = "";
            Retorno.Formulario = "";
            Retorno.Dados = new DataTable();

            Dbo dbo = getDbo();


            DataTable RetornoPagina = dbo.ExecutarQuery(@"SELECT * FROM  Tbbuscacampos  c , Tbbuscaformularios f ,TbControleHTML   con, TbTipoDado tpd
    
                where f.BuscaFormulario_id = c.BuscaCampo_buscaformulario_id
                and c.BuscaCampo_ControleHTML_id = con.ControleHTML_id
				and c.BuscaCampo_TipoDado_id = tpd.TipoDado_id
                and c._deleted_ = 0     and BuscaFormulario_BuscaTabela_id =  " + IdPgProcura);

            for (int x = 0; x < RetornoPagina.Rows.Count; x++)
            {
                if (RetornoPagina.Rows[x]["BuscaCampo_Echave"].ToString() == "1")
                {
                    Retorno.CampoChave = RetornoPagina.Rows[x]["BuscaCampo_NomeCampo"].ToString();
                    break;

                }
            }

            if (RetornoPagina.Rows.Count > 0)
            {

                Retorno.Titulo = RetornoPagina.Rows[0]["BuscaFormulario_Descricao"].ToString();

                string MontagemDeQueryAExecutar = "select * from  " + RetornoPagina.Rows[0]["BuscaFormulario_tabela"].ToString() + " where   " + Retorno.CampoChave + "=" + IdLinha;

                if (string.IsNullOrWhiteSpace(IdLinha))
                {
                    MontagemDeQueryAExecutar = "select * from  " + RetornoPagina.Rows[0]["BuscaFormulario_tabela"].ToString() + " where  1 != 1 ";
                }

                //if (RetornoPagina.Rows[0]["BuscaTabela_condicao"] != DBNull.Value)
                //{
                //if (RetornoPagina.Rows[0]["BuscaTabela_condicao"].ToString() != "")
                //{
                //    MontagemDeQueryAExecutar += " where " + RetornoPagina.Rows[0]["BuscaTabela_condicao"].ToString();
                //    MontagemDeQueryAExecutar = MontagemDeQueryAExecutar.Replace("#BuscaTabela_condicaoComplemento#", "");

                //    // MontagemDeQueryAExecutar = MontagemDeQueryAExecutar.Replace("= #usuario_logado_id#", " <> -1 " );

                //}

                DataTable RetornoDadosPagina = dbo.ExecutarQuery(MontagemDeQueryAExecutar);
                Retorno.Dados = RetornoDadosPagina;
                Retorno.DadosApresentacao = new System.Data.DataTable();
                Retorno.DadosColunas = RetornoPagina;
                Retorno.TabelaBanco = RetornoPagina.Rows[0]["BuscaFormulario_tabela"].ToString();

                string Tabela = "";

                for (int x = 0; x < RetornoPagina.Rows.Count; x++)
                {
                    int PosicaoColunaEncontrada = RetornoDadosPagina.Columns.IndexOf(RetornoPagina.Rows[x]["BuscaCampo_NomeCampo"].ToString());

                    Tabela = RetornoPagina.Rows[x]["BuscaFormulario_id"].ToString();

                    if (PosicaoColunaEncontrada > -1)
                    {
                        DataColumn NovaColuna = new DataColumn();
                        NovaColuna.ColumnName = RetornoDadosPagina.Columns[PosicaoColunaEncontrada].ColumnName;
                        NovaColuna.DataType = RetornoDadosPagina.Columns[PosicaoColunaEncontrada].DataType;
                        NovaColuna.AllowDBNull = RetornoDadosPagina.Columns[PosicaoColunaEncontrada].AllowDBNull;
                        NovaColuna.Caption = RetornoPagina.Rows[x]["BuscaCampo_CampoDescricao"].ToString();
                        Retorno.DadosApresentacao.Columns.Add(NovaColuna);

                        if (x == 0)
                        {
                            Retorno.Formulario = "form" + RetornoPagina.Rows[x]["BuscaCampo_NomeCampo"].ToString().ToLower().Replace("_ID", "").Replace("_id", "").Replace("_Id", "").Replace("_", "") + ".aspx";
                        }

                    }

                }


                //if (RetornoDadosPagina.Rows.Count > 0)
                //{
                //    DataColumn NovaColuna = new DataColumn();
                //    NovaColuna.ColumnName = "Editar";
                //    NovaColuna.DataType = typeof(String);
                //    NovaColuna.Caption = "Editar";
                //    Retorno.DadosApresentacao.Columns.Add(NovaColuna);


                //    DataColumn Excluir = new DataColumn();
                //    Excluir.ColumnName = "Excluir";
                //    Excluir.DataType = typeof(String);
                //    Excluir.Caption = "Excluir";
                //    Retorno.DadosApresentacao.Columns.Add(Excluir);

                //}



                for (int x = 0; x < RetornoDadosPagina.Rows.Count; x++)
                {
                    string Id = "";
                    string Pagina = "";

                    DataRow Linha = Retorno.DadosApresentacao.NewRow();

                    for (int z = 0; z < Retorno.DadosApresentacao.Columns.Count; z++)
                    {

                        if (z < Retorno.DadosApresentacao.Columns.Count)
                        {
                            if (z == 0)
                            {
                                Id += RetornoDadosPagina.Rows[x][Retorno.DadosApresentacao.Columns[z].ColumnName].ToString().Replace("_", "");
                                Pagina += "form" + Retorno.DadosApresentacao.Columns[z].ColumnName.Replace("_id", "").Replace("_ID", "").Replace("_Id", "").Replace("_", "") + ".aspx?codigo=";
                            }


                            Linha[z] = RetornoDadosPagina.Rows[x][Retorno.DadosApresentacao.Columns[z].ColumnName];
                        }
                        else
                        {

                            //Linha["Editar"] = "<a  class='linkEditar' style='border:none !important;' href='" + Pagina + Id + "&Tabela=" + Tabela + "'> <img src='../imagens/icones/b_edit.png' /></a>";

                            //if (IdPgProcura != "9")
                            //{

                            //    Linha["Excluir"] = "<a onclick='return Confirmacao(" + Id + ")' class='linkEditar' style='border:none !important;' href='procura.aspx?tabela=" + IdPgProcura + "&codigoAExcluir=" + Id + "'> <img src='../imagens/icones/b_drop.png' /></a>";
                            //}
                        }
                    }
                    Retorno.DadosApresentacao.Rows.Add(Linha);

                }



                //DataColumn workCol = workTable.Columns.Add("CustID", typeof(Int32));
                //workCol.AllowDBNull = false;
                //workCol.Unique = true;

                //workTable.Columns.Add("CustLName", typeof(String));
                //workTable.Columns.Add("CustFName", typeof(String));
                //workTable.Columns.Add("Purchases", typeof(Double));





                //   }

            }


            return Retorno;




        }



        public ListaDePaginas RetornaPaginaProcura(string IdPgProcura, int tamanhoPagina, int PaginaAtual, int PerfilLogado)
        {
            ListaDePaginas Retorno = new ListaDePaginas();
            Retorno.Titulo = "";
            Retorno.Formulario = "";
            Retorno.Dados = new DataTable();
            Dbo dbo = getDbo();

            string sqlBuscaTab = "select * from  Tbbuscatabelas, Tbbuscacampos  where BuscaTabela_id=BuscaCampo_BuscaTabela_id and  Tbbuscatabelas._deleted_=0 and  Tbbuscacampos._deleted_=0  and BuscaTabela_id=" + IdPgProcura;

            switch (PerfilLogado)
            {
                case -1:// Não Logado
                  
                    break;
                   
                case 1:// == Geral ==
                    break;

                case 2:// Administrador Geral
                    break;


                case 3:// Colaborador
                default:
                    sqlBuscaTab += " and BuscaTabela_Perfil_Id=" + PerfilLogado.ToString();
                    break;

                    
            }



            DataTable RetornoPagina = dbo.ExecutarQuery(sqlBuscaTab);


            if (RetornoPagina.Rows.Count > 0)
            {

                Retorno.Titulo = RetornoPagina.Rows[0]["BuscaTabela_Descricao"].ToString();

                string MontagemDeQueryAExecutar = "";
                MontagemDeQueryAExecutar += "  " + RetornoPagina.Rows[0]["BuscaTabela_tabela"].ToString() + "  ";

                if (RetornoPagina.Rows[0]["BuscaTabela_condicao"] != DBNull.Value)
                {
                    if (RetornoPagina.Rows[0]["BuscaTabela_condicao"].ToString() != "")
                    {
                        MontagemDeQueryAExecutar += " where " + RetornoPagina.Rows[0]["BuscaTabela_condicao"].ToString();
                        MontagemDeQueryAExecutar = MontagemDeQueryAExecutar.Replace("#BuscaTabela_condicaoComplemento#", "");

                        // MontagemDeQueryAExecutar = MontagemDeQueryAExecutar.Replace("= #usuario_logado_id#", " <> -1 " );

                    }

                    DataTable RetornoDadosPagina = dbo.ExecutarQuery(" select count(0) qtd  from " + MontagemDeQueryAExecutar);


                    //DataTable RetornoDadosPagina = dbo.ExecutarQuery(MontagemDeQueryAExecutar);
                    Retorno.QtDRegistrosOriginal = int.Parse(RetornoDadosPagina.Rows[0]["qtd"].ToString());
                    MontagemDeQueryAExecutar += "  LIMIT " + ((PaginaAtual - 1) * tamanhoPagina).ToString() + " , " + tamanhoPagina.ToString();

                    DataTable dadosPaginados = dbo.ExecutarQuery(" select * from " + MontagemDeQueryAExecutar);
                    RetornoDadosPagina = dadosPaginados;





                    Retorno.Dados = RetornoDadosPagina;
                    Retorno.DadosApresentacao = new System.Data.DataTable();




                    string Tabela = "";

                    for (int x = 0; x < RetornoPagina.Rows.Count; x++)
                    {
                        int PosicaoColunaEncontrada = RetornoDadosPagina.Columns.IndexOf(RetornoPagina.Rows[x]["BuscaCampo_NomeCampo"].ToString());

                        Tabela = RetornoPagina.Rows[x]["BuscaTabela_Id"].ToString();

                        if (PosicaoColunaEncontrada > -1)
                        {
                            DataColumn NovaColuna = new DataColumn();
                            NovaColuna.ColumnName = RetornoDadosPagina.Columns[PosicaoColunaEncontrada].ColumnName;
                            NovaColuna.DataType = RetornoDadosPagina.Columns[PosicaoColunaEncontrada].DataType;
                            NovaColuna.AllowDBNull = RetornoDadosPagina.Columns[PosicaoColunaEncontrada].AllowDBNull;
                            NovaColuna.Caption = RetornoPagina.Rows[x]["BuscaCampo_CampoDescricao"].ToString();
                            Retorno.DadosApresentacao.Columns.Add(NovaColuna);

                            if (x == 0)
                            {
                                Retorno.Formulario = "form" + RetornoPagina.Rows[x]["BuscaCampo_NomeCampo"].ToString().ToLower().Replace("_ID", "").Replace("_id", "").Replace("_Id", "").Replace("_", "") + ".aspx";
                            }

                        }

                    }


                    //if (RetornoDadosPagina.Rows.Count > 0)
                    //{
                    //    DataColumn NovaColuna = new DataColumn();
                    //    NovaColuna.ColumnName = "Editar";
                    //    NovaColuna.DataType = typeof(String);
                    //    NovaColuna.Caption = "Editar";
                    //    Retorno.DadosApresentacao.Columns.Add(NovaColuna);


                    //    DataColumn Excluir = new DataColumn();
                    //    Excluir.ColumnName = "Excluir";
                    //    Excluir.DataType = typeof(String);
                    //    Excluir.Caption = "Excluir";
                    //    Retorno.DadosApresentacao.Columns.Add(Excluir);

                    //}



                    for (int x = 0; x < RetornoDadosPagina.Rows.Count; x++)
                    {
                        string Id = "";
                        string Pagina = "";

                        DataRow Linha = Retorno.DadosApresentacao.NewRow();

                        for (int z = 0; z < Retorno.DadosApresentacao.Columns.Count; z++)
                        {

                            if (z < Retorno.DadosApresentacao.Columns.Count)
                            {
                                if (z == 0)
                                {
                                    Id += RetornoDadosPagina.Rows[x][Retorno.DadosApresentacao.Columns[z].ColumnName].ToString().Replace("_", "");
                                    Pagina += "form" + Retorno.DadosApresentacao.Columns[z].ColumnName.Replace("_id", "").Replace("_ID", "").Replace("_Id", "").Replace("_", "") + ".aspx?codigo=";
                                }


                                Linha[z] = RetornoDadosPagina.Rows[x][Retorno.DadosApresentacao.Columns[z].ColumnName];
                            }
                            else
                            {

                                //Linha["Editar"] = "<a  class='linkEditar' style='border:none !important;' href='" + Pagina + Id + "&Tabela=" + Tabela + "'> <img src='../imagens/icones/b_edit.png' /></a>";

                                //if (IdPgProcura != "9")
                                //{

                                //    Linha["Excluir"] = "<a onclick='return Confirmacao(" + Id + ")' class='linkEditar' style='border:none !important;' href='procura.aspx?tabela=" + IdPgProcura + "&codigoAExcluir=" + Id + "'> <img src='../imagens/icones/b_drop.png' /></a>";
                                //}
                            }
                        }
                        Retorno.DadosApresentacao.Rows.Add(Linha);

                    }



                    //DataColumn workCol = workTable.Columns.Add("CustID", typeof(Int32));
                    //workCol.AllowDBNull = false;
                    //workCol.Unique = true;

                    //workTable.Columns.Add("CustLName", typeof(String));
                    //workTable.Columns.Add("CustFName", typeof(String));
                    //workTable.Columns.Add("Purchases", typeof(Double));





                }

            }


            return Retorno;




        }

        //public ListaDePaginas RetornaPaginaProcura(string IdPgProcura )
        //{
        //    Dbo dbo = getDbo();
        //    ListaDePaginas Retorno = new ListaDePaginas();
        //    Retorno.Titulo = "";
        //    Retorno.Formulario = "";
        //    Retorno.Dados = new DataTable();


        //    DataTable RetornoPagina = dbo.ExecutarQuery("select * from  tbbuscatabelas, tbbuscacampos  where BuscaTabela_id=BuscaCampo_BuscaTabela_id and  tbbuscatabelas._deleted_=0 and  tbbuscacampos._deleted_=0  and BuscaTabela_id=" + IdPgProcura);


        //    if (RetornoPagina.Rows.Count > 0)
        //    {

        //        Retorno.Titulo = RetornoPagina.Rows[0]["BuscaTabela_Descricao"].ToString();

        //        string MontagemDeQueryAExecutar = "";
        //        MontagemDeQueryAExecutar += "select * from  " + RetornoPagina.Rows[0]["BuscaTabela_tabela"].ToString() + "  ";

        //        if (RetornoPagina.Rows[0]["BuscaTabela_condicao"] != DBNull.Value)
        //        {
        //            if (RetornoPagina.Rows[0]["BuscaTabela_condicao"].ToString() != "")
        //            {
        //                MontagemDeQueryAExecutar += " where " + RetornoPagina.Rows[0]["BuscaTabela_condicao"].ToString();
        //                MontagemDeQueryAExecutar = MontagemDeQueryAExecutar.Replace("#BuscaTabela_condicaoComplemento#", RetornoPagina.Rows[0]["BuscaTabela_condicaoComplemento"].ToString());
        //                MontagemDeQueryAExecutar = MontagemDeQueryAExecutar.Replace("#usuario_logado_id#", UsuarioLogado.Cliente_id.ToString());

        //            }

        //            DataTable RetornoDadosPagina = dbo.ExecutarQuery(MontagemDeQueryAExecutar);
        //            Retorno.Dados = RetornoDadosPagina;
        //            Retorno.DadosApresentacao = new System.Data.DataTable();



        //            string Tabela = "";

        //            for (int x = 0; x < RetornoPagina.Rows.Count; x++)
        //            {
        //                int PosicaoColunaEncontrada = RetornoDadosPagina.Columns.IndexOf(RetornoPagina.Rows[x]["BuscaCampo_NomeCampo"].ToString());

        //                Tabela = RetornoPagina.Rows[x]["BuscaTabela_Id"].ToString();

        //                if (PosicaoColunaEncontrada > -1)
        //                {
        //                    DataColumn NovaColuna = new DataColumn();
        //                    NovaColuna.ColumnName = RetornoDadosPagina.Columns[PosicaoColunaEncontrada].ColumnName;
        //                    NovaColuna.DataType = RetornoDadosPagina.Columns[PosicaoColunaEncontrada].DataType;
        //                    NovaColuna.AllowDBNull = RetornoDadosPagina.Columns[PosicaoColunaEncontrada].AllowDBNull;
        //                    NovaColuna.Caption = RetornoPagina.Rows[x]["BuscaCampo_CampoDescricao"].ToString();
        //                    Retorno.DadosApresentacao.Columns.Add(NovaColuna);

        //                    if (x == 0)
        //                    {
        //                        Retorno.Formulario = "form" + RetornoPagina.Rows[x]["BuscaCampo_NomeCampo"].ToString().ToLower().Replace("_ID", "").Replace("_id", "").Replace("_Id", "").Replace("_", "") + ".aspx";
        //                    }

        //                }

        //            }


        //            if (RetornoDadosPagina.Rows.Count > 0)
        //            {
        //                DataColumn NovaColuna = new DataColumn();
        //                NovaColuna.ColumnName = "Editar";
        //                NovaColuna.DataType = typeof(String);
        //                NovaColuna.Caption = "Editar";
        //                Retorno.DadosApresentacao.Columns.Add(NovaColuna);


        //                DataColumn Excluir = new DataColumn();
        //                Excluir.ColumnName = "Excluir";
        //                Excluir.DataType = typeof(String);
        //                Excluir.Caption = "Excluir";
        //                Retorno.DadosApresentacao.Columns.Add(Excluir);

        //            }



        //            for (int x = 0; x < RetornoDadosPagina.Rows.Count; x++)
        //            {
        //                string Id = "";
        //                string Pagina = "";

        //                DataRow Linha = Retorno.DadosApresentacao.NewRow();

        //                for (int z = 0; z < Retorno.DadosApresentacao.Columns.Count; z++)
        //                {

        //                    if (z < Retorno.DadosApresentacao.Columns.Count - 2)
        //                    {
        //                        if (z == 0)
        //                        {
        //                            Id += RetornoDadosPagina.Rows[x][Retorno.DadosApresentacao.Columns[z].ColumnName].ToString().Replace("_", "");
        //                            Pagina += "form" + Retorno.DadosApresentacao.Columns[z].ColumnName.Replace("_id", "").Replace("_ID", "").Replace("_Id", "").Replace("_", "") + ".aspx?codigo=";
        //                        }


        //                        Linha[z] = RetornoDadosPagina.Rows[x][Retorno.DadosApresentacao.Columns[z].ColumnName];
        //                    }
        //                    else
        //                    {

        //                        Linha["Editar"] = "<a  class='linkEditar' style='border:none !important;' href='" + Pagina + Id + "&Tabela=" + Tabela + "'> <img src='../imagens/icones/b_edit.png' /></a>";

        //                        if (IdPgProcura != "9")
        //                        {

        //                            Linha["Excluir"] = "<a onclick='return Confirmacao(" + Id + ")' class='linkEditar' style='border:none !important;' href='procura.aspx?tabela=" + IdPgProcura + "&codigoAExcluir=" + Id + "'> <img src='../imagens/icones/b_drop.png' /></a>";
        //                        }
        //                    }
        //                }
        //                Retorno.DadosApresentacao.Rows.Add(Linha);

        //            }



        //            //DataColumn workCol = workTable.Columns.Add("CustID", typeof(Int32));
        //            //workCol.AllowDBNull = false;
        //            //workCol.Unique = true;

        //            //workTable.Columns.Add("CustLName", typeof(String));
        //            //workTable.Columns.Add("CustFName", typeof(String));
        //            //workTable.Columns.Add("Purchases", typeof(Double));





        //        }

        //    }


        //    return Retorno;




        //}
    }
}
