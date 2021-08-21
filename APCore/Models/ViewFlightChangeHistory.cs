using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFlightChangeHistory
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }
        public int FlightId { get; set; }
        public int? OldRegisterId { get; set; }
        public string NewRegister { get; set; }
        public string OldRegister { get; set; }
        public int? NewRegisterId { get; set; }
        public DateTime? OldSTD { get; set; }
        public DateTime? NewSTD { get; set; }
        public string OldFlightNumer { get; set; }
        public string NewFlightNumber { get; set; }
        public int? OldFromAirportId { get; set; }
        public string OldToAirport { get; set; }
        public string NewToAirport { get; set; }
        public string OldFromAirport { get; set; }
        public string NewFromAirport { get; set; }
        public int? NewFromAirportId { get; set; }
        public int? OldStatusId { get; set; }
        public int? NewStatusId { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
        public DateTime? OldOffBlock { get; set; }
        public DateTime? NewOffBlock { get; set; }
        public DateTime? OldTakeOff { get; set; }
        public DateTime? NewTakeOff { get; set; }
        public DateTime? OldLanding { get; set; }
        public DateTime? NewLanding { get; set; }
        public DateTime? OldOnBlock { get; set; }
        public DateTime? NewOnBlock { get; set; }
        public int? OldToAirportId { get; set; }
        public int? NewToAirportId { get; set; }
        public DateTime? OldSTA { get; set; }
        public DateTime? NewSTA { get; set; }
    }
}
