using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class CrewPickupSM
    {
        public int Id { get; set; }
        public int CrewId { get; set; }
        public int FlightId { get; set; }
        public DateTime? Pickup { get; set; }
        public string RefId { get; set; }
        public string Status { get; set; }
        public int? StatusId { get; set; }
        public string Message { get; set; }
        public DateTime? DateSent { get; set; }
        public DateTime? DateStatus { get; set; }
        public int? Type { get; set; }
        public DateTime? DateVisit { get; set; }
        public string RecName { get; set; }
        public string RecMobile { get; set; }
        public string Sender { get; set; }
        public DateTime? DutyDate { get; set; }
        public string DutyType { get; set; }
        public int? FDPId { get; set; }
        public string Flts { get; set; }
        public string Routes { get; set; }
        public string FltIds { get; set; }

        public virtual FDP FDP { get; set; }
    }
}
