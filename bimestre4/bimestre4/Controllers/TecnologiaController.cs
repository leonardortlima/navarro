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
    public class TecnologiaController : Controller
    {
        private Bimestre4Context db = new Bimestre4Context();

        //
        // GET: /Tecnologia/

        public ActionResult Index()
        {
            return View(db.Tecnologias.ToList());
        }

        //
        // GET: /Tecnologia/Details/5

        public ActionResult Details(int id = 0)
        {
            Tecnologia tecnologia = db.Tecnologias.Find(id);
            if (tecnologia == null)
            {
                return HttpNotFound();
            }
            return View(tecnologia);
        }

        //
        // GET: /Tecnologia/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tecnologia/Create

        [HttpPost]
        public ActionResult Create(Tecnologia tecnologia)
        {
            if (ModelState.IsValid)
            {
                db.Tecnologias.Add(tecnologia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tecnologia);
        }

        //
        // GET: /Tecnologia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tecnologia tecnologia = db.Tecnologias.Find(id);
            if (tecnologia == null)
            {
                return HttpNotFound();
            }
            return View(tecnologia);
        }

        //
        // POST: /Tecnologia/Edit/5

        [HttpPost]
        public ActionResult Edit(Tecnologia tecnologia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tecnologia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tecnologia);
        }

        //
        // GET: /Tecnologia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tecnologia tecnologia = db.Tecnologias.Find(id);
            if (tecnologia == null)
            {
                return HttpNotFound();
            }
            return View(tecnologia);
        }

        //
        // POST: /Tecnologia/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Tecnologia tecnologia = db.Tecnologias.Find(id);
            db.Tecnologias.Remove(tecnologia);
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