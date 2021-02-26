using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyNewProject.Data.Orders;
using MyNewProject.Framework.DataSources;
using MyNewProject.UI.Orders.ViewModels;
using MyNewProject.UI.Orders.Views;
using MyNewProject.UseCases.Orders;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using MainPageViewModel = MyNewProject.Web.ViewModels.MainPageViewModel;

namespace MyNewProject.Web
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
            services.AddTransient<MainPageViewModel>();
            services.AddTransient<OrdersRepository>();
            services.AddTransient<IOrdersSource, WebApiOrdersSource>();
            services.AddTransient<GetCurrentUserOrders>();
            services.AddControllersWithViews();
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
            }
            app.UseStaticFiles();

            app.UseOoui();

            Xamarin.Forms.Forms.Init();

            //var appXamarin = new App();
            //var containerRegistry = appXamarin.Container.GetContainer();
            //containerRegistry.RegisterType(OrdersRepository);

            //containerRegistry.RegisterForNavigation<NavigationPage>();
            //containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            //containerRegistry.Register<OrdersRepository>();
            //containerRegistry.Register<IOrdersSource, InMemoryOrdersSource>();
            //containerRegistry.Register<GetCurrentUserOrders>();

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
