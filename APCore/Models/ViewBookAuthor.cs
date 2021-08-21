using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewBookAuthor
    {
        public int TypeId { get; set; }
        public int PersonMiscId { get; set; }
        public int Id { get; set; }
        public int BookId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public int PersonTypeId { get; set; }
        public string PersonType { get; set; }
        public string Type { get; set; }
    }
}
