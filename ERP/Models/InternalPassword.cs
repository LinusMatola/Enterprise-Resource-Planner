using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFCPortal.Models
{
    public class InternalPassword
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Old Password is requierd")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "New Password is requierd")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is requierd")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }
    }
}