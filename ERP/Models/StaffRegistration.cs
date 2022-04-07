using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFCPortal.Models
{
    public class StaffRegistration
    {

        [Display(Name = "ID Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID Number is required")]
        public string IDNumber { get; set; }

        [Display(Name = "Staff Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = " Staff Email ID is required")]
        public string username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = " Staff ID is required")]
        public string userID { get; set; }
    }
}