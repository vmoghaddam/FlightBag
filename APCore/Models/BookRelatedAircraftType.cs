using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class BookRelatedAircraftType
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AircraftTypeId { get; set; }
        public string Remark { get; set; }

        public virtual AircraftType AircraftType { get; set; }
        public virtual Book Book { get; set; }
    }
}
