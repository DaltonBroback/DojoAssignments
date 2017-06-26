
using System;
using System.ComponentModel.DataAnnotations;

namespace logreg.Models
{
    public abstract class BaseEntity {}

    public class User : BaseEntity
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name not entered")]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "Last name not entered")]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]

        public string lastname { get; set; }

        [Required(ErrorMessage = "Email address not entered")]
        [EmailAddress]
        public string email { get; set; }

        [Required(ErrorMessage = "Password not entered")]
        [MinLength(8)]
        [DataTypeAttribute(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Passwords do not match")]
        [DataTypeAttribute(DataType.Password)]
        [Compare("password", ErrorMessage = "Passwords do not match")]
        public string passwordcon { get; set; }

        // public DateTime CreatedAt { get; set; }

        // public DateTime UpdatedAt { get; set; }
    }
}