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
    public class VagaController : Controller
    {
        private Bimestre4Context db = new Bimestre4Context();

        //
        // GET: /Vaga/

        public ActionResult Index()
        {
            return View(db.Vagas.ToList());
        }

        //
        // GET: /Vaga/Details/5

        public ActionResult Details(int id = 0)
        {
            ViewModel<Vaga, TecnologiaVaga, Tecnologia> viewModel = new ViewModel<Vaga, TecnologiaVaga, Tecnologia>();
            viewModel.genericModel = db.Vagas.Find(id);
            if (viewModel.genericModel == null)
            {
                return HttpNotFound();
            }
            viewModel.List = db.TecnologiaVaga.Where(o => o.VagaID == viewModel.genericModel.ID).ToList();
            viewModel.FullList = db.Tecnologias.ToList();
            return View(viewModel);
        }

        //
        // GET: /Vaga/Create

        public ActionResult Create()
        {
            ViewModel<Vaga, TecnologiaVaga, Tecnologia> viewModel = new ViewModel<Vaga, TecnologiaVaga, Tecnologia>();
            viewModel.FullList = db.Tecnologias.ToList();
            return View(viewModel);
        }

        //
        // POST: /Vaga/Create

        [HttpPost]
        public ActionResult Create(ViewModel<Vaga, TecnologiaVaga, Tecnologia> viewModel, string[] tecnologiasSelecionadas, string[] pesos)
        {
            if (ModelState.IsValid)
            {
                var pesoTecnologia = pesos.ToList();
                pesoTecnologia.RemoveAll(item => item == "0");
                db.Entry(viewModel.genericModel).State = EntityState.Modified;
                // Busca as tecnologias e os relacionamentos novamente
                viewModel.List = db.TecnologiaVaga.Where(o => o.VagaID == viewModel.genericModel.ID).ToList();
                viewModel.FullList = db.Tecnologias.ToList();
                // Novos
                int i;

                for (i = 0; i < tecnologiasSelecionadas.Length; i++)
                {
                    TecnologiaVaga tv = new TecnologiaVaga();
                        tv.Vaga = viewModel.genericModel;
                        tv.VagaID = viewModel.genericModel.ID;
                        tv.TecnologiaID = Convert.ToInt32(tecnologiasSelecionadas[i]);
                        tv.Tecnologia = db.Tecnologias.Where(a => a.ID == tv.TecnologiaID).Single();
                        tv.Peso = Convert.ToInt32(pesoTecnologia[i]);
                        db.TecnologiaVaga.Add(tv);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel.genericModel);
        }

        //
        // GET: /Vaga/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ViewModel<Vaga, TecnologiaVaga, Tecnologia> viewModel = new ViewModel<Vaga, TecnologiaVaga, Tecnologia>();
            viewModel.genericModel = db.Vagas.Find(id);
            if (viewModel.genericModel == null)
            {
                return HttpNotFound();
            }
            viewModel.List = db.TecnologiaVaga.Where(o => o.VagaID == viewModel.genericModel.ID).ToList();
            viewModel.FullList = db.Tecnologias.ToList();
            return View(viewModel);
        }

        //
        // POST: /Vaga/Edit/5

        [HttpPost]
        public ActionResult Edit(ViewModel<Vaga, TecnologiaVaga, Tecnologia> viewModel, string[] tecnologiasSelecionadas, string[] pesos)
        {
            if (ModelState.IsValid)
            {
                var pesoTecnologia = pesos.ToList();
                pesoTecnologia.RemoveAll(item => item == "0");
                db.Entry(viewModel.genericModel).State = EntityState.Modified;
                // Busca as tecnologias e os relacionamentos novamente
                viewModel.List = db.TecnologiaVaga.Where(o => o.VagaID == viewModel.genericModel.ID).ToList();
                viewModel.FullList = db.Tecnologias.ToList();
                // Novos
                int i;

                for(i = 0; i < tecnologiasSelecionadas.Length; i++)
                {
                    TecnologiaVaga tv = null;
                    try
                    {
                        tv = viewModel.List.Single(x => x.TecnologiaID.ToString().Equals(tecnologiasSelecionadas[i]));
                    } catch(Exception e)
                    {
                    }
                    // se nao existe, cria um relacionamento novo
                    if (tv == null)
                    {
                        tv = new TecnologiaVaga();
                        tv.Vaga = viewModel.genericModel;
                        tv.VagaID = viewModel.genericModel.ID;
                        tv.TecnologiaID = Convert.ToInt32(tecnologiasSelecionadas[i]);
                        tv.Tecnologia = db.Tecnologias.Where(a => a.ID == tv.TecnologiaID).Single();
                        tv.Peso = Convert.ToInt32(pesoTecnologia[i]);
                        db.TecnologiaVaga.Add(tv);
                    }
                    else
                    {
                        // se existe, atualiza
                        tv.Peso = Convert.ToInt32(pesoTecnologia[i]);
                        db.Entry(tv).State = EntityState.Modified;
                    }
                }


                // Removidos ou atualizados
                foreach (var tecnologiaVaga in viewModel.List)
                {
                    if (!tecnologiasSelecionadas.Any(x => x.Equals(tecnologiaVaga.TecnologiaID.ToString())))
                    {
                        db.TecnologiaVaga.Remove(tecnologiaVaga);
                    } 

                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel.genericModel);
        }

        //
        // GET: /Vaga/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Vaga vaga = db.Vagas.Find(id);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            return View(vaga);
        }

        //
        // POST: /Vaga/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vaga vaga = db.Vagas.Find(id);
            db.Vagas.Remove(vaga);
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