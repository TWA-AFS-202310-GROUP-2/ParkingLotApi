using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace ParkingLotApiTest
{
    public class WeatherForcastTest : TestBase
    {
        public WeatherForcastTest(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_return_200_when_get_weather_forcast()
        {
            // given
            var client = GetClient();

            // when
            var response = await client.GetAsync("/WeatherForecast");

            // then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}