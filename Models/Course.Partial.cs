namespace MVC5Demo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(CourseMetaData))]
    public partial class Course
    {
    }

    public partial class CourseMetaData
    {
        [Required]
        public int CourseID { get; set; }

        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1, 5)]
        [MustBeEvent]
        //[MustBeEvent(ErrorMessage ="請輸入偶數的Budget資料!!")]
        public int Credits { get; set; }
        [Required]
        public int DepartmentID { get; set; }

    }

    public class CourseEditView
    {
        [Required]
        public int CourseID { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1, 5)]
        public int Credits { get; set; }
        [Required]
        public int DepartmentID { get; set; }
    }
}
