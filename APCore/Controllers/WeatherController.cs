using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;
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
    public class WeatherController : ControllerBase
    {
        private IWeatherService _weatherService;
        private IFlightService _flightService;

        public WeatherController(IWeatherService weatherService,IFlightService flightService)
        {
            _weatherService = weatherService;
            _flightService = flightService;
        }


        [HttpGet]
        //[Authorize]
        [Route("api/weather/sigwx/adds/{doc}")]
        public async Task<IActionResult> GetSIGWX_ADDS(string doc)
        {
            //  var userData = User.FindFirst(ClaimTypes.UserData).Value;

            var result = await _weatherService.GetSIGWX_ADDS(doc);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/weather/sigwx/adds/date/{dt}")]
        public async Task<IActionResult> GetSIGWX_ADDS_Date(string dt)
        {
            //  var userData = User.FindFirst(ClaimTypes.UserData).Value;

            var result = await _weatherService.GetSIGWX_ADDS_Date(dt);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }
        [HttpGet]
        //[Authorize]
        [Route("api/weather/sigwx/adds/version")]
        public async Task<IActionResult> GetSIGWX_ADDS_version()
        {
            //  var userData = User.FindFirst(ClaimTypes.UserData).Value;

            var result = await _weatherService.GetSIGWX_ADDS_UPDATE();
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }
        [HttpGet]
        //[Authorize]
        [Route("api/weather/wind/adds/{fl}/{str}")]
        public async Task<IActionResult> GetWIND_ADDS_IMG(string fl,string str)
        {
            //  var userData = User.FindFirst(ClaimTypes.UserData).Value;
            if (str == "-1")
                str = "";
            var result = await _weatherService.GetWIND_ADDS_IMG(fl,str);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/weather/wind/adds/pdf")]
        public async Task<IActionResult> GetWIND_ADDS_PDF()
        {
            //  var userData = User.FindFirst(ClaimTypes.UserData).Value;

            var result = await _weatherService.GetWIND_ADDS_PDF();
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/weather/sigwx/irimo")]
        public async Task<IActionResult> GetSIGWX_IRIMO()
        {
            //  var userData = User.FindFirst(ClaimTypes.UserData).Value;

            var result = await _weatherService.GetSIGWX_IRIMO();
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/weather/flightfolder/irimo")]
        public async Task<IActionResult> GetFF_IRIMO()
        {
            //  var userData = User.FindFirst(ClaimTypes.UserData).Value;

            var result = await _weatherService.GetFlightFolder_IRIMO();
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/weather/flightfolder/irimo2")]
        public async Task<ActionResult> GetAttachment(int FileID)
        {



            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri("https://irimo.ir/");
                client.DefaultRequestHeaders.Accept.Clear();

                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                System.Net.Http.HttpResponseMessage response = await client.GetAsync("https://irimo.ir/far/index.php?module=cdk&func=loadmodule&system=cdk&sismodule=user___call_function.php&ctp_id=119&func_name=met_getPdf&pdf_name=FLT21071000_IRAN");

                if (response.IsSuccessStatusCode)
                {
                    System.Net.Http.HttpContent content = response.Content;
                    var contentStream = await content.ReadAsStreamAsync(); // get the actual content stream
                    return File(contentStream, "application/pdf", "TEST100.PDF");
                }
                else
                {
                    throw new Exception();
                }
            }
        }


        [HttpGet]
        //[Authorize]
        [Route("api/weather/taf/{icao}/{date}/{useoffset}")]
        public async Task<ActionResult> GetTAF(string icao, string date, int useoffset)
        {

            var result = await _weatherService.GetTAFMETAR_METNO(icao, date, useoffset, "taf");
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        //[HttpGet]
        ////[Authorize]
        //[Route("api/weather/taf/adds")]
        //public async Task<ActionResult> GetTAFADDS()
        //{
        //    var url = "https://www.aviationweather.gov/adds/dataserver_current/httpparam?dataSource=tafs&requestType=retrieve&format=xml&stationString=OIII&hoursBeforeNow=4";
        //    object result = null;
        //    XElement xml = XElement.Load(url);
        //    var tafElements = (from item in xml.Descendants("TAF")
        //                       select new WeatherTafADD()
        //                       {
        //                           DateCreate = DateTime.Now,
        //                           RawText = (string)item.Element("raw_text"),
        //                           IssueTime = string.IsNullOrEmpty((string)item.Element("issue_time")) ? null :(Nullable<DateTime>) Convert.ToDateTime((string)item.Element("issue_time")).ToUniversalTime(),
        //                       }).ToList();
        //    //using (WebClient webClient = new WebClient())
        //    //{
        //    //    var txt = webClient.DownloadString(url);
        //    //    XElement xml= XElement.Load()
        //    //}
        //    return Ok(tafElements);
        //}

        [Route("api/weather/taf/adds/date/hitory/{date}/{stations}")]
        public async Task<ActionResult> GetTAFADDS_DateHistory(string date,string stations)
        {
            //"2021-08-10T00:00:00+0430"
            
            var fromDate=(DateTime) Helper.ConvertToDateNoTime(date);
            var tz = Math.Abs(TimeZoneInfo.Local.GetUtcOffset(fromDate).TotalMinutes);
            var offset = "";
            if (tz == 210)
                offset = "+0330";
            else
                offset = "+0430";
            var from = fromDate.Date.ToString("yyyy-MM-dd") + "T00:00:00" + offset;
            var to=fromDate.Date.AddDays(1).Date.ToString("yyyy-MM-dd") + "T00:00:00" + offset;
            stations = stations.Replace("_", ",");

            var result = await _weatherService.GetTAF_ADDS(stations, from, to, fromDate);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [Route("api/weather/taf/adds/all")]
        public async Task<ActionResult> GetTAFADDS_All( )
        {
            var result = await _weatherService.GetTAF_ADDS_All();
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }
        [Route("api/weather/metar/adds/all")]
        public async Task<ActionResult> GetMETARADDS_All()
        {
            var result = await _weatherService.GetMETAR_ADDS_ALL();
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }
       
        [Route("api/weather/taf/adds/FDP/{fdpId}")]
        public async Task<ActionResult> GetTAFADDS_DateHistoryByFDPId(int fdpId)
        {
            //"2021-08-10T00:00:00+0430"
            var _flights = await _flightService.GetFDPFlights(fdpId);
            if (_flights.IsSuccess && _flights.Data!=null)
            {
                var flights = (_flights.Data as List<AppCrewFlight>).OrderBy(q=>q.STD).ToList();
                var firstDate =(DateTime) flights.First().STDDay;
                var lastDate =(DateTime) flights.Last().STADay;
               
                
                var tz1 = Math.Abs(TimeZoneInfo.Local.GetUtcOffset(firstDate).TotalMinutes);
                var offset1 = "";
                if (tz1 == 210)
                    offset1 = "+0330";
                else
                    offset1 = "+0430";

                var tz2 = Math.Abs(TimeZoneInfo.Local.GetUtcOffset(lastDate).TotalMinutes);
                var offset2 = "";
                if (tz2 == 210)
                    offset2 = "+0330";
                else
                    offset2 = "+0430";

                var from = firstDate.Date.ToString("yyyy-MM-dd") + "T00:00:00" + offset1;
                var to = lastDate.Date.AddDays(1).Date.ToString("yyyy-MM-dd") + "T00:00:00" + offset2;
                var _stations = new List<string>();
                foreach(var f in flights)
                {
                    _stations.Add(f.FromAirportIATA);
                    _stations.Add(f.ToAirportIATA);
                    if (!string.IsNullOrEmpty(f.ALT1))
                        _stations.Add(f.ALT1);
                    if (!string.IsNullOrEmpty(f.ALT2))
                        _stations.Add(f.ALT2);
                }
                _stations = _stations.Distinct().ToList();
                var stations =string.Join(',',_stations);

                var result = await _weatherService.GetTAF_ADDS(stations, from, to, firstDate);
                if (!result.IsSuccess)
                    return NotFound(result.Errors);
                return Ok(result);
            }
            else
                 return NotFound(new List<string>() { "Flights Not Found."});


        }



        [Route("api/weather/taf/adds/archive/FDP/{fdpId}")]
        public async Task<ActionResult> GetTAFADDS_DateHistoryByFDPIdFromArchive(int fdpId)
        {
            var _flights = await _flightService.GetFDPFlights(fdpId);
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
            var stations = string.Join(',', _stations);
            var result = await _weatherService.GetTAF_ADDS_FromArchive(stations, DateTime.Now);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);

        }
        [Route("api/weather/metar/adds/archive/FDP/{fdpId}")]
        public async Task<ActionResult> GetMETARADDS_DateHistoryFromArchive(int fdpId)
        {
            //"2021-08-10T00:00:00+0430"
            var _flights = await _flightService.GetFDPFlights(fdpId);
            if (!_flights.IsSuccess || _flights.Data==null)
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
            var stations = string.Join(',', _stations);
            var result = await _weatherService.GetMETAR_ADDS_FromArchive(stations, DateTime.Now);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
            


           
        }



        [Route("api/weather/metar/adds/FDP/{fdpId}")]
        public async Task<ActionResult> GetMETARADDS_DateHistory(int fdpId)
        {
            //"2021-08-10T00:00:00+0430"
            var _flights = await _flightService.GetFDPFlights(fdpId);
            if (!_flights.IsSuccess || _flights.Data == null)
                return NotFound(new List<string>() { "Flights Not Found." });

            var flights = (_flights.Data as List<AppCrewFlight>).OrderBy(q => q.STD).ToList();
            var firstDate = (DateTime)flights.First().STDDay;
            var lastDate = (DateTime)flights.Last().STADay;


            var tz1 = Math.Abs(TimeZoneInfo.Local.GetUtcOffset(firstDate).TotalMinutes);
            var offset1 = "";
            if (tz1 == 210)
                offset1 = "+0330";
            else
                offset1 = "+0430";

            var tz2 = Math.Abs(TimeZoneInfo.Local.GetUtcOffset(lastDate).TotalMinutes);
            var offset2 = "";
            if (tz2 == 210)
                offset2 = "+0330";
            else
                offset2 = "+0430";

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
            var stations = string.Join(',', _stations);

            var nowUTC = DateTime.UtcNow.Date;
            if (nowUTC == firstDate || nowUTC == lastDate)
            {

                var result = await _weatherService.GetMETAR_ADDS(stations, "24");
                if (!result.IsSuccess)
                    return NotFound(result.Errors);
                return Ok(result);
            }
            else
            {
                var from = firstDate.Date.ToString("yyyy-MM-dd") + "T00:00:00" + offset1;
                var to = lastDate.Date.AddDays(1).Date.ToString("yyyy-MM-dd") + "T00:00:00" + offset2;
                var result = await _weatherService.GetMETAR_ADDSByFDP(stations, from, to);
                if (!result.IsSuccess)
                    return NotFound(result.Errors);
                return Ok(result);
            }



        }

        [Route("api/weather/metar/adds/now/hitory/{stations}/{period}")]
        public async Task<ActionResult> GetMETARADDS_DateHistory( string stations,string period)
        {
            //"2021-08-10T00:00:00+0430"
            
           
            stations = stations.Replace("_", ",");

            var result = await _weatherService.GetMETAR_ADDS(stations, period);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }


        [HttpGet]
        //[Authorize]
        [Route("api/weather/metar/{icao}/{date}/{useoffset}")]
        public async Task<ActionResult> GetMETAR(string icao, string date, int useoffset)
        {

            var result = await _weatherService.GetTAFMETAR_METNO(icao, date, useoffset, "metar");
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/weather/tafmetar/{icao}/{date}/{useoffset}")]
        public async Task<ActionResult> GetTAFMETAR(string icao, string date, int useoffset)
        {

            var result = await _weatherService.GetTAFMETAR_METNO(icao, date, useoffset, "tafmetar");
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }


    }
}
