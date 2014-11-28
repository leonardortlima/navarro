namespace bimestre4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tecnologia",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NomeTecnologia = c.String(),
                        DescTecnologia = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TecnologiaVaga",
                c => new
                    {
                        TecnologiaID = c.Int(nullable: false),
                        VagaID = c.Int(nullable: false),
                        Peso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TecnologiaID, t.VagaID })
                .ForeignKey("dbo.Tecnologia", t => t.TecnologiaID, cascadeDelete: true)
                .ForeignKey("dbo.Vaga", t => t.VagaID, cascadeDelete: true)
                .Index(t => t.TecnologiaID)
                .Index(t => t.VagaID);
            
            CreateTable(
                "dbo.Vaga",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NomeVaga = c.String(),
                        DescVaga = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CandidatoTecnologia",
                c => new
                    {
                        TecnologiaID = c.Int(nullable: false),
                        CandidatoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TecnologiaID, t.CandidatoID })
                .ForeignKey("dbo.Tecnologia", t => t.TecnologiaID, cascadeDelete: true)
                .ForeignKey("dbo.Candidato", t => t.CandidatoID, cascadeDelete: true)
                .Index(t => t.TecnologiaID)
                .Index(t => t.CandidatoID);
            
            CreateTable(
                "dbo.Candidato",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NomeCandidato = c.String(),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CandidatoTecnologia", new[] { "TecnologiaID" });
            DropIndex("dbo.CandidatoTecnologia", new[] { "CandidatoID" });
            DropIndex("dbo.TecnologiaVaga", new[] { "TecnologiaID" });
            DropIndex("dbo.TecnologiaVaga", new[] { "VagaID" });
            DropForeignKey("dbo.CandidatoTecnologia", "TecnologiaID", "dbo.Tecnologia");
            DropForeignKey("dbo.CandidatoTecnologia", "CandidatoID", "dbo.Candidato");
            DropForeignKey("dbo.TecnologiaVaga", "TecnologiaID", "dbo.Tecnologia");
            DropForeignKey("dbo.TecnologiaVaga", "VagaID", "dbo.Vaga");
            DropTable("dbo.Candidato");
            DropTable("dbo.CandidatoTecnologia");
            DropTable("dbo.Vaga");
            DropTable("dbo.TecnologiaVaga");
            DropTable("dbo.Tecnologia");
        }
    }
}
