using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewLibraryFolder
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public string Remark { get; set; }
        public string Code { get; set; }
        public string Fullcode { get; set; }
        public string TitleFormated { get; set; }
        public string TitleFormatedSpace { get; set; }
        public int? Items83 { get; set; }
        public int? Items84 { get; set; }
        public int? Items85 { get; set; }
        public int? Items86 { get; set; }
        public int? Files83 { get; set; }
        public int? Files84 { get; set; }
        public int? Files85 { get; set; }
        public int? Files86 { get; set; }
    }
}
