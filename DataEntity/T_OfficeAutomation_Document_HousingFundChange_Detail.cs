using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_HousingFundChange_Detail
    {
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_HousingFundChange_Detail_ID { get; set; }
        public Guid OfficeAutomation_Document_HousingFundChange_Detail_MainID { get; set; }
        public string OfficeAutomation_Document_HousingFundChange_Detail_Name { get; set; }
        public string OfficeAutomation_Document_HousingFundChange_Detail_Dep { get; set; }
        public string OfficeAutomation_Document_HousingFundChange_Detail_Code { get; set; }
        public string OfficeAutomation_Document_HousingFundChange_Detail_InDate { get; set; }
        public string OfficeAutomation_Document_HousingFundChange_Detail_Pos { get; set; }
        public string OfficeAutomation_Document_HousingFundChange_Detail_Grade { get; set; }
        public bool? OfficeAutomation_Document_HousingFundChange_Detail_IsPay { get; set; }
        public string OfficeAutomation_Document_HousingFundChange_Detail_PayMonth { get; set; }
        public string OfficeAutomation_Document_HousingFundChange_Detail_PayRate { get; set; }
        public string OfficeAutomation_Document_HousingFundChange_Detail_Reason { get; set; }
        public DateTime OfficeAutomation_Document_HousingFundChange_Detail_Addtime { get; set; }
    }
}
