using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupo7_Market.Models
{
    public class Clientes
    {
        
       [Key]
        public int ClienteId { get; set; }

        [Required]
        [MaxLength(50)]
        public string NombreCliente { get; set; }
    }
}