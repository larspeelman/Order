using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Order_Api.DTO;
using Order_Domain.items;
using System.Collections.Generic;

namespace Order.IntegrationTests
{
    public class itemIntegrationtests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        //public itemIntegrationtests()
        //{
        //    // Arrange
        //    _server = new TestServer(new WebHostBuilder()
        //        .UseStartup<Startup>());

        //    _client = _server.CreateClient();
        //    _client.DefaultRequestHeaders.Accept.Clear();
        //    _client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));

        //    itemDB.DBitems.Clear();
            

        //}

        //[Fact]
        //public async Task AddNewitem_WhengivenANewitem_ThenitemIsAddedToDatabase()
        //{
        //    var itemone = (new Items()
        //    {
        //        Name = "iphone8",
        //        Description = "gsm",
        //        Price = 200.00M,
        //        Amount = 100,
        //        ItemID = "10"
        //    });
        //    itemDB.DBitems.Add(itemone);

        //    var content = JsonConvert.SerializeObject(itemone);
        //    var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

        //    var response = await _client.PostAsync("/api/item", stringContent);

        //    Assert.Collection(List, );
        //}
    }
}
