using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Ideas.Helper
{
    public class SqlHelper
    {
        #region "subclasses"
        public enum SqlHelperType { INSERT, UPDATE, SELECT, DELETE }
        public class SqlHelperTable
        {
            /// <summary>
            /// Nome da coluna que é chave primária, usada para gerar o número da linha no select
            /// </summary>
            public string PrimaryKey { get; set; }
            public string Name { get; set; }
            public string Alias { get; set; }
            public List<SqlHelperTableField> Fields { get; set; }
            public Dictionary<string, string> ComputerCols { get; set; } = null;
        }

        public class SqlHelperTableJoin
        {
            /// <summary>
            /// INNER JOIN | LEFT JOIN ... qualquer junção possível
            /// </summary>
            public string TypeJoin { get; set; }
            public SqlHelperTable Tb;
            public string LeftKey { get; set; }
            public string RigthKey { get; set; }

            public bool IsertColsInSelect { get; set; } = true;
        }

        public class SqlHelperTableField: Dao.MsSql.Dbo
        {
            public string Name { get; set; }
            public string PrefixAlias { get; set; }
            public string Alias { get; set; }

            /// <summary>
            /// lista de campos da tabela
            /// </summary>
            /// <param name="tb"></param>
            /// <param name="schema"></param>
            /// <returns></returns>
            public List<SqlHelperTableField> GetFields(SqlHelperTable tb, string schema = "Dbo")
            {
                List<SqlHelperTableField> fields = null;
                string q =$@"SELECT COLUMN_NAME
                    FROM INFORMATION_SCHEMA.COLUMNS
                    WHERE TABLE_NAME = '{tb.Name}' AND COLUMN_NAME <> '_deleted_' AND TABLE_SCHEMA = '{schema}'";

                using (Reader = SelectReader(q, null))
                {
                    if (Reader.HasRows)
                    {
                        fields = new List<SqlHelperTableField>();
                        while (Reader.Read())
                        {
                            SqlHelperTableField field = new SqlHelperTableField();
                            field.Name = Reader.GetString(0);
                            field.PrefixAlias = tb.Alias;
                            field.Alias = $"[{field.PrefixAlias}_{field.Name}]";
                            fields.Add(field);
                        }
                    }
                }                
                return fields;
            }
        }

        #endregion

        #region "atributos"
        private string sql;
        private string where;
        #endregion

        #region "propriedades"
        public SqlHelperTable Tb;

        public string GetSql { get { return sql; }  }
        #endregion

        private List<SqlHelperTableJoin> joins;

        public SqlHelper Join(SqlHelperTableJoin tableJoin)
        {
            joins = joins ?? new List<SqlHelperTableJoin>();
            joins.Add(tableJoin);
            return this;
        }

        public SqlHelper SqlCreate(SqlHelperType type)
        {
            StringBuilder qB = new StringBuilder();
            switch (type)
            {
                case SqlHelperType.SELECT:
                    qB.Append("SELECT DISTINCT ");
                    break;
            }
            string separador = " ";
            Tb.Fields = new SqlHelperTableField().GetFields(Tb);
            for(int idx = 0; idx < Tb.Fields.Count; idx++)
            {
                qB.Append($"{separador}{Tb.Alias}.{Tb.Fields[idx].Name} AS {Tb.Fields[idx].Alias}\n");
                separador = ",";
            }

            if (Tb.ComputerCols != null && Tb.ComputerCols.Count > 0)
            {
                foreach (var c in Tb.ComputerCols)
                {
                    qB.Append($"{separador}[{Tb.Alias}_{c.Key}] = {c.Value}\n");               
                }
            }

            // faz as junçoes
            if (joins != null)
            {
                foreach(var join in joins)
                {
                    if (join.IsertColsInSelect)
                    {
                        join.Tb.Fields = new SqlHelperTableField().GetFields(join.Tb);
                        for (int idx = 0; idx < join.Tb.Fields.Count; idx++)
                        {
                            qB.Append($"{separador}{join.Tb.Alias}.{join.Tb.Fields[idx].Name} AS {join.Tb.Fields[idx].Alias}\n");
                        }
                    }
                }
            }            
            qB.Append($" FROM {Tb.Name} AS {Tb.Alias}\n");
            separador = " ";
            if (joins != null && joins.Count > 0)
            {
                foreach(var join in joins)
                {
                    qB.Append($"{separador}{join.TypeJoin} {join.Tb.Name} AS {join.Tb.Alias} ON {join.LeftKey} = {join.RigthKey}\n");
                }
            }
            if (where != null) qB.Append(where);

            //if (Tb.PrimaryKey != null)
            //{
            //    // cria o identificador de linhas
            //    StringBuilder qB2 = new StringBuilder();
            //    qB2.Append($"SELECT sQuery.*\n");
            //    qB2.Append($", ROW_NUMBER() OVER(ORDER BY {Tb.Alias}_{Tb.PrimaryKey} ASC) AS [{Tb.Alias}_NUM_LINHA]\n");
            //    qB2.Append($"FROM ({qB.ToString()}) AS sQuery");
            //    sql = qB2.ToString();
            //}
            //else
            //{
            //    sql = qB.ToString();
            //}
            sql = qB.ToString();
            return this;
        }

        /// <summary>
        /// codição where
        /// </summary>
        /// <param name="pWhere">campo1 = valor1 AND campo2 <> valor2 ..etc</param>
        /// <returns></returns>
        public SqlHelper Where(string pWhere)
        {
            where = where ?? "WHERE ";
            where += $"{pWhere}\n";
            return this;
        } 
        
        /// <summary>
        /// Insert ou Updade dos dados na tabela equivalente no banco ativo.
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
       
    }
}
