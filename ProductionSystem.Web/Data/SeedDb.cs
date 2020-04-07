

namespace ProductionSystem.Web.Data
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using ProductionSystem.Web.Helpers;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            //para crear un administrador predeterminado
            var user = await this.userHelper.GetUserByEmailAsync("administrador@gmail.com");
            if(user == null)
            {
                user = new User
                {
                    Nombre = "Admin",
                    ApellidoPaterno = "Administrador",
                    ApellidoMaterno = "Administrador",
                    Cargo = "Administrador",
                    Email = "administrador@gmail.com",
                    UserName = "administrador@gmail.com"
                };
            }

            var result = await this.userHelper.AddUserAsync(user, "123456");
            if(result != IdentityResult.Success)
            {
                throw new InvalidOperationException("No se pudo crear el usuario en el Seeder");
            }




            if (!this.context.Sabores.Any())
            {
                this.AddSabor("Papaya");
                this.AddSabor("Frurilla");
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
