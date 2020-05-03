using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ErpWeb.Models
{
    public class PaginacaoModel
    {
        public int PaginaAtual { get; protected set; }
        public int TotalRegistros { get; protected set; }
        public int RegistrosPorPagina { get; protected set; }
        public int TotalPaginas { get; protected set; }
        public int Inicio { get; protected set; }
        public int Final { get; protected set; }
        public string Link { get; protected set; }

        public PaginacaoModel(int paginaAtual, int totalRegistros, int registrosPorPagina, string link)
        {
            this.PaginaAtual = paginaAtual;
            this.TotalRegistros = totalRegistros;
            this.RegistrosPorPagina = registrosPorPagina;
            this.Link = link;

            SetTotalPaginas();
            SetInicioFimPagina();
        }

        #region Metodos Privados
        private void SetTotalPaginas()
        {
            int qtdePaginas;

            if ((this.TotalRegistros % this.RegistrosPorPagina) == 0)
                qtdePaginas = (this.TotalRegistros / this.RegistrosPorPagina);
            else
                qtdePaginas = (this.TotalRegistros / this.RegistrosPorPagina) + 1;

            this.TotalPaginas = qtdePaginas;
        }

        private void SetInicioFimPagina()
        {
            int i = 0;
            int af = 0;
            int f = 0;
            int ai = 0;

            if (this.PaginaAtual - 4 < 1)
            {
                i = 1;
                af = Math.Abs(this.PaginaAtual - 4) + 1;
            }
            else
                i = this.PaginaAtual - 4;

            if (this.PaginaAtual + 4 >= this.TotalPaginas)
            {
                f = this.TotalPaginas;
                ai = Math.Abs(this.TotalPaginas - this.PaginaAtual - 4);
            }
            else
                f = this.PaginaAtual + 4;

            if (af + f >= this.TotalPaginas)
                f = this.TotalPaginas;
            else
                f = f + af;

            this.Final = f;

            if (i - ai <= 0)
                i = 1;
            else
                i = i - ai;

            this.Inicio = i;
        }

        public bool PossuiAnterior
        {
            get
            {
                return (PaginaAtual > 1);
            }
        }

        public bool PossuiProxima
        {
            get
            {
                return (PaginaAtual < this.TotalPaginas);
            }
        }
        #endregion
    }
}