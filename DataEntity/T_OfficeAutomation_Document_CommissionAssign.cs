using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_CommissionAssign
    {
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_CommissionAssign_ID { get; set; }
        public Guid OfficeAutomation_Document_CommissionAssign_MainID { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_Apply { get; set; }
        public DateTime OfficeAutomation_Document_CommissionAssign_ApplyDate { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_ApplyID { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_Department { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_ReceiveDepartment { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_Applicant { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_Subject { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_Phone { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_ProName { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_AssignNo { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_AssignType { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_ProType { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_ProTypeOther { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_AgentType { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_AgentTypeAmount { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_AgentTypeOther { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_StartDate { get; set; }
    }
}
