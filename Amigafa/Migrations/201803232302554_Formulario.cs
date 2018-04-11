namespace Amigafa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Formulario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Formularios",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Ano = c.DateTime(nullable: false),
                        EncontroVeterano = c.String(),
                        ChurrascoVeterano = c.String(),
                        CompletoVeterano = c.String(),
                        CamisaExtra = c.String(),
                        BoneExtra = c.String(),
                        VinhoVeterano = c.String(),
                        VinhoConvidado = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Formularios");
        }
    }
}
