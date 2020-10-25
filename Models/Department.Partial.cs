namespace MVC5Demo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(DepartmentMetaData))]
    public partial class Department : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Name != "Will" || this.Budget > 100)
            {
                yield return new ValidationResult("你的預算不足", new string[] { "Name", "Budget" });
            }
        }
    }

    public partial class DepartmentMetaData
    {
        public int DepartmentID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Name { get; set; }
        [Required]
        [MustBeEvent]
        public decimal Budget { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-mm-dd}")]
        public Nullable<System.DateTime> StartDate { get; set; }
        [Required]
        public Nullable<int> InstructorID { get; set; }
    }

    public class MustBeEventAttribute : DataTypeAttribute
    {
        public MustBeEventAttribute() : base(DataType.Text)
        {
            //default error message
            ErrorMessage = "請輸入偶數!!";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            int data = Convert.ToInt32(value);

            return (data % 2 == 0);


            //return base.IsValid(value);
        }
    }
}
