using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoImunobiologico.Dominio.Services;
using ProjetoImunobiologico.Dominio.Services.Interfaces;
using ProjetoImunobiologico.Infraestrutura.Configuration;
using ProjetoImunobiologico.Infraestrutura.Repository;
using ProjetoImunobiologico.Infraestrutura.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoImunobiologico.Front
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

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            //Cors
            services.AddCors();

            //services.AddControllers()
            //.AddFluentValidation(s =>
            //{
            //    s.RegisterValidatorsFromAssemblyContaining<Startup>();
            //    s.DisableDataAnnotationsValidation = false;
            //});



            //services.AddDbContext<ImunizanteContext>(options =>
            //   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Injeção de Dependencia
            services.AddScoped<IImunizanteService, ImunizanteService>();

            services.AddScoped<IImunizanteRepository, ImunizanteRepository>();

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
