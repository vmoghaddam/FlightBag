using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using APCore.Models;
using APCore.Services;
using APCore.ViewModels;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APCore.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private  IFlightService _flightService;

        public FlightsController(IFlightService flightService)
        {

            _flightService = flightService;
        }

        [EnableQuery()]  // requires using Microsoft.AspNet.OData;
        [HttpGet]
        [Route("api/crew/flights/query")]
        public ActionResult<IQueryable<AppCrewFlight>> GetCrewFlightsQuery()
        {
            return _flightService.GetCrewFlightsQuery();
        }
        [EnableQuery()]  // requires using Microsoft.AspNet.OData;
        [HttpGet]
        [Route("api/flights/query")]
        public ActionResult<IQueryable<AppLeg>> GetFlightsQuery()
        {
            return _flightService.GetFlightsQuery();
        }
        [HttpGet]
        [Authorize]
        [Route("api/crew/flights/{from}/{to}")]
        public async Task<IActionResult> GetCrewFlights(DateTime from,DateTime to)
        {
            var userData = User.FindFirst(ClaimTypes.UserData).Value;
            var crewId = Objects.AuthDataHelper.GetEmployeeId(userData);
            var result =await _flightService.GetCrewFlights(crewId,from,to);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("api/crew/calendar/ym/{crewId}/{year}/{month}")]
        public async Task<IActionResult> GetCrewCalendar(int crewId,int year,int month)
        {
            var userData = User.FindFirst(ClaimTypes.UserData).Value;
             
            var result = await _flightService.GetCrewCalendarByYearMonth(crewId, year, month);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("api/crew/calendar/{crewId}/{from}/{to}")]
        public async Task<IActionResult> GetCrewCalendarByRange(int crewId, DateTime from,DateTime to)
        {
            var userData = User.FindFirst(ClaimTypes.UserData).Value;

            var result = await _flightService.GetCrewCalendarByYearMonth(crewId, from, to);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("api/crew/duties/{crewId}/{from}/{to}/{nofdp}")]
        public async Task<IActionResult> GetCrewDuties(int crewId, DateTime from, DateTime to,int nofdp)
        {
            var userData = User.FindFirst(ClaimTypes.UserData).Value;

            var result = await _flightService.GetCrewDuties(crewId, from, to,nofdp);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("api/flight/crews/{flightId}")]
        public async Task<IActionResult> GetFlightCrews(int flightId)
        {
           // var userData = User.FindFirst(ClaimTypes.UserData).Value;
            //var crewId = Objects.AuthDataHelper.GetEmployeeId(userData);
            var result = await _flightService.GetFlightCrews(flightId);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("api/flight/{flightId}")]
        public async Task<IActionResult> GetFlight(int flightId)
        {
            // var userData = User.FindFirst(ClaimTypes.UserData).Value;
            //var crewId = Objects.AuthDataHelper.GetEmployeeId(userData);
            var result = await _flightService.GetFlight(flightId);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("api/flight/delays/{flightId}")]
        public async Task<IActionResult> GetFlightDelays(int flightId)
        {
            // var userData = User.FindFirst(ClaimTypes.UserData).Value;
            //var crewId = Objects.AuthDataHelper.GetEmployeeId(userData);
            var result = await _flightService.GetFlightDelays(flightId);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        [Route("api/flight/log/save")]
        public async Task<IActionResult> SaveFlightLog(LogViewModel log)
        {
            var result = await _flightService.SaveLog(log);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpPost] 
        [Authorize]
        [Route("api/flight/log/check")]
        public async Task<IActionResult> CheckFlightLog(  LogViewModel log)
        {
            var result = await _flightService.CheckLog(log);
            
            return Ok(result);
        }


        //GET: api/Airports
        //[HttpGet]
        //[Route("api/airports")]
        //public async Task<ActionResult<IEnumerable<Airport>>> GetAirports()
        //{

        //    return await _context.Airports.ToListAsync();
        //}

        //[HttpGet]
        //[Route("api/airport/iata/{iata}")]
        //public async Task<ActionResult<Airport>> GetAirportByIATA(string iata)
        //{

        //    return await _context.Airports.FirstOrDefaultAsync(q => q.Iata == iata);
        //}
        //[HttpGet]
        //[Authorize]
        //[Route("api/airport/iata2/{iata}")]
        //public async Task<IActionResult> GetAirportByIATA2(string iata)
        //{
        //    var v1 = User.Claims.ToList();
        //    var v2 = User.Identity.Name;
        //    var v3 = User.FindFirst("Email");
        //    var v4 = User.FindFirst(ClaimTypes.UserData);
        //    var v5 = User.FindFirst(ClaimTypes.NameIdentifier);
        //    var apt = await _context.Airports
        //        .Include(q => q.City)
        //        .FirstOrDefaultAsync(q => q.Iata == iata);
        //    if (apt == null)
        //        return NotFound("airport not found");
        //    return Ok(apt);
        //}
        //[HttpGet("apts")]
        //// [EnableQuery]
        //public async Task<ActionResult<IEnumerable<Airport>>> ListAPTS()
        //{
        //    //return _context.Airports;
        //    return await _context.Airports.Take(10).ToListAsync();
        //}
    }
}
