using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class FileType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FileExtension { get; set; }
        public string IconUrl { get; set; }
        public string Remark { get; set; }
    }
}
