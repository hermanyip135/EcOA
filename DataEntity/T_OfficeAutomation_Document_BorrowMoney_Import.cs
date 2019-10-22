using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
   public class T_OfficeAutomation_Document_BorrowMoney_Import
    {
       [CProperty("key")]
       public Guid OfficeAutomation_Document_BorrowMoney_Import_ID { get; set; }
       //流水号
       public string OfficeAutomation_Document_BorrowMoney_Import_ApplyID { get; set; }
       //导入类型
       public string OfficeAutomation_Document_BorrowMoney_Import_Type { get; set; }
      //导入金额
       public double OfficeAutomation_Document_BorrowMoney_Import_Money { get; set; }
       //日期
       public DateTime OfficeAutomation_Document_BorrowMoney_Import_Date { get; set; }
       //导入系统当前时间
       public DateTime OfficeAutomation_Document_BorrowMoney_Import_ImportDate { get; set; }
    }
}
