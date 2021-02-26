using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MyNewProject.Data.Orders;
using MyNewProject.Domain.Orders;

namespace MyNewProject.Framework.DataSources
{
    public class WebApiOrdersSource : IOrdersSource
    {
        private HttpClient client;

        public WebApiOrdersSource()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .AddJsonFile("config.json");
            var configuration = builder.Build();

            var serviceURL = configuration["DBService:BaseAddress"];

            client = new HttpClient();
            client.BaseAddress = new Uri(serviceURL);
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
