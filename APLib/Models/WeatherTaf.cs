﻿using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class WeatherTaf
    {
        public WeatherTaf()
        {
            WeatherTafForecasts = new HashSet<WeatherTafForecast>();
        }

        public int Id { get; set; }
        public DateTime? DateCreate { get; set; }
        public string StationId { get; set; }
        public string RawText { get; set; }
        public DateTime? IssueTime { get; set; }
        public DateTime? BulletinTime { get; set; }
        public DateTime? ValidTimeFrom { get; set; }
        public DateTime? ValidTimeTo { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? EvaluationM { get; set; }
        public string Remarks { get; set; }
        public DateTime? DateDay { get; set; }
        public int? FlightId { get; set; }
        public int? FDPId { get; set; }

        public virtual ICollection<WeatherTafForecast> WeatherTafForecasts { get; set; }
    }
}