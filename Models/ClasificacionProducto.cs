using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupo7_Market.Models
{
    public class ClasificacionProducto
    {
        [Key]
        public int ClasificacionId { get; set; }

        [Required]
        public int Codigo { get; set; }

        [Required]
        [MaxLength(20)]
        public string Clasificacion { get; set; }

        [Required]
        public string Estado { get; set; }

    }
}