namespace Grupo7_Market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionTablaProducto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Estado = c.String(nullable: false, maxLength: 6),
                        FechaCreacion = c.DateTime(nullable: false),
                        Precio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Producto");
        }
    }
}
