

namespace ProductionSystem.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using ProductionSystem.Web.Data.Entities;
    using System.Linq;

    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //para no permitir el borrado en cascada
            var cascadeFKS = builder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKS)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //datos unicos
            builder.Entity<Etiqueta>()
                .HasIndex(p => p.Nombre)
                .IsUnique(true);

            builder.Entity<Insumo>()
                .HasIndex(p => p.Nombre)
                .IsUnique(true);

            builder.Entity<Linea>()
                .HasIndex(p => p.Nombre)
                .IsUnique(true);

            builder.Entity<Presentacion>()
                .HasIndex(p => p.Nombre)
                .IsUnique(true);

            builder.Entity<Sabor>()
                .HasIndex(p => p.Nombre)
                .IsUnique(true);

            builder.Entity<TipoProducto>()
                .HasIndex(p => p.Nombre)
                .IsUnique(true);

        }

        public DbSet<Categoria> Categorias { get; set; }
        
        public DbSet<Deshecho> Deshechos { get; set; }

        public DbSet<EmpleadoProducción> EmpleadosProducciones { get; set; }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<EncargadoEmpresa> EncargadosEmpresas { get; set; }

        public DbSet<Envase> Envases { get; set; }

        public DbSet<Etiqueta> Etiquetas { get; set; }

        public DbSet<Fase> Fases { get; set; }

        public DbSet<Insumo> Insumos { get; set; }

        public DbSet<Linea> Lineas { get; set; }

        public DbSet<Pago> Pagos { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Persona> Personas { get; set; }

        public DbSet<Presentacion> Presentaciones { get; set; }

        public DbSet<Produccion> Producciones { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<ProductoReal> ProductoReal { get; set; }

        public DbSet<Resultado> Resultados { get; set; }

        public DbSet<Sabor> Sabores { get; set; }

        public DbSet<Sucursal> Sucursales { get; set; }

        public DbSet<TipoProducto> TipoProductos { get; set; }

        public DbSet<InventarioEmpresa> InventarioEmpresas { get; set; }

        public DbSet<ProductoPago> ProductoPagos { get; set; }

        public DbSet<Receta> Recetas { get; set; }

        public DbSet<InsumoUsado> InsumoUsados { get; set; }

    }
}
