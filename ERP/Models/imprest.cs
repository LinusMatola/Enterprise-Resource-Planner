using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KFCPortal.Models
{
    public class imprest
    {
        public string RequestorID { get; set; }
        public string Date { get; set; }
        public string ActivityCode { get; set; }
        public string BranchCode { get; set; }
        public string AccountName { get; set; }
        public string AccountNo { get; set; }
        public string AccountType { get; set; }
        public string JobGroup { get; set; }
        public string Bank { get; set; }
        public string Vendor { get; set; }
        public string SelectedAccountType { get; set; }
        public string PayingAccountType { get; set; }
        public string PayingAccountNo { get; set; }
        public string PayingAccountName { get; set; }
        public string Status { get; set; }
        public decimal TotalNetAmount { get; set; }

        #region imprest lines details
        public string GLAccountName { get; set; }
        public string GLAccountType { get; set; }
        public string GLAccountNo { get; set; }
        public string GLAccountAmount { get; set; }
        public string GLAccountPurpose { get; set; }
        #endregion
        public List<string> PayingAccountTypes { get; set; }
        public List<string> AllVendorAccounts { get; set; }
        public List<string> ActivityCodes { get; set; }
        public List<string> BranchCodes { get; set; }
        public List<string> AccountNames { get; set; }
        public List<string> AllBankAccounts { get; set; }
        public List<string> AllPaymentTypes { get; set; }
        public List<Dictionary<string, string>> PaymentTypeDetails { get; set; }
        public List<Dictionary<string, string>> AccountDetails { get; set; }
        public List<Dictionary<string, string>> VendorDetails { get; set; }
        public List<Dictionary<string, string>> BankAccounts { get; set; }
        public List<Dictionary<string, string>> PayingAccounts { get; set; }
        public List<Dictionary<string,string>> ActivityDetails { get; set; }
        public List<Dictionary<string, string>> BranchDetails { get; set; }

        public List<Dictionary<string, string>> PayingAccountNos { get; set; }
        public List<imprestDetail> ImprestDetails { get; set; }

    }

    public class imprestDetail
    {
        public string AccountNo { get; set; }
        public string AdvanceType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Purpose { get; set; }
        public string ImprestHolder { get; set; }
    }
}
