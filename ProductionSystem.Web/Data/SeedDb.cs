

namespace ProductionSystem.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using ProductionSystem.Web.Data.Entities;
    using ProductionSystem.Web.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly UserManager<User> userManager;
        private readonly IUserHelper userHelper;
        private Random random;

        public SeedDb(DataContext context, UserManager<User> userManager, IUserHelper userHelper)
        {
            this.context = context;
            this.userManager = userManager;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            await this.userHelper.CheckRoleAsync("Administrador");
            var user = await this.userManager.FindByEmailAsync("Admin@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    Nombre = "Oscar",
                    ApellidoPaterno = "Claros",
                    ApellidoMaterno = "Carrillo",
                    Ci = 11337793,
                    Cargo = "Administrador",
                    Email = "Admin@gmail.com",
                    UserName = "Admin@gmail.com",
                    Disponible = true,
                    IsAdmin = true,
                };

                var result = await this.userManager.CreateAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
                await this.userHelper.AddUserToRoleAsync(user, "Administrador");
            }


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

            if (!this.context.Lineas.Any())
            {
                this.AddLinea("Niños", "Sin azucar", "Con azucar", "Organicos");
                this.AddLinea("Adultos", "Sin azucar", "Con azucar", "Organicos");
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Fases.Any())
            {
                this.AddFase("Administrador", 0, "Prueba");
                this.AddFase("Pelado", 1, "Prueba");
                this.AddFase("Coccion", 2, "Prueba");
                this.AddFase("Envasado", 3, "Prueba");
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

        private void AddLinea(string name, string cat1, string cat2, string cat3)
        {
            
            this.context.Lineas.Add(new Linea
            {
                Nombre = name,
                Categorias = AddCategorias(cat1,cat2, cat3),
            });
        }

        private void AddFase(string name, int numero, string descripcion)
        {
            this.context.Fases.Add(new Fase
            {
                Nombre = name,
                Numero = numero,
                Descripcion = descripcion, 
            });
        }

        //de a 3
        private List<Categoria> AddCategorias(string name1, string name2, string name3)
        {
            var categorias = new List<Categoria>();

            categorias.Add(new Categoria { Nombre = name1 });
            categorias.Add(new Categoria { Nombre = name2 });
            categorias.Add(new Categoria { Nombre = name3 });

            return categorias;
        }




    }

}
