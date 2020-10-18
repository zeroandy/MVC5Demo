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
        [Required(ErrorMessage ="請輸入年紀")]
        [Range(18, 99, ErrorMessage ="請輸入{1} ~ {2}")]
        public int Age { get; set; }
    }
}