using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewLegFdpItem
    {
        public int ID { get; set; }
        public DateTime? ChocksIn { get; set; }
        public DateTime? Landing { get; set; }
        public DateTime? Takeoff { get; set; }
        public DateTime? ChocksOut { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? STDLocal { get; set; }
        public DateTime? STALocal { get; set; }
        public DateTime? Date { get; set; }
        public int? FlightStatusID { get; set; }
        public DateTime? STDDay { get; set; }
        public DateTime? STADay { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? ArrivalLocal { get; set; }
    }
}
