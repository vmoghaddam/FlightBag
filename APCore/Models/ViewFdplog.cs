using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFDPLog
    {
        public int Id { get; set; }
        public int? FDPId { get; set; }
        public int? CrewId { get; set; }
        public string Name { get; set; }
        public int? DutyType { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? InitStart { get; set; }
        public DateTime? InitEnd { get; set; }
        public DateTime? InitRestTo { get; set; }
        public string InitFlts { get; set; }
        public string InitRoute { get; set; }
        public string InitFromIATA { get; set; }
        public string InitToIATA { get; set; }
        public string InitNo { get; set; }
        public string InitKey { get; set; }
        public string InitRank { get; set; }
        public string InitFlights { get; set; }
        public string CanceledNo { get; set; }
        public string CanceledRoute { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public string ConfirmedBy { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; }
        public DateTime? DateAction { get; set; }
    }
}
