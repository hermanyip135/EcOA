using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
   public class T_OfficeAutomation_Document_UtContract_PlanScale
    {
         [CProperty("Key")]
       public Guid OfficeAutomation_Document_UtContract_PlanScale_ID { get; set; }
       //关联续约或者新项目ID
       public Guid OfficeAutomation_Document_UtContract_PlanScale_MainID { get; set; }
       //工号
       public string OfficeAutomation_Document_UtContract_PlanScale_EmployeeID { get; set; }
       //姓名
       public string OfficeAutomation_Document_UtContract_PlanScale_EmployeeName { get; set; }
       //分组名
       public string OfficeAutomation_Document_UtContract_PlanScale_UnitName { get; set; }
       //分佣比例
       public int OfficeAutomation_Document_UtContract_PlanScale_Scale { get; set; }
       //开始日期
       public DateTime? OfficeAutomation_Document_UtContract_PlanScale_BeginDate { get; set; }
       //结束日期
       public DateTime? OfficeAutomation_Document_UtContract_PlanScale_EndDate { get; set; }
       //添加时间
       public DateTime OfficeAutomation_Document_UtContract_PlanScale_AddDate { get; set; }
       //排序
       public string OfficeAutomation_Document_UtContract_PlanScale_Sort { get; set; }
       //是否删除
       public string OfficeAutomation_Document_UtContract_PlanScale_IsDelete { get; set; }
    }
}
