using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Demo.Models.VIewModel
{
    public class LoginVM
    {
        [Required] [StringLength(16)]
        public string Username { get; set; }

        [Required]
        [MinLength(3), MaxLength(16)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}