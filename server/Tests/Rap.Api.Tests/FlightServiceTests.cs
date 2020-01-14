using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rap.Data;
using Rap.Models;
using Rap.Services.Implementations;
using System;
using System.Linq;
using Xunit;

namespace Rap.Api.Tests
{
    public class FlightServiceTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;
        private readonly MapperConfiguration _mapper;

        public FlightServiceTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ApplicationDatabase")
            .Options;

            using (var context = new ApplicationDbContext(_options))
            {
                if (!context.Flights.Any())
                {
                    context.Flights.AddRange(new Flight[]
                    {
                        new Flight
                        {
                            Details = "Engine failure at 33 seconds and loss of vehicle",
                            LandSuccess = false,
                            LaunchDateUTC = new DateTime(2006, 03, 24, 22, 30, 0),
                            ArticleLink = "https://www.space.com/2196-spacex-inaugural-falcon-1-rocket-lost-launch.html",
                            MissionName = "FalconSat",
                            RedditCampaign = true,
                            Reuse = false,
                            RocketName = "Merlin A",
                            FlightNumber = 1,
                            MissionPatch = "",
                            RocketType = ""
                        },
                        new Flight
                        {
                            Details = "Engine failure at 33 seconds and loss of vehicle",
                            LandSuccess = false,
                            LaunchDateUTC = new DateTime(2006, 03, 24, 22, 30, 0),
                            ArticleLink = "https://www.space.com/2196-spacex-inaugural-falcon-1-rocket-lost-launch.html",
                            MissionName = "TESS",
                            RedditCampaign = true,
                            Reuse = true,
                            RocketName = "Merlin A",
                            FlightNumber = 2,
                            MissionPatch = "",
                            RocketType = ""
                        },
                        new Flight
                        {
                            Details = "Engine failure at 33 seconds and loss of vehicle",
                            LandSuccess = true,
                            LaunchDateUTC = new DateTime(2006, 03, 24, 22, 30, 0),
                            ArticleLink = "https://www.space.com/2196-spacex-inaugural-falcon-1-rocket-lost-launch.html",
                            MissionName = "CRS-14",
                            RedditCampaign = true,
                            Reuse = false,
                            RocketName = "Merlin A",
                            FlightNumber = 3,
                            MissionPatch = "",
                            RocketType = ""
                        },
                        new Flight
                        {
                            Details = "Engine failure at 33 seconds and loss of vehicle",
                            LandSuccess = true,
                            LaunchDateUTC = new DateTime(2006, 03, 24, 22, 30, 0),
                            ArticleLink = "https://www.space.com/2196-spacex-inaugural-falcon-1-rocket-lost-launch.html",
                            MissionName = "Iridium NEXT Mission 5",
                            RedditCampaign = true,
                            Reuse = true,
                            RocketName = "Merlin A",
                            FlightNumber = 4,
                            MissionPatch = "",
                            RocketType = ""
                        },
                        new Flight
                        {
                            Details = "Engine failure at 33 seconds and loss of vehicle",
                            LandSuccess = false,
                            LaunchDateUTC = new DateTime(2006, 03, 24, 22, 30, 0),
                            ArticleLink = "https://www.space.com/2196-spacex-inaugural-falcon-1-rocket-lost-launch.html",
                            MissionName = "Hispasat 30W-6",
                            RedditCampaign = false,
                            Reuse = false,
                            RocketName = "Merlin A",
                            FlightNumber = 5,
                            MissionPatch = "",
                            RocketType = ""
                        }
                    });

                    context.SaveChanges();
                }
            }

            _mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile<FlightModelMapper>());
        }

        [Fact]
        public void TestAutomapperConfig()
        {
            _mapper.AssertConfigurationIsValid();
        }

        [Fact]
        public void TestGetFlights()
        {
            using (var ctx = new ApplicationDbContext(_options))
            {
                var service = new FlightService(ctx, _mapper.CreateMapper());
                var results = service.GetFlights();

                Assert.Equal(5, results.Count);

                Assert.Equal("FalconSat", results[0].Name);
                Assert.Equal("TESS", results[1].Name);
                Assert.Equal("CRS-14", results[2].Name);
                Assert.Equal("Iridium NEXT Mission 5", results[3].Name);
                Assert.Equal("Hispasat 30W-6", results[4].Name);
            }
        }
    }
}
