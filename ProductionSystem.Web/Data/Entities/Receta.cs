using System.ComponentModel.DataAnnotations;

namespace ProductionSystem.Web.Data.Entities
{
    public class Receta : IEntity
    {
        public int Id { get; set; }

        [Range(0, 100, ErrorMessage = "Limite es 100%")]
        public decimal Porcentaje { get; set; }


        public Insumo Insumo { get; set; }

        public ProductoReal ProductoReal { get; set; }



    }
}
