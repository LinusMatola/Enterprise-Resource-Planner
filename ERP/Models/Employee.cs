using KFCPortal.NAVODATA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Services.Client;
using System.Linq;
using System.Net;
using System.Web;

namespace KFCPortal.Models
{
    public class Employee
    {
        public NAV nav;

        public static string Name
        {
            get;
            set;
        }

        public static string CompanyEmail
        {
            get;
            set;
        }

        public static string PersonalEmail
        {
            get;
            set;
        }

        public static string IdNumber
        {
            get;
            set;
        }

        public static string PhoneNumber
        {
            get;
            set;
        }

        public static string CellularPhoneNumber
        {
            get;
            set;
        }

        public static string Title
        {
            get;
            set;
        }

        public static string PostalAddress
        {
            get;
            set;
        }

        public static string PostalCode
        {
            get;
            set;
        }

        public static string City
        {
            get;
            set;
        }

        public static string Department
        {
            get;
            set;
        }

        public static string Institute
        {
            get;
            set;
        }

        public static string DepartmentName
        {
            get;
            set;
        }

        public static string Gender
        {
            get;
            set;
        }

        public static string UserId
        {
            get;
            set;
        }

        public static decimal LeaveAllocatedDays
        {
            get;
            set;
        }

        public static decimal LeaveDaysTotal
        {
            get;
            set;
        }

        public static decimal LeaveDaysTaken
        {
            get;
            set;
        }

        public static decimal LeaveBalance
        {
            get;
            set;
        }

        public static string ResponsibilityCenter
        {
            get;
            set;
        }

        public static string StaffNo
        {
            get;
            set;
        }

        public static decimal SickLeaveDays
        {
            get;
            set;
        }

        public Employee(string user)
        {
            NAV nAV = new NAV(new Uri(ConfigurationManager.AppSettings["ODATA_URI"]));
            nAV.Credentials = ((ICredentials)new NetworkCredential(ConfigurationManager.AppSettings["W_USER"], ConfigurationManager.AppSettings["W_PWD"], ConfigurationManager.AppSettings["DOMAIN"]));
            nav = nAV;
            //base._002Ector();
            IQueryable<StaffInfo> queryable = ((IQueryable<StaffInfo>)nav.HRLeaveApplicationCard).Where((StaffInfo employees) => employees.No == user);
            foreach (StaffInfo item in queryable)
            {
                Name = item.FirstName + " " + item.MiddleName + " " + item.LastName;
                StaffNo = item.No;
                CompanyEmail = item.Email;
                PersonalEmail = item.Email;
                IdNumber = item.Idnumber;
                PhoneNumber = item.MobileNo;
                Title = item.Job_Title;
                //PostalAddress = item.Postal_Address;
                //City = item.City;
                //CellularPhoneNumber = item.Cell_Phone_Number;
                //PostalCode = item.po;
                //Department = item.Department_Code;
                //DepartmentName = item.Department_Code;
                //Institute = item.Location_Division_Code;
                //Gender = item.Gender;
                //UserId = item.User_ID;
                //ResponsibilityCenter = item.Responsibility_Center;
                //LeaveBalance = Convert.ToDecimal(item.Leave_Balance);
                //LeaveAllocatedDays = Convert.ToDecimal(item.Allocated_Leave_Days);
                //LeaveDaysTaken = Convert.ToDecimal(item.Total_Leave_Taken);
                //LeaveDaysTotal = Convert.ToDecimal(item.Total_Leave_Days);
                //SickLeaveDays = Convert.ToDecimal(item.Sick_Leave_Acc);
            }
        }
    }
}