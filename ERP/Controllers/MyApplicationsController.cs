using KFCPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KFCPortal.Controllers
{
    public class MyApplicationsController : Controller
    {
        // GET: MyApplications
        public ActionResult Index()
        {
            if (this.Session["username"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            GetOpenApplications();
            return View();
        }

        public JsonResult GetOpenApplications()
        {
            string senderID = this.Session["username"].ToString();
            //string appoverID = "EOWINO";
            approval AppList = new approval();

            List<approvalList> listApproval = new List<approvalList>();
            approvalList approval = new approvalList();

            string[] arrays = WSConfig.ObjNav.FnApplicationStatus(senderID).Split(new string[1]
            {
            "||"
            }, StringSplitOptions.None);
            if (arrays.Length > 0)
            {
                foreach (string arr in arrays)
                {
                    approval = new approvalList();
                    string[] array = arr.Split(new string[1]
                    {
                            "|"
                    }, StringSplitOptions.None);
                    if (array.Length > 1)
                    {
                        approval.DocumentNo = array[0];
                        approval.DocumentType = array[1];
                        approval.ApprovalCode = array[2];
                        approval.ApprovalType = array[3];
                        approval.SequenceNo = array[4];
                        approval.DateSent = array[5];
                        approval.SenderID = array[6];
                        approval.DueDate = array[7];
                        approval.Amount = array[9];
                        listApproval.Add(approval);
                    }
                }
            }
            AppList.ApprovalList = listApproval;
            return Json(AppList, JsonRequestBehavior.AllowGet);
        }
    }
}



    
    
