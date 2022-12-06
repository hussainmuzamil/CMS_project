using System;
namespace CMS.Dtos
{
    public class ComplaintReadDto
    {

        public int complaintID { get; set; }

        public string status { get; set; }

        public string category { get; set; }

        public string description { get; set; }

        public string response { get; set; }

        public DateTime Timestamp { get; set; }

        public string userID { get; set; }


    }
}
