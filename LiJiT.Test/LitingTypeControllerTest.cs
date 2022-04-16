using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeItEasy;
using LiJiT.API.Controllers;
using LiJiT.Domain.DTO;
using LiJiT.Domain.IService;
using LiJiT.Model;
using Shouldly;
using Xunit;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace LiJiT.Test
{
    public class LitingTypeControllerTest
    {
 
        [Fact]
        public async Task GetAboutContentTestAsync()
        {
         
            var client = new RestSharp.RestClient("http://lijitapi.azurewebsites.net/AboutContent/About");
            var request = new RestRequest("http://lijitapi.azurewebsites.net/AboutContent/About", Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ARRAffinity=79e06db539acb57119e709978d2cf1da299e8341753d6f6345007fcab3f69bc5");
            var response = await client.ExecuteAsync(request);
            var result = JsonConvert.DeserializeObject<List<AboutContentDto>>(response.Content);
            result.Count().ShouldBe(2);
            result.First().Title1.ShouldNotBe(null);
            result.First().Content1.ShouldNotBe(null);

   
        }
        [Fact]
        public async Task GetCategoryDetailByIdTestAsync()
        {

            var client = new RestClient("https://lijitapi.azurewebsites.net/ListingDetail/getByCategoryId?categoryId=2");
            var request = new RestRequest("https://lijitapi.azurewebsites.net/ListingDetail/getByCategoryId?categoryId=2", Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ARRAffinity=22a7daa836b64a8ce56c907737553d08297ff2e76cd06a1f52c29956b9a85c17; ARRAffinitySameSite=22a7daa836b64a8ce56c907737553d08297ff2e76cd06a1f52c29956b9a85c17");
            var body = @" ";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);
            var result = JsonConvert.DeserializeObject<List<ListingDetailDto>>(response.Content);
            result.Count().ShouldBe(3);



        }
        [Fact]
        public async Task GetCategoryTestAsync()
        {

            var client = new RestClient("https://lijitapi.azurewebsites.net/ListingType/Category");
            var request = new RestRequest("https://lijitapi.azurewebsites.net/ListingType/Category", Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ARRAffinity=22a7daa836b64a8ce56c907737553d08297ff2e76cd06a1f52c29956b9a85c17; ARRAffinitySameSite=22a7daa836b64a8ce56c907737553d08297ff2e76cd06a1f52c29956b9a85c17");
            var body = @" ";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);
            var result = JsonConvert.DeserializeObject<List<ListingTypeDto>>(response.Content);
            result.Count().ShouldBe(5);
            result.First().Id.ShouldNotBe((Int16)0);
            result.First().Name.ShouldNotBeEmpty();
   
        }
        [Fact]
        public async Task GetCategoryDetailTestAsync()
        {

            var client = new RestClient("https://lijitapi.azurewebsites.net/ListingDetail/Stores");
            var request = new RestRequest("https://lijitapi.azurewebsites.net/ListingDetail/Stores", Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ARRAffinity=22a7daa836b64a8ce56c907737553d08297ff2e76cd06a1f52c29956b9a85c17; ARRAffinitySameSite=22a7daa836b64a8ce56c907737553d08297ff2e76cd06a1f52c29956b9a85c17");
            var body = @" ";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);
            var result = JsonConvert.DeserializeObject<List<ListingDetailDto>>(response.Content);
            result.Count().ShouldBeGreaterThanOrEqualTo(4);
      

        }
        [Fact]
        public async Task GetHottestTestAsync()
        {

            var client = new RestClient("https://lijitapi.azurewebsites.net/ListingDetail/getHottestStores");
            var request = new RestRequest("https://lijitapi.azurewebsites.net/ListingDetail/getHottestStores", Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ARRAffinity=22a7daa836b64a8ce56c907737553d08297ff2e76cd06a1f52c29956b9a85c17; ARRAffinitySameSite=22a7daa836b64a8ce56c907737553d08297ff2e76cd06a1f52c29956b9a85c17");
            var body = @" ";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);
            var result = JsonConvert.DeserializeObject<List<ListingDetailDto>>(response.Content);
            result.Count().ShouldNotBe(0);


        }
    }
}
