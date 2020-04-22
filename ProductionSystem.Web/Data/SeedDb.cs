

namespace ProductionSystem.Web.Data
{
    using ProductionSystem.Web.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Sabores.Any())
            {
                this.AddSabor("Frutilla");
                this.AddSabor("Granada");
                this.AddSabor("Manzana");
                this.AddSabor("Papaya");
                this.AddSabor("Pera");
                this.AddSabor("Platano");
                this.AddSabor("Pinha");
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Envases.Any())
            {
                this.AddEnvase(10, false);
                this.AddEnvase(40, false);
                this.AddEnvase(55, false);
                this.AddEnvase(60, false);
                await this.context.SaveChangesAsync();
            }

            if (!this.context.TipoProductos.Any())
            {
                this.AddTipoProducto("Jalea");
                this.AddTipoProducto("Jugo");
                this.AddTipoProducto("Mermelada");
                this.AddTipoProducto("Pulpa");
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Insumos.Any())
            {
                this.AddInsumo("Azucar",500,false);
                this.AddInsumo("Papaya", 500, true);
                this.AddInsumo("Pinha", 100, true);
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Etiquetas.Any())
            {
                this.AddEtiqueta("Daflex", 3, 3, 5, true);
                this.AddEtiqueta("Editorial Bless", 12, 12, 14, true);
                this.AddEtiqueta("La Sierra Impresiones", 20, 21, 1, true);
                this.AddEtiqueta("Sie7e Impresiones", 7, 5, 2, true);
                await this.context.SaveChangesAsync();
            }

        }

        private void AddSabor(string name)
        {
            this.context.Sabores.Add(new Sabor
            {
                Nombre = name
            });
        }

        private void AddEnvase(int capacidad, bool esPlastico)
        {
            this.context.Envases.Add(new Envase
            {
                Capacidad = capacidad,
                Isplastic = esPlastico
            });
        }

        private void AddTipoProducto(string nombre)
        {
            this.context.TipoProductos.Add(new TipoProducto
            {
                Nombre = nombre
            });
        }

        private void AddInsumo(string nombre, decimal stock, bool esMateriaPrima)
        {
            this.context.Insumos.Add(new Insumo
            {
                Nombre = nombre,
                Stock = stock,
                IsRawProduct = esMateriaPrima
            });
        }

        private void AddEtiqueta(string nombre, decimal altura, decimal ancho,decimal precioU, bool esResistente)
        {
            this.context.Etiquetas.Add(new Etiqueta
            {
                Nombre = nombre,
                Altura = altura,
                Ancho = ancho,
                PrecioUnitario = precioU,
                IsWaterProof = esResistente
                
            });
        }


    }

}
