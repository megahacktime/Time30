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
    public class DaoProduto
    {
        public List<ProdutoModel> ListaProdutosParaUsuarios(UsuarioModel usuario, int QtdProdutos)
        {
            Dbo conec = new Dbo();
            string sql = "";
            if (!usuario.Usuario_UsarIA)
            {
                sql = @"
                        select * from (
                        SELECT * FROM  TbProdutos where Produto_Ativo = 1 and produto_id = @produto_id1
                        union
                        SELECT * FROM  TbProdutos where Produto_Ativo = 1 and produto_id = @produto_id2
                        union
                        SELECT * FROM  TbProdutos where Produto_Ativo = 1 and produto_id = @produto_id3
                        union
                        SELECT * FROM TbProdutos where Produto_Ativo = 1 and produto_id not in (@produto_id1 , @produto_id2 , @produto_id3  )
                        ) a limit @QtdProdutos
                       ";
                sql = sql.Replace("@produto_id1", usuario.Usuario_Produto_id1.ToString());
                sql = sql.Replace("@produto_id2", usuario.Usuario_Produto_id2.ToString());
                sql = sql.Replace("@produto_id3", usuario.Usuario_Produto_id3.ToString());
                sql = sql.Replace("@QtdProdutos", QtdProdutos.ToString());
            }
            else
            {
                sql = @" 
                    select  * from (    select  * from (
                     SELECT pd.* FROM  TbProdutos pd
	                    inner join (
	                    select LogUso_Usuario_id,  LogUso_Produto_id    ,    count(0) QtdUsos FROM TbLogUso lg
	                    where lg.LogUso_Usuario_id = @Usuario_id group by LogUso_Usuario_id,  LogUso_Produto_id 
	                    ) a on LogUso_Produto_id = Produto_id    order by QtdUsos desc
                    ) Cb
                     union   
                    SELECT * FROM  TbProdutos pd where produto_ativo = 1
                    ) j limit  @QtdProdutos
                   ";

                sql = sql.Replace("@Usuario_id", usuario.Usuario_id.ToString());
                sql = sql.Replace("@QtdProdutos", QtdProdutos.ToString());


            }

            DataTable dados = conec.Select(sql);
            List<ProdutoModel> ListaProds = Util.DadosParaObjetoLista<ProdutoModel>(dados);


            List<Erp.Configuracoes> confis = new Erp.Configuracoes().Lista();

            string URLImagens = "";

            Erp.Configuracoes configura = confis.Find(x => x.chave == "URLRaizImagem");
            if (configura != null)
            {
                URLImagens = configura.valor;
            }

            foreach (ProdutoModel pd in ListaProds)
            {
                pd.Produto_Icone = URLImagens + pd.Produto_Icone;
                pd.conteudos = GetConteudosProduto(usuario.Usuario_id, pd.Produto_id);


            }


            return ListaProds;
        }

        public ProdutoModel GetProduto(int usuario_id, int Produto_id)
        {
            Dbo conec = new Dbo();
            string sql = "SELECT * FROM  TbProdutos where Produto_id = " + usuario_id.ToString();
            DataTable dados = conec.Select(sql);
            DaoUsuarios user = new DaoUsuarios();
            user.GravarLog(usuario_id.ToString(), Produto_id.ToString(), "", "");


            return Util.DadosParaObjeto<ProdutoModel>(dados);


        }

        public List<Conteudo> GetConteudosProduto(int usuario_id, int Produto_id)
        {
            Dbo conec = new Dbo();
            string sql = @"select * from TbConteudo c where   
            -- c.Conteudo_ativo = 1 and 
            c.Conteudo_Produto_id  = " + Produto_id.ToString();
            DataTable dados = conec.Select(sql);
            DaoUsuarios user = new DaoUsuarios();
            //user.GravarLog(usuario_id.ToString(), Produto_id.ToString(), "", "");


            return Util.DadosParaObjetoLista<Conteudo>(dados);


        }


        public Conteudo GetConteudos(int usuario_id, int Conteudo_id)
        {
            Dbo conec = new Dbo();
            string sql = "select * from TbConteudo c where c.Conteudo_ativo = 1 and  c.Conteudo_id  = " + Conteudo_id.ToString();
            DataTable dados = conec.Select(sql);
            DaoUsuarios user = new DaoUsuarios();
            user.GravarLog(usuario_id.ToString(), "", Conteudo_id.ToString(), "");


            return Util.DadosParaObjeto<Conteudo>(dados);
        }

    }
}