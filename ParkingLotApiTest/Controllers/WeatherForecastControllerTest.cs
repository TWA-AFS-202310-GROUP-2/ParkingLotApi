using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ParkingLotApiTest.Controllers
{
    public class WeatherForecastControllerTest
    {
        private HttpClient _httpClient;
        public WeatherForecastControllerTest()
        {
            WebApplicationFactory<Program> webApplicationFactory = new WebApplicationFactory<Program>();
            _httpClient = webApplicationFactory.CreateClient();
        }

        [Fact]
        public async Task Should_return_correct_when_get_weather_forecast()
        {
            //given and when
            HttpResponseMessage httpResponse = await _httpClient.GetAsync("/WeatherForecast");
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }
    }
}
