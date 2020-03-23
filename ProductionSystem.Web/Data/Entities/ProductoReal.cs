using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    public class ProductoReal
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int stock { get; set; }

        public Producto Producto { get; set; }

        public ICollection<Pedido> Pedido { get; set; }

      

        public ICollection<ProductoPago> ProductoPago {get; set;}

        public ICollection<InventarioEmpresa> InventarioEmpresas { get; set; }

        public ICollection<Receta> Recetas { get; set; }


    }
}
