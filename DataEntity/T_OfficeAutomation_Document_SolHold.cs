using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_SolHold
    {
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_SolHold_ID { get; set; }
        public Guid OfficeAutomation_Document_SolHold_MainID { get; set; }
        public string OfficeAutomation_Document_SolHold_Apply { get; set; }
        public DateTime OfficeAutomation_Document_SolHold_ApplyDate { get; set; }
        public string OfficeAutomation_Document_SolHold_ApplyID { get; set; }
        public string OfficeAutomation_Document_SolHold_Department { get; set; }
        public string OfficeAutomation_Document_SolHold_Phone { get; set; }
        public string OfficeAutomation_Document_SolHold_Address { get; set; }
        public string OfficeAutomation_Document_SolHold_Money { get; set; }
        public string OfficeAutomation_Document_SolHold_Reason { get; set; }
        public string OfficeAutomation_Document_SolHold_Summary { get; set; }
        public string OfficeAutomation_Document_SolHold_FinText { get; set; }
        public string OfficeAutomation_Document_SolHold_Remark { get; set; }
        public DateTime? OfficeAutomation_Document_SolHold_RemarkDate { get; set; }
    }
}
