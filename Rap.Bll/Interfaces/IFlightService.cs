using Rap.Models;
using System.Collections.Generic;

namespace Rap.Services.Interfaces
{
    public interface IFlightService
    {
        List<FlightModel> GetFlights();
    }
}
