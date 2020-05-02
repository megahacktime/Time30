using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MySql.Data.MySqlClient;

namespace Ideas.Dao.MySQL
{
    /// <summary>
    /// Classe que define o mapeamento da tabela e o prefixo dos atributos
    /// </summary>
    [Serializable()]
    public class Table
    {
        private bool pkAutoIncremento;
        private string nomeTabela;
        private string prefixo;
        public Dbo Dbo { get; set; }

        public bool getPKautoIncremento() { return pkAutoIncremento; }
        public void setPKautoIncremento(bool flag) { pkAutoIncremento = flag; }
        public string getNomeDaTabela() { return nomeTabela; }
        public void setNomeDaTabela(string nt) { nomeTabela = nt; }
        public string getPrefixo() { return prefixo; }
        public void setPrefixo(string px) { prefixo = px; }
        
        /// <summary>
        /// dicionários de chaves estrageiras 
        /// </summary>
        public Dictionary<string, int> ChaveEstrageira { get; set; }

        public Table()
        {
            this.ChaveEstrageira = new Dictionary<string, int>();
        }

        protected Dbo getDbo()
        {
            if (Dbo == null) Dbo = new Dbo();
            return Dbo;
        }

        /// <summary>
        /// Metódo virtual que verifica se o valor de um atributo existe na base de dados
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="attribute">nome do atributo da tabela</param>
        /// <param name="val">valor da condição de comparação</param>
        /// <returns>TRUE|FALSE</returns>
        protected virtual bool Existe<T>(string attribute, string val)where T:Table, new() 
        {
            T t = getDbo().Scalar<T>("Id", string.Format("_deleted_ = 0 AND {0}=@pVal", attribute), new List<MySql.Data.MySqlClient.MySqlParameter>() { 
                new MySqlParameter(){ ParameterName = "@pVal", Value = val }
            });
            PropertyInfo pinto = typeof(T).GetProperty("Id");
            var pVal = pinto.GetValue(t, null);
            return pVal != null && ((int)pVal) > 0;
        }

        /// <summary>
        /// Metódo virtual que verifica se o valor de um atributo existe e não é o mesmo
        /// </summary>
        /// <param name="pk">Valor da chave primária</param>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="attribute">nome do atributo da tabela</param>
        /// <param name="val">valor da condição de comparação</param>
        /// <returns>True se o pk do objeto for diferente do pk informado</returns>
        
        protected virtual bool Existe<T>(int pk, string attribute, string val) where T : Table, new()
        {
            T t = getDbo().Scalar<T>("Id", string.Format("_deleted_ = 0 AND {0}=@pVal", attribute), new List<MySql.Data.MySqlClient.MySqlParameter>() { 
                new MySqlParameter(){ ParameterName = "@pVal", Value = val }
            });
            PropertyInfo pinto = typeof(T).GetProperty("Id");
            var pVal = pinto.GetValue(t, null);
            return pVal != null && ((int)pVal) > 0 && ((int)pVal) != pk;
        }

    }
}
