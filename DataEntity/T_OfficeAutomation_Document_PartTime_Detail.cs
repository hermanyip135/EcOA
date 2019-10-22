using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_PartTime_Detail
    {
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_PartTime_Detail_ID { get; set; }
        public Guid OfficeAutomation_Document_PartTime_Detail_MainID { get; set; }
        public string OfficeAutomation_Document_PartTime_Detail_Duty { get; set; }
        public string OfficeAutomation_Document_PartTime_Detail_StartDate { get; set; }
        public string OfficeAutomation_Document_PartTime_Detail_EndDate { get; set; }
        public string OfficeAutomation_Document_PartTime_Detail_Day { get; set; }
        public string OfficeAutomation_Document_PartTime_Detail_Count { get; set; }
        public string OfficeAutomation_Document_PartTime_Detail_Payment { get; set; }
        public string OfficeAutomation_Document_PartTime_Detail_TotalCost { get; set; }
        public DateTime OfficeAutomation_Document_PartTime_Detail_Addtime { get; set; }
    }
}
