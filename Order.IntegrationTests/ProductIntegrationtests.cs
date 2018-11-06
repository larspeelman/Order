using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Order_Api.DTO;
using Order_Domain.Products;
using System.Collections.Generic;

namespace Order.IntegrationTests
{
    public class ProductIntegrationtests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ProductIntegrationtests()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

            _client = _server.CreateClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            ProductDB.DBProducts.Clear();
            

        }

        [Fact]
        public async Task AddNewProduct_WhengivenANewProduct_ThenProductIsAddedToDatabase()
        {
            var productone = (new Product()
            {
                Name = "iphone8",
                Description = "gsm",
                Price = 200.00M,
                Amount = 100,
                ID = "10"
            });
            ProductDB.DBProducts.Add(productone);

            var content = JsonConvert.SerializeObject(productone);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/product", stringContent);

            Assert.Equal(1, ProductDB.DBProducts.Count);
        }
    }
}
