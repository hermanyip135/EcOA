using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_LinkageCoordination
    {
        //文档表主键
        public Guid OfficeAutomation_Document_LinkageCoordination_ID { get; set; }
        //文档表对应的主表ID
        public Guid OfficeAutomation_Document_LinkageCoordination_MainID { get; set; }
        //申请表类型（入职Inservice、离职Dimission、调动PersonalChange）
        public string OfficeAutomation_Document_LinkageCoordination_RecordType { get; set; }
        //申请人
        public string OfficeAutomation_Document_LinkageCoordination_Apply { get; set; }
        //申请日期
        public DateTime OfficeAutomation_Document_LinkageCoordination_ApplyDate { get; set; }
        //工号
        public string OfficeAutomation_Document_LinkageCoordination_EmpCode { get; set; }
        //姓名
        public string OfficeAutomation_Document_LinkageCoordination_EmpName { get; set; }
        //备注
        public string OfficeAutomation_Document_LinkageCoordination_Remark { get; set; }
        //直属主管
        public string OfficeAutomation_Document_LinkageCoordination_ZSSupervisor { get; set; }
        //隶属主管
        public string OfficeAutomation_Document_LinkageCoordination_LSSupervisor { get; set; }
        //入职申请-入职部门
        //public Guid OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDepartmentID { get; set; }
        public string OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDepartment { get; set; }
        //入职申请-职位
        //public Guid OfficeAutomation_Document_LinkageCoordination_Inservice_PositionID { get; set; }
        public string OfficeAutomation_Document_LinkageCoordination_Inservice_Position { get; set; }
        //入职申请-职等
        public string OfficeAutomation_Document_LinkageCoordination_Inservice_PosGrade { get; set; }
        //入职申请-基本工资
        public decimal OfficeAutomation_Document_LinkageCoordination_Inservice_BasicSalary { get; set; }
        //入职申请-入职日期
        public DateTime OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDate { get; set; }
        //入职申请-计佣角色
        public string OfficeAutomation_Document_LinkageCoordination_Inservice_EccRole { get; set; }
        //入职申请-工作性质
        public string OfficeAutomation_Document_LinkageCoordination_Inservice_WorkNature { get; set; }
        //入职申请-最近一次离职前三个月业绩
        public string OfficeAutomation_Document_LinkageCoordination_Inservice_LastComm { get; set; }
        //入职申请-亲属关系
        public string OfficeAutomation_Document_LinkageCoordination_Inservice_Relationship { get; set; }
        //入职申请-行家业绩
        public string OfficeAutomation_Document_LinkageCoordination_Inservice_OtherCompanyComm { get; set; }
        //离职申请-所属部门
        //public Guid OfficeAutomation_Document_LinkageCoordination_Dimission_DepartmentID { get; set; }
        public string OfficeAutomation_Document_LinkageCoordination_Dimission_Department { get; set; }
        //离职申请-所在职位
        //public Guid OfficeAutomation_Document_LinkageCoordination_Dimission_PositionID { get; set; }
        public string OfficeAutomation_Document_LinkageCoordination_Dimission_Position { get; set; }
        //离职申请-所在职等
        public string OfficeAutomation_Document_LinkageCoordination_Dimission_PosGrade { get; set; }
        //离职申请-离职类别
        public string OfficeAutomation_Document_LinkageCoordination_Dimission_Type { get; set; }
        //离职申请-离职原因
        public string OfficeAutomation_Document_LinkageCoordination_Dimission_Reason { get; set; }
        //离职申请-离职原因（其他内容）
        public string OfficeAutomation_Document_LinkageCoordination_Dimission_ReasonRemark { get; set; }
        //离职申请-提交辞职申请日期
        public DateTime OfficeAutomation_Document_LinkageCoordination_Dimission_ApplyDate { get; set; }
        //离职申请-最后出勤日期
        public DateTime OfficeAutomation_Document_LinkageCoordination_Dimission_LastDate { get; set; }
        //离职申请-入职日期
        public DateTime OfficeAutomation_Document_LinkageCoordination_Dimission_EnterDate { get; set; }
        //离职申请-离职前第一个月业绩（格式：月份|业绩）
        public string OfficeAutomation_Document_LinkageCoordination_Dimission_MonthComm1 { get; set; }
        //离职申请-离职前第二个月业绩（格式：月份|业绩）
        public string OfficeAutomation_Document_LinkageCoordination_Dimission_MonthComm2 { get; set; }
        //离职申请-离职前第三个月业绩（格式：月份|业绩）
        public string OfficeAutomation_Document_LinkageCoordination_Dimission_MonthComm3 { get; set; }
        //离职申请-离职前三个月业绩总计（格式：月份|业绩）
        public string OfficeAutomation_Document_LinkageCoordination_Dimission_MonthCommTotal { get; set; }

        //人事调动申请-部门（旧）
        //public Guid OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_DepartmentID { get; set; }
        public string OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_Department { get; set; }
        //人事调动申请-职位（旧）
        //public Guid OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_PositionID { get; set; }
        public string OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_Position { get; set; }
        //人事调动申请-职等（旧）
        public string OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_PosGrade { get; set; }
        //人事调动申请-基本工资（旧）
        public decimal OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_BasicSalary { get; set; }
        //人事调动申请-直属主管（旧）
        public string OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_ZSSupervisor { get; set; }
        //人事调动申请-隶属主管（旧）
        public string OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_LSSupervisor { get; set; }
        //人事调动申请-计佣角色（旧）
        public string OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_EccRole { get; set; }
        //人事调动申请-工作性质（旧）
        public string OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_WorkNature { get; set; }
        //人事调动申请-部门（旧）
        //public Guid OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_DepartmentID { get; set; }
        public string OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_Department { get; set; }
        //人事调动申请-职位（新）
        //public Guid OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_PositionID { get; set; }
        public string OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_Position { get; set; }
        //人事调动申请-职等（新）
        public string OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_PosGrade { get; set; }
        //人事调动申请-基本工资（新）
        public decimal OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_BasicSalary { get; set; }
        //人事调动申请-直属主管（新）
        public string OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_ZSSupervisor { get; set; }
        //人事调动申请-隶属主管（新）
        public string OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_LSSupervisor { get; set; }
        //人事调动申请-计佣角色（新）
        public string OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_EccRole { get; set; }
        //人事调动申请-工作性质（新）
        public string OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_WorkNature { get; set; }
        //人事调动申请-生效日期
        public DateTime OfficeAutomation_Document_LinkageCoordination_PersonalChange_EffectiveDate { get; set; }
        //人事调动申请-调动类型
        public string OfficeAutomation_Document_LinkageCoordination_PersonalChange_ChangType { get; set; }
        //人事调动申请-调动类型（其他备注）
        public string OfficeAutomation_Document_LinkageCoordination_PersonalChange_ChangTypeRemark { get; set; }
        ////申请是否逻辑删除
        //public bool OfficeAutomation_Document_LinkageCoordination_IsDelete { get; set; }
    }
}
