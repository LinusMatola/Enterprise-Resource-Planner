using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KFCPortal.Controllers
{
    public class PayrollController : Controller
    {
        //DropDown : SelectListItem Define for Month & Year DropDownList.  
        List<SelectListItem> ddlMonths = new List<SelectListItem>();  
        List<SelectListItem> ddlYears = new List<SelectListItem>();  
  
        // GET: DropDown  
        public ActionResult Index(int? Year)
        {
            if (Year == null)
            {
                Year = DateTime.Now.Year;
            }

            ViewBag.linktoYearId = GetYears(Year);
            ViewBag.linktoMonthId = GetMonths(Year);
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


        //DropDown : GetMonths() will fill Months as per selected Year and Return List.  
        private SelectList GetMonths(int? iSelectedYear)
        {
            var months = Enumerable.Range(1, 12).Select(i => new
            {
                A = i,
                B = DateTimeFormatInfo.CurrentInfo.GetMonthName(i)
            });

            int CurrentMonth = 1; //January  

            if (iSelectedYear == DateTime.Now.Year)
            {
                CurrentMonth = DateTime.Now.Month;
                months = Enumerable.Range(1, CurrentMonth).Select(i => new
                {
                    A = i,
                    B = DateTimeFormatInfo.CurrentInfo.GetMonthName(i)
                });
            }

            foreach (var item in months)
            {
                ddlMonths.Add(new SelectListItem { Text = item.B.ToString(), Value = item.A.ToString() });
            }

            //Default It will Select Current Month  
            return new SelectList(ddlMonths, "Value", "Text", CurrentMonth);
        }  
        
        
    }
}