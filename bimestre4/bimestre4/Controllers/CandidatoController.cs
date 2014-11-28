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
    public class CandidatoController : Controller
    {
        private Bimestre4Context db = new Bimestre4Context();

        //
        // GET: /Candidato/

        public ActionResult Index()
        {
            return View(db.Candidatos.ToList());
        }

        //
        // GET: /Candidato/Details/5

        public ActionResult Details(int id = 0)
        {
            ViewModel<Candidato,CandidatoTecnologia,Tecnologia> viewModel = new ViewModel<Candidato,CandidatoTecnologia,Tecnologia>();
            viewModel.genericModel = db.getCandidato(id);
            if (viewModel.genericModel == null)
            {
                return HttpNotFound();
            }
            viewModel.List = db.getTecnologiasCandidato(id);
            viewModel.FullList = db.getAllTecnologias();
            return View(viewModel);
        }

        //
        // GET: /Candidato/Create

        public ActionResult Create()
        {
            ViewModel<Candidato, CandidatoTecnologia, Tecnologia> viewModel = new ViewModel<Candidato, CandidatoTecnologia, Tecnologia>();
            viewModel.FullList = db.Tecnologias.ToList();
            return View(viewModel);
        }

        //
        // POST: /Candidato/Create

        [HttpPost]
        public ActionResult Create(ViewModel<Candidato, CandidatoTecnologia, Tecnologia> viewModel, string[] tecnologiasSelecionadas)
        {
            if (ModelState.IsValid)
            {
                db.Candidatos.Add(viewModel.genericModel);

                foreach (var tecnologiaID in tecnologiasSelecionadas)
                {
                    CandidatoTecnologia ct = new CandidatoTecnologia();
                    ct.Candidato = viewModel.genericModel;
                    ct.CandidatoID = viewModel.genericModel.ID;
                    ct.TecnologiaID = Convert.ToInt32(tecnologiaID);
                    ct.Tecnologia = db.Tecnologias.Where(i => i.ID == ct.TecnologiaID).Single();
                    db.CandidatoTecnologia.Add(ct);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        //
        // GET: /Candidato/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ViewModel<Candidato, CandidatoTecnologia, Tecnologia> viewModel = new ViewModel<Candidato, CandidatoTecnologia, Tecnologia>();
            viewModel.genericModel = db.getCandidato(id);
            if (viewModel.genericModel == null)
            {
                return HttpNotFound();
            }
            viewModel.List = db.getTecnologiasCandidato(id);
            viewModel.FullList = db.getAllTecnologias();
            return View(viewModel);
        }

        //
        // POST: /Candidato/Edit/5

        [HttpPost]
        public ActionResult Edit(ViewModel<Candidato, CandidatoTecnologia, Tecnologia> viewModel, string[] tecnologiasSelecionadas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewModel.genericModel).State = EntityState.Modified;
                // Busca as tecnologias e os relacionamentos novamente
                viewModel.List = db.getTecnologiasCandidato(viewModel.genericModel.ID);
                viewModel.FullList = db.getAllTecnologias();
                // Novos
                foreach (var tecnologiaID in tecnologiasSelecionadas)
                {
                    // Procura IDS que nao existem na lista de relacionamentos
                    if (!viewModel.List.Any(x => x.TecnologiaID.ToString().Equals(tecnologiaID)))
                    {
                        CandidatoTecnologia ct = new CandidatoTecnologia();
                        ct.Candidato = viewModel.genericModel;
                        ct.CandidatoID = viewModel.genericModel.ID;
                        ct.TecnologiaID = Convert.ToInt32(tecnologiaID);
                        ct.Tecnologia = db.Tecnologias.Where(i => i.ID == ct.TecnologiaID).Single();
                        db.CandidatoTecnologia.Add(ct);
                    }
                }
                // Removidos
                foreach (var candidatoTecnologia in viewModel.List)
                {
                    if (!tecnologiasSelecionadas.Any(x => x.Equals(candidatoTecnologia.TecnologiaID.ToString())))
                    {
                        db.CandidatoTecnologia.Remove(candidatoTecnologia);
                    }

                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel.genericModel);
        }

        //
        // GET: /Candidato/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Candidato candidato = db.Candidatos.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            return View(candidato);
        }

        //
        // POST: /Candidato/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidato candidato = db.Candidatos.Find(id);
            db.Candidatos.Remove(candidato);
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