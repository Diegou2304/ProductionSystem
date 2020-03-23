using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    public class Categoria
    {
        
        public int Id { get; set; }


        
        [Display(Name ="Nombre")]
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public string Nombre { get; set; }


        public Linea Linea { get; set; }
    }
}
