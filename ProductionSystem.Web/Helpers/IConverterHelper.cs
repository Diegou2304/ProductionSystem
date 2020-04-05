﻿using ProductionSystem.Web.Data.Entities;
using ProductionSystem.Web.Models;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Presentacion> ToPresentacionAsync(AddPresentacionViewModel model);
    }
}