using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Dtos;
using System.Net;
using System.Net.Http.Json;

namespace ParkingLotApiTest
{
    public class ParkingLotsControllerTest : TestBase
    {
        public ParkingLotsControllerTest(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact]
        public async Task Should_return_400_when_create_parking_lot_given_capacity_less_than_10()
        {
            ParkingLotDto ParkingLotDtoWithCapacityLessThan10 = new ParkingLotDto() 
            {   
              Name = "ABC",
              Capacity = 9,
              Location = "My home"
            };

            HttpClient httpClient = GetClient();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("/ParkingLots", ParkingLotDtoWithCapacityLessThan10);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}