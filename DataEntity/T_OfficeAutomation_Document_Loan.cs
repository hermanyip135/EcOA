using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
   public class T_OfficeAutomation_Document_Loan
    {
        /// <summary>
        /// 
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_Loan_ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid OfficeAutomation_Document_Loan_MainID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_Department { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime OfficeAutomation_Document_Loan_ApplyDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_Apply { get; set; }
        public string OfficeAutomation_Document_Loan_Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_IsContract { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_IsUpReport { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_ReportNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? OfficeAutomation_Document_Loan_TotalPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_CustomerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_LoanReason { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_IsRecePurpose { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_IsRecePurposeMoney { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? OfficeAutomation_Document_Loan_RecePurposeMoney { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_RecePurposeMonth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_IsSingleRed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_SingleRedReason { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_IsBranchRefund { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_PayeeName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_PayeeBankName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_PayeeNum { get; set; }
        public string OfficeAutomation_Document_Loan_Remarks { get; set; }
       //其他放款原因
        public string OfficeAutomation_Document_Loan_LoReMarkes { get; set; }
    }
}
