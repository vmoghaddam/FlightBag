using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using APCore.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HtmlAgilityPack;
using System.Net;
using System.Text.RegularExpressions;
using APCore.Services;

namespace APCore.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly ppa_cspnContext _context;
        private IAirportService _airportService;
        private IFlightService _flightService;


        public AirportsController(ppa_cspnContext context,IAirportService airportService, IFlightService flightService)
        {

            _context = context;
            _airportService = airportService;
            _flightService = flightService;
        }
        //GET: api/Airports
        //[HttpGet]
        //[Route("api/airports")]
        //public async Task<ActionResult<IEnumerable<Airport>>> GetAirports()
        //{

        //    return await _context.Airports.ToListAsync();
        //}
        [EnableQuery()]  // requires using Microsoft.AspNet.OData;
        [HttpGet]
        [Route("api/airports")]
        public ActionResult<IQueryable<Airport>> GetAirportsQuery()
        {
            return _context.Airports;
        }
        [HttpGet]
        [Route("api/airport/iata/{iata}")]
        public async Task<ActionResult<Airport>> GetAirportByIATA(string iata)
        {

            return await _context.Airports.FirstOrDefaultAsync(q => q.IATA == iata);
        }
        [HttpGet]
        [Authorize]
        [Route("api/airport/iata2/{iata}")]
        public async Task<IActionResult> GetAirportByIATA2(string iata)
        {
            var v1 = User.Claims.ToList();
            var v2 = User.Identity.Name;
            var v3 = User.FindFirst("Email");
            var v4 = User.FindFirst(ClaimTypes.UserData);
            var v5 = User.FindFirst(ClaimTypes.NameIdentifier);
            var apt = await _context.Airports
                .Include(q => q.City)
                .FirstOrDefaultAsync(q => q.IATA == iata);
            if (apt == null)
                return NotFound("airport not found");
            return Ok(apt);
        }
        [HttpGet("apts")]
        // [EnableQuery]
        public async Task<ActionResult<IEnumerable<Airport>>> ListAPTS()
        {
            //return _context.Airports;
            return await _context.Airports.Take(10).ToListAsync();
        }

        [HttpGet]
        //[Authorize]
        [Route("api/airport/notam/{icao}")]
        public async Task<IActionResult> GetAirportNotam(string icao)
        {
            var result = await _airportService.GetAirportNotam(icao);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);

            
             
        }
        [HttpGet]
        //[Authorize]
        [Route("api/airport/notam/all")]
        public async Task<IActionResult> GetAirportNotamAll()
        {
            var result = await _airportService.GetAirportNotamAll();
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);



        }
        [HttpGet]
        //[Authorize]
        [Route("api/airport/notam/FDP/{fdpId}")]
        public async Task<IActionResult> GetAirportNotamByFDP(int fdpId)
        {
            var _flights = await _flightService.GetFDPFlights(fdpId);
            if (!_flights.IsSuccess || _flights.Data == null)
                return NotFound(new List<string>() { "Flights Not Found." });
            var flights = (_flights.Data as List<AppCrewFlight>).OrderBy(q => q.STD).ToList();
            var _stations = new List<string>();
            foreach (var f in flights)
            {
                _stations.Add(f.FromAirportIATA);
                _stations.Add(f.ToAirportIATA);
                if (!string.IsNullOrEmpty(f.ALT1))
                    _stations.Add(f.ALT1);
                if (!string.IsNullOrEmpty(f.ALT2))
                    _stations.Add(f.ALT2);
            }
            _stations = _stations.Distinct().ToList();
            _stations.Add("OIIX");
            var stations = string.Join(',', _stations);

            var result = await _airportService.GetAirportNotam(stations);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);



        }

        [HttpGet]
        //[Authorize]
        [Route("api/airport/notam/archive/FDP/{fdpId}")]
        public async Task<IActionResult> GetAirportNotamByFDPFromArchive(int fdpId)
        {
            var _flights = await _flightService.GetFDPFlights(fdpId);
            if (!_flights.IsSuccess || _flights.Data == null)
                return NotFound(new List<string>() { "Flights Not Found." });
            var flights = (_flights.Data as List<AppCrewFlight>).OrderBy(q => q.STD).ToList();
            var _stations = new List<string>();
            foreach (var f in flights)
            {
                _stations.Add(f.FromAirportIATA);
                _stations.Add(f.ToAirportIATA);
                if (!string.IsNullOrEmpty(f.ALT1))
                    _stations.Add(f.ALT1);
                if (!string.IsNullOrEmpty(f.ALT2))
                    _stations.Add(f.ALT2);
            }
            _stations = _stations.Distinct().ToList();
            _stations.Add("OIIX");
            

            var result = await _airportService.GetAirportNotamArchive(_stations);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);



        }

    }
}
