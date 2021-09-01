using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class OFPImport
    {
        public OFPImport()
        {
            OFPImportItems = new HashSet<OFPImportItem>();
            OFPImportProps = new HashSet<OFPImportProp>();
        }

        public int Id { get; set; }
        public string FileName { get; set; }
        public string FlightNo { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime? DateFlight { get; set; }
        public DateTime? DateCreate { get; set; }
        public string Text { get; set; }
        public string User { get; set; }
        public string TextOutput { get; set; }
        public int? FlightId { get; set; }

        public virtual ICollection<OFPImportItem> OFPImportItems { get; set; }
        public virtual ICollection<OFPImportProp> OFPImportProps { get; set; }
    }
}
