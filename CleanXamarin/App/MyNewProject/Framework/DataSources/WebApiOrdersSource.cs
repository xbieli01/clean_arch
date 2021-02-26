using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MyNewProject.Data.Orders;
using MyNewProject.Domain.Orders;

namespace MyNewProject.Framework.DataSources
{
    public class WebApiOrdersSource : IOrdersSource
    {
        private HttpClient client;

        public WebApiOrdersSource()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:19135/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IReadOnlyList<Order>> GetAll()
        {
            List<Order> orders = new List<Order>();
            HttpResponseMessage response = await client.GetAsync("api/order");
            if (response.IsSuccessStatusCode)
            {
                orders = await response.Content.ReadAsAsync<List<Order>>();
            }
            return orders;
        }
    }
}
