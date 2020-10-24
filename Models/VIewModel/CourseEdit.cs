using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Demo.Models.VIewModel
{
    public class CourseEdit
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
    }
}