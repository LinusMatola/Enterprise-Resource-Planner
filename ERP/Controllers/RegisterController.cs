using KFCPortal.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KFCPortal.Models;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Reflection;
using System.Text.RegularExpressions;

namespace KFCPortal.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            base.Session["username"] = null;
            
            return View();
        }

        public string Getemail(string user)
        {
            string[] array = WSConfig.ObjNav.FnStaffInfo(user).Split(new string[1]
            {
            ":"
            }, StringSplitOptions.None);
            StaffInfo staffInfo = new StaffInfo();
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
            return staffInfo.Email;
        }
        public string GetNo(string user)
        {
            string[] array = WSConfig.ObjNav.FnStaffInfo(user).Split(new string[1]
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
            return staffInfo.No;
        }
       
        
      
        public ActionResult UserRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Getcode(Login s)
        {
            try
            {
                string text = NewPassword();
                string email = WSConfig.ObjNav.FnUpdatePassword(s.username, s.idnumber.ToString(), text);
                if (WSConfig.MailFunction(("Dear Sacco Member, Your start key for UNITED WOMEN sacco portal is  " + text) ?? "", email, "Portal password reset successful") && !string.IsNullOrEmpty(email))
                {
                    base.Session["first"] = s.username;
                    base.ViewBag.Message = "Please wait as your start key is sent to your phone and email";
                    return View("setpassword");
                }
                if (string.IsNullOrEmpty(email))
                {
                    base.Session["first"] = s.username;
                    base.ViewBag.Message = "Please wait as your start key is sent to your email or phone";
                    return View("setpassword");
                }
                base.ViewBag.Message = "Please insert correct id number and password";
            }
            catch (Exception ex)
            {
                base.ViewBag.Message = ex.Message;
            }
            return View("Register");
        }

        protected string NewPassword()
        {
            string text = "";
            Random random = new Random();
            return random.Next(1000, 1999).ToString();
        }

        public ActionResult forgotpassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authenticate(Login l)
        {
            try
            {
                string username = l.username;
                if (WSConfig.ObjNav.FnLogin(l.username, l.password))
                {
                    base.Session["username"] = l.username;
                    base.Session["password"] = l.password;
                    base.Response.Redirect("~/Dashboard/Index");
                    return null;
                }
                base.ViewBag.Message = "Authentification failed";
                return View("Index");
            }
            catch (Exception)
            {
                base.ViewBag.Message = "Password or member number cannot be empty";
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult sepass(Login s)
        {
            if (s.password != s.passconfirm)
            {
                base.ViewBag.Message = "The passwords do not much try again";
            }
            else
            {
                s.username = base.Session["first"].ToString();
                try
                {
                    if (WSConfig.ObjNav.FnChangePasswordNew(base.Session["first"].ToString(), s.username1, s.password))
                    {
                        base.Session["username"] = base.Session["first"].ToString();
                        base.Session["first"] = null;
                        base.ViewBag.Message = "You have successfully changed your password, please use it to log in to access web portal services";
                        return View("index");
                    }
                }
                catch (Exception)
                {
                    base.ViewBag.Message = "Password not created";
                }
            }
            return View("setpassword");
        }


        public ActionResult setpassword()
        {
            if (base.Session["username"] != null)
            {
                RedirectToAction("Index", "Dashboard");
            }
            return View();
        }
       
        public ActionResult LogOut()
        {
            base.Session["username"] = null;
            return View("Index");
        }


    }
}