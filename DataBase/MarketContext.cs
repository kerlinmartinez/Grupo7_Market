using Grupo7_Market.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Grupo7_Market.DataBase
{
    public class MarketContext:DbContext
    {
        public MarketContext() : base("Market")
        {
        }

        public DbSet<Clientes> Cliente { get; set; }

        public DbSet<Orden> ordens { get; set; }

        public DbSet<OrdenDetalle> ordenDetalles { get; set; }

        public DbSet<Producto> productos { get; set; }

        public DbSet<ClasificacionProducto> clasificacionProductos { get; set; }

        public DbSet<UnidadMedidas> UnidadMedidas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

    }
}