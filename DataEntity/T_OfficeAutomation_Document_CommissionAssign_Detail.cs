using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_CommissionAssign_Detail
    {
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_CommissionAssign_Detail_ID { get; set; }
        public Guid OfficeAutomation_Document_CommissionAssign_Detail_MainID { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_Detail_Class { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_Detail_Position { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_Detail_EmpoyeeID { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_Detail_Empoyee { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_Detail_AgentProject { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_Detail_AdviserProject { get; set; }
        public string OfficeAutomation_Document_CommissionAssign_Detail_OtherProject { get; set; }
        public DateTime? OfficeAutomation_Document_CommissionAssign_Detail_Addtime { get; set; }
        public int? OfficeAutomation_Document_CommissionAssign_Detail_Sort { get; set; }
    }
}
