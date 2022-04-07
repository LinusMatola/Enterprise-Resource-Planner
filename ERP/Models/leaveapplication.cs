using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KFCPortal.Models
{
    public class leaveapplication
    {
        public string userID { get; set; }
        public string responsibilityCenter { get; set; }
                    
        public string leaveType { get; set; }
        public string leaveTaken { get; set; }
        public int daysApplied { get; set; }
        public DateTime startDate { get; set; }
        public DateTime returnDate { get; set; }
        public DateTime endDate { get; set; }

        public string returnDateString { get; set; }
        public string endDateString { get; set; }
        public string applicationDate { get; set; }
        public bool request_Leave_Allowance { get; set; }

        public string employeeNo { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string JobTittle { get; set; }
        public string Gender { get; set; }
        public string DepartmentName { get; set; }

        
        public string SupervisorName { get; set; }
        public string SupervisorID { get; set; }
        public string SupervisorEmail { get; set; }
        public string Approveddays { get; set; }

        
                     
                      
        public string LeaveDays { get; set; }
        public string TotalLeaveTaken { get; set; }
        public string LeaveBalance { get; set; }
        public DateTime applicationDate1 { get; set; }
        public string RelieverCode { get; set; }
        public string RelieverName { get; set; }
        public int status { get; set; }
        
        
        public string CellPhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public string applicantComments { get; set; }

        public List<string> leaveTypes { get; set; }
        public List<string> employees { get; set; }

        public List<Dictionary<string,string>> reliever { get; set; }


    }
}