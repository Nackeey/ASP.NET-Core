using System;
using System.ComponentModel.DataAnnotations;

namespace Eventures.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Display(Name = "Role")]
        public string UserRole { get; set; }
    }
}
