namespace bimestre4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tecnologia", "NomeTecnologia", c => c.String(nullable: false));
            AlterColumn("dbo.Vaga", "NomeVaga", c => c.String(nullable: false));
            AlterColumn("dbo.Candidato", "NomeCandidato", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Candidato", "NomeCandidato", c => c.String());
            AlterColumn("dbo.Vaga", "NomeVaga", c => c.String());
            AlterColumn("dbo.Tecnologia", "NomeTecnologia", c => c.String());
        }
    }
}
