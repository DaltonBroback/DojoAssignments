using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace netCoreBeltExam.Models
{
    public abstract class BaseEntity {}

    public class User : BaseEntity
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        public string description { get; set;}

        [Required(ErrorMessage = "Please a valid email address")]
        [EmailAddress(ErrorMessage = "Please a valid email address")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        
        [Compare("password", ErrorMessage = "Passwords do not match")]
        public string pwconfirm { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set;}

        

    }
}