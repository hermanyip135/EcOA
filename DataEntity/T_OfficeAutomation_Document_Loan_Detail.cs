using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
   public class T_OfficeAutomation_Document_Loan_Detail
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid OfficeAutomation_Document_Loan_Detail_ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid OfficeAutomation_Document_Loan_Detail_MainID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_Detail_ReceiptNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_Detail_Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_Detail_PaymentName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_Detail_TransactionNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? OfficeAutomation_Document_Loan_Detail_BorrowMoney { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? OfficeAutomation_Document_Loan_Detail_LoanMoney { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Loan_Detail_FinanceConf { get; set; }

        public DateTime OfficeAutomation_Document_Loan_Detail_AddTime { get; set; }
    }
}
