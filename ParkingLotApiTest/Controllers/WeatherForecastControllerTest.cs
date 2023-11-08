using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ParkingLotApiTest.Controllers
{
    public class WeatherForecastControllerTest : TestBase
    {
        public WeatherForecastControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_return_correct_when_get_weather_forecast()
        {
            // given and when
            HttpClient httpClient = GetClient();
            HttpResponseMessage httpResponse = await httpClient.GetAsync("/WeatherForecast");
            // then
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }
    }
}
