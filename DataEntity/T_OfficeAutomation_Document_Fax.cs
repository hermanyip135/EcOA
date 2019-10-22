using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
  public class T_OfficeAutomation_Document_Fax
    {
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_Fax_ID { get; set; }
        public Guid OfficeAutomation_Document_Fax_MainID { get; set; }
        public string OfficeAutomation_Document_Fax_Apply { get; set; }
        public DateTime OfficeAutomation_Document_Fax_ApplyDate { get; set; }
        public string OfficeAutomation_Document_Fax_ApplyID { get; set; }
        public string OfficeAutomation_Document_Fax_Department { get; set; }
     //   public string OfficeAutomation_Document_Fax_image { get; set; }
    }
}
