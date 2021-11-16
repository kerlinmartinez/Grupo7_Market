namespace Grupo7_Market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionTablaOrdenDetalle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrdenDetalle",
                c => new
                    {
                        DetalleId = c.Int(nullable: false, identity: true),
                        Precio = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Descuento = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetalleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrdenDetalle");
        }
    }
}
