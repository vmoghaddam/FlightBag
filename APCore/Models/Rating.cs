using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class Rating
    {
        public Rating()
        {
            PersonRatings = new HashSet<PersonRating>();
        }

        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Rate { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<PersonRating> PersonRatings { get; set; }
    }
}
