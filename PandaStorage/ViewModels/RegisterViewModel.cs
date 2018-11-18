using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PandaStorage.ViewModels
{
    public class RegisterViewModel
    {   
        [Required]
        [Remote(action: "VerifyUsername", controller:"Account")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Password required minimum length must be atleast 4 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
