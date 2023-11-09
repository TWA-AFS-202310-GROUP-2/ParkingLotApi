using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.Controller
{
    public class WeatherForecastControllerTest : TestBase
    {
        public WeatherForecastControllerTest(WebApplicationFactory<Program> factory):base(factory)
        {
        }
        
        [Fact]
        public async void Should_return_correct_When_whetherForcast_Given_date()
        {
            //given & when
            HttpClient _httpClient = GetClient();//继承自他的父类
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("/WeatherForecast");
            //then
            Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        }
    }
}
