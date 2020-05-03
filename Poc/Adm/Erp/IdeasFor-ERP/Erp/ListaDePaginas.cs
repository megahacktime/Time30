using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp
{
    public class ListaDePaginas
    {
        public string Titulo { get; set; }
        public string Formulario { get; set; }
        public DataTable Dados { get; set; }
        public DataTable DadosColunas { get; set; }
        public DataTable DadosApresentacao { get; set; }
        public string CampoChave  { get; set; }

        public string CampoPesquisa { get; set; }
        public string ValorBusca { get; set; }

        public string TabelaBanco   { get; set; }
        public int QtDRegistrosOriginal = 0;

        public ListaDePaginas()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
