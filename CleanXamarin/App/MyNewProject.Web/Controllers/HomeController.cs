using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyNewProject.Web.Models;
using Ooui.AspNetCore;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MyNewProject.UI.Orders.Views;
using MyNewProject.UseCases.Orders;
using MyNewProject.Web.ViewModels;
using Xamarin.Forms;

namespace MyNewProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MainPageViewModel _mainPageViewModel;

        public HomeController(ILogger<HomeController> logger, MainPageViewModel mainPageViewModel)
        {
            _logger = logger;
            _mainPageViewModel = mainPageViewModel;
        }

        public async Task<IActionResult> Index()
        {
            
            var page = new MyNewProject.UI.Orders.Views.MainPage();
            //var mainPageContext = new MainPageViewModel();
            //var orders = await _getCurrentUserOrders.Invoke();
            //foreach (var order in orders)
            //{
            //    mainPageContext.Orders.Add(order);
            //}

            //page.BindingContext = mainPageContext;
            page.BindingContext = _mainPageViewModel;
            var element = page.GetOouiElement();
            return new ElementResult(element, "Hello from XAML!");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
