using KFCPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KFCPortal.Controllers
{
    public class ApprovalsController : Controller
    {
        // GET: Approvals
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
            string appoverID = this.Session["username"].ToString();
            //string appoverID = "EOWINO";
            approval AppList = new approval();
            
            List<approvalList> listApproval = new List<approvalList>();
            approvalList approval = new approvalList();

            string[] arrays = WSConfig.ObjNav.FnApprovals(appoverID).Split(new string[1]
            {
            "||"
            }, StringSplitOptions.None);
            if (arrays.Length>0) {
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
                        approval.Amount = array[8];
                        approval.ApproverId = array[9];
                        listApproval.Add(approval);
                    }
                }
            }
            AppList.ApprovalList = listApproval;
            return Json(AppList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Approve(string docNo)
        {
            try
            {
                WSConfig.ObjNav.FnApproveData(docNo);
            }

            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
        }
        [HttpPost]
        public ActionResult Reject(string docNo)
        {
            try
            {
                WSConfig.ObjNav.FnReject(docNo);
            }

            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delegate(string docNo)
        {
            try
            {
                WSConfig.ObjNav.FnDelegate(docNo);
            }

            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }


    }
             
}