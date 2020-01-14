using Rap.Api.Tests.Fakes;
using Rap.Models;
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

        [Fact]
        public void FilterAllFalseTest()
        {
            var filterModel = new FilterModel
            {
                Landed = false,
                Reddit = false,
                Reused = false
            };

            var results = _controller.Post(filterModel);

            Assert.Empty(results);
        }

        [Fact]
        public void FilterLandedTest()
        {
            var filterModel = new FilterModel
            {
                Landed = true,
                Reddit = false,
                Reused = false
            };

            var results = _controller.Post(filterModel);

            Assert.Single(results);
        }

        [Fact]
        public void FilterLandedAndRedditTest()
        {
            var filterModel = new FilterModel
            {
                Landed = true,
                Reddit = true,
                Reused = false
            };

            var results = _controller.Post(filterModel);

            Assert.Single(results);
        }

        [Fact]
        public void FilterAllTrueTest()
        {
            var filterModel = new FilterModel
            {
                Landed = true,
                Reddit = true,
                Reused = true
            };

            var results = _controller.Post(filterModel);

            Assert.Single(results);
        }

        [Fact]
        public void FilterLandedAndReusedTest()
        {
            var filterModel = new FilterModel
            {
                Landed = true,
                Reddit = false,
                Reused = true
            };

            var results = _controller.Post(filterModel);

            Assert.Empty(results);
        }

        [Fact]
        public void FilterRedditAndReusedTest()
        {
            var filterModel = new FilterModel
            {
                Landed = false,
                Reddit = true,
                Reused = true
            };

            var results = _controller.Post(filterModel);

            Assert.Empty(results);
        }

        [Fact]
        public void FilterRedditTest()
        {
            var filterModel = new FilterModel
            {
                Landed = false,
                Reddit = true,
                Reused = false
            };

            var results = _controller.Post(filterModel);

            Assert.Empty(results);
        }

        [Fact]
        public void FilterReusedTest()
        {
            var filterModel = new FilterModel
            {
                Landed = false,
                Reddit = false,
                Reused = true
            };

            var results = _controller.Post(filterModel);

            Assert.Empty(results);
        }
    }
}
