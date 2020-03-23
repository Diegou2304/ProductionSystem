using Microsoft.EntityFrameworkCore;
using ProductionSystem.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TipoProducto> Categorias { get; set; }
        
        public DbSet<TipoProducto> Deshechos { get; set; }

        public DbSet<TipoProducto> EmpleadosProducciones { get; set; }

        public DbSet<TipoProducto> Empresas { get; set; }

        public DbSet<TipoProducto> EncargadosEmpresas { get; set; }

        public DbSet<TipoProducto> Envases { get; set; }

        public DbSet<TipoProducto> Etiquetas { get; set; }

        public DbSet<TipoProducto> Fases { get; set; }

        public DbSet<TipoProducto> Insumos { get; set; }

        public DbSet<TipoProducto> Lineas { get; set; }

        public DbSet<TipoProducto> Pagos { get; set; }

        public DbSet<TipoProducto> Pedidos { get; set; }

        public DbSet<TipoProducto> Personas { get; set; }
        public DbSet<TipoProducto> Presentaciones { get; set; }

        public DbSet<TipoProducto> Producciones { get; set; }

        public DbSet<TipoProducto> Productos { get; set; }
        public DbSet<TipoProducto> ProductoReal { get; set; }

        public DbSet<TipoProducto> Resultados { get; set; }

        public DbSet<TipoProducto> Sabores { get; set; }
        public DbSet<TipoProducto> Sucursales { get; set; }

        public DbSet<TipoProducto> TipoProductos { get; set; }


       


        public DbSet<InventarioEmpresa> InventarioEmpresas { get; set; }


        public DbSet<ProductoPago> ProductoPagos { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<InsumoUsado> InsumoUsados { get; set; }




    }
}
