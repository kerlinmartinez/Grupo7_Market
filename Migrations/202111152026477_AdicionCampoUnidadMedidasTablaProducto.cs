namespace Grupo7_Market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionCampoUnidadMedidasTablaProducto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Producto", "UnidadId", c => c.Int(nullable: false));
            CreateIndex("dbo.Producto", "UnidadId");
            AddForeignKey("dbo.Producto", "UnidadId", "dbo.UnidadMedidas", "UnidadId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Producto", "UnidadId", "dbo.UnidadMedidas");
            DropIndex("dbo.Producto", new[] { "UnidadId" });
            DropColumn("dbo.Producto", "UnidadId");
        }
    }
}
