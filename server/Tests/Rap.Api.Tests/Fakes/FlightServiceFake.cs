using System;
using System.Collections.Generic;
using Rap.Models;
using Rap.Services.Interfaces;

namespace Rap.Api.Tests.Fakes
{
    internal class FlightServiceFake : IFlightService
    {
        public FlightServiceFake()
        {

        }

        public List<FlightModel> GetFlights()
        {
            return new List<FlightModel>
            {
                new FlightModel
                {
                    Badge = "https://images2.imgbox.com/40/e3/GypSkayF_o.png",
                    Details = "Engine failure at 33 seconds and loss of vehicle",
                    ID = 1,
                    Landed = false,
                    LaunchDate = new DateTime(2006, 03, 24, 22, 30, 0),
                    Link = "https://www.space.com/2196-spacex-inaugural-falcon-1-rocket-lost-launch.html",
                    Name = "FalconSat",
                    Reddit = true,
                    Reused = false,
                    Type = "Merlin A"
                },
                new FlightModel
                {
                    Badge = "https://images2.imgbox.com/7d/2c/pYXpOVCz_o.png",
                    Details = "Part of the Explorers program, this space telescope is intended for wide-field search of exoplanets transiting nearby stars. It is the first NASA high priority science mission launched by SpaceX. It was the first time SpaceX launched a scientific satellite not primarily intended for Earth observations. The second stage placed it into a high-Earth elliptical orbit, after which the satellite's own booster will perform complex maneuvers including a lunar flyby, and over the course of two months, reach a stable, 2:1 resonant orbit with the Moon. In January 2018, SpaceX received NASA's Launch Services Program Category 2 certification of its Falcon 9 'Full Thrust', certification which is required for launching medium risk missions like TESS. It was the last launch of a new Block 4 booster, and marked the 24th successful recovery of the booster. An experimental water landing was performed in order to attempt fairing recovery.",
                    ID = 2,
                    Landed = true,
                    LaunchDate = new DateTime(2006, 03, 24, 22, 30, 0),
                    Link = "https://www.space.com/2196-spacex-inaugural-falcon-1-rocket-lost-launch.html",
                    Name = "TESS",
                    Reddit = true,
                    Reused = true,
                    Type = "Merlin A"
                },
                new FlightModel
                {
                    Badge = "https://images2.imgbox.com/40/e3/GypSkayF_o.png",
                    Details = "Engine failure at 33 seconds and loss of vehicle",
                    ID = 3,
                    Landed = false,
                    LaunchDate = new DateTime(2006, 03, 24, 22, 30, 0),
                    Link = "https://www.space.com/2196-spacex-inaugural-falcon-1-rocket-lost-launch.html",
                    Name = "CRS-14",
                    Reddit = true,
                    Reused = false,
                    Type = "Merlin A"
                },
                new FlightModel
                {
                    Badge = "https://images2.imgbox.com/40/e3/GypSkayF_o.png",
                    Details = "Engine failure at 33 seconds and loss of vehicle",
                    ID = 4,
                    Landed = false,
                    LaunchDate = new DateTime(2006, 03, 24, 22, 30, 0),
                    Link = "https://www.space.com/2196-spacex-inaugural-falcon-1-rocket-lost-launch.html",
                    Name = "Iridium NEXT Mission 5",
                    Reddit = true,
                    Reused = false,
                    Type = "Merlin A"
                },
                new FlightModel
                {
                    Badge = "https://images2.imgbox.com/40/e3/GypSkayF_o.png",
                    Details = "Engine failure at 33 seconds and loss of vehicle",
                    ID = 5,
                    Landed = false,
                    LaunchDate = new DateTime(2006, 03, 24, 22, 30, 0),
                    Link = "https://www.space.com/2196-spacex-inaugural-falcon-1-rocket-lost-launch.html",
                    Name = "Hispasat 30W-6",
                    Reddit = true,
                    Reused = false,
                    Type = "Merlin A"
                },
            };
        }
    }
}
