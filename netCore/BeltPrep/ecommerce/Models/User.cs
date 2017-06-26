using System.ComponentModel.DataAnnotations;

namespace ecommerce.Models
{
    public abstract class BaseEntity {}

    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Please enter first name")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "Please a valid email address")]
        [EmailAddress(ErrorMessage = "Please a valid email address")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please a password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        
        [Compare("password", ErrorMessage = "Passwords do not match")]
        public string pwconfirm { get; set; }
    }
}