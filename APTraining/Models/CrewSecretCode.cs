﻿using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class CrewSecretCode
    {
        public int CrewId { get; set; }
        public string Code { get; set; }
        public string Remark { get; set; }
    }
}
