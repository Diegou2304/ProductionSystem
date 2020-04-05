using Microsoft.AspNetCore.Mvc.Rendering;
using ProductionSystem.Web.Data;
using ProductionSystem.Web.Data.Entities;
using ProductionSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {

        private readonly DataContext _dataContext;



        public ConverterHelper(DataContext dataContext)
        {

            _dataContext = dataContext;

        }

        public async Task<Presentacion> ToPresentacionAsync(AddPresentacionViewModel model)
        {

            return new Presentacion
            {
               
                
                Nombre = model.Nombre,
                Etiqueta = await _dataContext.Etiquetas.FindAsync(model.EtiquetaId),
                Envase = await _dataContext.Envases.FindAsync(model.EnvaseId)




            };

        }




    }
}
