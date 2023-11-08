using Microsoft.AspNetCore.Mvc.Testing;

namespace ParkingLotApiTest;

public class TestBase: IClassFixture<WebApplicationFactory<Program>>
{
    
    protected WebApplicationFactory<Program>Factory { get; set; }

    public TestBase(WebApplicationFactory<Program> factory)
    {
        this.Factory = factory;
    }

    protected HttpClient GetClient()
    {
        return Factory.CreateClient();
    }
    
}