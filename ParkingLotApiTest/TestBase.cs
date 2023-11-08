using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest
{
    public class TestBase : IClassFixture<WebApplicationFactory<Program>>
    {
        protected WebApplicationFactory<Program> webApplicationFactory { get; }
        
        public TestBase(WebApplicationFactory<Program> webApplicationFactory) { 
            this.webApplicationFactory = webApplicationFactory;
        }
        
        protected HttpClient GetClient()
        {
            return webApplicationFactory.CreateClient();
        }

    }
}
