using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Cadeteria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Repositorio;
using WebAppCadeteria.Models.Repositorio;

namespace WebAppCadeteria
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
            services.AddControllersWithViews();
            
            string ConnectionString = Configuration.GetConnectionString("default");
            
            CadeteRepositorio repoCadete = new CadeteRepositorio(ConnectionString); services.AddSingleton(repoCadete);
            PedidoRepositorio repoPedido = new PedidoRepositorio(ConnectionString); services.AddSingleton(repoPedido);
            UsuarioRepositorio repoUsuario = new UsuarioRepositorio(ConnectionString); services.AddSingleton(repoUsuario);
            ClienteRepositorio repoCliente = new ClienteRepositorio(ConnectionString); services.AddSingleton(repoCliente);

            services.AddAutoMapper(typeof(Mapper.PerfilDeMapeo));
            
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
