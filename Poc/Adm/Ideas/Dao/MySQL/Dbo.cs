using System;
using System.Collections.Generic;
using System.Reflection;
using MySql.Data.MySqlClient;
using System.Data;


namespace Ideas.Dao.MySQL
{
    /// <summary>
    /// Dbo - Database Object (classe responsável por manipular o banco de dados MySQL)
    /// </summary>
    public class Dbo
    {
        private static Dbo _mysql;
        private MySqlConnection _conn;
        public MySqlDataReader Reader { get; set; }
        public MySqlDataAdapter Adapter { get; set; }
        public MySqlCommand Cmd { get; set; }


        /// <summary>
        /// Cria uma nova conexação com o MysqlServer.
        /// Caso queira reutilizar guarde a conexão em um objeto
        /// </summary>
        public MySqlConnection GetConexao()
        {

            _conn = new MySqlConnection(IdeasConfig.Default.MySQL);
            MySqlConnection.ClearPool(_conn); // limpa o pool
            _conn.Open();
            return _conn;


            //get
            //{
            //    _conn = new MySqlConnection(IdeasConfig.Default.MySQL);
            //    MySqlConnection.ClearPool(_conn); // limpa o pool
            //    _conn.Open();
            //    return _conn;
            //}            
        }

        public DataTable ExecutarQuery(string SQL)
        {
            return Select(SQL);
        }

        /// <summary>
        /// Executa o select e retorna os dados em um datatable
        /// </summary>
        /// <param name="Selecao"></param>
        /// <returns></returns>
        public DataTable Select(string Selecao)
        {
            DataTable dados = new DataTable();
            MySqlConnection MsSQl = GetConexao();
            try
            {
                MySqlCommand CMD = new MySqlCommand(Selecao, MsSQl);
                MySqlDataAdapter Adapter = new MySqlDataAdapter(CMD);
                DataTable Retorno = new DataTable();
                //ds.view_Convenios.Clear();
                Adapter.Fill(Retorno);
                return Retorno;
            }
            catch (MySqlException ex)
            {
                return dados; //throw new Exception("Houve um erro no método Select " + ex.Message);
            }

        }

        public int ExecuteNoQuery(string query, bool fecharConexao = true)
        {
            try
            {
                int retorno = 0;


                try
                {

                    string Sql = query;
                    MySqlConnection MsSQl = GetConexao();

                    if (MsSQl.State != ConnectionState.Open)
                    {
                        MsSQl.Open();
                    }

                    MySqlCommand CMD = new MySqlCommand(Sql, MsSQl);

                    retorno = CMD.ExecuteNonQuery();
                    if (MsSQl.State != ConnectionState.Closed && fecharConexao)
                    {
                        MsSQl.Close();
                        MsSQl.Dispose();
                    }



                }

                catch (Exception Ex)
                {
                    throw new Exception("Houve um erro no método ExecuteNoQuery(string query,  params SqlParameter[]  parametro) da classe MsSqlServer \n" + Ex.Message);
                }


                return retorno;
            }
            catch (Exception Ex)
            {
                throw new Exception("Houve um erro no método ExecuteNoQuery(string query,  params SqlParameter[]  parametro) da classe MsSqlServer \n" + Ex.Message);
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
                                    if (v is string && v.Equals(el.ToString()) || v is int && (int)v == (int)el)
                                    {
                                        pinfo.SetValue(p, Convert.ChangeType(el, pinfo.PropertyType), null);
                                        break;
                                    }
                                }
                            }
                            else // demais
                            {
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
        /// Retorna o objeto preenchido com os valores de suas propriedades contidas no datareader
        /// </summary>
        /// <typeparam name="T">Classe que define o tipo do objeto</typeparam>
        /// <returns>Objeto T preenchido</returns>
        public T getCurrentCustomerRowInDataReader<T>() where T : new()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            // cria a nova instância
            T p = new T();
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
                                pinfo.SetValue(p, Convert.ChangeType(v, pinfo.PropertyType), null);
                            }
                            break;
                        }
                    }
                }
            }
            return p;
        }

        private bool eUmTipoPrimitivo(Type tp)
        {
            bool r = false;
            r = tp == typeof(string);
            r = r || tp == typeof(int);
            r = r || tp == typeof(decimal);
            r = r || tp == typeof(double);
            r = r || tp == typeof(bool);
            r = r || tp == typeof(char);
            r = r || tp == typeof(long);
            r = r || tp == typeof(DateTime);
            r = r || tp == typeof(Nullable<DateTime>);
            r = r || tp.IsEnum;
            return r;
        }

        /// <summary>
        /// Insere os dados do objeto na base de dados
        /// </summary>
        /// <typeparam name="T">Classe de tipo</typeparam>
        /// <param name="value">Objeto com os valores</param>
        /// <returns>0 ou o número de linhas inseridas</returns>
        public int Insert<T>(T value) where T : Table, new()
        {
            int retorno = -1;
            MySqlConnection conn = null;

            try
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                string sql = string.Format("INSERT INTO {0} (", value.getNomeDaTabela());
                string v = "VALUES(";
                List<MySqlParameter> pts = new List<MySqlParameter>();

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
                                    pts.Add(new MySqlParameter() { ParameterName = dc.Key, Value = dc.Value });
                                }
                            }
                        }

                        // senão se for um dos tipos primitivos
                        else if (eUmTipoPrimitivo(tp))
                        {
                            // se for a propriedade Token
                            if (atributos.Length > 0 && atributos[0].eToken)
                            {
                                sql += string.Format("{0}, ", value.getPrefixo() + properties[i].Name);
                                v += string.Format("{0}, ", "MD5(CONCAT(CURDATE() +0, CURTIME(4)+0,RAND()))");
                            }
                            else if (atributos.Length > 0 && atributos[0].eMD5)
                            {
                                sql += string.Format("{0}, ", value.getPrefixo() + properties[i].Name);
                                v += string.Format(@"MD5('{0}'), ", @properties[i].GetValue(value, null));
                            }
                            // senão, se for o atributo chave primaria e não é auto incrementado
                            else if (atributos.Length == 0 || (atributos[0].eUmAtributoDaTabela && !value.getPKautoIncremento()))
                            {
                                sql += string.Format("{0},  ", value.getPrefixo() + properties[i].Name);
                                v += string.Format("@{0}, ", properties[i].Name);
                                pts.Add(new MySqlParameter() { ParameterName = string.Format("@{0}", properties[i].Name), Value = getValueOrDbNull(@properties[i].GetValue(value, null)) });
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

                conn = GetConexao();
                Cmd = new MySqlCommand(sql, conn);
                foreach (MySqlParameter p in pts)
                {
                    Cmd.Parameters.Add(p);
                }
                retorno = Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                FecharConexao(conn);
            }

            return retorno;
        }

        /// <summary>
        /// Insere os dados do objeto na base de dados
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="value">Os valores</param>
        /// <param name="autoincremento">escreve o id gerado para o registro</param>
        /// <returns></returns>
        public int Insert<T>(T value, out int autoincremento) where T : Table, new()
        {
            int retorno = -1;
            autoincremento = 0;
            MySqlConnection conn = null;

            try
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                string sql = string.Format("INSERT INTO {0} (", value.getNomeDaTabela());
                string v = "VALUES(";
                List<MySqlParameter> pts = new List<MySqlParameter>();

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
                                    pts.Add(new MySqlParameter() { ParameterName = dc.Key, Value = dc.Value });
                                }
                            }
                        }

                        // senão se for um dos tipos primitivos
                        else if (eUmTipoPrimitivo(tp))
                        {
                            // se for a propriedade Token
                            if (atributos.Length > 0 && atributos[0].eToken)
                            {
                                sql += string.Format("{0}, ", value.getPrefixo() + properties[i].Name);
                                v += string.Format("{0}, ", "MD5(CONCAT(CURDATE() +0, CURTIME(4)+0,RAND()))");
                            }
                            else if (atributos.Length > 0 && atributos[0].eMD5)
                            {
                                sql += string.Format("{0}, ", value.getPrefixo() + properties[i].Name);
                                v += string.Format(@"MD5('{0}'), ", @properties[i].GetValue(value, null));
                            }
                            // senão, se for o atributo chave primaria e não é auto incrementado
                            else if (atributos.Length == 0 || (atributos[0].eUmAtributoDaTabela && !value.getPKautoIncremento()))
                            {
                                sql += string.Format("{0},  ", value.getPrefixo() + properties[i].Name);
                                v += string.Format("@{0}, ", properties[i].Name);
                                pts.Add(new MySqlParameter() { ParameterName = string.Format("@{0}", properties[i].Name), Value = getValueOrDbNull(@properties[i].GetValue(value, null)) });
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

                conn = GetConexao();
                Cmd = new MySqlCommand(sql, conn);
                foreach (MySqlParameter p in pts)
                {
                    Cmd.Parameters.Add(p);
                }
                retorno = Cmd.ExecuteNonQuery();
                // comando executado
                if (retorno > 0)
                {
                    // pega o auto incremento
                    autoincremento = LastInsertID(conn);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                FecharConexao(conn);
            }

            return retorno;
        }


        /// <summary>
        /// Atualiza a base de dados com os dados contidos no objeto.
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="query">A query especifica de update</param>
        /// <param name="value">Objeto com preenchido</param>
        /// <param name="where">COndição sql</param>
        /// <param name="whereParametros">parâmetros da condição</param>
        /// <returns></returns>
        public int Update<T>(T value, string query, string where, List<MySqlParameter> whereParametros) where T : Table, new()
        {
            MySqlConnection conn = null;
            try
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                string sql = string.Format("UPDATE {0} SET ", value.getNomeDaTabela());
                List<MySqlParameter> pts = new List<MySqlParameter>();

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
                                    // se for -1 (atribuir null
                                    if (dc.Value == -1)
                                    {
                                        sql += string.Format("{0}=@{1}, ", dc.Key, dc.Key);
                                        pts.Add(new MySqlParameter() { ParameterName = string.Format("@{0}", dc.Key), Value = DBNull.Value });
                                    }
                                    else if (dc.Value > 0)
                                    {
                                        sql += string.Format("{0}=@{1}, ", dc.Key, dc.Key);
                                        pts.Add(new MySqlParameter() { ParameterName = string.Format("@{0}", dc.Key), Value = dc.Value });
                                    }
                                }
                            } // senão, se não foi definido atributos ou se foi e um atributo da tabela e é um dos tipos primitivos
                            else if (eUmTipoPrimitivo(tp) && (atributos.Length == 0 || atributos[0].eUmAtributoDaTabela))
                            {
                                var pVal = properties[i].GetValue(value, null);
                                // se não tem atributo definido
                                if (atributos.Length == 0)
                                {
                                    sql += string.Format("{0}=@{1},  ", value.getPrefixo() + properties[i].Name, properties[i].Name);
                                    pts.Add(new MySqlParameter() { ParameterName = string.Format("@{0}", properties[i].Name), Value = getValueOrDbNull(pVal) });
                                }
                                // se o atributo é um MD5 e foi definido o valor pra criptografar
                                else if (atributos[0].eMD5 && pVal != null)
                                {
                                    sql += string.Format("{0}=MD5('{1}'),  ", value.getPrefixo() + properties[i].Name, pVal);
                                }// senão, se é um atributo token e o valor é null
                                else if (atributos[0].eToken && pVal == null)
                                {
                                    sql += string.Format("{0}=MD5(CONCAT(CURDATE() +0, CURTIME(4)+0,RAND()))", value.getPrefixo() + properties[i].Name);
                                }// senão, se não é a chave primária e não é readonly
                                else if (!atributos[0].eChavePrimaria && !atributos[0].eReadOnly)
                                {
                                    sql += string.Format("{0}=@{1},  ", value.getPrefixo() + properties[i].Name, properties[i].Name);
                                    pts.Add(new MySqlParameter() { ParameterName = string.Format("@{0}", properties[i].Name), Value = getValueOrDbNull(pVal) });
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

                if (where != null)
                {
                    sql += string.Format(" WHERE {0}", where);
                }
                else // update sem where (não permitido)
                {
                    throw new Exception("Udate sem condição (where) não é permitdo");
                }

                conn = GetConexao();
                Cmd = new MySqlCommand(sql, conn);

                // adiciona os parâmentros internos
                foreach (MySqlParameter p in pts)
                {
                    Cmd.Parameters.Add(p);
                }
                // adiciona os parâmetros externos
                if (whereParametros != null)
                {
                    foreach (MySqlParameter p2 in whereParametros)
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
            finally
            {
                FecharConexao(conn);
            }
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
            MySqlConnection conn = null;
            try
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                string sql = string.Format("UPDATE {0} SET _deleted_ = 1 ", value.getNomeDaTabela());
                // so permite excluir se houver propriedades preenchidas
                // no mínimo uma 
                bool temCondicao = false;
                List<MySqlParameter> pts = new List<MySqlParameter>();
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
                                    pts.Add(new MySqlParameter() { ParameterName = string.Format("@{0}", dc.Key), Value = dc.Value });
                                    temCondicao = true;
                                }
                            }
                        }
                        // senão se for um dos tipos primitivos
                        else if (eUmTipoPrimitivo(tp))
                        {
                            //se for a chave primaria da tabela
                            if (atributos.Length > 0 && atributos[0].eChavePrimaria)
                            {
                                var val = properties[i].GetValue(value, null);
                                // se não for null e não for 0, "", empty e false
                                if (val != null && (!val.Equals(0) && !val.Equals("") && !val.Equals(string.Empty) && !val.Equals(false) && !val.Equals(DateTime.MinValue)))
                                {
                                    sql += string.Format("AND {0}=@{1}  ", value.getPrefixo() + properties[i].Name, properties[i].Name);
                                    pts.Add(new MySqlParameter() { ParameterName = string.Format("@{0}", properties[i].Name), Value = getValueOrDbNull(@properties[i].GetValue(value, null)) });
                                    temCondicao = true;
                                }
                            }
                        }
                    }
                }
                conn = GetConexao();
                Cmd = new MySqlCommand(sql, conn);

                // adiciona os parâmentros internos
                foreach (MySqlParameter p in pts)
                {
                    Cmd.Parameters.Add(p);
                }
                if (temCondicao) return Cmd.ExecuteNonQuery(); else return 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                FecharConexao(conn);
            }
        }

        public object getValueOrDbNull(object val)
        {
            if (val == null) return DBNull.Value;
            else return val;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Tipo do objeto de retorno</typeparam>
        /// <param name="alias">apelido com conjunto de dados (select)</param>
        /// <param name="where">condição sql sem a palavra WHERE</param>
        /// <param name="parametros">lista de parâmetros</param>
        /// <param name="inner">junção usada para filtro (INNER JOIN, LEFT JOIN, RIGH JOIN) nota: não retorna dados da junção</param>
        /// <param name="orderBy">campos e ordenação sem a palavra ORDER BY</param>
        /// <param name="distinct">true/false</param>
        /// <param name="limit">limita de registros a serem retornados, exemplo: 1, 5 retorna as 5 linhas(2, 3, 4, 5, 6)</param>
        /// <returns></returns>
        public List<T> Select<T>(string alias, string where, List<MySqlParameter> parametros, string inner = null, string orderBy = null, bool distinct = false, string limit = null) where T : Table, new()
        {
            List<T> result = new List<T>();
            T p = new T();
            MySqlConnection conn = null;

            try
            {

                PropertyInfo[] properties = typeof(T).GetProperties();

                string sql = "SELECT ";
                if (distinct) sql += "DISTINCT ";

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
                        else if (eUmTipoPrimitivo(tp))
                        {
                            sql += string.Format("{0}, ", p.getPrefixo() + properties[i].Name);
                        }
                    }
                }
                sql += string.Format("CURRENT_TIMESTAMP() AS TIMESTAMP FROM {0} ", p.getNomeDaTabela());
                if (alias != null) sql += string.Format(" {0} ", alias);
                if (inner != null) sql += inner;
                if (where != null) sql += string.Format(" WHERE {0} ", where);
                if (orderBy != null) sql += string.Format(" ORDER BY {0} ", orderBy);
                if (limit != null) sql += string.Format(" LIMIT {0}", limit);

                conn = GetConexao();
                Cmd = new MySqlCommand(sql, conn);
                if (parametros != null)
                {
                    foreach (MySqlParameter param in parametros)
                    {
                        Cmd.Parameters.Add(param);
                    }
                }
                using (Reader = Cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        result.Add(getCurrentRowInDataReader<T>());
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                FecharConexao(conn);
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
        public T Scalar<T>(string property, string where, List<MySqlParameter> parametros) where T : Table, new()
        {
            T p = new T();
            MySqlConnection conn = null;
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

                conn = GetConexao();
                Cmd = new MySqlCommand(sql, conn);
                if (parametros != null)
                {
                    foreach (MySqlParameter param in parametros)
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
            finally
            {
                FecharConexao(conn);
            }
            return p;
        }

        public int LastInsertID(MySqlConnection conexaoAtiva)
        {
            try
            {
                string sql = "SELECT LAST_INSERT_ID()";
                Cmd = new MySqlCommand(sql, conexaoAtiva);
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

        public List<T> SelectCustomer<T>(string query, string where, List<MySqlParameter> parametros, string orderBy = null) where T : new()
        {
            List<T> result = new List<T>();
            T p = new T();
            MySqlConnection conn = null;
            try
            {
                string sql = query;
                if (where != null) sql += string.Format(" WHERE {0} ", where);
                if (orderBy != null) sql += orderBy;

                conn = GetConexao();
                Cmd = new MySqlCommand(sql, conn);
                if (parametros != null)
                {
                    foreach (MySqlParameter param in parametros)
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
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                FecharConexao(conn);
            }

            return result;
        }

        /// <summary>
        /// Fecha a conexão e libera o dataReader
        /// </summary>
        public void FecharConexao(MySqlConnection conexaoAtiva)
        {
            try
            {
                if (conexaoAtiva != null)
                {
                    if (this.Reader != null && !this.Reader.IsClosed)
                    {
                        this.Reader.Close();
                    }
                    if (conexaoAtiva != null && conexaoAtiva.State != ConnectionState.Closed)
                    {
                        conexaoAtiva.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
