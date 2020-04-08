

namespace ProductionSystem.Web.Data.Entities
{

    using System;
    using System.Collections.Generic;

    //agregar la IEntity a todas las entidades
    public class Insumo : IEntity
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        public Decimal Stock { get; set; }

        public bool IsRawProduct { get; set;}

        public ICollection<Receta> Recetas { get; set; }

        public ICollection<Produccion> Producciones { get; set; }

        public ICollection<InsumoUsado> InsumosUsados { get; set; }


    }
}
