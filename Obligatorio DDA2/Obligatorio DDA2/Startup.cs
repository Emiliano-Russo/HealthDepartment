using Interfaces;
using Interfaces.Validaciones;
using LogicaNegocio;
using LogicaNegocio.Validaciones.Implementaciones;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Reflection;
using Relfection.Interfaces;
using Repositorio.Repositorio.RepositorioBDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obligatorio_DDA2
{
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
            services.AddControllers();
            string conexion = System.IO.File.ReadAllText(@"C:\Users\Public\ArchivosTexto\Conexion.txt");
            var opciones = new DbContextOptionsBuilder<EntidadesContexto>().
                UseSqlServer(conexion)
                .Options;
            IRepositorio respositorio = new RepositorioBDD(opciones);
            IValidacionEntidades validacion = new ValidacionEntidades(respositorio);
            IMenuImportaciones menu = new MenuImportaciones();
            ISistema sistema = new Sistema(respositorio, validacion, menu);

            services.AddTransient<ISistema>(s => new Sistema(respositorio, validacion, menu));
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseEndpoints(endpoints =>
              {
                  endpoints.MapControllers();
              });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
