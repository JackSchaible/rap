using Rap.Api.Tests.Fakes;
using RapServer.Controllers;
using Xunit;

namespace Rap.Api.Tests
{
    public class FlightsControllerTests
    {
        private readonly FlightsController _controller;

        public FlightsControllerTests()
        {
            var service = new FlightServiceFake();
            _controller = new FlightsController(null, service);
        }

        [Fact]
        public void GetResponseTest()
        {
            var results = _controller.Get();

            Assert.Equal(5, results.Count);

            Assert.Equal("FalconSat", results[0].Name);
            Assert.Equal("TESS", results[1].Name);
            Assert.Equal("CRS-14", results[2].Name);
            Assert.Equal("Iridium NEXT Mission 5", results[3].Name);
            Assert.Equal("Hispasat 30W-6", results[4].Name);
        }
    }
}
