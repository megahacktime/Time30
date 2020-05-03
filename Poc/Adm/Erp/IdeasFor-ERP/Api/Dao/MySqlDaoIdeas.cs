using Ideas.Dao.MySQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Api.Dao
{
    public class MySqlDaoIdeas
    {

        public int Salvar(object Objeto, string CampoChave, string Inicial, bool ForcarInsert = false)
        {
            Dbo conec = new Dbo();
            int retorno = 0;
            try
            {

                String NomeObjeto = Objeto.GetType().Name;
                string NomeTabela = Inicial + NomeObjeto.Replace(Inicial, "");

                var propriedades = Objeto.GetType().GetProperties();
                string ValorChave = "";

                foreach (var propriedade in propriedades)
                {
                    if (propriedade.Name.ToUpper() == CampoChave.ToUpper())
                    {
                        ValorChave = propriedade.GetValue(Objeto, null).ToString();
                        break;
                    }
                }

                DataTable dados = conec.Select("Select * from " + NomeTabela + " Where " + CampoChave + "='" + ValorChave + "'");

                string SQLGravar = "";
                List<string> ListaColunas = new List<string>();
                List<string> ListaDados = new List<string>();
                bool Insert;

                if (dados.Rows.Count > 0)
                {
                    Insert = false;

                    if (ForcarInsert)
                    {
                        Insert = true;
                    }
                }
                else
                {
                    Insert = true;
                }

                if (dados.Columns.Count > 0)
                {
                    for (int x = 0; x < dados.Columns.Count; x++)
                    {
                        foreach (var propriedade in propriedades)
                        {


                            if (propriedade.Name.ToUpper() == dados.Columns[x].ColumnName.ToUpper())
                            {

                                ListaColunas.Add(propriedade.Name.ToUpper());
                                string DadoObjeto = "";

                                if ((propriedade.GetValue(Objeto, null) != null))
                                {
                                    DadoObjeto = propriedade.GetValue(Objeto, null).ToString();
                                }
                                if (propriedade.PropertyType.FullName.IndexOf("DateTime") > -1)
                                {
                                    if (!DadoObjeto.Contains(DateTime.MinValue.ToString()))
                                    {
                                        ListaDados.Add((DadoObjeto == "" ? "NULL" : "convert(datetime, '" + DateTime.Parse(DadoObjeto).ToString("dd/MM/yyyy HH:mm:ss") + "' , 103)"));
                                    }
                                    else
                                    {
                                        ListaDados.Add("NULL");
                                    }
                                }
                                else
                                {
                                    if (propriedade.PropertyType.FullName.ToLower().IndexOf("decimal") > -1 || propriedade.PropertyType.FullName.ToLower().IndexOf("double") > -1)
                                    {
                                        ListaDados.Add((DadoObjeto == "" ? "NULL" : "'" + DadoObjeto.Replace(".", "").Replace(",", ".") + "'"));
                                    }
                                    else
                                    {
                                        ListaDados.Add((DadoObjeto == "" ? "NULL" : "'" + DadoObjeto + "'"));
                                    }
                                }

                                break;
                            }

                            //propriedade.Name;                pra pegar o nome dela
                            //propriedade.PropertyType;     pra pegar o tipo
                            //propriedade.SetValue(...);    pra setar um valor
                            //propriedade.GetValue(...);    pra ler um valor
                        }
                    }


                    if (Insert)
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

                        for (int x = 0; x < ListaDados.Count; x++)
                        {
                            if (CampoChave.ToUpper() != ListaColunas[x])
                            {
                                strDados += (strDados == "" ? "" + ListaDados[x] + "" : "," + ListaDados[x] + "");
                            }
                        }
                        SQLGravar += Colunas + ") Values (" + strDados + ")";
                    }
                    else
                    {
                        SQLGravar = "update  " + NomeTabela + " set ";

                        string Colunas = "";


                        for (int x = 0; x < ListaColunas.Count; x++)
                        {
                            if (CampoChave.ToUpper() != ListaColunas[x])
                            {
                                Colunas += (Colunas == "" ? ListaColunas[x] + "=" + ListaDados[x] + "" : "," + ListaColunas[x] + "=" + ListaDados[x] + "");

                            }
                        }

                        SQLGravar += Colunas + " Where " + CampoChave + "='" + ValorChave + "'";

                    }

                    retorno = conec.ExecuteNoQuery(SQLGravar, true);

                    //if (Insert)
                    //{
                    //    int ID =  PegarIdentidade(this.MsSQl, NomeTabela);

                    //    foreach (var propriedade in propriedades)
                    //    {
                    //        if (propriedade.Name.ToUpper() == CampoChave.ToUpper())
                    //        {
                    //            propriedade.SetValue(Objeto, ID, null);
                    //            break;
                    //        }
                    //    }

                    //    if (MsSQl.State != ConnectionState.Closed)
                    //    {
                    //        MsSQl.Close();
                    //        MsSQl.Dispose();
                    //    }

                    //}
                    //else
                    //{
                    //    if (MsSQl.State != ConnectionState.Closed)
                    //    {
                    //        MsSQl.Close();
                    //        MsSQl.Dispose();
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                //if (MsSQl != null && MsSQl.State != ConnectionState.Closed)
                //{
                //    MsSQl.Close();
                //    MsSQl.Dispose();
                //}

                throw new Exception(ex.Message);

            }
            return retorno;
        }

        //public int SalvaNoBaco(DataTable DadosTela, string NomeTabela, string CampoChave, List<string> ListaColunas, List<string> ListaDados, int? id)
        //{

        //    string SQLGravar = "";

        //    if (id == null)
        //    {
        //        SQLGravar = "Insert into " + NomeTabela + "(";
        //        string Colunas = "";
        //        string strDados = "";

        //        for (int x = 0; x < ListaColunas.Count; x++)
        //        {
        //            if (CampoChave.ToUpper() != ListaColunas[x])
        //            {
        //                Colunas += (Colunas == "" ? "" + ListaColunas[x] + "" : "," + ListaColunas[x] + "");
        //            }
        //        }


        //        for (int x = 0; x < ListaColunas.Count; x++)
        //        {
        //            string DadoTratato = "";
        //            DataColumn DtColunas = DadosTela.Columns[ListaColunas[x]];
        //            if (DtColunas.DataType == typeof(UInt64))
        //            {
        //                DadoTratato = ListaDados[x];
        //            }
        //            else if (DtColunas.DataType == typeof(UInt32))
        //            {
        //                DadoTratato = ListaDados[x];
        //                if (string.IsNullOrEmpty(DadoTratato))
        //                {
        //                    DadoTratato = "NULL";
        //                }
        //            }
        //            else if (DtColunas.DataType == typeof(DateTime))
        //            {
        //                DadoTratato = ListaDados[x];
        //                DateTime data = DateTime.MinValue;
        //                if (string.IsNullOrEmpty(DadoTratato))
        //                {
        //                    DadoTratato = "NULL";
        //                }
        //                else
        //                {
        //                    DateTime.TryParse(DadoTratato, out data);
        //                    DadoTratato = (data != DateTime.MinValue ? "'" + data.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL");
        //                }
        //            }
        //            else
        //            {
        //                DadoTratato = "'" + ListaDados[x] + "'";
        //            }

        //            if (CampoChave.ToUpper() != ListaColunas[x])
        //            {
        //                strDados += (strDados == "" ? DadoTratato : "," + DadoTratato);

        //            }
        //        }

        //        //for (int x = 0; x < ListaDados.Count; x++)
        //        //{
        //        //    if (CampoChave.ToUpper() != ListaColunas[x])
        //        //    {
        //        //        strDados +=   (strDados == "" ? "'" +  ListaDados[x] + "'" : " , '" + ListaDados[x] + "'")  ;
        //        //    }
        //        //}
        //        SQLGravar += Colunas + ") Values (" + strDados + ")";
        //    }
        //    else
        //    {
        //        SQLGravar = "update  " + NomeTabela + " set ";

        //        string Colunas = "";


        //        for (int x = 0; x < ListaColunas.Count; x++)
        //        {
        //            string DadoTratato = "";
        //            DataColumn DtColunas = DadosTela.Columns[ListaColunas[x]];
        //            if (DtColunas.DataType == typeof(UInt64))
        //            {
        //                DadoTratato = ListaDados[x];
        //            }
        //            else if (DtColunas.DataType == typeof(UInt32))
        //            {
        //                DadoTratato = ListaDados[x];
        //                if (string.IsNullOrEmpty(DadoTratato))
        //                {
        //                    DadoTratato = "NULL";
        //                }
        //            }
        //            else if (DtColunas.DataType == typeof(DateTime))
        //            {
        //                DadoTratato = ListaDados[x];
        //                DateTime data = DateTime.MinValue;
        //                if (string.IsNullOrEmpty(DadoTratato))
        //                {
        //                    DadoTratato = "NULL";
        //                }
        //                else
        //                {
        //                    DateTime.TryParse(DadoTratato, out data);
        //                    DadoTratato = (data != DateTime.MinValue ? "'" + data.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "NULL");
        //                }
        //            }
        //            else
        //            {
        //                DadoTratato = "'" + ListaDados[x] + "'";
        //            }

        //            if (CampoChave.ToUpper() != ListaColunas[x])
        //            {
        //                Colunas += (Colunas == "" ? ListaColunas[x] + "= " + DadoTratato + "" : "," + ListaColunas[x] + "= " + DadoTratato + "");

        //            }
        //        }

        //        SQLGravar += Colunas + " Where " + CampoChave + "='" + id.ToString() + "'";

        //    }

        //    Dbo conec = new Dbo();
        //    return conec.ExecuteNoQuery(SQLGravar);

        //}
    }
}