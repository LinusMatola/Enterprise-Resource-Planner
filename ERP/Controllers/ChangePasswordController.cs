using KFCPortal.DBContext;
using KFCPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace KFCPortal.Controllers
{
    public class ChangePasswordController : Controller
    {
        KFC_DBEntities1 objCon = new KFC_DBEntities1();
        // GET: ChangePassword
        public ActionResult Index()
        {
            if (this.Session["username"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(InternalPassword model)
        {
            if (ModelState.IsValid)
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    // the principal identity is a claims identity.
                    // now we need to find the NameIdentifier claim
                    var userIdClaim = claimsIdentity.Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.Name);

                    
                    var userIdValue = userIdClaim.Value;
                    bool isValid = objCon.COPY_OF_LIVE_Online_Users.Any(x => x.userID == userIdValue);

                    if (isValid)
                    {
                        var pass = KFCPortal.Models.encryptPassword.textToEncrypt(model.OldPassword);
                        var userr = objCon.COPY_OF_LIVE_Online_Users.Where(a => a.password == pass && a.userID == userIdValue).FirstOrDefault();
                        var user_id = userr.username;
                        var user = objCon.COPY_OF_LIVE_Online_Users.Find(user_id);
                        if (user_id != null)
                        {
                            //you can encrypt password here
                            model.NewPassword = KFCPortal.Models.encryptPassword.textToEncrypt(model.NewPassword);
                            userr.password = model.NewPassword;

                            objCon.COPY_OF_LIVE_Online_Users.AddOrUpdate(userr);
                            objCon.SaveChanges();
                            //to avoid validation issues, disable it
                            objCon.Configuration.ValidateOnSaveEnabled = false;
                            //objCon.SaveChanges();
                          
                        }
                    
                    }

                }
            }

            return View();
        }
    }

}