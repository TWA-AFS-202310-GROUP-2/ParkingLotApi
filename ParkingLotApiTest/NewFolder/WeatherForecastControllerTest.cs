using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi;

namespace ParkingLotApiTest.NewFolder
{
    public class WeatherForecastControllerTest
    {
        private HttpClient _httpClient;
        public WeatherForecastControllerTest()
        {
            var factory = new WebApplicationFactory<Program>();
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task TestResult_ReturnSucceed_GetWeatherForecasts()
        {
            var response = await _httpClient.GetAsync("/WeatherForecast");
            var WeatherForecastList = await response.Content.ReadFromJsonAsync<List<WeatherForecast>>();
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
            Assert.Equal(5,WeatherForecastList.Count);
        }
    }
}
