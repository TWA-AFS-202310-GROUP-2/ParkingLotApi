using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi;
using ParkingLotApi.Dtos;

namespace ParkingLotApiTest.ControllersTest
{

    public class ParkingLotsControllerTest: TestBase
    {
        public ParkingLotsControllerTest(WebApplicationFactory<Program> factory):base(factory)
        {
        }

        [Fact]
        public async Task TestResult400_WhenCreateParkinglot_GivenCapacityLow()
        {
            var httpClient = GetClient();
            
            ParkingLotDto parkingLotDtoWithCapacityLess10 = new ParkingLotDto()
                {Name ="FirstPark",Capacity = 9,Location ="Building A"};
            HttpResponseMessage httpResponse =
                await httpClient.PostAsJsonAsync("/Parkinglots", parkingLotDtoWithCapacityLess10);
            
            Assert.Equal(HttpStatusCode.BadRequest,httpResponse.StatusCode);
        }
    }
}
