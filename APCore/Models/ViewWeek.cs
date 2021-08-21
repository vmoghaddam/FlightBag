using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewWeek
    {
        public DateTime Date { get; set; }
        public int? PassedDay { get; set; }
        public int? PassedWeek { get; set; }
        public int? PassedMonth { get; set; }
        public int? PassedYear { get; set; }
        public int? DayOfMonth { get; set; }
        public int? DayOfWeek { get; set; }
        public int? WeekOfMonth { get; set; }
        public int? MonthOfYear { get; set; }
        public long? Rank { get; set; }
        public long? RankDesc { get; set; }
        public long? RankMonth { get; set; }
        public long? RankMonthDesc { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}
