﻿using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class CourseRelatedCourse
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Remark { get; set; }
        public int RelatedCourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Course RelatedCourse { get; set; }
    }
}
