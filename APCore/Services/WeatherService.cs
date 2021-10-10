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
using System.Xml.Linq;
using System.Drawing;
using HtmlAgilityPack;
using ImageMagick;

namespace APCore.Services
{
    public class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            return request;
        }
    }
    public interface IWeatherService
    {
        Task<DataResponse> GetSIGWX_ADDS(string doc);
        Task<DataResponse> GetSIGWX_ADDS_UPDATE();
        Task<DataResponse> GetSIGWX_ADDS_Date(string dt);
        Task<DataResponse> GetWIND_ADDS_IMG(string fl, string dtstr = "");
        Task<DataResponse> GetWIND_ADDS_PDF();
        Task<DataResponse> GetTAF_ADDS(string stations, string from, string to, DateTime baseDate);
        Task<DataResponse> GetTAF_ADDS_All();
        Task<DataResponse> GetTAF_ADDS_FromArchive(string stations, DateTime baseDate);
        Task<DataResponse> GetMETAR_ADDS(string stations, string period);
        Task<DataResponse> GetMETAR_ADDSByFDP(string stations, string from, string to);
        Task<DataResponse> GetMETAR_ADDS_ALL();
        Task<DataResponse> GetMETAR_ADDS_FromArchive(string stations, DateTime baseDate);
        Task<DataResponse> GetSIGWX_IRIMO();
        Task<DataResponse> GetFlightFolder_IRIMO();
        Task<DataResponse> GetTAFMETAR_METNO(string icao, string date, int useoffset, string type);

    }
    public class WeatherService : IWeatherService
    {
        private readonly ppa_cspnContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IConfiguration _configuration;
        public WeatherService(ppa_cspnContext context, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }
        public async Task<DataResponse> GetSIGWX_ADDS_UPDATE()
        {
            var html = "https://www.aviationweather.gov/flightfolder/products?type=sigwx";

            using (WebClient webClient = new WebClient())
            {
                //webClient.Headers.Add(HttpRequestHeader.Cookie, "akamai_pilotweb_access=true");
                var txt = webClient.DownloadString(html);
                var doc = new HtmlDocument();
                doc.LoadHtml(txt);


                var updated = doc.DocumentNode.Descendants("table")
                    .Where(q => q.HasClass("spreadsheet"))
                    .Select(q => q.Descendants("tr").First(w => w.Id == "rw_5").Descendants("td").Last().InnerText)

                    .FirstOrDefault();
                var issued = doc.DocumentNode.Descendants("table")
                   .Where(q => q.HasClass("spreadsheet"))
                   .Select(q => q.Descendants("tr").First(w => w.Id == "rw_5").Descendants("td").ToList()[7].InnerText)

                   .FirstOrDefault();
                var product = doc.DocumentNode.Descendants("table")
                 .Where(q => q.HasClass("spreadsheet"))
                 .Select(q => q.Descendants("tr").First(w => w.Id == "rw_5").Descendants("td").ToList()[6].InnerText)

                 .FirstOrDefault();
                return new DataResponse
                {
                    Data = new List<string>() { product, issued, updated },
                    Errors = null,
                    IsSuccess = true
                };

            }

            //var saveresult = await _context.SaveAsync();
            //return new DataResponse
            //{
            //    Data = data,
            //    Errors = null,
            //    IsSuccess = true
            //};
        }

        public async Task<DataResponse> GetSIGWX_ADDS(string doc)
        {

            var result = "SIGWX_ADDS_" + DateTime.Now.ToString("yyyyMMdd") + "_" + doc + ".png";
            string webRootPath = _webHostEnvironment.ContentRootPath;
            string path = "";
            path = Path.Combine(webRootPath, "Upload", "Weather", "SIGWX", "ADDS", result);
            var url = _configuration["WeatherUrls:SIGWX_ADDS"];
            using (WebClient webClient = new WebClient())
            {
                byte[] data = webClient.DownloadData(url + doc + ".gif");

                using (MemoryStream mem = new MemoryStream(data))
                {
                    using (var yourImage = System.Drawing.Image.FromStream(mem))
                    {
                        // If you want it as Png
                        yourImage.Save(path, System.Drawing.Imaging.ImageFormat.Png);

                        // If you want it as Jpeg
                        //yourImage.Save("path_to_your_file.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }

            }

            return new DataResponse
            {
                Data = result,
                Errors = null,
                IsSuccess = true
            };
        }

        public async Task<DataResponse> GetSIGWX_ADDS_Date(string dt)
        {
            string webRootPath = _webHostEnvironment.ContentRootPath;
            var info = (await GetSIGWX_ADDS_UPDATE()).Data as List<string>;
            var issued = info[1];
            var product = info[0];
            var updated = info[2];
            var date = ((DateTime)Helper.ConvertToDateNoTime(dt)).Date;
            var now = DateTime.UtcNow.Date;
            if (date != now)
            {
                var record = await _context.WeatherSIGWXes.Where(q => q.DateDay == date).FirstOrDefaultAsync();
                if (record != null)
                {
                    return new DataResponse
                    {
                        Data = new List<string>() { record.CurrentUrl, record.PastUrl },
                        Errors = null,
                        IsSuccess = true
                    };
                }
                else
                    return new DataResponse
                    {
                        Data = null,
                        Errors = null,
                        IsSuccess = true
                    };
            }
            else
            {
                var lastSIGWX = await _context.WeatherSIGWXes.Where(q => q.DateDay == date).OrderByDescending(q => q.DateCreate).FirstOrDefaultAsync();
                if (lastSIGWX == null || lastSIGWX.Updated != updated)
                {
                    var rec = new WeatherSIGWX() { DateDay = date, };
                    _context.WeatherSIGWXes.Add(rec);
                    //if (lastSIGWX == null)
                    //{
                    //    lastSIGWX = new WeatherSIGWX() { DateDay = date, };
                    //    _context.WeatherSIGWXes.Add(lastSIGWX);
                    //}
                    //else
                    if (lastSIGWX != null)
                    {
                        var oldCurrent = "SIGWX_ADDS_" + date.ToString("yyyyMMdd") + "_" + "2105" + ".png";
                        var newCurrent = "SIGWX_ADDS_" + date.ToString("yyyyMMdd") + "_" + "2105" + "_" + lastSIGWX.Updated + ".png";
                        var oldPast = "SIGWX_ADDS_" + date.ToString("yyyyMMdd") + "_" + "3105" + ".png";
                        var newPast = "SIGWX_ADDS_" + date.ToString("yyyyMMdd") + "_" + "3105" + "_" + lastSIGWX.Updated + ".png";

                        lastSIGWX.CurrentUrl = newCurrent;
                        lastSIGWX.PastUrl = newPast;

                        var currentPath = Path.Combine(webRootPath, "Upload", "Weather", "SIGWX", "ADDS", oldCurrent);
                        var pastPath = Path.Combine(webRootPath, "Upload", "Weather", "SIGWX", "ADDS", oldPast);
                        var newCurrentPath = Path.Combine(webRootPath, "Upload", "Weather", "SIGWX", "ADDS", newCurrent);
                        var newPastPath = Path.Combine(webRootPath, "Upload", "Weather", "SIGWX", "ADDS", newPast);
                        if (File.Exists(currentPath))
                        {
                            File.Move(currentPath, newCurrentPath);
                        }
                        if (File.Exists(pastPath))
                        {
                            File.Move(pastPath, newPastPath);
                        }

                    }
                    rec.Issued = issued;
                    rec.Region = "EUR-C ASIA (D)";
                    rec.Updated = updated;
                    rec.Product = product;
                    List<string> docs = new List<string>() { /*"2105", "2106", "2107"*/"2105", "3105" };
                    List<string> results = new List<string>();
                    foreach (var doc in docs)
                    {
                        var result = "SIGWX_ADDS_" + DateTime.Now.ToString("yyyyMMdd") + "_" + doc + ".png";
                        results.Add(result);

                        string path = "";
                        path = Path.Combine(webRootPath, "Upload", "Weather", "SIGWX", "ADDS", result);
                        var url = _configuration["WeatherUrls:SIGWX_ADDS"];
                        using (WebClient webClient = new WebClient())
                        {
                            byte[] data = webClient.DownloadData(url + doc + ".gif");

                            using (MemoryStream mem = new MemoryStream(data))
                            {
                                using (var yourImage = System.Drawing.Image.FromStream(mem))
                                {
                                    //Bitmap bitmap1;
                                    //bitmap1.
                                    yourImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                    // If you want it as Png
                                    yourImage.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                                    if (doc == "2105")
                                        rec.CurrentUrl = result;
                                    else
                                        rec.PastUrl = result;
                                    // If you want it as Jpeg
                                    //yourImage.Save("path_to_your_file.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                }
                            }

                        }
                    }

                    rec.DateCreate = DateTime.UtcNow;

                    //dool
                    var saveResult = await _context.SaveAsync();

                    return new DataResponse
                    {
                        Data = results,
                        Errors = null,
                        IsSuccess = true
                    };
                }
                else
                    return new DataResponse
                    {
                        Data = new List<string>() { lastSIGWX.CurrentUrl, lastSIGWX.PastUrl },
                        Errors = null,
                        IsSuccess = true
                    };
            }




        }
        public Image ScaleImage(Image image, int height)
        {
            double ratio = (double)height / image.Height;
            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            image.Dispose();
            return newImage;
        }

        public async Task<DataResponse> GetWIND_ADDS_PDF()
        {

            List<ADDSWindUrl> docs = ADDSWindUrl.GetADDSWindUrls();
            List<string> results = new List<string>();
            foreach (var doc in docs)
            {
                var result = "WIND_ADDS_" + DateTime.Now.ToString("yyyyMMdd") + "_FL" + doc.FL + "_VALID" + doc.Valid + ".pdf";
                results.Add(result);
                string webRootPath = _webHostEnvironment.ContentRootPath;
                string path = "";
                path = Path.Combine(webRootPath, "Upload", "Weather", "WIND", "ADDS", result);
                var url = _configuration["WeatherUrls:SIGWX_WIND"];

                using (HttpClient httpClient = new HttpClient())
                {
                    var fn = url + doc.Url + ".pdf";
                    httpClient.BaseAddress = new Uri("https://www.aviationweather.gov/");

                    System.Net.Http.HttpRequestMessage httpRequestMessage = new System.Net.Http.HttpRequestMessage();
                    httpRequestMessage.Method = new System.Net.Http.HttpMethod("GET");
                    httpRequestMessage.Headers.Add("context-type", "application/pdf");
                    httpRequestMessage.RequestUri = new Uri(fn);

                    System.Net.Http.HttpResponseMessage httpResponseMessage = httpClient.SendAsync(httpRequestMessage).Result;

                    if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        System.IO.Stream stream = httpResponseMessage.Content.ReadAsStreamAsync().Result;
                        using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.CreateNew))
                        {
                            byte[] buffer = new byte[stream.Length];
                            stream.Read(buffer, 0, buffer.Length);
                            fs.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }



            //////////////////////

            return new DataResponse
            {
                Data = results,
                Errors = null,
                IsSuccess = true
            };
        }
        int getImagePercentage(string fl) {
            switch (fl) {
                case "180":
                    return 50;
                case "240":
                    return 50;
                case "300":
                    return 50;
                case "340":
                    return 50;
                default:
                    return 50;
            }
        }
        public async Task<DataResponse> GetWIND_ADDS_IMG(string fl,string dtstr="")
        {
            List<ADDSWindUrl> docs = ADDSWindUrl.GetADDSWindUrls();
            if (fl != "-1")
                docs = docs.Where(q => q.FL == fl).ToList();
            List<string> results = new List<string>();
            foreach (var doc in docs)
            {
                var result = "WIND_ADDS_" + (string.IsNullOrEmpty(dtstr)? DateTime.Now.ToString("yyyyMMdd"):dtstr) + "_FL" + doc.FL + "_VALID" + doc.Valid + ".png";
                var result2 = "WIND_ADDS_" + DateTime.Now.ToString("yyyyMMdd") + "_FL" + doc.FL + "_VALID" + doc.Valid + "_XXXX.png";
                results.Add(result);
                string webRootPath = _webHostEnvironment.ContentRootPath;
                string path = "";
                path = Path.Combine(webRootPath, "Upload", "Weather", "WIND", "ADDS", result);
                var path2 = Path.Combine(webRootPath, "Upload", "Weather", "WIND", "ADDS", result2);
                var url = _configuration["WeatherUrls:SIGWX_WIND"];
                using (WebClient webClient = new WebClient())
                {
                    byte[] data = webClient.DownloadData(url + doc.Url + ".gif");

                    using (MemoryStream mem = new MemoryStream(data))
                    {
                        MagickImage image = new MagickImage(mem);
                        image.Rotate(270);
                         image.Resize(new Percentage(getImagePercentage(fl)));
                        //image.Quality = 10;
                        image.ColorType = ColorType.Grayscale;
                        image.Write(path,MagickFormat.Png8);
                        //using (var yourImage = System.Drawing.Image.FromStream(mem))
                        //{
                        //    // If you want it as Png
                        //    //var h =Convert.ToInt32( Math.Round( (yourImage.Height*0.8)));
                        //    //var img = ScaleImage(yourImage, h);
                        //    yourImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        //   // var image2 = yourImage.GetThumbnailImage(yourImage.Width, yourImage.Height, null, System.IntPtr.Zero);
                        //   ;

                        //    yourImage.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                        //   // image2.Save(path2, System.Drawing.Imaging.ImageFormat.Png);

                        //    // If you want it as Jpeg
                        //    //yourImage.Save("path_to_your_file.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        //}
                    }

                }
                Task.Delay(1000).Wait();
            }


            return new DataResponse
            {
                Data = results,
                Errors = null,
                IsSuccess = true
            };
        }

        public async Task<DataResponse> GetSIGWX_IRIMO()
        {
            List<string> valid = new List<string>() { "00", "06", "12", "18" };
            List<string> level = new List<string>() { "IRAN"/*, "WEST", "EAST"*/ };
            List<string> results = new List<string>();
            var nowDate = DateTime.Now.Date;
            foreach (var v in valid)
            {
                foreach (var l in level)
                {
                    var result = "SIGWX_IRIMO_" + nowDate.ToString("yyyyMMdd") + "_" + "VALID" + v + "LVL" + l + ".png";
                    results.Add(result);
                    string webRootPath = _webHostEnvironment.ContentRootPath;
                    string path = "";
                    path = Path.Combine(webRootPath, "Upload", "Weather", "SIGWX", "IRIMO", result);
                    var url = _configuration["WeatherUrls:SIGWX_IRIMO"];
                    using (WebClient webClient = new WebClient())
                    {

                        byte[] data = webClient.DownloadData(url + "SIGWX_" + l + v);

                        using (MemoryStream mem = new MemoryStream(data))
                        {
                            var memLen = mem.Length;
                            using (var yourImage = System.Drawing.Image.FromStream(mem))
                            {
                                var yyy = yourImage.GetHashCode();
                                var dbrec = await _context.WeatherSIGWXIrimos.Where(q => q.Title == result).FirstOrDefaultAsync();
                                if (dbrec != null)
                                {
                                    if (dbrec.Size != memLen)
                                    {

                                        result = "SIGWX_IRIMO_" + nowDate.AddDays(1).ToString("yyyyMMdd") + "_" + "VALID" + v + "LVL" + l + ".png";
                                        path = Path.Combine(webRootPath, "Upload", "Weather", "SIGWX", "IRIMO", result);
                                        var newdbRec = await _context.WeatherSIGWXIrimos.Where(q => q.Title == result).FirstOrDefaultAsync();
                                        if (newdbRec == null)
                                            _context.WeatherSIGWXIrimos.Add(new WeatherSIGWXIrimo()
                                            {
                                                DateCreate = DateTime.Now,
                                                DateDay = nowDate.AddDays(1).Date,
                                                Level = l,
                                                Valid = v,
                                                Size = Convert.ToInt32(memLen),
                                                Title = result

                                            });
                                        else
                                        {
                                            newdbRec.DateCreate = DateTime.Now;
                                            newdbRec.DateDay = nowDate.AddDays(1).Date;
                                            newdbRec.Size = Convert.ToInt32(memLen);
                                        }
                                    }

                                }
                                else
                                {
                                    _context.WeatherSIGWXIrimos.Add(new WeatherSIGWXIrimo()
                                    {
                                        DateCreate = DateTime.Now,
                                        DateDay = nowDate.Date,
                                        Level = l,
                                        Valid = v,
                                        Size = Convert.ToInt32(memLen),
                                        Title = result

                                    });
                                }
                                // If you want it as Png
                                yourImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                yourImage.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                                await _context.SaveAsync();
                                // If you want it as Jpeg
                                //yourImage.Save("path_to_your_file.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            }
                        }

                    }
                }

            }


            return new DataResponse
            {
                Data = results,
                Errors = null,
                IsSuccess = true
            };
        }


        public async Task<DataResponse> GetFlightFolder_IRIMO()
        {
            //  string apiUrl = "https://irimo.ir/far/index.php?module=cdk&func=loadmodule&system=cdk&sismodule=user___call_function.php&ctp_id=119&func_name=met_getPdf&pdf_name=FLT21071000_IRAN";
            //   var _uri = new Uri(apiUrl);



            ////////////////////////////////



            List<string> valid = new List<string>() { "06", "12", "18", "00" };
            List<string> level = new List<string>() { "IRAN"/*, "WEST", "EAST"*/ };
            List<DateTime> _dates = new List<DateTime>() { DateTime.Now, DateTime.Now.AddDays(1) };
            List<string> results = new List<string>();
            foreach (var _dts in _dates)
            {
                //var dtstr = DateTime.Now.ToString("yMMdd");
                var dtstr = _dts.ToString("yMMdd");
                foreach (var v in valid)
                {
                    foreach (var l in level)
                    {
                        var result = "FF_IRIMO_" + /*DateTime.Now.ToString("yyyyMMdd")*/_dts.ToString("yyyyMMdd") + "_" + "VALID" + v + "LVL" + l + ".pdf";
                        results.Add(result);
                        string webRootPath = _webHostEnvironment.ContentRootPath;
                        string path = "";
                        path = Path.Combine(webRootPath, "Upload", "Weather", "FF", "IRIMO", result);
                        var url = _configuration["WeatherUrls:PDF_IRIMO"];
                        //using (WebClient webClient = new WebClient())
                        //{

                        //    var fn = url + "FLT210" + dtstr + v + "_" + l;
                        //    var data = webClient.DownloadData(fn);
                        //    using (MemoryStream mem = new MemoryStream(data))
                        //    {

                        //    }


                        //}
                        using (HttpClient httpClient = new HttpClient())
                        {
                            var fn = url + "FLT" + dtstr + v + "_" + l;
                            httpClient.BaseAddress = new Uri("https://irimo.ir/");

                            System.Net.Http.HttpRequestMessage httpRequestMessage = new System.Net.Http.HttpRequestMessage();
                            httpRequestMessage.Method = new System.Net.Http.HttpMethod("GET");
                            httpRequestMessage.Headers.Add("context-type", "application/pdf");
                            httpRequestMessage.RequestUri = new Uri(fn);

                            System.Net.Http.HttpResponseMessage httpResponseMessage = httpClient.SendAsync(httpRequestMessage).Result;

                            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                System.IO.Stream stream = httpResponseMessage.Content.ReadAsStreamAsync().Result;
                                if (stream.Length > 0)
                                {
                                    using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                    {
                                        byte[] buffer = new byte[stream.Length];
                                        stream.Read(buffer, 0, buffer.Length);
                                        fs.Write(buffer, 0, buffer.Length);
                                    }
                                }

                            }
                        }






                    }

                }

            }


            return new DataResponse
            {
                Data = results,
                Errors = null,
                IsSuccess = true
            };
        }


        public async Task<DataResponse> GetTAFMETAR_METNO(string icao, string date, int useoffset, string type)
        {
            var result = new List<string>();
            var url = _configuration["WeatherUrls:METNO"] + "tafmetar/1.0/?icao=" + icao + "&content_type=text/plain&date=" + date + "&content=" + type;
            if (useoffset == 1)
            {
                var dts = date.Split('-').Select(q => Convert.ToInt32(q)).ToList();
                var tz = Math.Abs(TimeZoneInfo.Local.GetUtcOffset(new DateTime(dts[0], dts[1], dts[2])).TotalMinutes);
                if (tz == 210)
                    url += "&offset=+03:30";
                else
                    url += "&offset=+04:30";

            }
            using (WebClient webClient = new WebClient())
            {
                var str = webClient.DownloadString(url);
                result = str.Split(
                         new[] { "\r\n", "\r", "\n" },
                            StringSplitOptions.None
                            ).Where(q => !string.IsNullOrEmpty(q)).ToList();

            }

            return new DataResponse
            {
                Data = result,
                Errors = null,
                IsSuccess = true
            };
        }

        DateTime? getDateTimeFromElement(XElement x)
        {
            return string.IsNullOrEmpty((string)x) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)x).ToUniversalTime();
        }

        public List<WeatherForecastSkyCondition> getSkyConditions(XElement elem)
        {
            List<WeatherForecastSkyCondition> result = new List<WeatherForecastSkyCondition>();
            var items = elem.Elements("sky_condition").ToList();
            foreach (var item in items)
            {
                var obj = new WeatherForecastSkyCondition()
                {


                    sky_cover = item.Attribute("sky_cover") != null ? (string)item.Attribute("sky_cover") : null,
                    cloud_base_ft_agl = item.Attribute("cloud_base_ft_agl") != null ? (Nullable<double>)Convert.ToDouble((string)item.Attribute("cloud_base_ft_agl")) : null,
                    cloud_type = item.Attribute("cloud_type") != null ? (string)item.Attribute("cloud_type") : null,

                };

                result.Add(obj);

            }
            return result;
        }


        public List<WeatherForecastTurbulence> getTurbulenceConditions(XElement elem)
        {
            List<WeatherForecastTurbulence> result = new List<WeatherForecastTurbulence>();
            var items = elem.Elements("turbulence_condition").ToList();
            foreach (var item in items)
            {
                var obj = new WeatherForecastTurbulence()
                {

                    turbulence_intensity = item.Element("turbulence_intensity") != null ? (string)item.Element("turbulence_intensity") : null,
                    turbulence_min_alt_ft_agl = item.Element("turbulence_min_alt_ft_agl") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("turbulence_min_alt_ft_agl")) : null,
                    turbulence_max_alt_ft_agl = item.Element("turbulence_max_alt_ft_agl") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("turbulence_max_alt_ft_agl")) : null,



                };

                result.Add(obj);

            }
            return result;
        }


        public List<WeatherForecastIcingCondition> getIcingConditions(XElement elem)
        {
            List<WeatherForecastIcingCondition> result = new List<WeatherForecastIcingCondition>();
            var items = elem.Elements("icing_condition").ToList();
            foreach (var item in items)
            {
                var obj = new WeatherForecastIcingCondition()
                {

                    icing_intensity = item.Element("icing_intensity") != null ? (string)item.Element("icing_intensity") : null,
                    icing_min_alt_ft_agl = item.Element("icing_min_alt_ft_agl") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("icing_min_alt_ft_agl")) : null,
                    icing_max_alt_ft_agl = item.Element("icing_max_alt_ft_agl") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("icing_max_alt_ft_agl")) : null,

                };

                result.Add(obj);

            }
            return result;
        }


        public List<WeatherForecastTemperature> getTemperatures(XElement elem)
        {
            List<WeatherForecastTemperature> result = new List<WeatherForecastTemperature>();
            var items = elem.Elements("temperature").ToList();
            foreach (var item in items)
            {
                var obj = new WeatherForecastTemperature()
                {

                    valid_time = item.Element("valid_time") != null ? getDateTimeFromElement(item.Element("valid_time")) : null,
                    sfc_temp_c = item.Element("sfc_temp_c") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("sfc_temp_c")) : null,
                    max_temp_c = item.Element("max_temp_c") != null ? (string)item.Element("max_temp_c") : null,
                    min_temp_c = item.Element("min_temp_c") != null ? (string)item.Element("min_temp_c") : null,


                };

                result.Add(obj);

            }
            return result;
        }

        public List<WeatherTafForecast> getForecasts(XElement elem)
        {
            List<WeatherTafForecast> result = new List<WeatherTafForecast>();
            var forecasts = elem.Elements("forecast").ToList();
            foreach (var item in forecasts)
            {
                var forecast = new WeatherTafForecast();
                forecast.fcst_time_from = item.Element("fcst_time_from") != null ? getDateTimeFromElement(item.Element("fcst_time_from")) : null;
                forecast.fcst_time_to = item.Element("fcst_time_to") != null ? getDateTimeFromElement(item.Element("fcst_time_to")) : null;
                forecast.time_becoming = item.Element("time_becoming") != null ? getDateTimeFromElement(item.Element("time_becoming")) : null;
                forecast.change_indicator = item.Element("change_indicator") != null ? (string)item.Element("change_indicator") : null;

                forecast.probability = item.Element("probability") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("probability")) : null;
                forecast.wind_dir_degrees = item.Element("wind_dir_degrees") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("wind_dir_degrees")) : null;
                forecast.wind_speed_kt = item.Element("wind_speed_kt") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("wind_speed_kt")) : null;
                forecast.wind_gust_kt = item.Element("wind_gust_kt") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("wind_gust_kt")) : null;
                forecast.wind_shear_hgt_ft_agl = item.Element("wind_shear_hgt_ft_agl") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("wind_shear_hgt_ft_agl")) : null;
                forecast.wind_shear_dir_degrees = item.Element("wind_shear_dir_degrees") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("wind_shear_dir_degrees")) : null;
                forecast.wind_shear_speed_kt = item.Element("wind_shear_speed_kt") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("wind_shear_speed_kt")) : null;
                forecast.visibility_statute_mi = item.Element("visibility_statute_mi") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("visibility_statute_mi")) : null;
                forecast.altim_in_hg = item.Element("altim_in_hg") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("altim_in_hg")) : null;
                forecast.vert_vis_ft = item.Element("vert_vis_ft") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("vert_vis_ft")) : null;
                forecast.wx_string = item.Element("wx_string") != null ? (string)item.Element("wx_string") : null;
                forecast.not_decoded = item.Element("not_decoded") != null ? (string)item.Element("not_decoded") : null;
                forecast.WeatherForecastSkyConditions = getSkyConditions(item);
                forecast.WeatherForecastTurbulences = getTurbulenceConditions(item);
                forecast.WeatherForecastIcingConditions = getIcingConditions(item);
                forecast.WeatherForecastTemperatures = getTemperatures(item);

                result.Add(forecast);

            }
            return result;
        }
        public async Task<DataResponse> GetTAF_ADDS_All()
        {
            var stations = await _context.Airports.Where(q => q.ICAO.StartsWith("OI") || q.ICAO.StartsWith("ORNI")).Select(q => q.ICAO).ToListAsync();
            // var oldTafs = await _context.WeatherTafs.Where(q => stations.Contains(q.StationId)).ToListAsync();

            var baseDate = DateTime.Now.Date;
            var tz1 = Math.Abs(TimeZoneInfo.Local.GetUtcOffset(baseDate).TotalMinutes);
            var offset1 = "";
            if (tz1 == 210)
                offset1 = "+0330";
            else
                offset1 = "+0430";
            var from = baseDate.Date.ToString("yyyy-MM-dd") + "T00:00:00" + offset1;
            var to = baseDate.Date.AddDays(1).Date.ToString("yyyy-MM-dd") + "T00:00:00" + offset1;
            List<Models.WeatherTaf> result = new List<Models.WeatherTaf>();
            foreach (var station in stations)
            {
                try
                {
                    // var station = apt.ICAO;
                    var url = "https://www.aviationweather.gov/adds/dataserver_current/httpparam?dataSource=tafs&requestType=retrieve&format=xml"
                   + "&startTime=" + from//"2021-08-10T00:00:00+0430"
                   + "&endTime=" + to//"2021-08-11T00:00:00+0430"
                   + "&timeType=valid"
                   + "&stationString=" + station//"OISS,OIII";
                   ;

                    XElement xml = XElement.Load(url);
                    var tafElements = xml.Descendants("TAF").ToList();
                    foreach (var item in tafElements)
                    {
                        var taf = new Models.WeatherTaf()
                        {
                            DateDay = baseDate.Date,
                            DateCreate = DateTime.Now,
                            RawText = (string)item.Element("raw_text"),
                            StationId = (string)item.Element("station_id"),
                            BulletinTime = string.IsNullOrEmpty((string)item.Element("bulletin_time")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("bulletin_time")).ToUniversalTime(),
                            ValidTimeFrom = string.IsNullOrEmpty((string)item.Element("valid_time_from")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("valid_time_from")).ToUniversalTime(),
                            ValidTimeTo = string.IsNullOrEmpty((string)item.Element("valid_time_to")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("valid_time_to")).ToUniversalTime(),
                            IssueTime = string.IsNullOrEmpty((string)item.Element("issue_time")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("issue_time")).ToUniversalTime(),
                            Latitude = Convert.ToDecimal((string)item.Element("latitude")),
                            Longitude = Convert.ToDecimal((string)item.Element("longitude")),
                            EvaluationM = Convert.ToDecimal((string)item.Element("elevation_m")),
                        };
                        taf.WeatherTafForecasts = getForecasts(item);
                        _context.WeatherTafs.Add(taf);

                        result.Add(taf);
                    }
                }
                catch (Exception ex)
                {

                }



            }


            var _stations = result.Select(q => q.StationId).ToList();
            var exist = await _context.WeatherTafs.Where(q => q.DateDay == baseDate && _stations.Contains(q.StationId)).ToListAsync();
            _context.WeatherTafs.RemoveRange(exist);

            var saveResult = await _context.SaveAsync();

            return new DataResponse
            {
                Data = result,
                Errors = null,
                IsSuccess = true
            };
        }
        public async Task<DataResponse> GetTAF_ADDS_FromArchive(string stations, DateTime baseDate)
        {
            baseDate = baseDate.Date;
            var tafs = await _context.WeatherTafs.Where(q => q.DateDay == baseDate && stations.Contains(q.StationId)).ToListAsync();
            var result = tafs.OrderBy(q => stations.IndexOf(q.StationId)).OrderByDescending(q => q.IssueTime).ToList();
            return new DataResponse
            {
                Data = result,
                Errors = null,
                IsSuccess = true
            };
        }
        public async Task<DataResponse> GetTAF_ADDS(string stations, string from, string to, DateTime baseDate)
        {
            baseDate = baseDate.Date;

            var url = "https://www.aviationweather.gov/adds/dataserver_current/httpparam?dataSource=tafs&requestType=retrieve&format=xml"
                + "&startTime=" + from//"2021-08-10T00:00:00+0430"
                + "&endTime=" + to//"2021-08-11T00:00:00+0430"
                + "&timeType=valid"
                + "&stationString=" + stations//"OISS,OIII";
                ;
            List<Models.WeatherTaf> result = new List<Models.WeatherTaf>();
            XElement xml = XElement.Load(url);
            var tafElements = xml.Descendants("TAF").ToList();
            foreach (var item in tafElements)
            {
                var taf = new Models.WeatherTaf()
                {
                    DateDay = baseDate.Date,
                    DateCreate = DateTime.Now,
                    RawText = (string)item.Element("raw_text"),
                    StationId = (string)item.Element("station_id"),
                    BulletinTime = string.IsNullOrEmpty((string)item.Element("bulletin_time")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("bulletin_time")).ToUniversalTime(),
                    ValidTimeFrom = string.IsNullOrEmpty((string)item.Element("valid_time_from")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("valid_time_from")).ToUniversalTime(),
                    ValidTimeTo = string.IsNullOrEmpty((string)item.Element("valid_time_to")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("valid_time_to")).ToUniversalTime(),
                    IssueTime = string.IsNullOrEmpty((string)item.Element("issue_time")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("issue_time")).ToUniversalTime(),
                    Latitude = Convert.ToDecimal((string)item.Element("latitude")),
                    Longitude = Convert.ToDecimal((string)item.Element("longitude")),
                    EvaluationM = Convert.ToDecimal((string)item.Element("elevation_m")),
                };
                taf.WeatherTafForecasts = getForecasts(item);
                _context.WeatherTafs.Add(taf);
                result.Add(taf);
            }

            var _stations = result.Select(q => q.StationId).ToList();
            var exist = await _context.WeatherTafs.Where(q => q.DateDay == baseDate && _stations.Contains(q.StationId)).ToListAsync();
            _context.WeatherTafs.RemoveRange(exist);

            var saveResult = await _context.SaveAsync();


            return new DataResponse
            {
                Data = result,
                Errors = null,
                IsSuccess = true
            };
        }




        public List<WeatherMetarSkyCondition> getSkyConditionsMETAR(XElement elem)
        {
            List<WeatherMetarSkyCondition> result = new List<WeatherMetarSkyCondition>();
            var items = elem.Elements("sky_condition").ToList();
            foreach (var item in items)
            {
                var obj = new WeatherMetarSkyCondition()
                {


                    sky_cover = item.Attribute("sky_cover") != null ? (string)item.Attribute("sky_cover") : null,
                    cloud_base_ft_agl = item.Attribute("cloud_base_ft_agl") != null ? (Nullable<int>)Convert.ToInt32((string)item.Attribute("cloud_base_ft_agl")) : null,


                };

                result.Add(obj);

            }
            return result;
        }

        public List<WeatherMetarQualityControl> getQualityControlMETAR(XElement elem)
        {
            List<WeatherMetarQualityControl> result = new List<WeatherMetarQualityControl>();
            var items = elem.Elements("quality_control_flags").ToList();
            foreach (var item in items)
            {
                var obj = new WeatherMetarQualityControl()
                {



                    corrected = item.Element("corrected") != null ? (string)item.Element("corrected") : null,
                    auto = item.Element("auto") != null ? (string)item.Element("auto") : null,
                    auto_station = item.Element("auto_station") != null ? (string)item.Element("auto_station") : null,
                    maintenance_indicator_on = item.Element("maintenance_indicator_on") != null ? (string)item.Element("maintenance_indicator_on") : null,
                    no_signal = item.Element("no_signal") != null ? (string)item.Element("no_signal") : null,
                    lightning_sensor_off = item.Element("lightning_sensor_off") != null ? (string)item.Element("lightning_sensor_off") : null,
                    freezing_rain_sensor_off = item.Element("freezing_rain_sensor_off") != null ? (string)item.Element("freezing_rain_sensor_off") : null,
                    present_weather_sensor_off = item.Element("present_weather_sensor_off") != null ? (string)item.Element("present_weather_sensor_off") : null,
                };

                result.Add(obj);

            }
            return result;
        }


        public async Task<DataResponse> GetMETAR_ADDS(string stations, string period)
        {
            var baseDate = DateTime.Now.Date;

            var url = "https://www.aviationweather.gov/adds/dataserver_current/httpparam?dataSource=metars&requestType=retrieve&format=xml&stationString="
                + stations
                + "&hoursBeforeNow=" + period;
            List<Models.WeatherMetar> result = new List<Models.WeatherMetar>();
            XElement xml = XElement.Load(url);
            var tafElements = xml.Descendants("METAR").ToList();
            foreach (var item in tafElements)
            {
                var metar = new Models.WeatherMetar()
                {
                    DateDay = baseDate.Date,
                    DateCreate = DateTime.Now,
                    RawText = (string)item.Element("raw_text"),
                    StationId = (string)item.Element("station_id"),
                    observation_time = string.IsNullOrEmpty((string)item.Element("observation_time")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("observation_time")).ToUniversalTime(),

                    latitude = Convert.ToDouble((string)item.Element("latitude")),
                    longitude = Convert.ToDouble((string)item.Element("longitude")),
                    temp_c = Convert.ToDouble((string)item.Element("temp_c")),

                    dewpoint_c = Convert.ToDouble((string)item.Element("dewpoint_c")),
                    wind_dir_degrees = Convert.ToInt32((string)item.Element("wind_dir_degrees")),
                    wind_speed_kt = Convert.ToInt32((string)item.Element("wind_speed_kt")),
                    wind_gust_kt = Convert.ToInt32((string)item.Element("wind_gust_kt")),
                    visibility_statute_mi = Convert.ToDouble((string)item.Element("visibility_statute_mi")),
                    altim_in_hg = Convert.ToDouble((string)item.Element("altim_in_hg")),
                    sea_level_pressure_mb = Convert.ToDouble((string)item.Element("sea_level_pressure_mb")),
                    flight_category = (string)item.Element("flight_category"),
                    three_hr_pressure_tendency_mb = Convert.ToDouble((string)item.Element("three_hr_pressure_tendency_mb")),
                    maxT_c = Convert.ToDouble((string)item.Element("maxT_c")),
                    minT_c = Convert.ToDouble((string)item.Element("minT_c")),
                    maxT24hr_c = Convert.ToDouble((string)item.Element("maxT24hr_c")),
                    minT24hr_c = Convert.ToDouble((string)item.Element("minT24hr_c")),
                    precip_in = Convert.ToDouble((string)item.Element("precip_in")),
                    pcp3hr_in = Convert.ToDouble((string)item.Element("pcp3hr_in")),
                    pcp6hr_in = Convert.ToDouble((string)item.Element("pcp6hr_in")),
                    pcp24hr_in = Convert.ToDouble((string)item.Element("pcp24hr_in")),
                    snow_in = Convert.ToDouble((string)item.Element("snow_in")),
                    vert_vis_ft = Convert.ToInt32((string)item.Element("vert_vis_ft")),
                    metar_type = (string)item.Element("metar_type"),
                    elevation_m = Convert.ToDouble((string)item.Element("elevation_m")),

                    FlightId = null,
                    FDPId = null,

                };
                metar.WeatherMetarSkyConditions = getSkyConditionsMETAR(item);
                metar.WeatherMetarQualityControls = getQualityControlMETAR(item);
                _context.WeatherMetars.Add(metar);
                result.Add(metar);
            }

            var _stations = result.Select(q => q.StationId).ToList();
            var exist = await _context.WeatherMetars.Where(q => q.DateDay == baseDate && _stations.Contains(q.StationId)).ToListAsync();
            _context.WeatherMetars.RemoveRange(exist);

            var saveResult = await _context.SaveAsync();


            return new DataResponse
            {
                Data = result,
                Errors = null,
                IsSuccess = true
            };
        }
        public async Task<DataResponse> GetMETAR_ADDS_ALL()
        {
            var stations = await _context.Airports.Where(q => q.ICAO.StartsWith("OI") || q.ICAO.StartsWith("ORNI")).Select(q => q.ICAO).ToListAsync();
            // var oldTafs = await _context.WeatherTafs.Where(q => stations.Contains(q.StationId)).ToListAsync();

            var baseDate = DateTime.Now.Date;
            var tz1 = Math.Abs(TimeZoneInfo.Local.GetUtcOffset(baseDate).TotalMinutes);
            var offset1 = "";
            if (tz1 == 210)
                offset1 = "+0330";
            else
                offset1 = "+0430";
            var from = baseDate.Date.ToString("yyyy-MM-dd") + "T00:00:00" + offset1;
            var to = baseDate.Date.AddDays(1).Date.ToString("yyyy-MM-dd") + "T00:00:00" + offset1;
            List<Models.WeatherMetar> result = new List<Models.WeatherMetar>();
            foreach (var station in stations)
            {
                try
                {
                    var url = "https://www.aviationweather.gov/adds/dataserver_current/httpparam?dataSource=metars&requestType=retrieve&format=xml&stationString="
                + station
                + "&startTime=" + from
                + "&endTime=" + to
                ;
                   
                    XElement xml = XElement.Load(url);
                    var tafElements = xml.Descendants("METAR").ToList();
                    foreach (var item in tafElements)
                    {
                        var metar = new Models.WeatherMetar()
                        {
                            DateDay = baseDate.Date,
                            DateCreate = DateTime.Now,
                            RawText = (string)item.Element("raw_text"),
                            StationId = (string)item.Element("station_id"),
                            observation_time = string.IsNullOrEmpty((string)item.Element("observation_time")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("observation_time")).ToUniversalTime(),

                            latitude = Convert.ToDouble((string)item.Element("latitude")),
                            longitude = Convert.ToDouble((string)item.Element("longitude")),
                            temp_c = Convert.ToDouble((string)item.Element("temp_c")),

                            dewpoint_c = Convert.ToDouble((string)item.Element("dewpoint_c")),
                            wind_dir_degrees = Convert.ToInt32((string)item.Element("wind_dir_degrees")),
                            wind_speed_kt = Convert.ToInt32((string)item.Element("wind_speed_kt")),
                            wind_gust_kt = Convert.ToInt32((string)item.Element("wind_gust_kt")),
                            visibility_statute_mi = Convert.ToDouble((string)item.Element("visibility_statute_mi")),
                            altim_in_hg = Convert.ToDouble((string)item.Element("altim_in_hg")),
                            sea_level_pressure_mb = Convert.ToDouble((string)item.Element("sea_level_pressure_mb")),
                            flight_category = (string)item.Element("flight_category"),
                            three_hr_pressure_tendency_mb = Convert.ToDouble((string)item.Element("three_hr_pressure_tendency_mb")),
                            maxT_c = Convert.ToDouble((string)item.Element("maxT_c")),
                            minT_c = Convert.ToDouble((string)item.Element("minT_c")),
                            maxT24hr_c = Convert.ToDouble((string)item.Element("maxT24hr_c")),
                            minT24hr_c = Convert.ToDouble((string)item.Element("minT24hr_c")),
                            precip_in = Convert.ToDouble((string)item.Element("precip_in")),
                            pcp3hr_in = Convert.ToDouble((string)item.Element("pcp3hr_in")),
                            pcp6hr_in = Convert.ToDouble((string)item.Element("pcp6hr_in")),
                            pcp24hr_in = Convert.ToDouble((string)item.Element("pcp24hr_in")),
                            snow_in = Convert.ToDouble((string)item.Element("snow_in")),
                            vert_vis_ft = Convert.ToInt32((string)item.Element("vert_vis_ft")),
                            metar_type = (string)item.Element("metar_type"),
                            elevation_m = Convert.ToDouble((string)item.Element("elevation_m")),

                            FlightId = null,
                            FDPId = null,

                        };
                        metar.WeatherMetarSkyConditions = getSkyConditionsMETAR(item);
                        metar.WeatherMetarQualityControls = getQualityControlMETAR(item);
                        _context.WeatherMetars.Add(metar);
                        result.Add(metar);
                    }
                }
                catch(Exception ex)
                {

                }
            }

            var exist = await _context.WeatherMetars.Where(q => q.DateDay == baseDate && stations.Contains(q.StationId)).ToListAsync();
            _context.WeatherMetars.RemoveRange(exist);

            var saveResult = await _context.SaveAsync();
            return new DataResponse
            {
                Data = result,
                Errors = null,
                IsSuccess = true
            };


        }
        public async Task<DataResponse> GetMETAR_ADDS_FromArchive(string stations, DateTime baseDate)
        {
            baseDate = baseDate.Date;
            var tafs = await _context.WeatherMetars.Where(q => q.DateDay == baseDate && stations.Contains(q.StationId)).ToListAsync();
            var result = tafs.OrderBy(q => stations.IndexOf(q.StationId)).OrderByDescending(q => q.observation_time).ToList();
            return new DataResponse
            {
                Data = result,
                Errors = null,
                IsSuccess = true
            };
        }

        public async Task<DataResponse> GetMETAR_ADDSByFDP(string stations, string from, string to)
        {
            var baseDate = DateTime.Now.Date;

            var url = "https://www.aviationweather.gov/adds/dataserver_current/httpparam?dataSource=metars&requestType=retrieve&format=xml&stationString="
                + stations
                + "&startTime=" + from
                + "&endTime=" + to
                ;
            List<Models.WeatherMetar> result = new List<Models.WeatherMetar>();
            XElement xml = XElement.Load(url);
            var tafElements = xml.Descendants("METAR").ToList();
            foreach (var item in tafElements)
            {
                var metar = new Models.WeatherMetar()
                {
                    DateDay = baseDate.Date,
                    DateCreate = DateTime.Now,
                    RawText = (string)item.Element("raw_text"),
                    StationId = (string)item.Element("station_id"),
                    observation_time = string.IsNullOrEmpty((string)item.Element("observation_time")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("observation_time")).ToUniversalTime(),

                    latitude = Convert.ToDouble((string)item.Element("latitude")),
                    longitude = Convert.ToDouble((string)item.Element("longitude")),
                    temp_c = Convert.ToDouble((string)item.Element("temp_c")),

                    dewpoint_c = Convert.ToDouble((string)item.Element("dewpoint_c")),
                    wind_dir_degrees = Convert.ToInt32((string)item.Element("wind_dir_degrees")),
                    wind_speed_kt = Convert.ToInt32((string)item.Element("wind_speed_kt")),
                    wind_gust_kt = Convert.ToInt32((string)item.Element("wind_gust_kt")),
                    visibility_statute_mi = Convert.ToDouble((string)item.Element("visibility_statute_mi")),
                    altim_in_hg = Convert.ToDouble((string)item.Element("altim_in_hg")),
                    sea_level_pressure_mb = Convert.ToDouble((string)item.Element("sea_level_pressure_mb")),
                    flight_category = (string)item.Element("flight_category"),
                    three_hr_pressure_tendency_mb = Convert.ToDouble((string)item.Element("three_hr_pressure_tendency_mb")),
                    maxT_c = Convert.ToDouble((string)item.Element("maxT_c")),
                    minT_c = Convert.ToDouble((string)item.Element("minT_c")),
                    maxT24hr_c = Convert.ToDouble((string)item.Element("maxT24hr_c")),
                    minT24hr_c = Convert.ToDouble((string)item.Element("minT24hr_c")),
                    precip_in = Convert.ToDouble((string)item.Element("precip_in")),
                    pcp3hr_in = Convert.ToDouble((string)item.Element("pcp3hr_in")),
                    pcp6hr_in = Convert.ToDouble((string)item.Element("pcp6hr_in")),
                    pcp24hr_in = Convert.ToDouble((string)item.Element("pcp24hr_in")),
                    snow_in = Convert.ToDouble((string)item.Element("snow_in")),
                    vert_vis_ft = Convert.ToInt32((string)item.Element("vert_vis_ft")),
                    metar_type = (string)item.Element("metar_type"),
                    elevation_m = Convert.ToDouble((string)item.Element("elevation_m")),

                    FlightId = null,
                    FDPId = null,

                };
                metar.WeatherMetarSkyConditions = getSkyConditionsMETAR(item);
                metar.WeatherMetarQualityControls = getQualityControlMETAR(item);
                _context.WeatherMetars.Add(metar);
                result.Add(metar);
            }

            var _stations = result.Select(q => q.StationId).ToList();
            var exist = await _context.WeatherMetars.Where(q => q.DateDay == baseDate && _stations.Contains(q.StationId)).ToListAsync();
            _context.WeatherMetars.RemoveRange(exist);

            var saveResult = await _context.SaveAsync();


            return new DataResponse
            {
                Data = result,
                Errors = null,
                IsSuccess = true
            };
        }





    }
}
