using bimestre4.DAL;
using bimestre4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bimestre4.Controllers
{
    public class RelatorioController : Controller
    {
        private Bimestre4Context db = new Bimestre4Context();

        //
        // GET: /Relatorio/

        public ActionResult Index()
        {
            var vagas = db.Vagas.ToList();
            var rankList = new List<RankModel>();


            foreach (var vaga in vagas)
            {
                var rank = new RankModel();
                rank.vaga = vaga;
                var candidatos = new List<Candidato>();

                foreach (var tv in vaga.TecnologiaVaga)
                {
                    var cts = db.CandidatoTecnologia.Where(i => i.TecnologiaID == tv.TecnologiaID).ToList();

                    foreach (var ct in cts)
                    {
                        var candidato = candidatos.Find(o => o.ID == ct.CandidatoID);
                        if (candidato != null)
                        {
                            candidato.Pontuacao += tv.Peso;
                        }
                        else
                        {
                            ct.Candidato.Pontuacao = tv.Peso;
                            candidatos.Add(ct.Candidato);
                        }
                    }

                }
                rank.candidatos = candidatos.OrderBy(x => x.Pontuacao).ToList();
                rankList.Add(rank);
            }

            return View(rankList);
        }

    }
}
