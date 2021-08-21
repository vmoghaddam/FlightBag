using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewEmployeeAb
    {
        public int Id { get; set; }
        public string PID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? CustomerId { get; set; }
        public int? GroupId { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
        public string JobGroupCategory { get; set; }
        public string NID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string IDNo { get; set; }
        public string Customer { get; set; }
        public int PersonId { get; set; }
    }
}
