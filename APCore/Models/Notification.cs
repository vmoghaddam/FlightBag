using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? CustomerId { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; }
        public int? SenderId { get; set; }
        public bool SMS { get; set; }
        public bool Email { get; set; }
        public bool App { get; set; }
        public DateTime? DateSMSSent { get; set; }
        public DateTime? DateEmailSent { get; set; }
        public DateTime? DateAppSent { get; set; }
        public string SMSIssue { get; set; }
        public string EmailIssue { get; set; }
        public string AppIssue { get; set; }
        public DateTime? DateAppVisited { get; set; }
        public int TypeId { get; set; }
        public string Subject { get; set; }
        public int? ModuleId { get; set; }
    }
}
