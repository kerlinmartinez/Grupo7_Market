namespace Grupo7_Market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionCampoProductoTablaOrdenDetalle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenDetalle", "ProductoId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrdenDetalle", "ProductoId");
            AddForeignKey("dbo.OrdenDetalle", "ProductoId", "dbo.Producto", "ProductoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenDetalle", "ProductoId", "dbo.Producto");
            DropIndex("dbo.OrdenDetalle", new[] { "ProductoId" });
            DropColumn("dbo.OrdenDetalle", "ProductoId");
        }
    }
}
