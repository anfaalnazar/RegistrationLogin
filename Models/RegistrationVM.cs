using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationLogin.Models
{
    public class RegistrationVM
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Your name is required")]
        public string firstname { get; set; }

        public string lastname { get; set; }
        [Range(18, 56, ErrorMessage = "Age Must be between 18 to 56")]
        public int age { get; set; }
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage = "Enter valid Email")]
        public string email { get; set; }
        public int phone { get; set; }
        public string username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string confirmpassword { get; set; }
    }
}
