using KFCPortal.Properties;
using KFCPortal.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KFCPortal.Controllers
{
    
    public class P9Controller : Controller
    {
        public static int cMonth = 0;

        List<SelectListItem> ddlYears = new List<SelectListItem>();

        // GET: DropDown  
        public ActionResult Index(int? Year)
        {
            if (Year == null)
            {
                Year = DateTime.Now.Year;
            }

            ViewBag.linktoYearId = GetYears(Year);
            return View();
        }


        //DropDown : GetYears() will fill Year DropDown and Return List.  
        private SelectList GetYears(int? iSelectedYear)
        {
            int CurrentYear = DateTime.Now.Year;

            for (int i = 1980; i <= CurrentYear; i++)
            {
                ddlYears.Add(new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }

            //Default It will Select Current Year  
            return new SelectList(ddlYears, "Value", "Text", iSelectedYear);
        }


        public ActionResult PrintP9()
        {
            if (this.Session["username"] == null)
            {
                return this.RedirectToAction("Login", "Register");
            }

            try
            {
                int cMonth = VirtualParameter.cMonth;
                string dateString = DateTime.Now.ToString("ddMMyyyyhhssmm");
                Settings _settings = new Settings();
                string DownloadsPath = _settings.DownloadsPath + dateString + ".pdf";
                string pdfFileName = WSConfig.ObjNav.GenerateP9Report(this.Session["username"].ToString(), VirtualParameter.cMonth, DownloadsPath);
                Response.ContentType = "application/pdf";
                //string staffNo = Session["StaffNo"].ToString();
                

                //copyFile(idNo);
                Response.TransmitFile(DownloadsPath);
            }
            catch (Exception exception)
            {
                //cSaccoCentral.LogErrors(exception); // "Error payslip", exception.ToString());
                exception.Data.Clear();
            }
            return View();
        }
     

    }
}