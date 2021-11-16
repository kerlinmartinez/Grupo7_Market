namespace Grupo7_Market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionCampoOrdenTablaOrdenDetalle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenDetalle", "OrdenId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrdenDetalle", "OrdenId");
            AddForeignKey("dbo.OrdenDetalle", "OrdenId", "dbo.Orden", "OrdenId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenDetalle", "OrdenId", "dbo.Orden");
            DropIndex("dbo.OrdenDetalle", new[] { "OrdenId" });
            DropColumn("dbo.OrdenDetalle", "OrdenId");
        }
    }
}
