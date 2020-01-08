using AutoMapper;
using Rap.Data;
using Rap.Models;
using Rap.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Rap.Services.Implementations
{
    public class FlightService: IFlightService
    {
        private ApplicationDbContext _ctx;
        private IMapper _mapper;

        public FlightService(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public List<FlightModel> GetFlights() => _mapper.Map<List<FlightModel>>(_ctx.Flights.ToList());
    }
}
