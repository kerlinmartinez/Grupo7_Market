using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupo7_Market.Models
{
    public class UnidadMedidas
    {
        [Key]
        public int UnidadId { get; set; }

        [Required]
        public int Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public string Estado { get; set; }

    }
}