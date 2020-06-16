

namespace ProductionSystem.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Empresa : IEntity
    {
        public int Id { get; set; }


     
        [Required]
        [MaxLength(50, ErrorMessage = " El campo no puede tener mas caracteres")]
        public string Direccion { get; set; }

        [Required]
        public string Telefono { get; set; }

        public EncargadoEmpresa EncargadoEmpresa { get; set; }

        public ICollection<Sucursal> Sucursales { get; set; }
        public ICollection<Pago> Pagos { get; set; }
        public ICollection<InventarioEmpresa> InventarioEmpresas { get; set; }
    }
}
