using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APCore.ViewModels
{

    

    public class EFBVoyageReportViewModel
    {

        public int Id { get; set; }
        public int? FlightId { get; set; }
        public string Route { get; set; }
        public int? RestReduction { get; set; }
        public int? DutyExtention { get; set; }
        public string Report { get; set; }
        public string DatePICSignature { get; set; }
        public int? ActionedById { get; set; }
        public string DateActioned { get; set; }
        public string DateConfirmed { get; set; }
        public int? DepDelay { get; set; }
        public List<int> Irregularities { get; set; }
        public List<int> Reasons { get; set; }
        public string User { get; set; }
    }
}
