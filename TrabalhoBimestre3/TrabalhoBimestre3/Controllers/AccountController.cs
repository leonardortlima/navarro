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
        int id = 1;
        Dictionary<int,Usuario> usuarios;

        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View(this.usuarios);
        }

        public ActionResult Adiciona(Usuario usuario)
        {
            if (this.usuarios == null)
            {
                this.usuarios = new Dictionary<int,Usuario>();
            }

            usuarios.Add(id,usuario);
            id++;

            return RedirectToAction("Index");
        }

        public ActionResult Modifica(int id, Usuario usuario)
        {
            this.usuarios.Add(id, usuario);
            return RedirectToAction("Index");
        }

        public ActionResult Apaga(int id)
        {
            this.usuarios.Remove(id);
            return RedirectToAction("Index");
        }

    }
}
