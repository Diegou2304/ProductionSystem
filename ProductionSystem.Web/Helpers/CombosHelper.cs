using Microsoft.AspNetCore.Mvc.Rendering;
using ProductionSystem.Web.Data;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<SelectListItem> GetComboCategorias()
        {
            //lISTA DE PROPERTY TIPES TENEMOS QUE CONVERTIRLA
            var list = _dataContext.Categorias.Select(
                pt => new SelectListItem
                {
                    Text = pt.Nombre,
                    Value = $"{pt.Id}"

                })
                .OrderBy(pt => pt.Value)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona La categoria de tu producto",
                Value = "0"
            });

            return list;
        }

        //Select list item es una clase que tiene campo y valor
        public IEnumerable<SelectListItem> GetComboEnvases()
        {
            //lISTA DE PROPERTY TIPES TENEMOS QUE CONVERTIRLA
            var list = _dataContext.Envases.Select(
                pt => new SelectListItem
                {
                    Text = pt.Capacidad.ToString() + "Gr " + "Plastico: " + $"{pt.Isplastic}",
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
            var list = _dataContext.Etiquetas.Select(
                pt => new SelectListItem
                {
                    Text =
                    "Marca: " + pt.Nombre +
                    " WaterProof: " + $"{pt.IsWaterProof}" +
                    " Precio Unitario: " + $"{pt.PrecioUnitario}" +
                    " Altura (Cm): " + $"{pt.Altura}" +
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

        public IEnumerable<SelectListItem> GetComboPresentaciones()
        {
            //lISTA DE PROPERTY TIPES TENEMOS QUE CONVERTIRLA
            var list = _dataContext.Presentaciones.Select(
                pt => new SelectListItem
                {
                    Text =
                     pt.Nombre +
                    " Etiqueta: " + pt.Etiqueta.Nombre + " Precio U. " + pt.Etiqueta.PrecioUnitario +" Bs"+
                    " Plastico: " + $"{pt.Envase.Isplastic}" + " Capacidad " + $"{pt.Envase.Capacidad}" + " gr",

                    Value = $"{pt.Id}"

                })

                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona la Presentacion correspondiente",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboSabores()
        {
            //lISTA DE PROPERTY TIPES TENEMOS QUE CONVERTIRLA
            var list = _dataContext.Sabores.Select(
                pt => new SelectListItem
                {
                    Text =
                    "Sabor: " + pt.Nombre,
                    Value = $"{pt.Id}",

                })

                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona el sabor deseado.",
                Value = "0"
            });

            return list;

        }

        public IEnumerable<SelectListItem> GetComboTipoProducto()
        {

            //lISTA DE PROPERTY TIPES TENEMOS QUE CONVERTIRLA
            var list = _dataContext.TipoProductos.Select(
                pt => new SelectListItem
                {
                    Text = pt.Nombre,
                    Value = $"{pt.Id}",

                })

                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona Tipo de Producto deseado.",
                Value = "0"
            });

            return list;

        }

        public IEnumerable<SelectListItem> GetComboProductos()
        {
            

            //lISTA DE PROPERTY TIPES TENEMOS QUE CONVERTIRLA
            var list = _dataContext.Productos.Select(
                pt => new SelectListItem
                {
                    Text = 
                    pt.Nombre +
                    pt.TipoProducto.Nombre + 
                    pt.Sabor.Nombre,

                    Value = $"{pt.Id}",

                })

                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona el Producto deseado.",
                Value = "0"
            });

            return list;

        }
        public IEnumerable<SelectListItem> GetComboInsumo()
        {


            //lISTA DE PROPERTY TIPES TENEMOS QUE CONVERTIRLA
            var list = _dataContext.Insumos.Select(
                pt => new SelectListItem
                {
                    Text =
                    pt.Nombre + " Materia Prima " + 
                    $"{pt.IsRawProduct}",

                    Value = $"{pt.Id}",

                })

                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona el Insumo deseado.",
                Value = "0"
            });

            return list;

        }

     
        public IEnumerable<SelectListItem> GetComboProductosReales()
        {  
            //lISTA DE PROPERTY TIPES TENEMOS QUE CONVERTIRLA
            var list = _dataContext.ProductoReal.Select(
                pt => new SelectListItem
                {
                    Text =
                    pt.Nombre,

                    Value = $"{pt.Id}",

                })

                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona el Producto Real deseado.",
                Value = "0"
            });

            return list;
        }

        
        public IEnumerable<SelectListItem> GetComboFases()
        {
            //lISTA DE PROPERTY TIPES TENEMOS QUE CONVERTIRLA
            var list = _dataContext.Fases.Select(
                pt => new SelectListItem
                {
                    Text =
                    pt.Nombre,

                    Value = $"{pt.Id}",

                })

                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona la Fase",
                Value = "0"
            });

            return list;
        }


        public IEnumerable<SelectListItem> GetComboCargos()
        {
            //lISTA DE PROPERTY TIPES TENEMOS QUE CONVERTIRLA
            var list = _dataContext.Fases.Select(
                pt => new SelectListItem
                {
                    Text =
                    pt.Nombre,

                    Value = $"{pt.Id}",

                })

                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona el Cargo",
                Value = "0"
            });

            return list;
        }



    }
}
