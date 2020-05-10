

namespace ProductionSystem.Web
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Data;
    using Data.Entities;
    using Helpers;
    using ProductionSystem.Web.Data.Repositories.Interfaz;
    using ProductionSystem.Web.Data.Repositories.Repository;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //TODO: arreglar esto
            //propiedades para la autenticacion de usuarios
            
            services.AddIdentity<User, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
                cfg.Password.RequireDigit = false;
                cfg.Password.RequiredUniqueChars = 0;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequiredLength = 6; //tam minimo del password
            }).AddEntityFrameworkStores<DataContext>();
            

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //TODO : arreglar esto
            //services.AddTransient<SeedDb>();

            



            services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<ICombosHelper, CombosHelper>();
            services.AddScoped<IConverterHelper, ConverterHelper>();
            services.AddScoped<IValidatorHelper, ValidatorHelper>();

            //inyeccion de la interfaz
            services.AddScoped<IUserHelper, UserHelper>();

            //inyeccion de los repositorios
            services.AddTransient<SeedDb>(); //alimentador de base de datos
            services.AddScoped<IInsumoRepository, InsumoRepository>();
            services.AddScoped<ILineaRepository, LineaRepository>();
            services.AddScoped<ISaborRepository, SaborRepository>();
            services.AddScoped<IEtiquetaRepository, EtiquetaRepository>();
            services.AddScoped<ITipoProductoRepository, TipoProductoRepository>();
            services.AddScoped<IEnvaseRepository, EnvaseRepository>();
            services.AddScoped<IPresentacionRepository, PresentacionRepository>();

            services.AddScoped<IProductoRepository,ProductoRepository>();

        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //se agrego esta 
            app.UseAuthentication();
            //
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
