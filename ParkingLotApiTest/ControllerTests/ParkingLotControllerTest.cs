using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.ControllerTests
{
    public class ParkingLotControllerTest : TestBase
    {
        public ParkingLotControllerTest(WebApplicationFactory<Program> webApplicationFactory) : base(webApplicationFactory)
        {
        }

        [Fact]
        public async Task Should_return_400_bad_request_when_create_parking_lot_given_capacity_less_than_10()
        {
            var parkingLot = new ParkingLotRequest()
            {
                Name = "parking lot 1",
                Capacity = 9,
                Location = "Street No.1"
            };

            HttpResponseMessage httpResponse =  await GetClient().PostAsJsonAsync("api/v1/parkinglots", parkingLot);
            Assert.Equal(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }
    }
}
