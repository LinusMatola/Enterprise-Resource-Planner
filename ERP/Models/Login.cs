using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFCPortal.Models
{
    public class Login
    {

        //[Display(Name = "Staff User ID")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Staff User ID Required")]
        //public string UserID { get; set; }

        //[Display(Name = "Password")]
        //[DataType(DataType.Password)]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Password Required")]
        //public string Password { get; set; }

        //[Display(Name = "Remember Me")]
        //public bool Rememberme { get; set; }
        [Display(Name = "Member number")]
        public string username
        {
            get;
            set;
        }

        public string password
        {
            get;
            set;
        }

        [Display(Name = "Reset password")]
        public string resetpassword
        {
            get;
            set;
        }

        [Display(Name = "Email")]
        public string email
        {
            get;
            set;
        }

        [Display(Name = "National id number")]
        public string idnumber
        {
            get;
            set;
        }

        [Display(Name = "Confirm password")]
        public string passconfirm
        {
            get;
            set;
        }

        public string username1
        {
            get;
            set;
        }
    }
}