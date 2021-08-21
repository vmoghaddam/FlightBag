using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class UserExt
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual AspNetUser IdNavigation { get; set; }
    }
}
