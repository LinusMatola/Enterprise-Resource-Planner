using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KFCPortal.Models
{
    public class StaffInfo
    {
        public string No { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string username { get; set; }

        public string PersonalNumber { get; set; }

        public string Idnumber { get; set; }

        public string MobileNo { get; set; }
        public string Job_Title { get; set; }
        public string Supervisor_Id { get; set; }

        public string Bank_Name { get; set; }
        public string Department_Name { get; set; }
        public string Email { get; set; }
        public string Leave_Balance { get; set; }
        public string Total_Leave { get; set; }
        public string Leave_status { get; set; }

        public string Password { get; set; }

    }
}