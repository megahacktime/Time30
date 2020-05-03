using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ErpWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Sair()
        {
            Session["login"] = null;
            return RedirectToAction("Index");
        }




        /// <summary>
        /// POST: /home/login
        /// <paramref name="email"/>
        /// <paramref name="senha"/>
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string email, string senha)
        {
            Erp.Login login = Erp.Login.EfetuarLogin(email.Replace("'", ""), senha);
            Session["login"] = login;

            //Ark.Usuario usuario = new Ark.Usuario().Obter(email, senha);
            //if (usuario != null && usuario.Id > 0)
            //{
            //    Session[Ideas.Keys.USUARIO_LOGADO] = usuario;
            //}
            //else
            //{
            //    TempData[Ideas.Keys.AVISO] = Models.AvisoModel.Generico("FALHA NO LOGIN", new List<string>() { "Não foi possível validar o acesso com os dados informados" }, Ideas.Types.eTipoAviso.ALERT_WARNING);
            //}


            return RedirectToAction("Index");
        }

    }
}