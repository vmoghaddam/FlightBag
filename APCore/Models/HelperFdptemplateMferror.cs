using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperFDPTemplateMFError
    {
        public int Id { get; set; }
        public int? FlightId { get; set; }
        public int Males { get; set; }
        public int Females { get; set; }
    }
}
