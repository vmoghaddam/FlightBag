using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class Airport
    {
        public Airport()
        {
            EmployeeBaseAirports = new HashSet<Employee>();
            EmployeeCurrentLocationAirportNavigations = new HashSet<Employee>();
            FlightInformationFromAirports = new HashSet<FlightInformation>();
            FlightInformationToAirports = new HashSet<FlightInformation>();
            FlightPlanItemFromAirportNavigations = new HashSet<FlightPlanItem>();
            FlightPlanItemToAirportNavigations = new HashSet<FlightPlanItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string IATA { get; set; }
        public string ICAO { get; set; }
        public int? CityId { get; set; }
        public string ImportId { get; set; }
        public string Type { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? SortIndex { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Employee> EmployeeBaseAirports { get; set; }
        public virtual ICollection<Employee> EmployeeCurrentLocationAirportNavigations { get; set; }
        public virtual ICollection<FlightInformation> FlightInformationFromAirports { get; set; }
        public virtual ICollection<FlightInformation> FlightInformationToAirports { get; set; }
        public virtual ICollection<FlightPlanItem> FlightPlanItemFromAirportNavigations { get; set; }
        public virtual ICollection<FlightPlanItem> FlightPlanItemToAirportNavigations { get; set; }
    }
}
