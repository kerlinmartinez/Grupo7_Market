using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupo7_Market.Models
{
    public class OrdenDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        public int OrdenId { get; set; }

        public Orden Orden { get; set; }

        public int ProductoId { get; set; }

        public Producto producto { get; set; }

        [Required]
        public int Precio { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public int Descuento { get; set; }

        [Required]
        public int Total { get; set; }

    }
}