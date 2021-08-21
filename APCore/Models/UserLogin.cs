using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class UserLogin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime? DateAction { get; set; }
        public int? ActionId { get; set; }
        public string Ip { get; set; }
    }
}
