using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rap.Models;
using Rap.Services.Interfaces;

namespace RapServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly ILogger<FlightsController> _logger;
        private readonly IFlightService _service;

        public FlightsController(ILogger<FlightsController> logger, IFlightService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public List<FlightModel> Get() => _service.GetFlights();

        [HttpPost]
        public List<FlightModel> Post(FilterModel filters)
        {
            List<FlightModel> flights = Get();

            if (filters.Landed)
                flights = flights.Where(f => f.Landed).ToList();

            if (filters.Reused)
                flights = flights.Where(f => f.Reused).ToList();

            if (filters.Reddit)
                flights = flights.Where(f => f.Reddit).ToList();

            return flights;
        }
    }
}
