using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperBoxTime
    {
        public int Id { get; set; }
        public int? BoxId { get; set; }
        public int? Duration { get; set; }
        public int? Ground { get; set; }
        public int? BoxBegin { get; set; }
        public int BoxEnd { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? ActualDeparture { get; set; }
        public DateTime? ActualArrival { get; set; }
        public DateTime? ChocksOut { get; set; }
        public DateTime? ChocksIn { get; set; }
        public int? FlightStatusID { get; set; }
        public DateTime? Date { get; set; }
        public int? CalanderId { get; set; }
        public long? Rank { get; set; }
        public long? RankDesc { get; set; }
    }
}
