using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.Controllers
{
    public class WeatherForecastControllerTest : TestBase
    {
        public WeatherForecastControllerTest(WebApplicationFactory<Program> webApplicationFactory) : base(webApplicationFactory)
        {
        }

        [Fact]
        public async Task Should_return_weatherForecast_list_when_getAll()
        {
            var httpResponseMessage = await GetClient().GetAsync("/WeatherForecast");
            var weatherForecasts = await httpResponseMessage.Content.ReadFromJsonAsync<List<WeatherForecast>>();

            Assert.NotNull(weatherForecasts);
        }
    }
}
