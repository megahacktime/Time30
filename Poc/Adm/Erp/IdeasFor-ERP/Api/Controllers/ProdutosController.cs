using Api.Dao;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using static Api.Models.Api;

namespace Api.Controllers
{
    /// <summary>
    /// COntrole
    /// </summary>
    public class ProdutosController : ApiController
    {
        /// <summary>
        ///  Lista Produtos preferidos para usuário
        /// </summary>
        /// <param name="usuario_id">id do usuário</param>
        /// <param name="QtdProdutos">Tamanho máximo da lista de produtos</param>
        /// <returns></returns>
        [HttpGet]
        [Route("ListaProdutosParaUsuarios")]
        [ResponseType(typeof(ResponseMessage<List<ProdutoModel>>))]
        public HttpResponseMessage ListaProdutosParaUsuarios(int usuario_id, int QtdProdutos)
        {

            List<Erp.Configuracoes> confis = new Erp.Configuracoes().Lista();
            Erp.Configuracoes configura = confis.Find(x => x.chave == "QtdProdutosListar");
            if (configura != null)
            {
                int.TryParse(configura.valor, out QtdProdutos);
            }

            ResponseMessage<List<ProdutoModel>> response = new ResponseMessage<List<ProdutoModel>>()
            {
                Status = (int)HttpStatusCode.OK,
                Message = "Informe os dados para listar Login"
            };
            try
            {
                UsuarioModel user = new UsuarioModel() { Usuario_id = usuario_id };
                List<ProdutoModel> prod = new DaoProduto().ListaProdutosParaUsuarios(user, QtdProdutos);
                if (prod.Count > 0)
                {
                    response.Message = "Lista de Produtos preferidos";
                    response.Data = prod;
                    return Request.CreateResponse(HttpStatusCode.OK, response);

                }
                else
                {
                    response.Status = (int)HttpStatusCode.NotFound;
                    response.Message = "Dados Inválidos";
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, response));
                }


            }
            catch (Exception ex)
            {
                if (!(ex is HttpResponseException))
                {
                    response.Message = "Houve um erro interno no servidor.\nMais detalhes: " + ex.Message;
                    response.Status = (int)HttpStatusCode.InternalServerError;
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, response));
                }
                else
                {
                    throw ex;
                }
            }

        }


        /// <summary>
        ///  Retorna  Produto específico e grava log
        /// </summary>
        /// <param name="usuario_id"></param>
        /// <param name="Produto_id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProduto")]
        [ResponseType(typeof(ResponseMessage<ProdutoModel>))]
        public HttpResponseMessage GetProduto(int usuario_id, int Produto_id)
        {
            ResponseMessage<ProdutoModel> response = new ResponseMessage<ProdutoModel>()
            {
                Status = (int)HttpStatusCode.OK,
                Message = "Informe os dados para listar Login"
            };
            try
            {
                ProdutoModel prod = new DaoProduto().GetProduto(usuario_id, Produto_id);
                if (prod.Produto_id > 0)
                {
                    response.Message = "Sucesso ao retornar produto";
                    response.Data = prod;
                    return Request.CreateResponse(HttpStatusCode.OK, response);

                }
                else
                {
                    response.Status = (int)HttpStatusCode.NotFound;
                    response.Message = "Dados Inválidos";
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, response));
                }


            }
            catch (Exception ex)
            {
                if (!(ex is HttpResponseException))
                {
                    response.Message = "Houve um erro interno no servidor.\nMais detalhes: " + ex.Message;
                    response.Status = (int)HttpStatusCode.InternalServerError;
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, response));
                }
                else
                {
                    throw ex;
                }
            }

        }
        /// <summary>
        /// Retorna  conteúdo específico e grava log
        /// </summary>
        /// <param name="usuario_id"></param>
        /// <param name="Conteudo_id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetConteudo")]
        [ResponseType(typeof(ResponseMessage<Conteudo>))]
        public HttpResponseMessage GetConteudo(int usuario_id, int Conteudo_id)
        {
            ResponseMessage<Conteudo> response = new ResponseMessage<Conteudo>()
            {
                Status = (int)HttpStatusCode.OK,
                Message = "Informe os dados para listar Login"
            };
            try
            {
                Conteudo prod = new DaoProduto().GetConteudos(usuario_id, Conteudo_id);
                if (prod.Conteudo_id > 0)
                {
                    response.Message = "Sucesso ao retornar conteudo";
                    response.Data = prod;
                    return Request.CreateResponse(HttpStatusCode.OK, response);

                }
                else
                {
                    response.Status = (int)HttpStatusCode.NotFound;
                    response.Message = "Dados Inválidos";
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, response));
                }


            }
            catch (Exception ex)
            {
                if (!(ex is HttpResponseException))
                {
                    response.Message = "Houve um erro interno no servidor.\nMais detalhes: " + ex.Message;
                    response.Status = (int)HttpStatusCode.InternalServerError;
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, response));
                }
                else
                {
                    throw ex;
                }
            }

        }


    }
}
