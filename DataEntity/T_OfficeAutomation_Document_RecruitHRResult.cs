using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_RecruitHRResult
    {
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_RecruitHRResult_ID { get; set; }
        public Guid OfficeAutomation_Document_RecruitHRResult_MainID { get; set; }
        public string OfficeAutomation_Document_RecruitHRResult_Dep { get; set; }
        public string OfficeAutomation_Document_RecruitHRResult_Pos { get; set; }
        public string OfficeAutomation_Document_RecruitHRResult_Name { get; set; }
        public string OfficeAutomation_Document_RecruitHRResult_Date { get; set; }
        public string OfficeAutomation_Document_RecruitHRResult_Payment { get; set; }
        public string OfficeAutomation_Document_RecruitHRResult_Grade { get; set; }
        public DateTime OfficeAutomation_Document_RecruitHRResult_Addtime { get; set; }
        public string OfficeAutomation_Document_RecruitHRResult_InputPerson { get; set; }
    }
}
