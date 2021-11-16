namespace Grupo7_Market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionCampoClasificacionProductoTablaProducto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Producto", "ClasificacionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Producto", "ClasificacionId");
            AddForeignKey("dbo.Producto", "ClasificacionId", "dbo.ClasificacionProducto", "ClasificacionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Producto", "ClasificacionId", "dbo.ClasificacionProducto");
            DropIndex("dbo.Producto", new[] { "ClasificacionId" });
            DropColumn("dbo.Producto", "ClasificacionId");
        }
    }
}
