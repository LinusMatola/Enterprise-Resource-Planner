

// SettingsController
using KFCPortal;
using KFCPortal.Models;
using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;

public class SettingsController : Controller
{
    // GET: Settings
    public ActionResult Index()
    {
        if (base.Session["username"] == null)
        {
            return RedirectToAction("Index", "Login");
        }
        return View();
    }

    public ActionResult set(Login s)
    {
        if (base.Session["username"] == null)
        {
            return RedirectToAction("Index", "Login");
        }
        if (s.password != s.passconfirm)
        {
            base.ViewBag.Message = "The passwords do not much try again";
        }
        else
        {
            try
            {
                if (WSConfig.ObjNav.FnNewPass(base.Session["username"].ToString(), s.password, s.passconfirm))
                {
                    base.ViewBag.Message = "Password for KENYA FILM COMMISSION portal has been changed successfully";
                    return View("index");
                }
                base.ViewBag.Message = "Password not changed";
            }
            catch (Exception)
            {
                base.ViewBag.Message = "Invalid old password please contact ADMINISTRATOR";
            }
        }
        return View("index");
    }

}
