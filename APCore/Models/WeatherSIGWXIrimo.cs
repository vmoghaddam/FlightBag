using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class WeatherSIGWXIrimo
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public string Valid { get; set; }
        public int? Size { get; set; }
        public DateTime? DateCreate { get; set; }
        public string Title { get; set; }
        public DateTime? DateDay { get; set; }
    }
}
