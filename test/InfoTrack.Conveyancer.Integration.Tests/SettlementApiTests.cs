using System;
using System.Net.Http;
using System.Threading.Tasks;
using InfoTrack.Conveyancer.API.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Xunit;

namespace InfoTrack.Conveyancer.Integration.Tests;

public class SettlementApiTests
{
    private readonly HttpClient _httpClient;
    
    public SettlementApiTests()
    {
        var webApplicationFactory = new WebApplicationFactory<Program>();
        _httpClient = webApplicationFactory.CreateDefaultClient();
    }
    
    [Fact]
    public async Task Test1()
    {
        //Arrange
        var content = JsonConvert.SerializeObject(new CreateReservationRequest()
        {

        });
        var response = await _httpClient.PostAsync("/api/settlement/reservation", new StringContent(content));
        
        //Act
        var result = await response.Content.ReadAsStringAsync();

        //Assert
        Assert.True(!string.IsNullOrEmpty(result));
    }
}