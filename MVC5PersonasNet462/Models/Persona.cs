using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC5PersonasNet462.Models
{
    public class Persona
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [RegularExpression("[0-9]+")]
        public int Edad { get; set; }

        [RegularExpression("^[a-z0-9+_.-]+@[a-z0-9.-]+$")]
        public string Email { get; set; }
    }
}