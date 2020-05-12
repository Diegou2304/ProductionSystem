namespace ProductionSystem.Web.Data.Entities
{
    public class Receta : IEntity
    {
        public int Id { get; set; }

        public decimal Porcentaje { get; set; }


        public Insumo Insumo { get; set; }

        public ProductoReal ProductoReal { get; set; }



    }
}
