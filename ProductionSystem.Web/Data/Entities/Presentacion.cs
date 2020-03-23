using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    public class Presentacion
    {
        [ForeignKey("Etiqueta")]
       
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }

       
        public Etiqueta Etiqueta { get; set; }


        public Envase Envase { get; set; }

    }
}
