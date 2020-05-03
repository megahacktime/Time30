using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class ProdutoModel
    {
 
        public int Produto_id { get; set; }
        public string Produto_Nome { get; set; }
        public int Produto_Categoria_id { get; set; }
        public string Produto_Icone { get; set; }
        public DateTime Produto_Data { get; set; }
        public bool Produto_Ativo { get; set; }
        public bool Produto_mostrarIcone { get; set; }
        public string Produto_Descricao { get; set; }
        public string Produto_Abreviacao { get; set; }
        public bool Produto_gratuito { get; set; }

        public List<Conteudo> conteudos = new List<Conteudo>();

    }
}