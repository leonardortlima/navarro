using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoBimestre3.Models;

namespace TrabalhoBimestre3.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Usuario usuario)
        {
            if (usuario.Senha != usuario.ConfirmaSenha)
            {
                ModelState.AddModelError("", "As senhas digitadas não são iguais");
            }
            return RedirectToAction("Adiciona", "Account", usuario);
        }

    }
}
