using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class PersonRatingDocument
    {
        public int PersonRatingId { get; set; }
        public int DocumentId { get; set; }
        public string Remark { get; set; }
        public string Title { get; set; }

        public virtual Document Document { get; set; }
        public virtual PersonRating PersonRating { get; set; }
    }
}
