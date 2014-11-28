using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using bimestre4.Models;

namespace bimestre4.DAL
{
    public class Bimestre4Context : DbContext
    {
        public DbSet<Tecnologia> Tecnologias { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<TecnologiaVaga> TecnologiaVaga { get; set; }
        public DbSet<CandidatoTecnologia> CandidatoTecnologia { get; set; }

        public Candidato getCandidato(int id)
        {
            return Candidatos.Find(id);
        }

        public List<CandidatoTecnologia> getTecnologiasCandidato(int id)
        {
            return CandidatoTecnologia.Where(o => o.CandidatoID == id).ToList();
        }

        public List<Tecnologia> getAllTecnologias()
        {
            return Tecnologias.ToList();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<TecnologiaVaga>().
                HasKey(c => new { c.TecnologiaID, c.VagaID });

            modelBuilder.Entity<CandidatoTecnologia>().
                HasKey(c => new { c.TecnologiaID, c.CandidatoID });

            modelBuilder.Entity<Tecnologia>()
                .HasMany(c => c.TecnologiaVaga)
                .WithRequired()
                .HasForeignKey(c => c.TecnologiaID);

            modelBuilder.Entity<Tecnologia>()
                .HasMany(c => c.CandidatoTecnologia)
                .WithRequired()
                .HasForeignKey(c => c.TecnologiaID);

            modelBuilder.Entity<Vaga>()
                .HasMany(c => c.TecnologiaVaga)
                .WithRequired()
                .HasForeignKey(c => c.VagaID);

            modelBuilder.Entity<Candidato>()
                .HasMany(c => c.CandidatoTecnologia)
                .WithRequired()
                .HasForeignKey(c => c.CandidatoID);
        }
    }
}