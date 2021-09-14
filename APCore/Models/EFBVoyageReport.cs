using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class EFBVoyageReport
    {
        public EFBVoyageReport()
        {
            EFBFlightIrregularities = new HashSet<EFBFlightIrregularity>();
            EFBReasons = new HashSet<EFBReason>();
        }

        public int Id { get; set; }
        public int? FlightId { get; set; }
        public string Route { get; set; }
        public int? RestReduction { get; set; }
        public int? DutyExtention { get; set; }
        public string Report { get; set; }
        public DateTime? DatePICSignature { get; set; }
        public int? ActionedById { get; set; }
        public DateTime? DateActioned { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public int? DepDelay { get; set; }
        public string DateUpdate { get; set; }
        public string User { get; set; }
        public string JLSignedBy { get; set; }
        public DateTime? JLDatePICApproved { get; set; }
        public int? PICId { get; set; }
        public string PIC { get; set; }

        public virtual ICollection<EFBFlightIrregularity> EFBFlightIrregularities { get; set; }
        public virtual ICollection<EFBReason> EFBReasons { get; set; }
    }
}
