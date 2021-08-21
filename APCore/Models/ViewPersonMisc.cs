using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewPersonMisc
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Remark { get; set; }
        public int TypeId { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Instagram { get; set; }
        public string Telegram { get; set; }
        public string LinkedIn { get; set; }
        public string Website { get; set; }
        public string Tel { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public int? Books { get; set; }
    }
}
