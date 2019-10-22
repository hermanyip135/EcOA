using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_HousingFundChange
    {
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_HousingFundChange_ID { get; set; }
        public Guid OfficeAutomation_Document_HousingFundChange_MainID { get; set; }
        public string OfficeAutomation_Document_HousingFundChange_Apply { get; set; }
        public DateTime OfficeAutomation_Document_HousingFundChange_ApplyDate { get; set; }
        public string OfficeAutomation_Document_HousingFundChange_Department { get; set; }
        public string OfficeAutomation_Document_HousingFundChange_ApplyID { get; set; }
        public string OfficeAutomation_Document_HousingFundChange_Remark { get; set; }
    }
}
