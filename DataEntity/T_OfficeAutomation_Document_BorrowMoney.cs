using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_BorrowMoney
    {
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_BorrowMoney_ID { get; set; }
        public Guid OfficeAutomation_Document_BorrowMoney_MainID { get; set; }
        public string OfficeAutomation_Document_BorrowMoney_Apply { get; set; }
        public DateTime OfficeAutomation_Document_BorrowMoney_ApplyDate { get; set; }
        //流水号
        public string OfficeAutomation_Document_BorrowMoney_ApplyID { get; set; }
        public string OfficeAutomation_Document_BorrowMoney_Department { get; set; }
        public string OfficeAutomation_Document_BorrowMoney_ReplyPhone { get; set; }
        public string OfficeAutomation_Document_BorrowMoney_NeedDate { get; set; }
        public string OfficeAutomation_Document_BorrowMoney_PayK { get; set; }
        public string OfficeAutomation_Document_BorrowMoney_Acount { get; set; }
        public string OfficeAutomation_Document_BorrowMoney_Aname { get; set; }
        public string OfficeAutomation_Document_BorrowMoney_Bank { get; set; }
        public string OfficeAutomation_Document_BorrowMoney_Money { get; set; }
        public string OfficeAutomation_Document_BorrowMoney_BWMoney{ get; set; }
        public string OfficeAutomation_Document_BorrowMoney_ApplyNo{ get; set; }
        public string OfficeAutomation_Document_BorrowMoney_Dialog { get; set; }
        //财务审核人
        public string OfficeAutomation_Document_BorrowMoney_AuditorName { get; set; }
        //财务确认收单
        public string OfficeAutomation_Document_BorrowMoney_IsAgree { get; set; }
        //财务意见
        public string OfficeAutomation_Document_BorrowMoney_Suggestion { get; set; }
        public string OfficeAutomation_Document_BorrowMoney_AuditorDate { get; set; }
        //区域
        public string OfficeAutomation_Document_BorrowMoney_Area { get; set; }
      
    }
}
