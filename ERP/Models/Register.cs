using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFCPortal.Models
{
    public class Register
    {
        public string username { get; set; }
        public int idNumber { get; set; }
        public string userID { get; set; }
    }
}