﻿using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class BookRelatedGroup
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Remark { get; set; }
        public int BookId { get; set; }
        public int? TypeId { get; set; }

        public virtual Book Book { get; set; }
        public virtual JobGroup Group { get; set; }
    }
}
