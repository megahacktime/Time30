using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;
using System.Data;

namespace Ideas.Dao.MsSql
{
    public class Dbo
    {
        //private static MsSqlServer mssqlserver;
        private SqlConnection _conn;
        private string database = null;

        public SqlDataReader Reader { get; set; }
        public SqlDataAdapter Adapter { get; set; }
        public SqlCommand Cmd { get; set; }
        public bool isLocalDB { get; set; } = false;
        
        /// <summary>
        /// Cria um novo objeto
        /// </summary>
        /// <param name="db">Nome do bando de dados, quando NULL(assume o banco configurado na string de conexão)</param>
        public Dbo( string db = null)
        {
            database = db;
        }

        public SqlConnection Conexao
        {
            get
            {
                if (_conn == null)
                {
                    if (isLocalDB)
                    {
                        string strConn = IdeasConfig.Default.MsSqlLocalDB.Replace("#path#", AppDomain.CurrentDomain.BaseDirectory);
                        _conn = new SqlConnection(strConn);
                    }
                    else
                    {
                        _conn = new SqlConnection(IdeasConfig.Default.MsSQL);
                        SqlConnection.ClearPool(_conn);
                    }
                }
                if (_conn.State != ConnectionState.Open)
                {
                    _conn.Open();
                    if (database != null && database != string.Empty) _conn.ChangeDatabase(database);
                }
                return _conn;
            }
        }

        /// <summary>
        /// Retorna o objeto preenchido com os valores de suas propriedades contidas 
        /// no datareader
        /// </summary>
        /// <typeparam name="T">Classe que define o tipo do objeto</typeparam>
        /// <param name="p">O objeto que será preenchido</param>
        /// <returns></returns>
        public T getCurrentRowInDataReader<T>() where T : Table, new()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            // cria a nova instância
            T p = new T();
            // define o bando de dados do objeto
            p.Db = database;
            foreach (PropertyInfo pinfo in properties)
            {
                var tp = pinfo.PropertyType;
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    // se o valor da coluna não for null
                    if (!Reader.IsDBNull(i))
                    {
                        if (p.ChaveEstrageira != null && p.ChaveEstrageira.ContainsKey(Reader.GetName(i)))
                        {
                            p.ChaveEstrageira[Reader.GetName(i)] = Reader.GetInt32(i);
                        }
                        else if (Reader.GetName(i).ToLower() == (p.getPrefixo() + pinfo.Name).ToLower())
                        {
                            object v = Reader.GetValue(i);
                            // se for um enum
                            if (tp.BaseType == typeof(Enum))
                            {
                                foreach (var el in Enum.GetValues(pinfo.PropertyType))
                                {
                                    if (v.Equals(el.ToString()))
                                    {
                                        pinfo.SetValue(p, Convert.ChangeType(el, pinfo.PropertyType), null);
                                        break;
                                    }
                                }
                            }
                            else // demais
                            {
                                object objnullable = Convert.ChangeType(v, Nullable.GetUnderlyingType(pinfo.PropertyType) ?? pinfo.PropertyType);
                                pinfo.SetValue(p, objnullable, null);
                                //pinfo.SetValue(p, Convert.ChangeType(v, pinfo.PropertyType), null);
                            }
                            break;
                        }
                    }
                }
                //Attr[] att = (Attr[])pinfo.GetCustomAttributes(typeof(Attr), false);
                //if(att != null && att.Length > 0)
                //{
                //    if(att[0].ForeigKey != null)
                //    {
                //        setPrimaryKeyValue<T>(p, pinfo, att[0].ForeigKey);
                //    }
                //}
            }
            return p;
        }

        /// <summary>
        /// define o valor da chave primária que corresponde a chave estrangeira
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="property"></param>
        //private void setPrimaryKeyValue<T>(T obj, PropertyInfo property, string foreikey) where T:Table, new()
        //{            
        //    PropertyInfo[] pinfo = property.PropertyType.GetProperties();
        //    var subObjeto = Activator.CreateInstance(property.PropertyType);
            
        //    foreach (var p in pinfo)
        //    {
        //        Attr[] attr = (Attr[]) p.GetCustomAttributes(typeof(Attr), false);
        //        if (attr != null && attr.Length > 0)
        //        {
        //            if (attr[0].eChavaPrimaria)
        //            {
        //                object objnullable = Convert.ChangeType(obj.ChaveEstrageira[foreikey], Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType);
        //                p.SetValue(subObjeto, objnullable, null);
        //                property.SetValue(obj, subObjeto, null);
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// Retorna o objeto preenchido com os valores de suas propriedades contidas no datareader
        /// </summary>
        /// <typeparam name="T">Classe que define o tipo do objeto</typeparam>
        /// <returns>Objeto T preenchido</returns>
        public T getCurrentCustomerRowInDataReader<T>() where T : Table, new()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            // cria a nova instância
            T p = new T();
            // define o banco de dados
            p.Db = database;
            foreach (PropertyInfo pinfo in properties)
            {
                var tp = pinfo.PropertyType;
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    // se o valor da coluna não for null
                    if (!Reader.IsDBNull(i))
                    {
                        if (Reader.GetName(i).ToLower() == pinfo.Name.ToLower())
                        {
                            object v = Reader.GetValue(i);

                            // se for um enum
                            if (tp.BaseType == typeof(Enum))
                            {
                                foreach (var el in Enum.GetValues(pinfo.PropertyType))
                                {
                                    if (v.Equals(el.ToString()))
                                    {
                                        pinfo.SetValue(p, Convert.ChangeType(el, pinfo.PropertyType), null);
                                        break;
                                    }
                                }
                            }
                            else // demais
                            {
                                Type propertyType = Nullable.GetUnderlyingType(pinfo.PropertyType) ?? pinfo.PropertyType;
                                v = Convert.ChangeType(v, propertyType);
                                pinfo.SetValue(p, Convert.ChangeType(v, pinfo.PropertyType), null);
                            }
                            break;
                        }
                    }
                }
            }
            return p;
        }

        /// <summary>
        /// Inserre os dados do objeto na base de dados
        /// </summary>
        /// <typeparam name="T">Classe de tipo</typeparam>
        /// <param name="value">Objeto com os valores</param>
        /// <returns>O ID gerado para o objeto (se for auto increment, senão o numero de linhas afetadas)</returns>
        public int Insert<T>(T value) where T : Table
        {
            try
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                string sql = string.Format("INSERT INTO {0} (", value.getNomeDaTabela());
                string v = "VALUES(";
                List<SqlParameter> pts = new List<SqlParameter>();

                for (int i = 0; i < properties.Length; i++)
                {
                    var tp = properties[i].PropertyType;

                    Attr[] atributos = (Attr[])properties[i].GetCustomAttributes(typeof(Attr), false);

                    // se não foi definido o atributo ou se foi e é um atributo da tabela
                    if (atributos.Length == 0 || ((Attr)atributos[0]).eUmAtributoDaTabela)
                    {
                        // se for um dicionário de fk
                        if (tp == typeof(Dictionary<string, int>) && value.ChaveEstrageira != null)
                        {
                            // pega as chaves estrangeiras do objeto
                            foreach (var dc in value.ChaveEstrageira)
                            {
                                if (dc.Value > 0)
                                {
                                    sql += string.Format("{0}, ", dc.Key);
                                    v += string.Format("@{0}, ", dc.Key);
                                    pts.Add(new SqlParameter() { ParameterName = dc.Key, Value = dc.Value });
                                }
                            }
                        }

                        // senão se for um dos tipos primitivos
                        else if (eTipoPrimitivo(tp))
                        {
                            bool eUmaChavePrimaria = (atributos.Length > 0 && ((Attr)atributos[0]).eChavePrimaria);
                            bool eSenha = (atributos.Length > 0 && ((Attr)atributos[0]).eSenha);
                            bool eToken = (atributos.Length > 0 && ((Attr)atributos[0]).eToken);
                            bool eMD5 = (atributos.Length > 0 && ((Attr)atributos[0]).eMD5);
                            bool ePKautoincremento = (atributos.Length > 0 && ((Attr)atributos[0]).eChavePrimaria && value.getPKautoIncremento());
                            if (eMD5)
                            {
                                sql += string.Format("{0}, ", value.getPrefixo() + properties[i].Name);
                                v += string.Format("'{0}', ", Criptografia.getMD5(properties[i].GetValue(value, null).ToString()));
                            }// se for a propriedade Token
                            else if (eToken)
                            {
                                sql += string.Format("{0}, ", value.getPrefixo() + properties[i].Name);
                                v += string.Format("'{0}', ", "REPLACE(REPLACE(REPLACE(REPLACE(CONVERT(varchar ,SYSUTCDATETIME()),'-',''),':',''),' ',''),'.','')");
                            }// senão, se for a propriedade Senha
                            else if (eSenha)
                            {
                                sql += string.Format("{0}, ", value.getPrefixo() + properties[i].Name);
                                v += string.Format(@"PWDENCRYPT('{0}'), ", @properties[i].GetValue(value, null));
                            }// senão
                            else 
                            {
                                 // se não é uma chave primária auto incrementada
                                if (!ePKautoincremento)
                                {
                                    sql += string.Format("{0},  ", value.getPrefixo() + properties[i].Name);
                                    v += string.Format("@{0}, ", properties[i].Name);
                                    pts.Add(new SqlParameter() { ParameterName = string.Format("@{0}", properties[i].Name), Value = getValueOrDbNull(@properties[i].GetValue(value, null)) });
                                }
                            }
                        }
                    }
                }

                // remove a última vírgula dos campos e fecha a query
                int idxSQL = sql.LastIndexOf(",");
                sql = sql.Substring(0, idxSQL).Insert(idxSQL, ")");
                int idxV = v.LastIndexOf(",");
                v = v.Substring(0, idxV).Insert(idxV, ")");
                sql += v;
                
                Cmd = new SqlCommand(sql, Conexao);
                
                foreach (SqlParameter p in pts)
                {
                    Cmd.Parameters.Add(p);
                }
                // se for auto increment
                if (value.getPKautoIncremento())
                {
                    Cmd.Parameters.Add("@outID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    Cmd.CommandText += string.Format("; SET @outID = IDENT_CURRENT('{0}')", value.getNomeDaTabela());
                }
                int r = Cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    // se for auto incremento
                    if (value.getPKautoIncremento())
                    {
                        int rID = 0;
                        // pega o id gerado para tabela com autoincremento
                        if (int.TryParse(Cmd.Parameters["@outID"].Value.ToString(), out rID) && rID > 0)
                        {
                            r = rID;
                        }
                    }
                }
                return  r;
            }
            catch (SqlException sex)
            {
                throw sex;
            }
            catch (Exception ex)
            {
                throw ex;
            }                       
        }

        /// <summary>
        /// Atualiza a base de dados com os dados contidos no objeto.
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="query">A query especifica de update ou NULL para usar a extrutura do objeto </param>
        /// <param name="value">Objeto com preenchido</param>
        /// <param name="where">COndição sql</param>
        /// <param name="whereParametros">parâmetros da condição</param>
        /// <returns></returns>
        public int Update<T>(T value, string query, string where, List<SqlParameter> whereParametros) where T : Table, new()
        {
            try
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                string sql = string.Format("UPDATE {0} SET ", value.getNomeDaTabela());
                List<SqlParameter> pts = new List<SqlParameter>();

                // se não foi passado uma query
                if (query == null)
                {
                    for (int i = 0; i < properties.Length; i++)
                    {
                        var tp = properties[i].PropertyType;

                        Attr[] atributos = (Attr[])properties[i].GetCustomAttributes(typeof(Attr), false);

                        // se não foi definido o atributo ou se foi e é um atributo da tabela
                        if (atributos.Length == 0 || ((Attr)atributos[0]).eUmAtributoDaTabela)
                        {
                            // se for um dicionário de fk
                            if (tp == typeof(Dictionary<string, int>) && value.ChaveEstrageira != null)
                            {
                                // pega as chaves estrangeiras do objeto
                                foreach (var dc in value.ChaveEstrageira)
                                {
                                    if (dc.Value > 0)
                                    {
                                        sql += string.Format("{0}=@{1}, ", dc.Key, dc.Key);
                                        pts.Add(new SqlParameter() { ParameterName = string.Format("@{0}", dc.Key), Value = dc.Value });
                                    }
                                    else
                                    {
                                        sql += string.Format("{0}=@{1}, ", dc.Key, dc.Key);
                                        pts.Add(new SqlParameter() { ParameterName = string.Format("@{0}", dc.Key), Value = DBNull.Value });
                                    }
                                }
                            } // senão se for um dos tipos primitivos
                            else if (eTipoPrimitivo(tp))
                            {
                                
                                var pVal = properties[i].GetValue(value, null);
                                bool eUmaChavePrimaria = (atributos.Length > 0 && ((Attr)atributos[0]).eChavePrimaria);
                                bool eSenha = (atributos.Length > 0 && ((Attr)atributos[0]).eSenha);
                                bool eToken = (atributos.Length > 0 && ((Attr)atributos[0]).eToken);
                                bool eMD5 = (atributos.Length > 0 && ((Attr)atributos[0]).eMD5);
                                bool eReadOnly = (atributos.Length > 0 && ((Attr)atributos[0]).eReadOnly);
                                // se não for readonly
                                if (!eReadOnly)
                                {
                                    // se não for uma pk, Token, md5, Senha e se for null ou não for um valor default de data
                                    if (!eUmaChavePrimaria && !eToken && !eMD5  && !eSenha && (pVal == null || !pVal.Equals(DateTime.MinValue)))
                                    {
                                        sql += string.Format("{0}=@{1},  ", value.getPrefixo() + properties[i].Name, properties[i].Name);
                                        pts.Add(new SqlParameter() { ParameterName = string.Format("@{0}", properties[i].Name), Value = getValueOrDbNull(pVal) });
                                    }// senão se for a senha e a senha não é null
                                    else if (eSenha && pVal != null)
                                    {
                                        sql += string.Format("{0}=PWDENCRYPT('{1}'),  ", value.getPrefixo() + properties[i].Name, pVal);
                                    }
                                }
                            }
                        }
                    }
                    // remove a última vírgula dos campos e fecha a query
                    int idxSQL = sql.LastIndexOf(",");
                    sql = sql.Substring(0, idxSQL).Insert(idxSQL, " ");
                }
                else // query externa
                {
                    sql = query;
                }

                if (where != null) sql += string.Format(" WHERE {0}", where);

                Cmd = new SqlCommand(sql, Conexao);

                // adiciona os parâmentros internos
                foreach (SqlParameter p in pts)
                {
                    Cmd.Parameters.Add(p);
                }
                // adiciona os parâmetros externos
                if (whereParametros != null)
                {
                    foreach (SqlParameter p2 in whereParametros)
                    {
                        Cmd.Parameters.Add(p2);
                    }
                }
                return Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        private bool eTipoPrimitivo(Type tp)
        {
            // tp == typeof(string) || tp == typeof(int) || tp == typeof(decimal) || tp == typeof(double) || tp == typeof(bool) || tp == typeof(char) || tp == typeof(DateTime) || tp == typeof(long);
            bool r = false;
            r = tp == typeof(string) || tp == typeof(decimal) || tp == typeof(long);
            r = r || tp == typeof(int) || tp == typeof(Nullable<int>);
            r = r || tp == typeof(double) || tp == typeof(bool) || tp == typeof(char);
            r = r || tp == typeof(DateTime) || tp == typeof(Nullable<DateTime>);
            r = r || tp == typeof(TimeSpan) || tp == typeof(Nullable<TimeSpan>);
            r = r || tp.IsEnum;
            return r;
        }

        /// <summary>
        /// Exclui o objeto da base de dados que a linha coincida com todos os campos preenchido do objeto
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="value">Objeto a ser excluido</param>
        /// <param name="exclusaoFisica">Se verdadeiro exclui o registro senão apenas define a propriedade _delete_ = 1</param>
        /// <returns></returns>
        public int Delete<T>(T value, bool exclusaoFisica = false) where T : Table, new()
        {
            try
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                string sql = string.Format("UPDATE {0} SET _deleted_ = 1 ", value.getNomeDaTabela());
                // so permite excluir se houver propriedades preenchidas
                // no mínimo uma 
                bool temCondicao = false;
                List<SqlParameter> pts = new List<SqlParameter>();
                if (exclusaoFisica)
                {
                    sql = string.Format("DELETE FROM {0} ", value.getNomeDaTabela());
                }
                sql += "WHERE _deleted_ = 0 ";

                for (int i = 0; i < properties.Length; i++)
                {
                    var tp = properties[i].PropertyType;

                    Attr[] atributos = (Attr[])properties[i].GetCustomAttributes(typeof(Attr), false);

                    // se não foi definido o atributo ou se foi e é um atributo da tabela
                    if (atributos.Length == 0 || ((Attr)atributos[0]).eUmAtributoDaTabela)
                    {
                        // se for um dicionário de fk
                        if (tp == typeof(Dictionary<string, int>) && value.ChaveEstrageira != null)
                        {
                            // pega as chaves estrangeiras do objeto
                            foreach (var dc in value.ChaveEstrageira)
                            {
                                // se tem valor
                                if (dc.Value > 0)
                                {
                                    sql += string.Format("AND {0}=@{1} ", dc.Key, dc.Key);
                                    pts.Add(new SqlParameter() { ParameterName = string.Format("@{0}", dc.Key), Value = dc.Value });
                                    temCondicao = true;
                                }
                            }
                        }

                        // senão se for um dos tipos primitivos
                        else if (eTipoPrimitivo(tp))
                        {
                            // se não for a propriedade (Senha)
                            if (properties[i].Name.ToLower() != "senha")
                            {
                                var val = properties[i].GetValue(value, null);
                                // se não for null e não for 0, "", empty e false
                                if (val != null && (!val.Equals(0) && !val.Equals("") && !val.Equals(string.Empty) && !val.Equals(false) && !val.Equals(DateTime.MinValue)))
                                {
                                    sql += string.Format("AND {0}=@{1}  ", value.getPrefixo() + properties[i].Name, properties[i].Name);
                                    pts.Add(new SqlParameter() { ParameterName = string.Format("@{0}", properties[i].Name), Value = getValueOrDbNull(@properties[i].GetValue(value, null)) });
                                    temCondicao = true;
                                }
                            }
                        }
                    }
                }

                Cmd = new SqlCommand(sql, Conexao);

                // adiciona os parâmentros internos
                foreach (SqlParameter p in pts)
                {
                    Cmd.Parameters.Add(p);
                }
                if (temCondicao) return Cmd.ExecuteNonQuery(); else return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        public object getValueOrDbNull(object val)
        {
            if (val == null) return DBNull.Value;
            else return val;
        }


        /// <summary>
        /// Converte o objeto em DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataTable ConvertInDataTable<T>(List<T> values) where T : Table, new()
        {
            T obj = new T();
            obj.Db = database;
            PropertyInfo[] properties = typeof(T).GetProperties();
            DataTable tbrows = new DataTable(obj.GetType().Name);

            // cria as colunas
            for (int i = 0; i < properties.Length; i++)
            {
                if (eTipoPrimitivo(properties[i].PropertyType))
                {
                    tbrows.Columns.Add(properties[i].Name);
                }
            }
            // insere as linhas
            for(int r = 0; r < values.Count; r++)
            {
                var linha = values[r];
                DataRow row = tbrows.NewRow();
                // adiciona as colunas
                for (int c = 0; c < properties.Length; c++)
                {
                    if (eTipoPrimitivo(properties[c].PropertyType))
                    {
                        var pVal = properties[c].GetValue(linha, null);
                        row[properties[c].Name] = pVal;
                    }
                }
                tbrows.Rows.Add(row);                
            }
            return tbrows;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Tipo do objeto de retorno</typeparam>
        /// <param name="alias">apelido do conjunto de dados (select)</param>
        /// <param name="where">condição sql</param>
        /// <param name="parametros">lista de parâmetros</param>
        /// <param name="inner">junção usada para filtro (INNER JOIN, LEFT JOIN, RIGH JOIN) nota: não retorna dados da junção</param>
        /// <param name="groupBy">campos</param>
        /// <param name="orderBy">campos mais ASC OU DESC</param>
        /// <param name="distinct">apenas resgistros distintos (exclusivos)</param>
        /// <returns></returns>
        public List<T> Select<T>(string alias, string where, List<SqlParameter> parametros, string inner = null, string groupBy = null, string orderBy = null, bool distinct = false, int? top = null) where T : Table, new()
        {
            // cria uma nova lista
            List<T> result = new List<T>();
            T p = new T();
            p.Db = database;
            try
            {

                PropertyInfo[] properties = typeof(T).GetProperties();
                string sql = string.Format("SELECT {0} {1} ", distinct ? "DISTINCT" : "", top != null ? "TOP " + top.Value : "");

                for (int i = 0; i < properties.Length; i++)
                {
                    Attr[] atributos = (Attr[])properties[i].GetCustomAttributes(typeof(Attr), false);

                    // se não foi definido o atributo ou se foi e é um atributo da tabela
                    if (atributos.Length == 0 || ((Attr)atributos[0]).eUmAtributoDaTabela)
                    {
                        var tp = properties[i].PropertyType;
                        // se for um dicionário de fk
                        if (tp == typeof(Dictionary<string, int>) && p.ChaveEstrageira != null)
                        {
                            // pega as chaves estrangeiras do objeto
                            foreach (var dc in p.ChaveEstrageira)
                            {
                                sql += string.Format("{0}, ", dc.Key);
                            }
                        }
                        else if (eTipoPrimitivo(tp))
                        {
                            if (atributos.Length == 0 || !atributos[0].eSenha)
                            {
                                sql += string.Format("{0}, ", p.getPrefixo() + properties[i].Name);
                            }
                        }
                    }
                }
                sql += string.Format("GETDATE() AS TIMESTAMP FROM {0} ", p.getNomeDaTabela());
                if (alias != null) sql += string.Format(" {0} ", alias);
                if (inner != null) sql += inner;
                if (where != null) sql += string.Format(" WHERE {0} ", where);
                if (orderBy != null) sql += string.Format("ORDER BY {0}", orderBy);
                Cmd = new SqlCommand(sql);
                if (parametros != null)
                {
                    foreach (SqlParameter param in parametros)
                    {
                        Cmd.Parameters.Add(param);
                    }
                }
                Cmd.Connection = Conexao;
                using (Reader = Cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        result.Add(getCurrentRowInDataReader<T>());
                    }
                    Reader.Close();                   
                }

            }           
            catch (Exception ex)
            {
                throw ex;
            }            
            return result;
        }

        public T ScalarCustomer<T>(string queryScalar, string where, List<SqlParameter> parametros)
        {
            T result = (T)Activator.CreateInstance(typeof(T));
            if (where != null) queryScalar += string.Format(" WHERE {0} ", where);
            Cmd = new SqlCommand(queryScalar, Conexao);
            if (parametros != null)
            {
                foreach (SqlParameter param in parametros)
                {
                    Cmd.Parameters.Add(param);
                }
            }
            var obj = Cmd.ExecuteScalar();
            if(obj != null)
            {
                result = (T)obj;
            }
            return result;
        }

        /// <summary>
        /// Scalar: retorna o objeto com a propriedade preenchida com o valor do 
        /// priemeiro atributo da primera linha localizada do select
        /// </summary>
        /// <typeparam name="T">Typo do objeto</typeparam>
        /// <param name="property">Nome da propriedade que se deseja preencher</param>
        /// <param name="where">condição sql expressão(campo=valor)</param>
        /// <param name="parametros">lista de parâmentros sql</param>
        /// <returns></returns>
        public T Scalar<T>(string property, string where, List<SqlParameter> parametros) where T : Table, new()
        {
            T p = new T();
            p.Db = database;
            try
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                bool isDicionary = false;
                int idxPproperty = -1;

                string sql = "SELECT ";

                for (int i = 0; i < properties.Length; i++)
                {
                    var tp = properties[i].PropertyType;
                    // se for um dicionário de fk
                    if (tp == typeof(Dictionary<string, int>) && p.ChaveEstrageira != null)
                    {
                        // pega verifica se a propriedade e uma das chaves
                        foreach (var dc in p.ChaveEstrageira)
                        {
                            if (p.ChaveEstrageira.ContainsKey(property))
                            {
                                sql += string.Format("{0} ", dc.Key);
                                isDicionary = true;
                                break;
                            }
                        }
                    }// senão se encontrou a propriedade
                    else if (properties[i].Name.ToLower() == property.ToLower())
                    {
                        sql += string.Format("{0} ", p.getPrefixo() + properties[i].Name);
                        idxPproperty = i;
                    }
                }
                sql += string.Format("FROM {0} ", p.getNomeDaTabela());
                if (where != null) sql += string.Format(" WHERE {0} ", where);
                Cmd = new SqlCommand(sql, Conexao);
                if (parametros != null)
                {
                    foreach (SqlParameter param in parametros)
                    {
                        Cmd.Parameters.Add(param);
                    }
                }
                var obj = Cmd.ExecuteScalar();
                if (obj != null)
                {
                    // se a propriedade for um dicionário
                    if (isDicionary)
                    {
                        p.ChaveEstrageira[property] = (int)obj;
                    }
                    // senão se encontrou a propriedade
                    else if (idxPproperty > -1)
                    {
                        properties[idxPproperty].SetValue(p, Convert.ChangeType(obj, properties[idxPproperty].PropertyType), null);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }                       
            return p;
        }

        /// <summary>
        /// retorna o último id do registro inserido, método válido apenas para tabelas que
        /// contenham campo IDENTITY (auto incrementado)
        /// </summary>
        /// <param name="tbName">nome da tabela que se deseja obter</param>
        /// <returns></returns>
        public int LastInsertID(string tbName)
        {
            try
            {
                string sql = string.Format("SELECT IDENT_CURRENT('{0}')", tbName);
                Cmd = new SqlCommand(sql, Conexao);
                object v = Cmd.ExecuteScalar();
                int r;
                if (!int.TryParse(v.ToString(), out r)) r = 0;
                return r;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        /// <summary>
        /// Permite executar uma query customizada para tipo de objeto
        /// </summary>
        /// <typeparam name="T">O tipo do objeto</typeparam>
        /// <param name="query">a query com os atributos da classe</param>
        /// <param name="where"></param>
        /// <param name="parametros"></param>
        /// <param name="groupBy">campos</param>
        /// <param name="orderBy">campos + ASC OU DESC</param>
        /// <returns></returns>
        public List<T> SelectCustomer<T>(string query, string where, List<SqlParameter> parametros, string groupBy = null, string orderBy = null) where T :Table, new()
        {
            List<T> result = new List<T>();
            T p = new T();
            p.Db = database;
            try
            {
                string sql = query;
                if (where != null) sql += string.Format(" WHERE {0} ", where);
                if (groupBy != null) sql += string.Format(" GROUP BY {0}", groupBy);
                if (orderBy != null) sql += string.Format(" ORDER BY {0}", orderBy);
                Cmd = new SqlCommand(sql, Conexao);
                if (parametros != null)
                {
                    foreach (SqlParameter param in parametros)
                    {
                        Cmd.Parameters.Add(param);
                    }
                }
                using (Reader = Cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        result.Add(getCurrentCustomerRowInDataReader<T>());
                    }
                    Reader.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }           

            return result;
        }
      
        /// <summary>
        /// retorna um DataReader
        /// </summary>
        /// <param name="query"></param>
        /// <param name="where"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public SqlDataReader SelectReader(string query, string where, List<SqlParameter> parametros = null)
        {
            try
            {               
                string sql = query;
                if (where != null) sql += string.Format(" WHERE {0} ", where);
                Cmd = new SqlCommand(sql, Conexao);
                if (parametros != null)
                {
                    foreach (SqlParameter param in parametros)
                    {
                        Cmd.Parameters.Add(param);
                    }
                }
                return Cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SelectAdapter(DataTable tb, string query, string where, List<SqlParameter> parametros)
        {
            try
            {
                string sql = query;
                if (where != null) sql += string.Format(" WHERE {0} ", where);
                Cmd = new SqlCommand(sql, Conexao);
                if (parametros != null)
                {
                    foreach (SqlParameter param in parametros)
                    {
                        Cmd.Parameters.Add(param);
                    }
                }
                using (Adapter = new SqlDataAdapter(Cmd))
                {
                    Adapter.Fill(tb);    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object getDbValue<T>(T item, string propertyName=null)
        {
            object value = DBNull.Value;
            if (SYSinfo.EumTipoPrimitivo(typeof(T)))
            {
                if (item != null) value = item;
            }
            else if(propertyName != null) // demais tipos
            {
                PropertyInfo[] pinfos = typeof(T).GetProperties();
                var pinfo = pinfos.First(p => p.Name == propertyName);
                if (pinfo != null) value = pinfo.GetValue(item);
            }
            return value;
        } 

        /// <summary>
        /// Fecha a conexão e libera o dataReader
        /// </summary>
        public void FecharConexao()
        {
            try
            {
                if (this.Reader != null && !this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
                if (this._conn != null && _conn.State != ConnectionState.Closed)
                {                    
                    this._conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// destroi a referência do objeto
        /// </summary>
        //public void Dispose()
        //{
        //    FecharConexao();
        //    this = null;
        //}
    }
}
