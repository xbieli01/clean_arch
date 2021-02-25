using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNewProject.Domain.Orders;
using MyNewProject.UI.ViewModels;
using MyNewProject.UseCases.Orders;

namespace MyNewProject.Web.ViewModels
{
    public class MainPageViewModel 
    {
        public ObservableCollection<Order> Orders { get; set; }
        public string Title { get; set; }
        private readonly GetCurrentUserOrders _getCurrentUserOrders;

        public MainPageViewModel(GetCurrentUserOrders getCurrentUserOrders)
        {
            Title = "Orders Main Page";
            Orders = new ObservableCollection<Order>();
            _getCurrentUserOrders = getCurrentUserOrders;
            LoadOrders();
        }

        private async void LoadOrders()
        {
            var resultOrders = await _getCurrentUserOrders.Invoke();
            foreach (var item in resultOrders)
            {
                Orders.Add(item);
            }
        }
    }
}