using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewTrainingSMSHistory
    {
        public int Id { get; set; }
        public int CrewId { get; set; }
        public int FlightId { get; set; }
        public DateTime? Pickup { get; set; }
        public DateTime? PickupLocal { get; set; }
        public string RefId { get; set; }
        public string Status { get; set; }
        public int? StatusId { get; set; }
        public string Message { get; set; }
        public DateTime? DateStatus { get; set; }
        public DateTime? DateSent { get; set; }
        public DateTime? DateVisit { get; set; }
        public int IsVisited { get; set; }
        public int? Type { get; set; }
        public string TypeStr { get; set; }
        public string ScheduleName { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
        public string Name { get; set; }
        public int? PersonId { get; set; }
        public string Sender { get; set; }
        public DateTime? DutyDate { get; set; }
        public int? FDPId { get; set; }
    }
}
