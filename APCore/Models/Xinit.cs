using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class XInit
    {
        public int Id { get; set; }
        public DateTime? InitStart { get; set; }
        public DateTime? InitEnd { get; set; }
        public DateTime? InitRestTo { get; set; }
        public string InitScheduleName { get; set; }
        public int? InitFromIATA { get; set; }
        public int? InitToIATA { get; set; }
        public string InitGroup { get; set; }
        public int? InitHomeBase { get; set; }
        public string InitFlts { get; set; }
        public string InitRoute { get; set; }
        public int? InitIndex { get; set; }
        public string InitRank { get; set; }
        public string InitFlights { get; set; }
        public string InitNo { get; set; }
        public string InitKey { get; set; }
    }
}
