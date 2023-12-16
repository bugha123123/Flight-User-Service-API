using BookFlight.Data;
using BookFlight.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookFlight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public FlightsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/Flights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookFlightModel>>> GetFlights()
        {
            return await _context.Flights.ToListAsync();
        }


    }
}
