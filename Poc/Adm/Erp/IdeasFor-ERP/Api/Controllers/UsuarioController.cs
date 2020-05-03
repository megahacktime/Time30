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
    public class UsuarioController : ApiController
    {
        /// <summary>
        ///  Método de Login
        /// </summary>
        /// <param name="Usuario_Email">LOGIN</param>
        /// <param name="Usuario_Senha">SENHA</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Login")]
        [ResponseType(typeof(ResponseMessage<UsuarioModel>))]
        public HttpResponseMessage Login(string Usuario_Email, string Usuario_Senha, int QtdProdutosLista = 3)
        {
            ResponseMessage<UsuarioModel> response = new ResponseMessage<UsuarioModel>()
            {
                Status = (int)HttpStatusCode.OK,
                Message = "Informe os dados para efetuar Login"
            };
            try
            {
                UsuarioModel user = new DaoUsuarios().login(Usuario_Email, Usuario_Senha, QtdProdutosLista);
                if (user.Usuario_id > 0)
                {
                    response.Message = "Login encontrado";
                    response.Data = user;
                    return Request.CreateResponse(HttpStatusCode.OK, response);

                }
                else
                {
                    response.Status = (int)HttpStatusCode.NotFound;
                    response.Message = "Login Inválido";
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
        /// Grava Log de Navegação
        /// </summary>
        /// <param name="usuario_id"> Usuário que clicou</param>
        /// <param name="Produto_id"> Produto Clicado ou</param>
        /// <param name="Conteudo_id"> Conteúdo Clicado ou </param>
        /// <param name="categoria_id"> Categoria Clicada </param>
        /// <returns></returns>
        [Route("GravaLog")]
        [ResponseType(typeof(ResponseMessage<int>))]
        public HttpResponseMessage GravaLog(string usuario_id, string Produto_id, string Conteudo_id, string categoria_id)
        {
            ResponseMessage<int> response = new ResponseMessage<int>()
            {
                Status = (int)HttpStatusCode.OK,
                Message = "Informe os dados para gravar Log"
            };
            try
            {
                int retorno = new DaoUsuarios().GravarLog(usuario_id, Produto_id, Conteudo_id, categoria_id);
                if (retorno > -1)
                {
                    response.Message = "Log gravado com sucesso";
                    response.Data = retorno;
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    response.Status = (int)HttpStatusCode.InternalServerError;
                    response.Message = "Erro ao gravar log";
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
