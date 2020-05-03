using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class UsuarioModel
    {
        public int Usuario_id { get; set; }
        public string Usuario_Nome { get; set; }
        public int Usuario_Produto_id1 { get; set; }
        public int Usuario_Produto_id2 { get; set; }
        public int Usuario_Produto_id3 { get; set; }
        public int Usuario_Perfil_Id { get; set; }
        public int Usuario_Cidade_id { get; set; }
        public string Usuario_Email { get; set; }
        public bool Usuario_UsarIA { get; set; }
        public string Usuario_cep { get; set; }
        public DateTime Usuario_DataDeNascimento { get; set; }
        public bool Usuario_ativo { get; set; }

        public List<ProdutoModel> ListaProdutos = new List<ProdutoModel>();

    }
}