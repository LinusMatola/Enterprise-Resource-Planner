using KFCPortal.DBContext;
using KFCPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KFCPortal.Controllers
{
    public class RequisitionsController : Controller
    {
        KFC_DBEntitiesNew context = new KFC_DBEntitiesNew();
        // GET: Requisitions
        public ActionResult ImprestRequisition()
        {
            if (this.Session["username"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }


            imprest imprestApplication = UpdateModel();

            return this.View((object)imprestApplication);

        }

        public imprest UpdateModel()
        {
            imprest imprestApplication = new imprest();
            string[] array = WSConfig.ObjNav.GetUserByUserID(this.Session["username"].ToString()).Split(new string[1]
            {
            ":"
            }, StringSplitOptions.None);

            imprestApplication.RequestorID = this.Session["username"].ToString();
            imprestApplication.ActivityCodes = GetAllActivity();
            imprestApplication.ActivityDetails = GetActivityDetails();
            imprestApplication.BranchCodes = GetAllBranches();
            imprestApplication.BranchDetails = GetBranchDetails();
            imprestApplication.AccountNames = GetAllAccounts();
            imprestApplication.AccountDetails = GetAccountDetails();
            imprestApplication.BankAccounts = GetBankAccounts();
            imprestApplication.AllBankAccounts = GetAllBankAccounts();
            imprestApplication.PayingAccountTypes = GetAccountTypes();
            imprestApplication.VendorDetails = GetVendors();
            imprestApplication.AllVendorAccounts = GetVendorAccountList();
            imprestApplication.AllPaymentTypes = GetAllGLAccounts("Imprest");
            imprestApplication.PaymentTypeDetails = GetGLAccounts("Imprest");
            imprestApplication.Date = todaysDate();


            return imprestApplication;
        }

        public List<string> GetAllActivity()
        {
            List<Dictionary<string, string>> activityCodeAll = GetActivityDetails();
            List<string> activity = new List<string>();
            foreach (Dictionary<string, string> dict in activityCodeAll)
            {
                foreach (var vals in dict.Values)
                {
                    activity.Add(vals);
                }
            }
            return activity;
        }

        public List<Dictionary<string, string>> GetActivityDetails()
        {
            List<Dictionary<string, string>> keyValuePairs = new List<Dictionary<string, string>>();
            Dictionary<string, string> valuePairs = new Dictionary<string, string>();
            string[] activityDetails = WSConfig.ObjNav.GetActivityCode().Split(':');
            foreach (string act in activityDetails)
            {
                string[] actInfo = act.Split('|');
                if (string.IsNullOrEmpty(actInfo[0]))
                {

                }
                else
                {
                    valuePairs = new Dictionary<string, string>();
                    valuePairs.Add(actInfo[0].ToString(), actInfo[1].ToString());
                    keyValuePairs.Add(valuePairs);
                }
            }
            return keyValuePairs;
        }

        public List<string> GetAllBranches()
        {
            List<Dictionary<string, string>> branchCodeAll = GetBranchDetails();
            List<string> branch = new List<string>();
            foreach (Dictionary<string, string> dict in branchCodeAll)
            {
                foreach (var vals in dict.Values)
                {
                    branch.Add(vals);
                }
            }
            return branch;
        }

        public List<Dictionary<string, string>> GetBranchDetails()
        {
            List<Dictionary<string, string>> keyValuePairs = new List<Dictionary<string, string>>();
            Dictionary<string, string> valuePairs = new Dictionary<string, string>();
            string[] branchDetails = WSConfig.ObjNav.GetBranchCode().Split(':');
            foreach (string act in branchDetails)
            {
                string[] actInfo = act.Split('|');
                if (string.IsNullOrEmpty(actInfo[0]))
                {

                }
                else
                {
                    valuePairs = new Dictionary<string, string>();
                    valuePairs.Add(actInfo[0].ToString(), actInfo[1].ToString());
                    keyValuePairs.Add(valuePairs);
                }
            }
            return keyValuePairs;
        }

        public List<string> GetAllAccounts()
        {
            List<Dictionary<string, string>> accountCodeAll = GetAccountDetails();
            List<string> account = new List<string>();
            foreach (Dictionary<string, string> dict in accountCodeAll)
            {
                foreach (var vals in dict.Values)
                {
                    account.Add(vals);
                }
            }
            return account;
        }

        public List<Dictionary<string, string>> GetAccountDetails()
        {
            List<Dictionary<string, string>> keyValuePairs = new List<Dictionary<string, string>>();
            Dictionary<string, string> valuePairs = new Dictionary<string, string>();
            string[] accountDetails = WSConfig.ObjNav.GetAllCustomers().Split(':');
            foreach (string act in accountDetails)
            {
                string[] actInfo = act.Split('|');
                if (string.IsNullOrEmpty(actInfo[0]))
                {

                }
                else
                {
                    valuePairs = new Dictionary<string, string>();
                    valuePairs.Add(actInfo[0].ToString(), actInfo[1].ToString());
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



        public string GetAccountNumber(string accountName)
        {
            string accountNumber = string.Empty;
            imprest imp = new imprest();
            List<Dictionary<string, string>> AccountsAll = GetAccountDetails();
            if (AccountsAll.Count > 0)
            {

                foreach (Dictionary<string, string> dict in AccountsAll)
                {
                    foreach (KeyValuePair<string, string> kvp in dict)
                    {
                        if (kvp.Value == accountName)
                        {
                            imp.AccountNo = kvp.Key;
                            accountNumber = kvp.Key;
                        }
                    }
                }
            }
            return accountNumber;
        }
        public string GetPayingBankAccountName(string payingBankAccount)
        {
            string PayingBankAccountName = string.Empty;
            imprest imp = new imprest();
            List<Dictionary<string, string>> AccountsAll = GetBankAccounts();
            if (AccountsAll.Count > 0)
            {

                foreach (Dictionary<string, string> dict in AccountsAll)
                {
                    foreach (KeyValuePair<string, string> kvp in dict)
                    {
                        if (kvp.Value == payingBankAccount)
                        {
                            imp.PayingAccountName = kvp.Key;
                            PayingBankAccountName = kvp.Key;
                        }
                    }
                }
            }
            return PayingBankAccountName;
        }

        public string GetPayingVendorAccountName(string payingVendorAccount)
        {
            string PayingBankAccountName = string.Empty;
            imprest imp = new imprest();
            List<Dictionary<string, string>> AccountsAll = GetBankAccounts();
            if (AccountsAll.Count > 0)
            {

                foreach (Dictionary<string, string> dict in AccountsAll)
                {
                    foreach (KeyValuePair<string, string> kvp in dict)
                    {
                        if (kvp.Value == payingVendorAccount)
                        {
                            imp.PayingAccountName = kvp.Key;
                            PayingBankAccountName = kvp.Key;
                        }
                    }
                }
            }
            return PayingBankAccountName;
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

        public List<string> GetAccountTypes()
        {
            string[] accountTypes = { "Bank Account", "FOSA Account" };
            List<string> account = new List<string>();
            foreach (var a in accountTypes)
            {
                account.Add(a);
            }

            return account;
        }
        
        public List<string> GetAllBankAccounts()
        {
            List<Dictionary<string, string>> AllBanks = GetBankAccounts();
            List<string> account = new List<string>();
            foreach (Dictionary<string, string> dict in AllBanks)
            {
                foreach (var vals in dict.Values)
                {
                    account.Add(vals);
                }
            }
            return account;
        }

        public List<Dictionary<string, string>> GetBankAccounts()
        {
            List<Dictionary<string, string>> keyValuePairs = new List<Dictionary<string, string>>();
            Dictionary<string, string> valuePairs = new Dictionary<string, string>();
            string[] bankAccounts = WSConfig.ObjNav.GetAllBankAccounts().Split(':');
            foreach (string act in bankAccounts)
            {
                string[] actInfo = act.Split('|');
                if (string.IsNullOrEmpty(actInfo[0]))
                {

                }
                else
                {
                    valuePairs = new Dictionary<string, string>();
                    valuePairs.Add(actInfo[0].ToString(), actInfo[1].ToString());
                    keyValuePairs.Add(valuePairs);
                }
            }
            return keyValuePairs;
        }

        public List<string> GetAllVendorAccounts(string vendorName)
        {
            List<Dictionary<string, string>> AllVendors = GetVendorAccounts(vendorName);
            List<string> vendor = new List<string>();
            foreach (Dictionary<string, string> dict in AllVendors)
            {
                foreach (var vals in dict.Values)
                {
                    vendor.Add(vals);
                }
            }
            return vendor;
        }

        public List<Dictionary<string, string>> GetVendorAccounts(string vendorName)
        {
            List<Dictionary<string, string>> keyValuePairs = new List<Dictionary<string, string>>();
            Dictionary<string, string> valuePairs = new Dictionary<string, string>();
            string[] vendorAccounts = WSConfig.ObjNav.GetAllVendors(vendorName).Split(':');
            foreach (string act in vendorAccounts)
            {
                string[] actInfo = act.Split('|');
                if (string.IsNullOrEmpty(actInfo[0]))
                {

                }
                else
                {
                    valuePairs = new Dictionary<string, string>();
                    valuePairs.Add(actInfo[0].ToString(), actInfo[1].ToString());
                    keyValuePairs.Add(valuePairs);
                }
            }
            return keyValuePairs;
        }

        [HttpGet]
        public string GetActivityCode(string activityName)
        {
            string ActivityCode = string.Empty;
            try
            {
                //base.Session["username"] = userID;
                ActivityCode = WSConfig.ObjNav.GetActivityCodeUsingName(activityName);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                UpdateModel();
            }

            return ActivityCode;
        }

        [HttpGet]
        public string GetBranchCode(string branchName)
        {
            string BranchCode = string.Empty;
            try
            {
                //base.Session["username"] = userID;
                BranchCode = WSConfig.ObjNav.GetBranchCodeUsingName(branchName);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                UpdateModel();
            }

            return BranchCode;
        }

        [HttpPost]
        public string imprestApplication(string memberNo, string imprestAccount, string bankAccount, string payingAccount, string daysApplied, string startDate, string totalNet, string activityCode, string branchCode)
        {
            string ImprestAppNo = string.Empty;
            try
            {
                string actCode = GetActivityCode(activityCode);
                string braCode = GetBranchCode(branchCode);
                //base.Session["username"] = userID;
                ImprestAppNo =WSConfig.ObjNav.FnImprestApplication(memberNo, imprestAccount, bankAccount, Convert.ToInt32(payingAccount), Convert.ToInt32(daysApplied), Convert.ToDateTime(startDate), Convert.ToDecimal(totalNet), actCode, braCode);
                UpdateModel();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                UpdateModel();
            }

            return ImprestAppNo;
        }

        [HttpPost]
        public ActionResult imprestLine(string memberNo, string appNo, string accountNo, string purpose, string accName,string amount,string activityCode,string branchCode)
        {
            try
            {
                //base.Session["username"] = userID;
                string actCode = GetActivityCode(activityCode);
                string braCode = GetBranchCode(branchCode);
                WSConfig.ObjNav.FnImprestLinesApp(memberNo, appNo, accountNo, purpose,accName, Convert.ToDecimal(amount), actCode, braCode);
                //UpdateModel();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                UpdateModel();
            }

            return View();
        }


        public List<string> GetVendorAccountList()
        {
            List<Dictionary<string, string>> AllVendors = GetVendors();
            List<string> vendor = new List<string>();
            foreach (Dictionary<string, string> dict in AllVendors)
            {
                foreach (var vals in dict.Values)
                {
                    vendor.Add(vals);
                }
            }
            return vendor;
        }

        public List<Dictionary<string, string>> GetVendors()
        {
            List<Dictionary<string, string>> listDict = new List<Dictionary<string, string>>();
            Dictionary<string, string>  dict = new Dictionary<string, string>();
            using (var context = new KFC_DBEntitiesNew())
            {
                // List<KENYA_FILM_COMMISSION_Vendor> query = context.KENYA_FILM_COMMISSION_Vendor
                //                   .Where(s => s.Name.StartsWith(vendorName)).ToList();

                List<KENYA_FILM_COMMISSION_Vendor> query = context.KENYA_FILM_COMMISSION_Vendor
                                  .Where(s => !string.IsNullOrEmpty(s.Name)).OrderBy(d=>d.Name).ToList();
                foreach (var vendor in query)
                {
                    dict = new Dictionary<string, string>();
                    dict.Add(vendor.No_, vendor.Name+":"+ vendor.No_);
                    listDict.Add(dict);
                }
                                   //.FirstOrDefault<vendorName>();
            }

            return listDict;
        }

        public List<string> GetAllGLAccounts(string paymentType)
        {
            List<Dictionary<string, string>> AllPaymentTypes = GetGLAccounts(paymentType);
            List<string> types = new List<string>();
            foreach (Dictionary<string, string> dict in AllPaymentTypes)
            {
                foreach (var vals in dict.Values)
                {
                    types.Add(vals);
                }
            }
            return types;
        }



        //
        public List<Dictionary<string, string>> GetGLAccounts(string paymentType)
        {
            List<Dictionary<string, string>> keyValuePairs = new List<Dictionary<string, string>>();
            Dictionary<string, string> valuePairs = new Dictionary<string, string>();
            string[] paymentAccounts = WSConfig.ObjNav.GetAllGLAccounts(paymentType).Split(':');
            foreach (string act in paymentAccounts)
            {
                string[] actInfo = act.Split('|');
                if (string.IsNullOrEmpty(actInfo[0]))
                {

                }
                else
                {
                    valuePairs = new Dictionary<string, string>();
                    valuePairs.Add(actInfo[0].ToString(), actInfo[1].ToString());
                    keyValuePairs.Add(valuePairs);
                }
            }
            return keyValuePairs;
        }

        public string GetGLAccountNumber(string accountName)
        {
            string GLAccountNumber = string.Empty;
            imprest imp = new imprest();
            List<Dictionary<string, string>> GLAccountsAll = GetGLAccounts("Imprest");
            if (GLAccountsAll.Count > 0)
            {

                foreach (Dictionary<string, string> dict in GLAccountsAll)
                {
                    foreach (KeyValuePair<string, string> kvp in dict)
                    {
                        if (kvp.Value == accountName)
                        {
                            imp.GLAccountNo = kvp.Key;
                            GLAccountNumber = kvp.Key;
                        }
                    }
                }
            }
            return GLAccountNumber;
        }
        


    }



}