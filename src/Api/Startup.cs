using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Project.Api.Helpers;
using Project.Application;
using Project.Domain.Product;
using Project.Infra;
using Project.Infra.Data;
using Project.Infra.Repositories;

namespace Project.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add serices to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlServerConnection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ProductDbContext>(
                options => options.UseSqlServer(sqlServerConnection, b => b.MigrationsAssembly("Api")));            

            services.AddControllers().AddNewtonsoftJson();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });

            services.AddRazorPages();

            AddMediatr(services);

            services.AddTransient<IProductRepository, ProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(
                x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));

            app.UseAuthorization();
        }

        public void AddMediatr(IServiceCollection services)
        {
            var applicationAssembly = Assembly.GetAssembly(typeof(ApplicationAssemblyRef));
            var infraAssembly = Assembly.GetAssembly(typeof(InfraAssemblyRef));

            services.AddValidatorsFromAssemblies(new List<Assembly>
                {
                    applicationAssembly,
                    infraAssembly
                });

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddMediatR(applicationAssembly, infraAssembly);
        }
    }
}
