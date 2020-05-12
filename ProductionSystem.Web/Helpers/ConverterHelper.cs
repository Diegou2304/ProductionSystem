﻿using ProductionSystem.Web.Data;
using ProductionSystem.Web.Data.Entities;
using ProductionSystem.Web.Models;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {

        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(
            DataContext dataContext,
            ICombosHelper combosHelper)
        {

            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }

        public async Task<Presentacion> ToPresentacionAsync(AddPresentacionViewModel model)
        {

            return new Presentacion
            {


                Nombre = model.Nombre,
                Etiqueta = await _dataContext.Etiquetas.FindAsync(model.EtiquetaId),
                Envase = await _dataContext.Envases.FindAsync(model.EnvaseId),
                Id = model.Id



            };

        }

        public AddPresentacionViewModel ToPresentacionViewModelAsync(Presentacion model)
        {
            //Le llega con todos los datos

            return new AddPresentacionViewModel
            {
                Id = model.Id,
                Nombre = model.Nombre,
                EnvaseId = model.Envase.Id,
                EtiquetaId = model.Etiqueta.Id,
                Etiqueta = model.Etiqueta,
                Envase = model.Envase,
                Envases = _combosHelper.GetComboEnvases(),

                Etiquetas = _combosHelper.GetComboEtiqueta(),

                FormerEtiquetaId = model.Etiqueta.Id



            };

        }

        public async Task<Producto> ToProductoAsync(ProductoViewModel model)
        {
            return new Producto
            {


                Nombre = model.Nombre,
                Categoria = await _dataContext.Categorias.FindAsync(model.CategoriaId),

                TipoProducto = await _dataContext.TipoProductos.FindAsync(model.TipoProductoId),
                Sabor = await _dataContext.Sabores.FindAsync(model.SaborId),
                Presentacion = await _dataContext.Presentaciones.FindAsync(model.PresentacionId),

                Id = model.Id,




            };


        }

        public async Task<ProductoReal> ToProductoRealAsync(ProductoRealViewModel model)
        {
            return new ProductoReal
            {


                Nombre = model.Nombre,
                stock = model.stock,
                Producto = await _dataContext.Productos.FindAsync(model.ProductoId),

                Id = model.Id,




            };
        }

       


        public ProductoViewModel ToProductoViewModel(Producto model)
        {
            return new ProductoViewModel
            {
                Id = model.Id,

                Nombre = model.Nombre,

                CategoriaId = model.Categoria.Id,

                TipoProductoId = model.TipoProducto.Id,

                SaborId = model.Sabor.Id,

                PresentacionId = model.Presentacion.Id,

                Categoria = model.Categoria,

                TipoProducto = model.TipoProducto,

                Sabor = model.Sabor,

                Presentacion = model.Presentacion,



                Categorias = _combosHelper.GetComboCategorias(),

                TiposProductos = _combosHelper.GetComboTipoProducto(),

                Sabores = _combosHelper.GetComboSabores(),

                Presentaciones = _combosHelper.GetComboPresentaciones(),




            };

        }
      }
}
