using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Dtos
{
    public class UserCreateDto
    {
        public enum UserRole
        {
            Student,
            Admin,
            Head
        }

        [RegularExpression("[A-Z][0-9][0-9]-[0-9][0-9][0-9][0-9]"), Required]
        public string userID { get; set; }

        [Required]
        public UserRole Role { get; set; }

        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$"), Required]
        public string Password { get; set; }
    }
}
