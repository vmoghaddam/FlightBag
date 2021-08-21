using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class RptDelayLegBI
    {
        public int ID { get; set; }
        public DateTime? STDDay { get; set; }
        public DateTime? STDDayLocal { get; set; }
        public string MonthName { get; set; }
        public string DayName { get; set; }
        public string YearName { get; set; }
        public DateTime? LocalDate { get; set; }
        public string PDate { get; set; }
        public string PYearName { get; set; }
        public int? PYear { get; set; }
        public string PMonthName { get; set; }
        public int? PMonth { get; set; }
        public int Season { get; set; }
        public string SeasonTitle { get; set; }
        public string PDayName { get; set; }
        public int? PDay { get; set; }
        public string PYearMonthName { get; set; }
        public int FlightId { get; set; }
        public int DelayCodeId { get; set; }
        public int? DelayHH { get; set; }
        public int? DelayMM { get; set; }
        public int? Delay { get; set; }
        public int IsDelay { get; set; }
        public int DelayUnder30 { get; set; }
        public int DelayOver30 { get; set; }
        public int Delay3060 { get; set; }
        public int Delay60120 { get; set; }
        public int Delay120180 { get; set; }
        public int DelayOver180 { get; set; }
        public int DelayOver240 { get; set; }
        public int? DelayUnder30Time { get; set; }
        public int? DelayOver30Time { get; set; }
        public int? Delay3060Time { get; set; }
        public int? Delay60120Time { get; set; }
        public int? Delay120180Time { get; set; }
        public int? DelayOver180Time { get; set; }
        public int? DelayOver240Time { get; set; }
        public string Remark { get; set; }
        public string ICategory { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int DelayCategoryId { get; set; }
        public string DelayRemark { get; set; }
        public int? FlightH { get; set; }
        public byte? FlightM { get; set; }
        public DateTime? ChocksIn { get; set; }
        public DateTime? Landing { get; set; }
        public DateTime? Takeoff { get; set; }
        public DateTime? ChocksOut { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? Date { get; set; }
        public int? FlightStatusID { get; set; }
        public int? RegisterID { get; set; }
        public int? FlightTypeID { get; set; }
        public string FlightType { get; set; }
        public string FlightTypeAbr { get; set; }
        public int? TypeId { get; set; }
        public string FlightNumber { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public int? CustomerId { get; set; }
        public string FromAirportName { get; set; }
        public string FromAirportIATA { get; set; }
        public int FromAirportCityId { get; set; }
        public string ToAirportName { get; set; }
        public string ToAirportIATA { get; set; }
        public int? ToAirportCityId { get; set; }
        public string FromAirportCity { get; set; }
        public string ToAirportCity { get; set; }
        public string AircraftType { get; set; }
        public string Register { get; set; }
        public string FlightStatus { get; set; }
        public decimal? duration { get; set; }
        public int? DelayOffBlock { get; set; }
        public int? DelayTakeoff { get; set; }
        public int? DelayOnBlock { get; set; }
        public int? DelayLanding { get; set; }
        public int ActualFlightHOffBlock { get; set; }
        public decimal ActualFlightMOffBlock { get; set; }
        public int ActualFlightHTakeoff { get; set; }
        public decimal ActualFlightMTakeoff { get; set; }
        public int BaseId { get; set; }
        public string BaseIATA { get; set; }
        public string BaseName { get; set; }
        public string Route { get; set; }
        public DateTime? STDLocal { get; set; }
        public DateTime? STALocal { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? ArrivalLocal { get; set; }
        public int? BlockTime { get; set; }
        public int? FlightTime { get; set; }
        public int? TotalPax { get; set; }
        public int? TotalPaxAll { get; set; }
    }
}
