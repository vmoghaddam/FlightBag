using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewNotificationGroup
    {
        public int Id { get; set; }
        public string GroupTitle { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
