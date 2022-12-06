using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public enum UserRole
    {
        Student,
        Admin,
        Head
    }

    public class User
    {
       // [RegularExpression(@"[A-Z][0-9][0-9]-[0-9][0-9][0-9][0-9]|\w+"),Required]
        public string userID { get; set; }

        [Required]
        public UserRole Role { get; set; }

       // [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$"),Required]
        public string Password { get; set; }


    }
}
