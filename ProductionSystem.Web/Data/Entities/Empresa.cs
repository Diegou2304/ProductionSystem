using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    public class Empresa
    {
        public int Id { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public EncargadoEmpresa EncargadoEmpresa { get; set; }

       

        public ICollection<Sucursal> Sucursales { get; set; }
        

        public ICollection<Pago> Pagos { get; set; }
        public ICollection<InventarioEmpresa> InventarioEmpresas { get; set; }
    }
}
