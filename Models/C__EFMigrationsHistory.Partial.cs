namespace MVC5Demo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C__EFMigrationsHistoryMetaData))]
    public partial class C__EFMigrationsHistory
    {
    }
    
    public partial class C__EFMigrationsHistoryMetaData
    {
        
        [StringLength(150, ErrorMessage="欄位長度不得大於 150 個字元")]
        [Required]
        public string MigrationId { get; set; }
        
        [StringLength(32, ErrorMessage="欄位長度不得大於 32 個字元")]
        [Required]
        public string ProductVersion { get; set; }
    }
}
