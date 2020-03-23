using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    public class Etiqueta
    {

        public int Id { get; set; }

        [Display(Name ="Nombre")]
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public string Nombre { get; set; }


        [Display(Name = "Altura")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Decimal Altura { get; set; }


        [Display(Name = "Ancho")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Decimal Ancho { get; set; }


        [Display(Name = "Precio Unitario")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Decimal PrecioUnitario { get; set; }


        [Display(Name = "IsWaterProof")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool IsWaterProof { get; set; }


        public Presentacion Presentacion { get; set; }

    }
}
