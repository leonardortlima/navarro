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
    public class CandidatoTecnologiaController : Controller
    {
        private Bimestre4Context db = new Bimestre4Context();

        //
        // GET: /CandidatoTecnologia/

        public ActionResult Index()
        {
            var candidatotecnologia = db.CandidatoTecnologia.Include(c => c.Tecnologia).Include(c => c.Candidato);
            return View(candidatotecnologia.ToList());
        }

        //
        // GET: /CandidatoTecnologia/Details/5

        public ActionResult Details(int id = 0)
        {
            CandidatoTecnologia candidatotecnologia = db.CandidatoTecnologia.Find(id);
            if (candidatotecnologia == null)
            {
                return HttpNotFound();
            }
            return View(candidatotecnologia);
        }

        //
        // GET: /CandidatoTecnologia/Create

        public ActionResult Create()
        {
            ViewBag.TecnologiaID = new SelectList(db.Tecnologias, "ID", "NomeTecnologia");
            ViewBag.CandidatoID = new SelectList(db.Candidatos, "ID", "NomeCandidato");
            return View();
        }

        //
        // POST: /CandidatoTecnologia/Create

        [HttpPost]
        public ActionResult Create(CandidatoTecnologia candidatotecnologia)
        {
            if (ModelState.IsValid)
            {
                db.CandidatoTecnologia.Add(candidatotecnologia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TecnologiaID = new SelectList(db.Tecnologias, "ID", "NomeTecnologia", candidatotecnologia.TecnologiaID);
            ViewBag.CandidatoID = new SelectList(db.Candidatos, "ID", "NomeCandidato", candidatotecnologia.CandidatoID);
            return View(candidatotecnologia);
        }

        //
        // GET: /CandidatoTecnologia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CandidatoTecnologia candidatotecnologia = db.CandidatoTecnologia.Find(id);
            if (candidatotecnologia == null)
            {
                return HttpNotFound();
            }
            ViewBag.TecnologiaID = new SelectList(db.Tecnologias, "ID", "NomeTecnologia", candidatotecnologia.TecnologiaID);
            ViewBag.CandidatoID = new SelectList(db.Candidatos, "ID", "NomeCandidato", candidatotecnologia.CandidatoID);
            return View(candidatotecnologia);
        }

        //
        // POST: /CandidatoTecnologia/Edit/5

        [HttpPost]
        public ActionResult Edit(CandidatoTecnologia candidatotecnologia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidatotecnologia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TecnologiaID = new SelectList(db.Tecnologias, "ID", "NomeTecnologia", candidatotecnologia.TecnologiaID);
            ViewBag.CandidatoID = new SelectList(db.Candidatos, "ID", "NomeCandidato", candidatotecnologia.CandidatoID);
            return View(candidatotecnologia);
        }

        //
        // GET: /CandidatoTecnologia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CandidatoTecnologia candidatotecnologia = db.CandidatoTecnologia.Find(id);
            if (candidatotecnologia == null)
            {
                return HttpNotFound();
            }
            return View(candidatotecnologia);
        }

        //
        // POST: /CandidatoTecnologia/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CandidatoTecnologia candidatotecnologia = db.CandidatoTecnologia.Find(id);
            db.CandidatoTecnologia.Remove(candidatotecnologia);
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