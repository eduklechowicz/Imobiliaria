namespace Imobiliaria2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoSituacaoPropriedade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Propriedades", "Situacao", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Propriedades", "Situacao");
        }
    }
}
