using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FlightPlanItem
    {
        public FlightPlanItem()
        {
            BoxItems = new HashSet<BoxItem>();
            FlightInformations = new HashSet<FlightInformation>();
            FlightPlanCalanderCrews = new HashSet<FlightPlanCalanderCrew>();
            FlightPlanGroups = new HashSet<FlightPlanGroup>();
            FlightPlanItemPermits = new HashSet<FlightPlanItemPermit>();
        }

        public int Id { get; set; }
        public int FlightPlanId { get; set; }
        public int? TypeId { get; set; }
        public int? RegisterID { get; set; }
        public int? FlightTypeID { get; set; }
        public int? AirlineOperatorsID { get; set; }
        public string FlightNumber { get; set; }
        public int FromAirport { get; set; }
        public int ToAirport { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public int FlightH { get; set; }
        public int FlightM { get; set; }
        public string Unknown { get; set; }
        public int? StatusId { get; set; }
        public int? RouteId { get; set; }
        public int? BoxId { get; set; }
        public string DepartureRemark { get; set; }

        public virtual Organization AirlineOperators { get; set; }
        public virtual Box Box { get; set; }
        public virtual FlightPlan FlightPlan { get; set; }
        public virtual Airport FromAirportNavigation { get; set; }
        public virtual Ac_MSN Register { get; set; }
        public virtual Airport ToAirportNavigation { get; set; }
        public virtual AircraftType Type { get; set; }
        public virtual ICollection<BoxItem> BoxItems { get; set; }
        public virtual ICollection<FlightInformation> FlightInformations { get; set; }
        public virtual ICollection<FlightPlanCalanderCrew> FlightPlanCalanderCrews { get; set; }
        public virtual ICollection<FlightPlanGroup> FlightPlanGroups { get; set; }
        public virtual ICollection<FlightPlanItemPermit> FlightPlanItemPermits { get; set; }
    }
}
