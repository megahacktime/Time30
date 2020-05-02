using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ideas
{
    public sealed class Attr:Attribute
    {
        /// <summary>
        /// Atributo que define se a propriedade é ou não uma coluna da tabela na qual o objeto foi mapeado.
        /// </summary>
        public bool eUmAtributoDaTabela { get; set; } = true;

        /// <summary>
        /// Nome do atributo na base de dados
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Usado pra identificar a chave primária da tabela
        /// </summary>
        public bool eChavePrimaria { get; set; }

        public bool eToken { get; set; }

        public bool eMD5 { get; set; }

        public bool eSenha { get; set; }

        /// <summary>
        /// quando true não realiza update
        /// </summary>
        public bool eReadOnly { get; set; }

        public string ForeigKey { get; set; }

        public Attr()
        {
            eUmAtributoDaTabela = true;
        }
    }
}
