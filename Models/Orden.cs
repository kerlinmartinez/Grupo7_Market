using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupo7_Market.Models
{
    public class Orden
    {
        [Key]
        public int OrdenId { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        public int ClienteID { get; set; }

       public Clientes clientes { get; set; }
    }
}