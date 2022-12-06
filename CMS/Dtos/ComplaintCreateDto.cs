using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Dtos
{
    public class ComplaintCreateDto
    {
      
        [Required]
        public string status { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public string response { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public string userID { get; set; }

        [Required]
        public string category { get; set; }

        
    }
}
