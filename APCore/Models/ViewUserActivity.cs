using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewUserActivity
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int UserId { get; set; }
        public string Key { get; set; }
        public string Url { get; set; }
        public int? ModuleId { get; set; }
        public bool IsMain { get; set; }
        public int? CustomerId { get; set; }
        public string Remark { get; set; }
        public string PID { get; set; }
        public string NID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
