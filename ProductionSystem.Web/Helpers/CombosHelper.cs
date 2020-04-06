using Microsoft.AspNetCore.Mvc.Rendering;
using ProductionSystem.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(
            DataContext dataContext
            )
        {

            _dataContext = dataContext;
        }
        //Select list item es una clase que tiene campo y valor
        public IEnumerable<SelectListItem> GetComboEnvases()
        {
            //lISTA DE PROPERTY TIPES TENEMOS QUE CONVERTIRLA
            var list = _dataContext.Envases.Select(
                pt => new SelectListItem
                {
                    Text = pt.Capacidad.ToString()+"Gr " + "Plastico: " + $"{pt.Isplastic}",
                    Value = $"{pt.Id}"
                    
                })
                .OrderBy(pt => pt.Value)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona la capacidad del envase",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboEtiqueta()
        {
            //lISTA DE PROPERTY TIPES TENEMOS QUE CONVERTIRLA
            var list = _dataContext.Etiquetas.Where(pt => pt.IsUsed == false).Select(
                pt => new SelectListItem
                {
                    Text = 
                    "Marca: " +pt.Nombre +
                    " WaterProof: " + $"{pt.IsWaterProof}"+
                    " Precio Unitario: "+$"{pt.PrecioUnitario}"+ 
                    " Altura (Cm): "+$"{pt.Altura}" + 
                    " Ancho: " + $"{pt.Ancho}",
                     Value = $"{pt.Id}"

                })
                
                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona la marca de la etiqueta",
                Value = "0"
            });

            return list;
        }


    }
}
