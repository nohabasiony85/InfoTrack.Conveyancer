using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using InfoTrack.Conveyancer.API.Models;
using InfoTrack.Conveyancer.Domain.Models;
using Microsoft.AspNetCore.Mvc.Testing;
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
    public async Task CreateReservation_WithValidRequest_ReturnSuccessful()
    {
        //Arrange
        var content = JsonConvert.SerializeObject(new CreateReservationRequest()
        {
            BookingTime = new BookingTime()
            {
                Hour = 12,
                Minute = 0,
            },
            Name = "Test"

        });
        
        //Act
        var response = await _httpClient.PostAsync("/settlement/reservation", new StringContent(content, Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        var createReservationResponse = JsonConvert.DeserializeObject<CreateReservationResponse>(result);

        //Assert
        Assert.True(createReservationResponse != null && Guid.TryParse(createReservationResponse.Id, out _));
    }
    
    [Fact]
    public async Task CreateReservation_WithConflictBookingTimeRequest_Return409Conflict()
    {
        //Arrange
        var content = JsonConvert.SerializeObject(new CreateReservationRequest()
        {
            BookingTime = new BookingTime()
            {
                Hour = 09,
                Minute = 0,
            },
            Name = "Test 2"

        });
        
        //Act
        var response = await _httpClient.PostAsync("/settlement/reservation", new StringContent(content, Encoding.UTF8, "application/json"));
        
        //Assert
        Assert.Equal(HttpStatusCode.Conflict , response.StatusCode);
    }
    
    [Fact]
    public async Task CreateReservation_WithOutOfHoursBookingTimeRequest_Return400BadRequest()
    {
        //Arrange
        var content = JsonConvert.SerializeObject(new CreateReservationRequest()
        {
            BookingTime = new BookingTime()
            {
                Hour = 19,
                Minute = 00,
            },
            Name = "Test 3"

        });
        
        //Act
        var response = await _httpClient.PostAsync("/settlement/reservation", new StringContent(content, Encoding.UTF8, "application/json"));
        
        //Assert
        Assert.Equal(HttpStatusCode.BadRequest , response.StatusCode);
    }
    
    
    [Fact]
    public async Task CreateReservation_WithInvalidTimeRequest_Return400BadRequest()
    {
        //Arrange
        var content = JsonConvert.SerializeObject(new CreateReservationRequest()
        {
            BookingTime = new BookingTime()
            {
                Hour = 190,
                Minute = 00,
            },
            Name = "Test 3"

        });
        
        //Act
        var response = await _httpClient.PostAsync("/settlement/reservation", new StringContent(content, Encoding.UTF8, "application/json"));
        
        //Assert
        Assert.Equal(HttpStatusCode.BadRequest , response.StatusCode);
    }
}