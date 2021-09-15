using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class Coord
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public decimal? Lt { get; set; }
        public decimal? Lg { get; set; }
    }
}
