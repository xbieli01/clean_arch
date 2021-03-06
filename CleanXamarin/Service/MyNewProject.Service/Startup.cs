using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyNewProject.Domain.Orders;
using MyNewProject.Service.Models;
using MyNewProject.Service.Models.DataManager;
using MyNewProject.Service.Models.Repository;
using Pomelo.EntityFrameworkCore.MySql.Storage;

namespace MyNewProject.Service
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
            // ms sql server
            services.AddDbContext<MyNewProjectContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:MyNewProjectDB"]));
            //// mysql
            //services.AddDbContextPool<MyNewProjectContext>(opts => opts.UseMySql(Configuration["ConnectionString:MyNewProjectDB"]));
            //// oracle
            //services.AddDbContextPool<MyNewProjectContext>(opts => opts.UseOracle(Configuration["ConnectionString:MyNewProjectDB"]));


            services.AddScoped<IDataRepository<Order>, OrderManager>();
            services.AddControllers();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
