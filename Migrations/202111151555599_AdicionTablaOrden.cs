namespace Grupo7_Market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionTablaOrden : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orden",
                c => new
                    {
                        OrdenId = c.Int(nullable: false, identity: true),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrdenId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orden");
        }
    }
}
