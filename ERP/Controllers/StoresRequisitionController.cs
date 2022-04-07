using KFCPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KFCPortal.Controllers
{
    public class StoresRequisitionController : Controller
    {
        // GET: StoresRequisition
        public ActionResult Index()
        {
            if (this.Session["username"] == null)
            {
                return this.RedirectToAction("Login", "Register");
            }
            store storeApplication = UpdateModel();

            return this.View((object)storeApplication);
        }

        public string todaysDate()
        {
            DateTime time = DateTime.Now;
            return time.ToString("MM/dd/yyyy");
        }

        public store UpdateModel()
        {
            store storeApplication = new store();
            string[] array = WSConfig.ObjNav.GetUserByUserID(this.Session["username"].ToString()).Split(new string[1]
            {
            ":"
            }, StringSplitOptions.None);

            storeApplication.UserID = this.Session["username"].ToString();
            storeApplication.ActivityCodes = GetAllActivity();
            storeApplication.ActivityDetails = GetActivityDetails();
            storeApplication.LocationNames = GetAllLocations();
            storeApplication.BranchCodes = GetAllBranches();
            storeApplication.BranchCodeDetails = GetBranchCodeDetails();
            storeApplication.Date = todaysDate();


            return storeApplication;
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

        public string GetActivityDescription(string code)
        {
            string activityDescription = string.Empty;
            store store = new store();
            List<Dictionary<string, string>> AccountsAll = GetActivityDetails();
            if (AccountsAll.Count > 0)
            {

                foreach (Dictionary<string, string> dict in AccountsAll)
                {
                    foreach (KeyValuePair<string, string> kvp in dict)
                    {
                        if (kvp.Value == code)
                        {
                            store.ActivityDescription = kvp.Key;
                            activityDescription = kvp.Key;
                        }
                    }
                }
            }
            return activityDescription;
        }

        //Get Locations
        public List<string> GetAllLocations()
        {
            List<Dictionary<string, string>> locationAll = GetLocationDetails();
            List<string> location = new List<string>();
            foreach (Dictionary<string, string> dict in locationAll)
            {
                foreach (var vals in dict.Values)
                {
                    location.Add(vals);
                }
            }
            return location;
        }
        public List<Dictionary<string, string>> GetLocationDetails()
        {
            List<Dictionary<string, string>> keyValuePairs = new List<Dictionary<string, string>>();
            Dictionary<string, string> valuePairs = new Dictionary<string, string>();
            string[] locationDetails = WSConfig.ObjNav.GetLocation().Split(':');
            foreach (string act in locationDetails)
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

        //Get Branch Codes
        public List<string> GetAllBranches()
        {
            List<Dictionary<string, string>> branchCodeAll = GetBranchCodeDetails();
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

        public List<Dictionary<string, string>> GetBranchCodeDetails()
        {
            List<Dictionary<string, string>> keyValuePairs = new List<Dictionary<string, string>>();
            Dictionary<string, string> valuePairs = new Dictionary<string, string>();
            string[] brachCodeDetails = WSConfig.ObjNav.GetBranchCode().Split(':');
            foreach (string act in brachCodeDetails)
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

        public string GetBranchDescription(string branchCode)
        {
            string branchCodeDescription = string.Empty;
            store store = new store();
            List<Dictionary<string, string>> BranchCodeAll = GetBranchCodeDetails();
            if (BranchCodeAll.Count > 0)
            {

                foreach (Dictionary<string, string> dict in BranchCodeAll)
                {
                    foreach (KeyValuePair<string, string> kvp in dict)
                    {
                        if (kvp.Value == branchCode)
                        {
                            store.BranchCodeDescription = kvp.Key;
                            branchCodeDescription = kvp.Key;
                        }
                    }
                }
            }
            return branchCodeDescription;
        }
    }
}