

namespace ProductionSystem.Web.Data
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;


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
                this.AddSabor("Papaya");
                this.AddSabor("Frutilla");
                this.AddSabor("Manzana");
                await this.context.SaveChangesAsync();
            }

        }

        private void AddSabor(string name)
        {
            this.context.Sabores.Add(new Sabor
            {
                Nombre = name,
            });
        }

    }
}
