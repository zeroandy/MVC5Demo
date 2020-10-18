using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Demo.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceName ="Person_Name_req", ErrorMessageResourceType = typeof(Resource1))]
        public string Name { get; set; }
        [Required(ErrorMessageResourceName ="Person_Age_req", ErrorMessageResourceType = typeof(Resource1))]
        [Range(18, 99, ErrorMessageResourceName ="Person_Age_ran", ErrorMessageResourceType = typeof(Resource1))]
        public int Age { get; set; }
    }
}