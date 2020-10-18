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
        [Required(ErrorMessage = "請輸入姓名")]
        public string Name { get; set; }
        [Required(ErrorMessage ="請輸入18 ~ 99")]
        [Range(18, 99)]
        public int Age { get; set; }
    }
}