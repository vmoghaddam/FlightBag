using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewCrewAssignFDP
    {
        public int Id { get; set; }
        public int? CrewId { get; set; }
        public int? PositionId { get; set; }
        public string Position { get; set; }
        public int DutyType { get; set; }
        public int? TemplateId { get; set; }
        public int? fdpId { get; set; }
        public int? GroupId { get; set; }
        public string JobGroup { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public int SexId { get; set; }
    }
}
