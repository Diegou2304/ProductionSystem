using ProductionSystem.Web.Data;
using ProductionSystem.Web.Data.Entities;
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

            if(!pedido.estado)
            {
                return true; 


            }
            return false;
        }


    }
}
