using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KFCPortal.Models
{
    public class approvalList
    {
        public string DocumentNo { get; set; }
        public string DocumentType { get; set; }
        public string ApprovalCode { get; set; }
        public string ApprovalType { get; set; }
        public string SenderID { get; set; }
        public string SequenceNo { get; set; }
        public string DateSent { get; set; }
        public string DueDate { get; set; }
        public string Amount { get; set; }
        public string ApproverId { get; set; }

    }

    public class approval
    {
        public List<approvalList> ApprovalList { get; set; }
    }
}