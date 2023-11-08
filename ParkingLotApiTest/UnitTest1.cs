using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace ParkingLotApiTest
{
    public class WeatherForcastControllerTest : TestBase
    {
        public WeatherForcastControllerTest(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact]
        public async Task Test1()
        {
            HttpClient httpClient = GetClient();
            HttpResponseMessage response = await httpClient.GetAsync("/WeatherForecast");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}