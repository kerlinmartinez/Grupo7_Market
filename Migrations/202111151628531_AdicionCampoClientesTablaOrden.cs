namespace Grupo7_Market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionCampoClientesTablaOrden : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orden", "ClienteID", c => c.Int(nullable: false));
            CreateIndex("dbo.Orden", "ClienteID");
            AddForeignKey("dbo.Orden", "ClienteID", "dbo.Clientes", "ClienteId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orden", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.Orden", new[] { "ClienteID" });
            DropColumn("dbo.Orden", "ClienteID");
        }
    }
}
