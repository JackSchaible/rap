using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rap.Data;

namespace RapServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly ILogger<FlightsController> _logger;
        private readonly ApplicationDbContext _ctx;

        public FlightsController(ILogger<FlightsController> logger, ApplicationDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<Flight> Get()
        {
            return _ctx.Flights;
        }
    }
}
