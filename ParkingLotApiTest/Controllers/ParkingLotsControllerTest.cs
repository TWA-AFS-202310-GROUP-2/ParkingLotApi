using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi;
using ParkingLotApi.Dtos;

namespace ParkingLotApiTest.Controllers
{
    public class ParkingLotsControllerTest : TestBase
    {
        public ParkingLotsControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_return_400_when_create_parking_lot_given_capacity_less_than_10()
        {
            // given and when
            HttpClient httpClient = GetClient();
            ParkingLotDto ParkingLotDtoWithCapacityLessThan10 = new ParkingLotDto()
            { 
                Name = "Park1",
                Capacity = 9,
                Location = "Building"
            };
            // when
            HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync("/ParkingLots", ParkingLotDtoWithCapacityLessThan10);
            // then
            Assert.Equal(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }
    }
}
