namespace bimestre4.Migrations
{
    using bimestre4.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<bimestre4.DAL.Bimestre4Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(bimestre4.DAL.Bimestre4Context context)
        {
            var tecnologias = new List<Tecnologia>
            {
                new Tecnologia {NomeTecnologia = "C#"},
                new Tecnologia {NomeTecnologia = "SQLServer 2010"},
                new Tecnologia {NomeTecnologia = "Java"},
                new Tecnologia {NomeTecnologia = "PostgreSQL"},
                new Tecnologia {NomeTecnologia = "Android"},
                new Tecnologia {NomeTecnologia = "SQLite"},
                new Tecnologia {NomeTecnologia = "Scala"},
                new Tecnologia {NomeTecnologia = "Ruby"},
                new Tecnologia {NomeTecnologia = "Jasper"},

            };
            tecnologias.ForEach(s => context.Tecnologias.AddOrUpdate(p => p.NomeTecnologia, s));
            context.SaveChanges();

            var candidatos = new List<Candidato>
            {
                new Candidato {NomeCandidato = "Leonardo"},
                new Candidato {NomeCandidato = "Ricardo"},
                new Candidato {NomeCandidato = "Thiago"},
                new Candidato {NomeCandidato = "Rodrigo"},
                new Candidato {NomeCandidato = "MisterJP"},
                new Candidato {NomeCandidato = "Gustavo"},
            };
            candidatos.ForEach(s => context.Candidatos.AddOrUpdate(p => p.NomeCandidato, s));
            context.SaveChanges();

            var candidatosTecnologias = new List<CandidatoTecnologia>
            {
                new CandidatoTecnologia {CandidatoID = candidatos.Single(s => s.NomeCandidato == "Leonardo").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "Java").ID},
                new CandidatoTecnologia {CandidatoID = candidatos.Single(s => s.NomeCandidato == "Leonardo").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "Android").ID},
                new CandidatoTecnologia {CandidatoID = candidatos.Single(s => s.NomeCandidato == "Leonardo").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "SQLite").ID},
                new CandidatoTecnologia {CandidatoID = candidatos.Single(s => s.NomeCandidato == "Ricardo").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "Java").ID},
                new CandidatoTecnologia {CandidatoID = candidatos.Single(s => s.NomeCandidato == "Ricardo").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "Android").ID},
                new CandidatoTecnologia {CandidatoID = candidatos.Single(s => s.NomeCandidato == "Ricardo").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "SQLite").ID},
                new CandidatoTecnologia {CandidatoID = candidatos.Single(s => s.NomeCandidato == "Ricardo").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "Ruby").ID},
                new CandidatoTecnologia {CandidatoID = candidatos.Single(s => s.NomeCandidato == "Thiago").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "Java").ID},
                new CandidatoTecnologia {CandidatoID = candidatos.Single(s => s.NomeCandidato == "Thiago").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "SQLite").ID},
                new CandidatoTecnologia {CandidatoID = candidatos.Single(s => s.NomeCandidato == "MisterJP").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "Java").ID},
                new CandidatoTecnologia {CandidatoID = candidatos.Single(s => s.NomeCandidato == "MisterJP").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "PostgreSQL").ID},
                new CandidatoTecnologia {CandidatoID = candidatos.Single(s => s.NomeCandidato == "Gustavo").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "Java").ID},
                new CandidatoTecnologia {CandidatoID = candidatos.Single(s => s.NomeCandidato == "Gustavo").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "Jasper").ID},
            };

            candidatosTecnologias.ForEach(ct => context.CandidatoTecnologia.Add(ct));
            context.SaveChanges();

            var vagas = new List<Vaga>
            {
                new Vaga {NomeVaga = "Desenvolvedor Mobile"},
                new Vaga {NomeVaga = "Desenvolvedor Java"},
                new Vaga {NomeVaga = "Estagio"},
            };
            vagas.ForEach(s => context.Vagas.AddOrUpdate(p => p.NomeVaga, s));
            context.SaveChanges();

            var tecnologiasVagas = new List<TecnologiaVaga>
            {
                new TecnologiaVaga {VagaID = vagas.Single(s => s.NomeVaga == "Desenvolvedor Mobile").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "Java").ID,   Peso = 10},
                new TecnologiaVaga {VagaID = vagas.Single(s => s.NomeVaga == "Desenvolvedor Mobile").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "Android").ID,     Peso = 5},
                new TecnologiaVaga {VagaID = vagas.Single(s => s.NomeVaga == "Desenvolvedor Mobile").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "SQLite").ID,   Peso = 5},
                new TecnologiaVaga {VagaID = vagas.Single(s => s.NomeVaga == "Desenvolvedor Java").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "Java").ID,    Peso = 10},
                new TecnologiaVaga {VagaID = vagas.Single(s => s.NomeVaga == "Desenvolvedor Java").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "PostgreSQL").ID, Peso = 10},
                new TecnologiaVaga {VagaID = vagas.Single(s => s.NomeVaga == "Estagio").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "Jasper").ID,    Peso = 3},
                new TecnologiaVaga {VagaID = vagas.Single(s => s.NomeVaga == "Estagio").ID, TecnologiaID = tecnologias.Single(t => t.NomeTecnologia == "Java").ID, Peso = 10},
            };

            tecnologiasVagas.ForEach(tv => context.TecnologiaVaga.Add(tv));
            context.SaveChanges();
        }
    }
}
