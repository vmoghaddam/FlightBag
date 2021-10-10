using APCore.Models;
using APCore.Objects;
using APCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Net.Mime;
using System.Runtime.InteropServices.ComTypes;
using System.Net.Http;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace APCore.Services
{
    public interface IAirportService
    {
        Task<DataResponse> GetAirportNotam(string icao);
        Task<DataResponse> GetAirportNotamAll();
        Task<DataResponse> GetAirportNotamArchive(List<string> icao);

    }
    public class AirportService : IAirportService
    {
        private readonly ppa_cspnContext _context;
        private IConfiguration _configuration;
        public AirportService(ppa_cspnContext context, IConfiguration configuration)
        {
            _context = context;

            _configuration = configuration;
        }

        public async Task<DataResponse> GetAirportNotamAll()
        {
            var stations = await _context.Airports.Where(q => q.ICAO.StartsWith("OI") || q.ICAO.StartsWith("ORNI")).Select(q => q.ICAO).ToListAsync();
            stations.Add("OIIX");
            DateTime baseDate = DateTime.Now.Date;
            var data = new List<NOTAM>();
            var exists = await _context.NOTAMs.Where(q => stations.Contains(q.StationId) && q.DateDay == baseDate).ToListAsync();
            _context.NOTAMs.RemoveRange(exists);
            foreach (var apt in stations)
            {
                try
                {
                    var result = new List<string>();
                    var html = "https://pilotweb.nas.faa.gov/PilotWeb/notamRetrievalByICAOAction.do?method=displayByICAOs&reportType=REPORT&actionType=notamRetrievalByICAOs&retrieveLocId=" + apt.ToUpper() + "&formatType=ICAO";



                    using (WebClient webClient = new WebClient())
                    {
                        webClient.Headers.Add(HttpRequestHeader.Cookie, "akamai_pilotweb_access=true");
                        var txt = webClient.DownloadString(html);
                        var doc = new HtmlDocument();
                        doc.LoadHtml(txt);


                        var raw = doc.DocumentNode.Descendants("div")
                            .Where(q => q.Id == "notamRight")
                            .Select(q => q.Descendants("span").First().InnerText)

                            .ToList();

                        foreach (var x in raw)
                            result.Add(Regex.Replace(x, @"\r\n?|\n", "<br/>"));

                        //data.Add(new NotamResult() { ICAO = apt, NOTAMS = result });
                        var notam = new NOTAM()
                        {
                            DateDay = baseDate,
                            DateCreate = DateTime.Now,
                            FDPId = null,
                            FlightId = null,
                            StationId = apt,

                        };
                        notam.NOTAMItems = result.Select(q => new NOTAMItem()
                        {
                            Text = q,
                        }).ToList();
                        _context.NOTAMs.Add(notam);
                        data.Add(notam);

                    }
                }
                catch(Exception ex)
                {

                }
            }
            var saveresult = await _context.SaveAsync();
            return new DataResponse
            {
                Data = data,
                Errors = null,
                IsSuccess = true
            };
        }
        public async Task<DataResponse> GetAirportNotamArchive(List<string> icao)
        {
            DateTime baseDate = DateTime.Now.Date;
            var notams = await _context.NOTAMs.Where(q => q.DateDay == baseDate && icao.Contains(q.StationId)).ToListAsync();
            var notamIds = notams.Select(q => q.Id).ToList();
            var notamItems = await _context.NOTAMItems.Where(q => notamIds.Contains(q.NOTAMId)).ToListAsync();
            foreach (var notam in notams)
                notam.NOTAMItems = notamItems.Where(q => q.NOTAMId == notam.Id).ToList();
            var result = notams.OrderBy(q => icao.IndexOf(q.StationId)).OrderBy(q => q.Id).ToList();
            return new DataResponse
            {
                Data = result,
                Errors = null,
                IsSuccess = true
            };
        }
        public async Task<DataResponse> GetAirportNotam(string icao)
        {
             
            DateTime baseDate = DateTime.Now.Date;
            var data = new List<NOTAM>();
            var apts = icao.Split(',');
            var exists = await _context.NOTAMs.Where(q => apts.Contains(q.StationId) && q.DateDay == baseDate).ToListAsync();
            _context.NOTAMs.RemoveRange(exists);
            foreach (var apt in apts)
            {

                var result = new List<string>();
                var html = "https://pilotweb.nas.faa.gov/PilotWeb/notamRetrievalByICAOAction.do?method=displayByICAOs&reportType=REPORT&actionType=notamRetrievalByICAOs&retrieveLocId=" + apt.ToUpper() + "&formatType=ICAO";

               

                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers.Add(HttpRequestHeader.Cookie, "akamai_pilotweb_access=true");
                    var txt = webClient.DownloadString(html);
                    var doc = new HtmlDocument();
                    doc.LoadHtml(txt);


                    var raw = doc.DocumentNode.Descendants("div")
                        .Where(q => q.Id == "notamRight")
                        .Select(q => q.Descendants("span").First().InnerText)

                        .ToList();

                    foreach (var x in raw)
                        result.Add(Regex.Replace(x, @"\r\n?|\n", "<br/>"));

                    //data.Add(new NotamResult() { ICAO = apt, NOTAMS = result });
                    var notam = new NOTAM()
                    {
                        DateDay = baseDate,
                        DateCreate = DateTime.Now,
                        FDPId = null,
                        FlightId = null,
                        StationId = apt,

                    };
                    notam.NOTAMItems = result.Select(q => new NOTAMItem() {
                     Text=q,
                    }).ToList();
                    _context.NOTAMs.Add(notam);
                    data.Add(notam);

                }
            }

            var saveresult = await _context.SaveAsync();
            return new DataResponse
            {
                Data = data,
                Errors = null,
                IsSuccess = true
            };
        }



    }

    public class NotamResult
    {
        public string ICAO { get; set; }
        public List<string> NOTAMS { get; set; }
    }

}
