using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
   public class T_OfficeAutomation_Document_Fax_Detail_Flow
    {
        // 主键
        [CProperty("Key")]
       public Guid OfficeAutomation_Document_Fax_Detail_Flow_ID { get; set; }

        /// 申请表主键
        public Guid OfficeAutomation_Document_Fax_Detail_Flow_MainID { get; set; }

        // 流程序号
        public int OfficeAutomation_Document_Fax_Detail_Flow_Num { get; set; }
       
       /// 部门名称
        public string OfficeAutomation_Document_Fax_Detail_Flow_Department { get; set; }
       
       // 环节号
        public string OfficeAutomation_Document_Fax_Detail_Flow_Branch { get; set; }
      
       // 审批模式
        public bool OfficeAutomation_Document_Fax_Detail_Flow_Cmodel { get; set; }
       
       // 该环节是否开启
        public bool OfficeAutomation_Document_Fax_Detail_Flow_IsOpen { get; set; }
      
       // 标号
        public int OfficeAutomation_Document_Fax_Detail_Flow_Sign { get; set; }
      
    }
}
