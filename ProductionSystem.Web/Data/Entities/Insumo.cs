

namespace ProductionSystem.Web.Data.Entities
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    //agregar la IEntity a todas las entidades
    public class Insumo : IEntity
    {

        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }

        [Display(Name = "Stock")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Decimal Stock { get; set; }

        public bool IsRawProduct { get; set;}

        public ICollection<Receta> Recetas { get; set; }

        public ICollection<Produccion> Producciones { get; set; }

        public ICollection<InsumoUsado> InsumosUsados { get; set; }


    }
}
