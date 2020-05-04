using Api.Models;
using Ideas;
using Ideas.Dao.MySQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Api.Dao
{
    public class DaoUsuarios
    {
        public UsuarioModel login(string usuario, string Senha,int ProdutosLista = 7)
        {
            Dbo conec = new Dbo();
            string sql = "select * from TbUsuarios where Usuario_Email='" + usuario + "' and Usuario_Senha='" + Senha + "' and Usuario_ativo=1";
            DataTable dados = conec.Select(sql);
            UsuarioModel user = Util.DadosParaObjeto<UsuarioModel>(dados);

            if(user.Usuario_id > 0)
            {
                user.ListaProdutos = new DaoProduto().ListaProdutosParaUsuarios(user, ProdutosLista);
            }


            return user;

        }


        public int GravarLog(string usuario_id, string Produto_id, string Conteudo_id, string categoria_id)
        {

            Dbo conec = new Dbo();
            MySqlDaoIdeas bc = new MySqlDaoIdeas();
            LogUso log = new LogUso();
            log.LogUso_Usuario_id = int.Parse(usuario_id); 

            if (!string.IsNullOrEmpty(categoria_id))
             log.LogUso_Categoria_id = int.Parse(categoria_id);

            if (!string.IsNullOrEmpty(Produto_id))
                log.LogUso_Produto_id = int.Parse(Produto_id);

            if (!string.IsNullOrEmpty(Conteudo_id))
                log.LogUso_Conteudo_id = int.Parse(Conteudo_id);

            return bc.Salvar(log, "LogUso_id", "Tb", true);


        }

    }
}