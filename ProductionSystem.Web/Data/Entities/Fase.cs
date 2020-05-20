﻿

namespace ProductionSystem.Web.Data.Entities
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Fase : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        //TODO:hacer que esto sea unico
        [Required]
        public int Numero { get; set;}

        [Required]
        public string Descripcion { get; set; }

        public ICollection<Produccion> Producciones { get; set;}


    }
}
