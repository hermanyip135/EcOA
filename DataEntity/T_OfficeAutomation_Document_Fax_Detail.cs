using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
   public class T_OfficeAutomation_Document_Fax_Detail
    {
         [CProperty("Key")]
       public Guid OfficeAutomation_Document_Fax_Detail_ID { get; set; }
       //申请表ID
         public Guid OfficeAutomation_Document_Fax_Detail_Main_ID { get; set; }
       //审批表id
         public Guid OfficeAutomation_Document_Fax_Detail_Flow_ID { get; set; }
         //坐标
         public string OfficeAutomation_Document_Fax_Detail_CoordinateX { get; set; }
         public string OfficeAutomation_Document_Fax_Detail_CoordinateY { get; set; }
         //工号
         public string OfficeAutomation_Document_Fax_Detail_AuditorID { get; set; }
         //姓名
         public string OfficeAutomation_Document_Fax_Detail_AuditorName { get; set; }
    }
}
