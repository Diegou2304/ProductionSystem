﻿

namespace ProductionSystem.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Sabor : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
