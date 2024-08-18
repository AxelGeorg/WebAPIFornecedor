using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIFornecedor.Business;
using WebAPIFornecedor.Business.Implementations;
using WebAPIFornecedor.Model.Context;
using WebAPIFornecedor.Repository;

namespace WebAPIFornecedor
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

            var connection = Configuration["ConnectionStrings:MySqlConnection"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Web API em C# utilizando ASP.NET Core and Docker",
                        Version = "v1",
                        Description = "Web API em C# utilizando ASP.NET Core and Docker'",
                        Contact = new OpenApiContact
                        {
                            Name = "Axel Georg",
                            Url = new Uri("https://github.com/AxelGeorg")
                        }
                    });
            });

            // Dependency Injection
            //services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IFornecedorBusiness, FornecedorBusinessImplementation>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API em C# utilizando ASP.NET Core - v1");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
