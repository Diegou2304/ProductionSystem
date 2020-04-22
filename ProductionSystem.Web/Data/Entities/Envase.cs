

namespace ProductionSystem.Web.Data.Entities
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Envase : IEntity
    {

        public int Id { get; set; }

        [Display(Name ="Capacidad")]
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public int Capacidad { get; set; }

        [Display(Name = "EsPlastico")]
        [Required(ErrorMessage = "Este campo es obligatorio")]        
        public bool Isplastic { get; set; }

        public ICollection<Presentacion> Presentaciones{get; set;}

    }
}
