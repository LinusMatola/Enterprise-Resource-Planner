using KFCPortal.Models;
using KFCPortal.NAVODATA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KFCPortal.Controllers
{
    public class LeaveController : Controller
    {
        public ActionResult LeaveApplication()
        {
            if (this.Session["username"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }


            leaveapplication leaveApplication = UpdateModel();
            return this.View((object)leaveApplication);  
        }

        public leaveapplication UpdateModel()
        {
            leaveapplication leaveapplication = new leaveapplication();
            string[] array = WSConfig.ObjNav.GetUserByUserID(this.Session["username"].ToString()).Split(new string[1]
            {
            ":"
            }, StringSplitOptions.None);
            

            leaveapplication.userID = array[0];
            leaveapplication.FirstName = array[1];
            leaveapplication.MiddleName = array[2];
            leaveapplication.LastName = array[3];
            leaveapplication.JobTittle = array[4];
            leaveapplication.SupervisorEmail = array[5];
            leaveapplication.DepartmentName = array[6];
            leaveapplication.Gender = array[7];
            leaveapplication.EmailAddress = array[8];
            leaveapplication.CellPhoneNumber = array[9];
            leaveapplication.DepartmentName = array[10];
            leaveapplication.LeaveBalance = array[11];
            leaveapplication.LeaveDays = array[12];
            leaveapplication.leaveTaken = array[13];
            leaveapplication.SupervisorID = array[14];
            leaveapplication.SupervisorName = array[15];
            leaveapplication.SupervisorEmail = array[16];
            leaveapplication.employeeNo = array[17];
            leaveapplication.FullName = leaveapplication.FirstName + leaveapplication.MiddleName + leaveapplication.LastName;
            leaveapplication.leaveTypes = GetLeaveType(leaveapplication.Gender);
            leaveapplication.employees = GetAllEmployees();
            leaveapplication.applicationDate = todaysDate();
            return leaveapplication;
        }
        
        //[ResponseType(typeof(leaveapplication))]
        public string GetReturnDate(DateTime startdate, int leavedays)
        {
            DateTime returnDate = startdate.AddDays(leavedays).AddDays(1);
            leaveapplication leaveapplication = new leaveapplication();
            leaveapplication.startDate = startdate;
            leaveapplication.daysApplied = leavedays;        
            leaveapplication.returnDate = returnDate;
            leaveapplication.returnDateString = returnDate.ToString("yyyy-MM-dd");
            return leaveapplication.returnDateString;
        }

        public string GetEndDate(DateTime startdate, int leavedays)
        {
            DateTime endDate = startdate.AddDays(leavedays);
            leaveapplication leaveapplication = new leaveapplication();       
            leaveapplication.endDate = endDate;
            leaveapplication.endDateString = endDate.ToString("yyyy-MM-dd");
            return leaveapplication.endDateString;
        }

        protected Employee ReturnEmployee()
        {
            return new Employee(Session["username"].ToString());
        }
        public ActionResult GetStaffNames()
        {
            if (this.Session["username"] == null)
            {
                return this.RedirectToAction("Login", "Register");
            }
            string[] array1 = WSConfig.ObjNav.GetUserFullName(this.Session["username"].ToString()).Split(new string[1]
          {
            ":"
          }, StringSplitOptions.None);
            leaveapplication staffname = new leaveapplication();
            staffname.FirstName = array1[0];
            staffname.MiddleName = array1[1];
            staffname.LastName = array1[2];
            return this.View((object)staffname);
        }

        public List<string> GetLeaveType(string gender)
        {
            string[] leaveTypes = WSConfig.ObjNav.GetLeaveTypes(gender).Split(':');
            List<string> leave = new List<string>();
            foreach (var a in leaveTypes)
            {
                leave.Add(a);
            }

            return leave;


        }

        public string GetRelieverCode(string relieverName)
        {
            string relieverCode = string.Empty;
            leaveapplication leave = new leaveapplication();
            List<Dictionary<string, string>> employeesAll = GetEmployees();
            if (employeesAll.Count > 0) {

                foreach (Dictionary<string, string> dict in employeesAll)
                {
                    foreach (KeyValuePair<string, string> kvp in dict)
                    {
                        if(kvp.Value==relieverName)
                        {
                            leave.RelieverCode = kvp.Key;
                            relieverCode = kvp.Key;
                        }
                    }
                }
            }
            return relieverCode;
        }

        public List<string> GetAllEmployees()
        {
            List<Dictionary<string, string>> employeesAll = GetEmployees();
            List<string> employee = new List<string>();
            foreach (Dictionary<string, string> dict in employeesAll)
            {
                foreach(var vals in dict.Values)
                {
                    employee.Add(vals);
                }
            }
            return employee;
        }

        public List<Dictionary<string, string>> GetEmployees()
        {
            List<Dictionary<string, string>> keyValuePairs = new List<Dictionary<string, string>>();
            Dictionary<string, string> valuePairs = new Dictionary<string, string>();
            string[] employeeDetails = WSConfig.ObjNav.GetAllEmployeeNames().Split(':');
            foreach (string emp in employeeDetails)
            {
                string[] employeeInfo = emp.Split('|');
                if (string.IsNullOrEmpty(employeeInfo[0]))
                {

                }
                else
                {
                    valuePairs = new Dictionary<string, string>();
                    valuePairs.Add(employeeInfo[0].ToString(), employeeInfo[1].ToString());
                    keyValuePairs.Add(valuePairs);
                }
            }
            return keyValuePairs;
        }

        public string todaysDate()
        {
            DateTime time = DateTime.Now;
            return time.ToString("MM/dd/yyyy");
        }

       // GET: Leave
       // [Authorize]
        [HttpPost]
        public ActionResult LeaveApplication(string employeeNo, string FullName, string leaveType, string daysApplied, string startDate, string returnDate, string applicationDate, string status, string endDate, string userID, string applicantComments, string responsibilityCenter, string request_Leave_Allowance,string RelieverCode, string RelieverName)
        {


            try
            {
               // base.Session["username"] = userID;
                
                WSConfig.ObjNav.HRLeaveAppInsert(employeeNo, FullName, leaveType, Convert.ToInt16(daysApplied), Convert.ToDateTime(startDate), Convert.ToDateTime(returnDate), Convert.ToDateTime(applicationDate),Convert.ToInt16(status), Convert.ToDateTime(endDate), userID, "", "", Convert.ToBoolean(request_Leave_Allowance), RelieverCode, RelieverName);
                //UpdateModel();
                return this.RedirectToAction("LeaveApplication", "Leave");
                //ViewBag.Message = "Application successful wait for approval";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                //UpdateModel();
            }

            return View();
        }


    }
}