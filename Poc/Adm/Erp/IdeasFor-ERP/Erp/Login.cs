using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp
{
    public class Login
    {
        public int id { get; set; }
        public string Usuario { get; set; }
        public int Perfil_id { get; set; }

        string Tabela { get; set; }




        public static Login EfetuarLogin(string usuario, string senha)
        {
            string Tabela = "";
            string CampoId = "";
            string CampoLogin = "";
            string CampoSenha = "";
            string CampoAtivo = "";
            string CampoPerfil = "";
            string CampoNome = "";



            List<Erp.Configuracoes> confis = new Erp.Configuracoes().Lista();

            Login retorno = null;

            Erp.Configuracoes configura = confis.Find(x => x.chave == "tabelaLogin");
            if (configura != null)
            {
                Tabela = configura.valor;
            }

            configura = confis.Find(x => x.chave == "CampoUsuarioLogin");
            if (configura != null)
            {
                CampoLogin = configura.valor;
            }

            configura = confis.Find(x => x.chave == "CampoSenhaLogin");
            if (configura != null)
            {
                CampoSenha = configura.valor;
            }

            configura = confis.Find(x => x.chave == "CampoAtivoLogin");
            if (configura != null)
            {
                CampoAtivo = configura.valor;
            }

            configura = confis.Find(x => x.chave == "CampoPerfil");
            if (configura != null)
            {
                CampoPerfil = configura.valor;
            }

            configura = confis.Find(x => x.chave == "CampoNomeLogin");
            if (configura != null)
            {
                CampoNome = configura.valor;
            }


            configura = confis.Find(x => x.chave == "CampoIdLogin");
            if (configura != null)
            {
                CampoId = configura.valor;
            }

            string sql = "select * from " + Tabela + " where " + CampoLogin + "='" + usuario + "' and " + CampoSenha + "='" + senha + "' and " + CampoAtivo + "= 1";

            AutomatizaPaginas bc = new AutomatizaPaginas();
            DataTable dados = bc.ExecutaConsulta(sql);

            if (dados.Rows.Count > 0)
            {
                retorno = new Login();
                retorno.id = int.Parse(dados.Rows[0][CampoId].ToString());
                retorno.Usuario = dados.Rows[0][CampoNome].ToString();
                if (dados.Rows[0][CampoPerfil] != DBNull.Value)
                    retorno.Perfil_id = int.Parse(dados.Rows[0][CampoPerfil].ToString());
                else
                    retorno.Perfil_id = -1;
            }


            return retorno;
        }


    }
}
