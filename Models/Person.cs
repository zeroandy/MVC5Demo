using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Demo.Models
{
    public class Person
    {
        public int Id { get; set; }
        //[DisplayName("姓名")]
        [Display(Name = "Col_Name1", ResourceType = typeof(Resource1))]
        [Required(ErrorMessageResourceName ="Person_Name_req", ErrorMessageResourceType = typeof(Resource1))]
        public string Name { get; set; }
        //[DisplayName("年齡")]
        [Display(Name = "Col_Age", ResourceType = typeof(Resource1))]
        [Required(ErrorMessageResourceName ="Person_Age_req", ErrorMessageResourceType = typeof(Resource1))]
        [Range(18, 99, ErrorMessageResourceName ="Person_Age_ran", ErrorMessageResourceType = typeof(Resource1))]
        public int Age { get; set; }
    }
}