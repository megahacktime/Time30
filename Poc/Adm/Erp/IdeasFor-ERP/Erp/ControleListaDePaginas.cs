using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp
{
    public class ControleListaDePaginas
    {
        public ListaDePaginas Listagem = new ListaDePaginas();


        public ControleListaDePaginas()
        {


            //
            // TODO: Add constructor logic here
            //

        }

       
        public ControleListaDePaginas(string Pagina, string codigoAExcluir, int tamanhoPagina, int PaginaAtual, int PerfilLogado)
        {
            AutomatizaPaginas banco = new AutomatizaPaginas();

            if (codigoAExcluir != "")
            {
                banco.ExcluirPagina(Pagina, codigoAExcluir);
            }


            Listagem = banco.RetornaPaginaProcura(Pagina, tamanhoPagina, PaginaAtual, PerfilLogado);

            //Listagem.DadosApresentacao = new System.Data.DataTable();



            if (Listagem.Dados.Rows.Count > 0)
            {


            }

            //
            // TODO: Add constructor logic here
            //

        }

       

        public DataTable ExecutaConsulta(string SQL)
        {
            AutomatizaPaginas banco = new AutomatizaPaginas();

            DataTable dados = new DataTable();
            dados = banco.ExecutaConsulta(SQL);
            DataRow linha = dados.NewRow();
            linha[0] =DBNull.Value;
            linha[1] = "== SELECIONE ==";
            dados.Rows.InsertAt(linha, 0);

            return dados;
        }


        public int SalvaNoBaco(DataTable DadosTela , string  NomeTabela , string CampoChave, List<string> ListaColunas, List<string> ListaDados, int? id)
        { 

            string SQLGravar = "";

            if (id == null)
            {
                SQLGravar = "Insert into " + NomeTabela + "(";
                string Colunas = "";
                string strDados = "";

                for (int x = 0; x < ListaColunas.Count; x++)
                {
                    if (CampoChave.ToUpper() != ListaColunas[x])
                    {
                        Colunas += (Colunas == "" ? "" + ListaColunas[x] + "" : "," + ListaColunas[x] + "");
                    }
                }


                for (int x = 0; x < ListaColunas.Count; x++)
                {
                    string DadoTratato = "";
                    DataColumn DtColunas = DadosTela.Columns[ListaColunas[x]];
                    if (DtColunas.DataType == typeof(UInt64))
                    {
                        DadoTratato = ListaDados[x];
                    }
                    else if (DtColunas.DataType == typeof(UInt32))
                    {
                        DadoTratato = ListaDados[x];
                        if (string.IsNullOrEmpty(DadoTratato))
                        {
                            DadoTratato = "NULL";
                        }
                    }
                    else if (DtColunas.DataType == typeof(DateTime))
                    {
                        DadoTratato = ListaDados[x];
                        DateTime data = DateTime.MinValue;
                        if (string.IsNullOrEmpty(DadoTratato))
                        {
                            DadoTratato = "NULL";
                        }
                        else
                        {
                            DateTime.TryParse(DadoTratato, out data);
                            DadoTratato = ( data !=  DateTime.MinValue ? "'" +  data.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL");
                        }
                    }
                    else
                    {
                        DadoTratato = "'" + ListaDados[x] + "'";
                    }

                    if (CampoChave.ToUpper() != ListaColunas[x])
                    {
                        strDados += (strDados == "" ?   DadoTratato  : "," + DadoTratato  );

                    }
                }

                //for (int x = 0; x < ListaDados.Count; x++)
                //{
                //    if (CampoChave.ToUpper() != ListaColunas[x])
                //    {
                //        strDados +=   (strDados == "" ? "'" +  ListaDados[x] + "'" : " , '" + ListaDados[x] + "'")  ;
                //    }
                //}
                SQLGravar += Colunas + ") Values (" + strDados + ")";
            }
            else
            {
                SQLGravar = "update  " + NomeTabela + " set ";

                string Colunas = "";


                for (int x = 0; x < ListaColunas.Count; x++)
                {
                    string DadoTratato = "";
                    DataColumn DtColunas = DadosTela.Columns[ListaColunas[x]];
                    if(DtColunas.DataType == typeof(UInt64))
                    {
                        DadoTratato = ListaDados[x];
                    }else if(DtColunas.DataType == typeof(UInt32))
                    {
                        DadoTratato = ListaDados[x];
                        if (string.IsNullOrEmpty(DadoTratato))
                        {
                            DadoTratato = "NULL";
                        }
                    }
                    else if (DtColunas.DataType == typeof(DateTime))
                    {
                        DadoTratato = ListaDados[x];
                        DateTime data = DateTime.MinValue;
                        if (string.IsNullOrEmpty(DadoTratato))
                        {
                            DadoTratato = "NULL";
                        }
                        else
                        {
                            DateTime.TryParse(DadoTratato, out data);
                            DadoTratato = (data != DateTime.MinValue ? "'" + data.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL");
                        }
                    }
                    else
                    {
                        DadoTratato = "'" + ListaDados[x] + "'";
                    }

                    if (CampoChave.ToUpper() != ListaColunas[x])
                    {
                        Colunas += (Colunas == "" ? ListaColunas[x] + "= " + DadoTratato + "" : "," + ListaColunas[x] + "= " + DadoTratato + "");

                    }
                }

                SQLGravar += Colunas + " Where " + CampoChave + "='" + id.ToString() + "'";

            }

            AutomatizaPaginas banco = new AutomatizaPaginas();

            DataTable dados = new DataTable();
            return banco.ExecuteNoQuery(SQLGravar, false);
 
        }

        public ControleListaDePaginas (string Pagina, string IdLinha , string codigoAExcluir )
        {
            AutomatizaPaginas banco = new AutomatizaPaginas();

            if (codigoAExcluir != "")
            {
                banco.ExcluirPagina(Pagina, codigoAExcluir);
            }

            Listagem = banco.RetornaFormulario(Pagina, IdLinha);
            //Listagem.DadosApresentacao = new System.Data.DataTable();

            if (Listagem.Dados.Rows.Count > 0)
            {
            }

            //
            // TODO: Add constructor logic here
            //

        }


    }
}


