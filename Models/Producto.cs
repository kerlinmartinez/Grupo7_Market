using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupo7_Market.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required]
        public int Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(6)]
        public string Estado { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        public int UnidadId { get; set; }

        public UnidadMedidas unidadMedidas { get; set; }

        public int ClasificacionId { get; set; }

        public ClasificacionProducto clasificacionProducto { get; set; }

        [Required]
        public int Precio{ get; set; }
    }
}