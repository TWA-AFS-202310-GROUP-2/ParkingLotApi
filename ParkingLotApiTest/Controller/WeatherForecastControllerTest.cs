using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.Controller
{
    public class WeatherForecastControllerTest
    {
        private readonly HttpClient _httpClient;
        public WeatherForecastControllerTest()
        {
            WebApplicationFactory<Program> webApplicationFactory = new WebApplicationFactory<Program>();
            _httpClient = webApplicationFactory.CreateClient();
        }
        [Fact]
        public async void Should_return_correct_When_whetherForcast_Given_date()
        {
            //given & when
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("/WeatherForecast");
            //then
            Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        }
    }
}
