﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Demo.Models.VIewModel
{
    public class CoursesReport1VM
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int TeacherCount { get; set; }
        public int StudentCount { get; set; }
        public double? AvgGrade { get; set; }
    }
}