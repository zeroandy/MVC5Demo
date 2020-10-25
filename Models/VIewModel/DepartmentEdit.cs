using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Demo.Models
{
    public class DepartmentEdit : IValidatableObject
    {
        public int DepartmentID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MustBeEvent(ErrorMessage ="請輸入偶數的Budget資料!!")]
        public decimal Budget { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> InstructorID { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Name != "Will" || this.Budget > 100)
            {
                yield return new ValidationResult("你的預算不足", new string[] {"Name", "Budget"} );
            }
        }
    }
}