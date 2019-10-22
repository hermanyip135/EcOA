using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
   public class T_OfficeAutomation_Document_BorrowMoney_Detail
    {
       /// <summary>
       /// 本表ID
       /// </summary>
        [CProperty("Key")]
       public Guid OfficeAutomation_Document_BorrowMoney_Detail_ID { get; set; }
       /// <summary>
        /// 临时借用资金申请表主表ID
       /// </summary>
        public Guid OfficeAutomation_Document_BorrowMoney_Detail_MainID { get; set; }
       /// <summary>
       /// 起初日期
       /// </summary>
        public string OfficeAutomation_Document_BorrowMoney_Detail_StartDate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public string OfficeAutomation_Document_BorrowMoney_Detail_EndDate { get; set; }
       /// <summary>
       /// 费用项目
       /// </summary>
       public string OfficeAutomation_Document_BorrowMoney_Detail_CostProject { get; set; }
       /// <summary>
       /// 其他内容
       /// </summary>
       public string OfficeAutomation_Document_BorrowMoney_Detail_Other { get; set; }
       /// <summary>
       /// 价格
       /// </summary>
       public string OfficeAutomation_Document_BorrowMoney_Detail_UnitPrice { get; set; }
       /// <summary>
       /// 排序
       /// </summary>
       public int OfficeAutomation_Document_BorrowMoney_Detail_Sort { get; set; }
    }
}
