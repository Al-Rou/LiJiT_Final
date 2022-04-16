using LiJiT.Domain.DTO;
using Newtonsoft.Json;
using RestSharp;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LiJiT.Test
{
    public class AboutContentControllerTest
    {

        [Fact]
        public async Task GetAllTestAsync()
        {

            var client = new RestClient("https://lijitapi.azurewebsites.net/AboutContent/About");
            var request = new RestRequest("https://lijitapi.azurewebsites.net/AboutContent/About", Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ARRAffinity=22a7daa836b64a8ce56c907737553d08297ff2e76cd06a1f52c29956b9a85c17; ARRAffinitySameSite=22a7daa836b64a8ce56c907737553d08297ff2e76cd06a1f52c29956b9a85c17");
            var body = @" ";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);
            var result = JsonConvert.DeserializeObject<AboutContentDto>(response.Content);
            result.ShouldNotBeNull();


        }

    }
}
