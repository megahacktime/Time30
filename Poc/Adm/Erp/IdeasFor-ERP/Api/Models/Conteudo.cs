using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Conteudo
    {
 
        public int Conteudo_id { get; set; }
        public int Conteudo_Produto_id { get; set; }
        public string Conteudo_Nome { get; set; }
        public string Conteudo_Descricao { get; set; }
        public string Conteudo_URL { get; set; }
        public string Conteudo_Resumo { get; set; }
        public string Conteudo_Conteudo { get; set; }
        public bool Conteudo_Principal { get; set; }
        public bool Conteudo_ativo { get; set; }
        public DateTime Conteudo_dataCadastro { get; set; }
        public DateTime Conteudo_dataFimExibicao { get; set; }
        public int? Conteudo_Estado_id { get; set; }
        public int? Conteudo_Cidade_id { get; set; }
        

    }
}