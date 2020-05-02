using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MySql.Data.MySqlClient;
using System.Runtime.Serialization;

namespace Ideas.Dao.MsSql
{
    /// <summary>
    /// Classe que define o mapeamento da tabela e o prefixo dos atributos
    /// </summary>
    [DataContract]
    public class Table
    {
        private bool pkAutoIncremento;
        private string nomeTabela;
        private string prefixo;

        [Attr(eUmAtributoDaTabela = false)]
        public string Db { get; set; }

        [Attr(eUmAtributoDaTabela = false)]
        public Ideas.Dao.MsSql.Dbo Dbo { get; set; }

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

        /// <summary>
        /// Método que retorna o Dbo da instância
        /// </summary>
        protected Dbo getDbo()
        {
            if (Dbo == null) Dbo = new Ideas.Dao.MsSql.Dbo();
            return Dbo;
        }

        /// <summary>
        ///  preenche os objetos contido na lista que tenham o atibuto ForeignKey informado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db">Nome do bando de dados</param>
        /// <returns></returns>
        public static void DefineDependencias<T>(List<T> source, string db) where T : Table
        {
            for (int i = 0; i < source.Count; i++)
            {
                T obj = source[i];
                PropertyInfo[] pinfo = typeof(T).GetProperties();
                foreach (PropertyInfo p in pinfo)
                {

                    Attr[] att = (Attr[])p.GetCustomAttributes(typeof(Attr), false);
                    if (att != null && att.Length > 0)
                    {
                        if (att[0].ForeigKey != null)
                        {
                            setObjectValue<T>(obj, p, att[0].ForeigKey);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// preenche os objetos contido no objeto que tenham o atributo ForeignKey informado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="db">nome do banco de dados</param>
        public static void DefineDependencia<T>(T source) where T : Table
        {
            T obj = source;
            PropertyInfo[] pinfo = typeof(T).GetProperties();
            foreach (PropertyInfo p in pinfo)
            {
                Attr[] att = (Attr[])p.GetCustomAttributes(typeof(Attr), false);
                if (att != null && att.Length > 0)
                {
                    if (att[0].ForeigKey != null)
                    {
                        setObjectValue<T>(source, p, att[0].ForeigKey);
                    }
                }
            }
        }

        /// <summary>
        /// preenche o objeto.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="property"></param>
        /// <param name="foreikey"></param>
        private static void setObjectValue<T>(T obj, PropertyInfo property, string foreikey) where T : Table
        {
            PropertyInfo[] pinfo = property.PropertyType.GetProperties();
            var subObjeto = Activator.CreateInstance(property.PropertyType, obj.Db);
            foreach (var p in pinfo)
            {
                Attr[] attr = (Attr[])p.GetCustomAttributes(typeof(Attr), false);
                if (attr != null && attr.Length > 0)
                {
                    if (attr[0].eChavePrimaria)
                    {
                        object objnullable = Convert.ChangeType(obj.ChaveEstrageira[foreikey], Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType);
                        p.SetValue(subObjeto, objnullable, null);
                        MethodInfo metodo = subObjeto.GetType().GetMethod("Obter", new Type[] { typeof(int) });
                        subObjeto = metodo.Invoke(subObjeto, new[] { objnullable });
                        property.SetValue(obj, subObjeto, null);
                        break;
                    }
                }
            }
        }
                
    }       
}
