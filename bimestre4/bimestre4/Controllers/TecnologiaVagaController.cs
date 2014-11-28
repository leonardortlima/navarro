using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bimestre4.Models;
using bimestre4.DAL;

namespace bimestre4.Controllers
{
    public class TecnologiaVagaController : Controller
    {
        private Bimestre4Context db = new Bimestre4Context();

        //
        // GET: /TecnologiaVaga/

        public ActionResult Index()
        {
            var tecnologiavaga = db.TecnologiaVaga.Include(t => t.Tecnologia).Include(t => t.Vaga);
            return View(tecnologiavaga.ToList());
        }

        //
        // GET: /TecnologiaVaga/Details/5

        public ActionResult Details(int id = 0)
        {
            TecnologiaVaga tecnologiavaga = db.TecnologiaVaga.Find(id);
            if (tecnologiavaga == null)
            {
                return HttpNotFound();
            }
            return View(tecnologiavaga);
        }

        //
        // GET: /TecnologiaVaga/Create

        public ActionResult Create()
        {
            ViewBag.TecnologiaID = new SelectList(db.Tecnologias, "ID", "NomeTecnologia");
            ViewBag.VagaID = new SelectList(db.Vagas, "ID", "NomeVaga");
            return View();
        }

        //
        // POST: /TecnologiaVaga/Create

        [HttpPost]
        public ActionResult Create(TecnologiaVaga tecnologiavaga)
        {
            if (ModelState.IsValid)
            {
                db.TecnologiaVaga.Add(tecnologiavaga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TecnologiaID = new SelectList(db.Tecnologias, "ID", "NomeTecnologia", tecnologiavaga.TecnologiaID);
            ViewBag.VagaID = new SelectList(db.Vagas, "ID", "NomeVaga", tecnologiavaga.VagaID);
            return View(tecnologiavaga);
        }

        //
        // GET: /TecnologiaVaga/Edit/5

        public ActionResult Edit(int id = 0, int id2 = 0)
        {
            TecnologiaVaga tecnologiavaga = db.TecnologiaVaga.Find(id,id2);
            if (tecnologiavaga == null)
            {
                return HttpNotFound();
            }
            ViewBag.TecnologiaID = new SelectList(db.Tecnologias, "ID", "NomeTecnologia", tecnologiavaga.TecnologiaID);
            ViewBag.VagaID = new SelectList(db.Vagas, "ID", "NomeVaga", tecnologiavaga.VagaID);
            return View(tecnologiavaga);
        }

        //
        // POST: /TecnologiaVaga/Edit/5

        [HttpPost]
        public ActionResult Edit(TecnologiaVaga tecnologiavaga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tecnologiavaga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TecnologiaID = new SelectList(db.Tecnologias, "ID", "NomeTecnologia", tecnologiavaga.TecnologiaID);
            ViewBag.VagaID = new SelectList(db.Vagas, "ID", "NomeVaga", tecnologiavaga.VagaID);
            return View(tecnologiavaga);
        }

        //
        // GET: /TecnologiaVaga/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TecnologiaVaga tecnologiavaga = db.TecnologiaVaga.Find(id);
            if (tecnologiavaga == null)
            {
                return HttpNotFound();
            }
            return View(tecnologiavaga);
        }

        //
        // POST: /TecnologiaVaga/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TecnologiaVaga tecnologiavaga = db.TecnologiaVaga.Find(id);
            db.TecnologiaVaga.Remove(tecnologiavaga);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}