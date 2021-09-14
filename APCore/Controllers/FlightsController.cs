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
        //[Authorize]
        [Route("api/flights/{from}/{to}")]
        public async Task<IActionResult> GetFlights(DateTime from, DateTime to,string origin,string destination,string no,string register)
        {
            //var userData = User.FindFirst(ClaimTypes.UserData).Value;
            //var crewId = Objects.AuthDataHelper.GetEmployeeId(userData);
            var result = await _flightService.GetFlights(from, to, no, origin, destination, "", "", "", "", "", register);
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
        [Route("api/flight/commanders/{flightId}")]
        public async Task<IActionResult> GetFlightCommanders(int flightId)
        {
            // var userData = User.FindFirst(ClaimTypes.UserData).Value;
            //var crewId = Objects.AuthDataHelper.GetEmployeeId(userData);
            var result = await _flightService.GetFlightCommanders(flightId);
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
        [Route("api/flight/sign")]
        public async Task<IActionResult> SaveSign(dynamic dto)
        {
            var userData = User.FindFirst(ClaimTypes.UserData).Value;
            var crewId = Objects.AuthDataHelper.GetEmployeeId(userData);
            int flightId = Convert.ToInt32(dto.flightId);
            string doc = Convert.ToString(dto.doc);
            int pic = Convert.ToInt32(dto.pic);
            string picStr = Convert.ToString(dto.picStr);
            string user = Convert.ToString(dto.user);
            var result = await _flightService.SaveSign(flightId,pic,picStr, doc, crewId.ToString());
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

        [HttpGet]
       // [Authorize]
        [Route("api/check/lock/{flightId}/{doc}")]
        public async Task<IActionResult> CheckLock(int flightId,string doc)
        {
            var result = await _flightService.CheckLock(flightId,doc);

            return Ok(result);
        }


        [HttpGet]
        [Authorize]
        [Route("api/ofp/flight/{flightId}")]
        public async Task<IActionResult> GetFlightOFP(int flightId)
        {
            // var userData = User.FindFirst(ClaimTypes.UserData).Value;
            //var crewId = Objects.AuthDataHelper.GetEmployeeId(userData);
            var result = await _flightService.GetOFP(flightId);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

       

        [HttpPost]
        [Route("api/ofp/props/ids")]
        public async Task<IActionResult> PostGetOFPPropsByIds(SimpleDto dto)
        {

            var result = await _flightService.GetOFPPropsByIds(dto.ids);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/ofp/flights")]
        public async Task<IActionResult> PostGetOFPsByFlightIds(SimpleDto dto)
        {
            var _ids = dto.ids.Select(q => (Nullable<int>)q).ToList();
            var result = await _flightService.GetOFPsByFlightIds(_ids);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }


        [HttpGet]
        [Authorize]
        [Route("api/ofp/props/{ofpId}")]
        public async Task<IActionResult> GeOFPProps(int ofpId)
        {
            // var userData = User.FindFirst(ClaimTypes.UserData).Value;
            //var crewId = Objects.AuthDataHelper.GetEmployeeId(userData);
            var result = await _flightService.GetOFPProps(ofpId);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        [Route("api/ofp/prop/save")]
        public async Task<IActionResult> SaveOFPProp(dynamic dto)
        {
            //SaveOFPProp(int ofpId, string propName, string propValue, string user)
            int ofpId = Convert.ToInt32(dto.OFPId);
            string propName = Convert.ToString(dto.PropName);
            string propValue = Convert.ToString(dto.PropValue);
            string user = Convert.ToString(dto.User);
            var result = await _flightService.SaveOFPProp(ofpId, propName, propValue, user);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        [Route("api/ofp/props/save")]
        public async Task<IActionResult> SaveOFPProps(List<OFPPropViewModel> props)
        {
            //SaveOFPProp(int ofpId, string propName, string propValue, string user)
             
            var result = await _flightService.SaveOFPProps(props);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/drs")]
        public async Task<IActionResult> PostGetDRsByFlightIds(SimpleDto dto)
        {
            var _ids = dto.ids.Select(q => (Nullable<int>)q).ToList();
            var result = await _flightService.GetDRsByFlightIds(_ids);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
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
