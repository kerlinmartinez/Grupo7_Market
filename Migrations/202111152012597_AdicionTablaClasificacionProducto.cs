namespace Grupo7_Market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionTablaClasificacionProducto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClasificacionProducto",
                c => new
                    {
                        ClasificacionId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Clasificacion = c.String(nullable: false, maxLength: 20),
                        Estado = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClasificacionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClasificacionProducto");
        }
    }
}
