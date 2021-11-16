namespace Grupo7_Market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionTablaUnidadMedidas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UnidadMedidas",
                c => new
                    {
                        UnidadId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        Estado = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UnidadId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UnidadMedidas");
        }
    }
}
