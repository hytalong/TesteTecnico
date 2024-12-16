using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using School.API.Data;

namespace School.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Configura os serviços da aplicação.
        public void ConfigureServices(IServiceCollection services)
        {
            //DbContext com SQL Server
            services.AddDbContext<UsuarioContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
            ));

            // Adiciona serviços do controlador (MVC e APIs).
            services.AddControllers();

            // Adiciona suporte ao Swagger para documentação da API.
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "School API", Version = "v1" });
            });
        }

        // Configura o pipeline de requisição HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           if (env.IsDevelopment())
            {
                // Ativa o Swagger apenas em ambiente de desenvolvimento.
                app.UseDeveloperExceptionPage(); // Exibe erro detalhado no navegador
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Configura o roteamento e segurança.
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Mapeia os controladores da API.
            });
        }
    }
}