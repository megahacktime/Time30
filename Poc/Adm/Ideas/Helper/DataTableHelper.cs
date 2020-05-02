using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace Ideas.Helper
{
    public static class DataTableHelper
    {
        public static T ToObject<T>(this DataTable tb, List<string> alias=null) where T : class, new()
        {
            T obj = new T();
            try
            {
                DataRow row = null;
                if (tb != null && tb.Rows.Count > 0)
                {
                    row = tb.Rows[0];
                    obj = row.ToObject<T>(alias);
                }
            }
            finally { };
            
            return obj;
        }

        private static void toSubOjbject<T>(T obj, PropertyInfo property, DataRow row, List<string>alias=null)
        {
            PropertyInfo[] pinfo = property.PropertyType.GetProperties();
            var subObjeto = Activator.CreateInstance(property.PropertyType);
            foreach (var p in pinfo)
            {
                try
                {                    
                    string pName = null;
                    bool achou = getColumnNameForProperty(p, out pName, row, alias);
                    
                    if (achou)
                    {
                        var val = row[pName];
                        if (val != null && val != DBNull.Value)
                        {
                            if (p.PropertyType.IsGenericType && p.PropertyType.Name.Contains("Nullable"))
                            {
                                if (!string.IsNullOrEmpty(val.ToString()))
                                {
                                    object objnullable = Convert.ChangeType(obj, Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType);
                                    p.SetValue(subObjeto, objnullable, null);
                                }
                            }
                            else if (p.PropertyType.BaseType == typeof(Enum))
                            {                                
                                foreach (var el in Enum.GetValues(p.PropertyType))
                                {
                                    if (val.Equals(el.ToString()) || val.Equals(((int)el).ToString()))
                                    {
                                        p.SetValue(subObjeto, Convert.ChangeType(el, p.PropertyType), null);
                                        break;
                                    }
                                }
                                
                            }
                            else
                            {
                                p.SetValue(subObjeto, Convert.ChangeType(val, p.PropertyType), null);
                            }
                        }
                    }
                                        
                }
                catch (Exception)
                {
                    continue;
                }                
            }
            if(subObjeto != null)
            {
                property.SetValue(obj, Convert.ChangeType(subObjeto, property.PropertyType), null);
            }
        }

        private static bool getColumnNameForProperty(PropertyInfo pInfo, out string properyName, DataRow row, List<string> alias = null)
        {
            try
            {
                var atr = pInfo.GetCustomAttributes(typeof(Attr), false);
                
                string pName = pInfo.Name;
                if (atr != null && atr.Length >0)
                {
                    if (atr[0] is XmlElementAttribute) pName = ((XmlElementAttribute)atr[0]).ElementName ?? pName;
                    if (atr[0] is XmlAttributeAttribute) pName = ((XmlAttributeAttribute)atr[0]).AttributeName ?? pName;
                    if (atr[0] is Attr) pName = ((Attr)atr[0]).Nome ?? pName;
                }
                
                List<string> pNamesComAlias = new List<string>();
                bool achou = false;
                // com alias
                if (alias != null)
                {
                    foreach (var a in alias)
                    {
                        pNamesComAlias.Add($"{a}_{pName}");
                    }
                }
                else // senão, sem alias
                {
                    pNamesComAlias.Add(pName);
                }
                foreach (DataColumn col in row.Table.Columns)
                {
                    if (pNamesComAlias.Contains(col.ColumnName))
                    {
                        pName = col.ColumnName;
                        achou = true;
                        break;
                    }
                    //else // senão
                    //{
                    //    var parts = col.ColumnName.Split('.');
                    //    if (parts.Length > 1 && pNamesComAlias.Contains(parts[1]))
                    //    {
                    //        pName = col.ColumnName;
                    //        achou = true;
                    //        break;
                    //    }
                    //}
                }
                properyName = pName;
                return achou;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <param name="alias">alias da tabela</param>
        /// <returns></returns>
        public static T ToObject<T>(this DataRow row, List<string>alias=null) where T : class, new()
        {
            T obj = new T();
            List<string> colunas = new List<string>();              
            foreach (var p in obj.GetType().GetProperties())
            {
                try
                {
                    
                    if (p.PropertyType.IsClass && !SYSinfo.EumTipoPrimitivo(p.PropertyType))
                    {
                        string fname = obj.GetType().FullName;
                        string bfname = obj.GetType().BaseType.FullName;
                        if (p.PropertyType.FullName != fname && p.PropertyType.FullName != bfname)
                        {
                            toSubOjbject<T>(obj, p, row, alias);
                        }                        
                    }
                    else
                    {                        
                        string pName;
                        bool achou = getColumnNameForProperty(p, out pName, row, alias);
                        if (achou)
                        {
                            var val = row[pName];
                            if (p.PropertyType.IsGenericType && p.PropertyType.Name.Contains("Nullable"))
                            {
                                if (!string.IsNullOrEmpty(val.ToString()))
                                {
                                    //object objnullable = Convert.ChangeType(obj, Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType);
                                    object objnullable = Convert.ChangeType(val, Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType);
                                    p.SetValue(obj, objnullable, null);
                                }
                            }
                            else if (p.PropertyType.BaseType == typeof(Enum))
                            {
                                foreach (var el in Enum.GetValues(p.PropertyType))
                                {
                                    int venum = (int)el;
                                    if (val.Equals(el.ToString()) || val.Equals(venum))
                                    {
                                        p.SetValue(obj, Convert.ChangeType(el, p.PropertyType), null);
                                        break;
                                    }
                                }

                            }
                            else if(val != null && val != DBNull.Value)
                            {
                                p.SetValue(obj, Convert.ChangeType(val, p.PropertyType), null);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }            
            return obj;
        }

        /// <summary>
        /// Converte o datatable na lista T informada, nota: esse método aplica a regra de linhas distintas(DISTINCT)
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>
        public static List<T> DataTableToList<T>(this DataTable table, List<string>alias = null) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();
                var tbrowsdistinct = table.ToTable(alias);
                foreach (var row in tbrowsdistinct.AsEnumerable())
                {
                    var obj = row.ToObject<T>(alias);
                    
                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// retorna um datatable com todas as colunas que contenham o alias informado no início do nome
        /// ex.: <alias.nome> C.Credenciado_Id
        /// Nota: esse método não retornas linhas duplicadas (DISTINCT)
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="alias"></param>
        public static DataTable ToTable(this DataTable tb, List<string> alias, string expression = null)
        {
            //string seprarador = "";
            List<string> colunas = new List<string>();
            foreach(DataColumn col in tb.Columns)
            {
                foreach(string a in alias)
                {
                    var cAlias = col.ColumnName.Split(new char[] { '_' })[0];
                    if (cAlias.ToUpper() == a.ToUpper())
                    {
                        colunas.Add(col.ColumnName);
                    }
                }
            }

            //expression = "C_Credenciado_Credenciado_Id IS NOT NULL ";
            tb.DefaultView.RowFilter = expression ?? string.Empty;
            var ntb = tb.DefaultView.ToTable("view_filter", true, colunas.ToArray());
            return ntb;

            //var nTb = tb.DefaultView.ToTable(true, colunas.ToArray());
            //nTb.DefaultView.RowFilter = expression ?? string.Empty;
            //return nTb.DefaultView.ToTable("view_credenciado_filter", true, colunas.ToArray());
            //return nTb;
        }
               

        /// <summary>
        /// Retonna um datatable (DISTINCT) que corresponda ao filtro
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="nomeTb"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static DataTable ToTable(this DataTable tb, string nomeTb, string expression)
        {
            tb.DefaultView.RowFilter = expression ?? string.Empty;
            var ntb = tb.DefaultView.ToTable(nomeTb, true);
            return ntb;
        }
    }
}
