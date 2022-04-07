using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KFCPortal.Models
{
    public class store
    {
        public string Date { get; set; }
        public string UserID { get; set; }
        public string ActivityCode { get; set; }
        public string BranchCode { get; set; }
        public string LocationName { get; set; }
        public string ActivityDescription { get; set; }
        public string BranchCodeDescription { get; set; }
        public string Type { get; set; }
        public string No { get; set; }
        public string IssuingStore { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasure { get; set; }
        public List<string> ActivityCodes { get; set; }
        public List<string> LocationNames { get; set; }
        public List<string> BranchCodes { get; set; }
        public List<Dictionary<string, string>> ActivityDetails { get; set; }
        public List<Dictionary<string, string>> LocationDetails { get; set; }
        public List<Dictionary<string, string>> BranchCodeDetails { get; set; }
    }
}