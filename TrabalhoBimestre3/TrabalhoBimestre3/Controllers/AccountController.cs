using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoBimestre3.Models;

namespace TrabalhoBimestre3.Controllers
{
    public class AccountController : Controller
    {
        private static UsuarioManager usuarioManager = new UsuarioManager();

        //
        // GET: /Account/
        [HttpGet]
        public ActionResult Index()
        {
            return View(usuarioManager.Usuarios);
        }

        // GET: /Account/AdicionaUsuario
        [HttpGet]
        public ActionResult AdicionaUsuario()
        {
            return View();
        }

        // POST: /Account/AdicionaUsuario
        [HttpPost]
        public ActionResult AdicionaUsuario(Usuario usuario)
        {
            usuarioManager.AdicionaUsuario(usuario);
            return View();
        }

        // GET: /Account/ModificaUsuario
        [HttpGet]
        public ActionResult ModificaUsuario(int id)
        {
            return View(usuarioManager.BuscaUsuario(id));
        }

        // POST: /Account/ModificaUsuario
        [HttpPost]
        public ActionResult ModificaUsuario(Usuario usuario)
        {
            usuarioManager.ModificaUsuario(usuario);
            return View(usuarioManager.BuscaUsuario(usuario.Id));
        }

        // GET: /Account/ApagaUsuario
        [HttpGet]
        public ActionResult ApagaUsuario(int id)
        {
            return View(usuarioManager.BuscaUsuario(id));
        }

        // POST: /Account/ApagaUsuario
        [HttpPost]
        public ActionResult ApagaUsuario(Usuario usuario)
        {
            usuarioManager.DeletaUsuario(usuario);
            return RedirectToAction("Index");
        }

    }
}
