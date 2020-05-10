﻿using Microsoft.AspNetCore.Mvc.Rendering;
using ProductionSystem.Web.Data;
using ProductionSystem.Web.Data.Entities;
using ProductionSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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




    }
}
