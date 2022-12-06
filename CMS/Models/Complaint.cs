using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Complaint
    {

        public int complaintID { get; set; }

        public string status { get; set; }

        public string description { get; set; }

        public string response { get; set; }

        public DateTime Timestamp { get; set; }

        [Required]
        public string userID { get; set; }

        [Required]
        public string category { get; set; }


    }
}
