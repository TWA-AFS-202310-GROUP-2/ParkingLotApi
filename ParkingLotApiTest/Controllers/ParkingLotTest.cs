using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;

namespace ParkingLotApiTest
{
    public class ParkingLotTest : TestBase
    {
        public ParkingLotTest(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ShouldCreateParkingLotSuccess_WhenCreateParkingLot_GivenCorrectParkingLot()
        {
            // given
            var client = GetClient();
            var parkingLot = new CreateParkingLotDto
            {
                Name = "parkingLot1",
                Capacity = 100,
                Location = "location1"
            };

            var requestContent = new StringContent(JsonConvert.SerializeObject(parkingLot), Encoding.UTF8, "application/json");

            // when
            var response = await client.PostAsync("/api/parkinglots",requestContent);

            // then
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
        }

    }
}