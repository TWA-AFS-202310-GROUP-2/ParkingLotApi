using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.Controller
{
    public class ParkingLotsControllerTest : TestBase
    {
        public ParkingLotsControllerTest(WebApplicationFactory<Program> factory):base(factory)
        {
        }
        
        [Fact]
        public async void Should_return_bad_request_When_createParkinglot_Given_capacity_less_than_10()
        {
            //given
            ParkingLotDto parkingLotDto = new ParkingLotDto()
            {
                Name = "New ParkingLot",
                Capacity = 1,
                Location = "New Street"
            };
            //when
            HttpClient _httpClient = GetClient();//继承自他的父类
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync("/parkinglots", parkingLotDto);
            //then
            Assert.Equal(HttpStatusCode.BadRequest, responseMessage.StatusCode);
        }
    }
}
