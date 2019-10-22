using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
   public class T_OfficeAutomation_Document_TaiwanDeclare
    {
       [CProperty("Key")]
       public Guid OfficeAutomation_Document_TaiwanDeclare_ID { get; set; }
       public Guid OfficeAutomation_Document_TaiwanDeclare_MainID { get; set; }
       //申请豁免范围 1仅以申请人个人为单位申请 2  以组别为单位申请
       public string OfficeAutomation_Document_TaiwanDeclare_IsScope { get; set; }
       //工号
       public string OfficeAutomation_Document_TaiwanDeclare_Code { get; set; }
       //姓名
       public string OfficeAutomation_Document_TaiwanDeclare_Name { get; set; }
       //申请日期
       public DateTime OfficeAutomation_Document_TaiwanDeclare_ApplyDate { get; set; }
       //组别名称
       public string OfficeAutomation_Document_TaiwanDeclare_DeptName { get; set; }
       //职位
       public string OfficeAutomation_Document_TaiwanDeclare_Position { get; set; }
       //入职日期
       public string OfficeAutomation_Document_TaiwanDeclare_EntryDate { get; set; }
       //区域
       public string OfficeAutomation_Document_TaiwanDeclare_Region { get; set; }
       //联系电话
       public string OfficeAutomation_Document_TaiwanDeclare_Phone { get; set; }
       //生效日期
       public string OfficeAutomation_Document_TaiwanDeclare_EffectDate { get; set; }
       //区域1
       public string OfficeAutomation_Document_TaiwanDeclare_Region1 { get; set; }
       //组别名称1
       public string OfficeAutomation_Document_TaiwanDeclare_DeptName1 { get; set; }
       //生效日期1
       public string OfficeAutomation_Document_TaiwanDeclare_EffectDate1 { get; set; }
       //中台人员设置类型 1中台后勤服务人员 2中台业务支持人员
       public string OfficeAutomation_Document_TaiwanDeclare_SetUpType { get; set; }
       //中台后勤服务人员 1招聘 2拍摄 3其他
       public string OfficeAutomation_Document_TaiwanDeclare_logisticsType { get; set; }
       //中台后勤服务人员 选其他 备注
       public string OfficeAutomation_Document_TaiwanDeclare_logisticsTypeRemarks { get; set; }
       //中台业务支持人员 1联动项目营运支持 2其他
       public string OfficeAutomation_Document_TaiwanDeclare_BusinessType { get; set; }

       //中台业务支持人员2其他 备注
       public string OfficeAutomation_Document_TaiwanDeclare_BusinessTypeRemarks { get; set; }
       //备注
       public string OfficeAutomation_Document_TaiwanDeclare_Remarks { get; set; }
       //申请豁免内容 
       //1|2|3|4|5|6
       public string OfficeAutomation_Document_TaiwanDeclare_Content { get; set; }
    }
}
