namespace Amigafa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Militars",
                c => new
                    {
                        Cpf = c.String(nullable: false, maxLength: 128),
                        RgCivil = c.String(),
                        RgMilitar = c.String(),
                        Nome = c.String(nullable: false),
                        NomeGuerra = c.String(),
                        PostoGrad = c.String(),
                        DataFormatura = c.String(nullable: false),
                        Cep = c.String(nullable: false),
                        Endereco = c.String(),
                        NumeroEndereco = c.String(),
                        ComplementoEndereco = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        Telefone = c.String(nullable: false),
                        Celular = c.String(),
                    })
                .PrimaryKey(t => t.Cpf);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Militars");
        }
    }
}
