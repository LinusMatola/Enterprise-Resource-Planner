using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFCPortal.Models
{
    public class ForgotPassword
    {
        [Display(Name = "Staff Email ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Staff Email Id Required")]
        public string EmailId { get; set; }
    }
}