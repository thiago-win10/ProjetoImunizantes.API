using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjetoImunobiologico.Infraestrutura.Configuration;
using System;
using FluentValidation.AspNetCore;
using ProjetoImunobiologico.Dominio.Services.Interfaces;
using ProjetoImunobiologico.Dominio.Services;
using ProjetoImunobiologico.Infraestrutura.Repository.Interfaces;
using ProjetoImunobiologico.Infraestrutura.Repository;

namespace ProjetoImunobiologico.API
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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            //Cors
            services.AddCors();

            services.AddControllers()
            .AddFluentValidation(s =>
            {
            s.RegisterValidatorsFromAssemblyContaining<Startup>();
                s.DisableDataAnnotationsValidation = false;
            });



            services.AddDbContext<ImunizanteContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            //Injeção de Dependencia
            services.AddScoped<IImunizanteService, ImunizanteService>();

            services.AddScoped<IImunizanteRepository, ImunizanteRepository>();



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjetoImunobiologico.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoImunobiologico.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}