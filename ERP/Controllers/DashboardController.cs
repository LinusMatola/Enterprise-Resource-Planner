using KFCPortal.DBContext;
using KFCPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace KFCPortal.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            if (this.Session["username"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            string[] array = WSConfig.ObjNav.FnStaffInfo(this.Session["username"].ToString()).Split(new string[1]
            {
            ":"
            }, StringSplitOptions.None);
            StaffInfo staffInfo = new StaffInfo();
            staffInfo.No = array[0];
            staffInfo.FirstName = array[1];
            staffInfo.MiddleName = array[2];
            staffInfo.LastName = array[3];
            staffInfo.Email = array[4];
            staffInfo.Idnumber = array[10];
            staffInfo.Department_Name = array[11];
            staffInfo.Job_Title = array[5];
            staffInfo.Supervisor_Id = array[6];
            staffInfo.MobileNo = array[7];
            staffInfo.Bank_Name = array[8];
            staffInfo.username = array[9];
            staffInfo.Total_Leave = array[13].TrimEnd('.');
            staffInfo.Leave_Balance = array[12];
            staffInfo.Leave_status = array[14];
            return this.View((object)staffInfo);
        }
    }
}