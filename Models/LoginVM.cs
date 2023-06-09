﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationLogin.Models
{
    public class LoginVM
    {
        public int userid { get; set; }
        [Required(ErrorMessage = "Username is required")]
        
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
   
        public string Password { get; set; }
    }
}
