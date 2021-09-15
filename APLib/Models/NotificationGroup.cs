using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class NotificationGroup
    {
        public int Id { get; set; }
        public string GroupTitle { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
