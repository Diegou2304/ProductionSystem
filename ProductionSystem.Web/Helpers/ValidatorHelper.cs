using ProductionSystem.Web.Data;
using ProductionSystem.Web.Data.Entities;
using ProductionSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Helpers
{
    public class ValidatorHelper : IValidatorHelper
    {

        private readonly DataContext _dataContext;

        public ValidatorHelper(
            DataContext dataContext
            )
        {

            _dataContext = dataContext;
        }

        public bool IsEnoughProduct(int? id,int cantidad)
        {
            var producto = _dataContext.ProductoReal.FirstOrDefault(p => p.Id == id);

            if(producto.stock < cantidad)
            {
                return false;

            }
            return true; 
        }

        public bool IsEtiquetaUsed(int? id)
        {
            var etiqueta = _dataContext.Etiquetas.FirstOrDefault(et => et.Id == id);

            if (etiqueta.IsUsed)
            {
                return true;
            }

            return false;
        }

        public bool IsPedidoPendiente(int ?id)
        {
            var pedido = _dataContext.Pedidos.FirstOrDefault(i => i.Id == id);

            if(pedido.estado == "Pendiente")
            {
                return true; 

            }
            return false;
        }

        public bool ProductStorageExists(PagoViewModel model)
        {
                var inventarioempresa= _dataContext
                       .InventarioEmpresas
                       .FirstOrDefault(e => e.ProductoReal.Id == model.IdProductoFinal
                       && e.Empresa.Id == model.EmpresaId);

            if(inventarioempresa == null)
            {
                return false;
            }

            return true;

        }
    }
}
