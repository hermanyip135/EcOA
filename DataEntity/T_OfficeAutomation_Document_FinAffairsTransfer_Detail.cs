using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
   public class T_OfficeAutomation_Document_FinAffairsTransfer_Detail
    {
       [CProperty("Key")]
       public Guid OfficeAutomation_Document_FinAffairsTransfer_Detail_ID { get; set; }
       public Guid OfficeAutomation_Document_FinAffairsTransfer_Detail_MainID { get; set; }
       public string OfficeAutomation_Document_FinAffairsTransfer_Detail_Receipt { get; set; }//收据选择
       public string OfficeAutomation_Document_FinAffairsTransfer_Detail_ReceivablesOpenNum { get; set;}//起止号码
       public int OfficeAutomation_Document_FinAffairsTransfer_Detail_Sort { get; set; }//排序
    }
}
