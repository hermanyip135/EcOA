using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_StaffDataCheck
    {
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_StaffDataCheck_ID { get; set; }

        /// <summary>
        /// 公共主键
        /// </summary>
        public Guid OfficeAutomation_Document_StaffDataCheck_MainID { get; set; }

        /// <summary>
        /// 申请人ID
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_ApplyID { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Apply { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime OfficeAutomation_Document_StaffDataCheck_ApplyDate { get; set; }

        /// <summary>
        /// 职位申请人
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_ApplyName { get; set; }

        /// <summary>
        /// 入职部门
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Department { get; set; }

        /// <summary>
        /// 入职职位
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Position { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_EntryDate { get; set; }

        /// <summary>
        /// 资料上交日期
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_DataTurnDate { get; set; }

        /// <summary>
        /// 薪酬
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Pay { get; set; }

        /// <summary>
        /// 是否再次入职
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_AgainEntry { get; set; }

        /// <summary>
        /// 上级主管
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Directors { get; set; }

        /// <summary>
        /// 信息来源
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_InfoSource { get; set; }

        /// <summary>
        /// 入职后带领团队
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Team { get; set; }

        /// <summary>
        /// 团队人数
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_TeamNum { get; set; }

        /// <summary>
        /// 行家过档人数
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_ExpertNum { get; set; }

        /// <summary>
        /// 过档人员中4级及以上人数
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_ExpertFourNum { get; set; }

        /// <summary>
        /// 信息提供人
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_InfoProvider { get; set; }

        /// <summary>
        /// 其他情况备注
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_OtherRemark { get; set; }

        /// <summary>
        /// 经纪证号码
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_BrokerCertificate { get; set; }

        /// <summary>
        /// 经纪证挂靠单位
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Employer { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Phone { get; set; }

        /// <summary>
        /// 紧急联系人
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_UrgentPhone { get; set; }

        /// <summary>
        /// 原任职部门
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_OldDepartment { get; set; }

        /// <summary>
        /// 原任职职位
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_OldPosition { get; set; }

        /// <summary>
        /// 原直属主管
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_OldDirectors { get; set; }

        /// <summary>
        /// 原入职日期
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_OldEntryDate { get; set; }

        /// <summary>
        /// 原离职日期
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_OldLeaveDate { get; set; }

        /// <summary>
        /// 离职性质
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_LeaveType { get; set; }

        /// <summary>
        /// 任职历史
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_EntryInfo { get; set; }

        /// <summary>
        /// 精英会情况
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_EliteSituation { get; set; }

        /// <summary>
        /// 违规会情况
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_RulesSituation { get; set; }

        /// <summary>
        /// 管理账利润
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_AcountProfit { get; set; }

        /// <summary>
        /// 月份1
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Month1 { get; set; }

        /// <summary>
        /// 应收业绩1
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Achievement1 { get; set; }

        /// <summary>
        /// 实收业绩1
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_ResultAchievement1 { get; set; }

        /// <summary>
        /// 月份2
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Month2 { get; set; }

        /// <summary>
        /// 应收业绩2
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Achievement2 { get; set; }

        /// <summary>
        /// 实收业绩2
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_ResultAchievement2 { get; set; }

        /// <summary>
        /// 月份3
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Month3 { get; set; }

        /// <summary>
        /// 应收业绩3
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Achievement3 { get; set; }

        /// <summary>
        /// 实收业绩3
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_ResultAchievement3 { get; set; }

        /// <summary>
        /// 月份4
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Month4 { get; set; }

        /// <summary>
        /// 应收业绩4
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Achievement4 { get; set; }

        /// <summary>
        /// 实收业绩4
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_ResultAchievement4 { get; set; }

        /// <summary>
        /// 月份5
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Month5 { get; set; }

        /// <summary>
        /// 应收业绩5
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Achievement5 { get; set; }

        /// <summary>
        /// 实收业绩5
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_ResultAchievement5 { get; set; }

        /// <summary>
        /// 月份6
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Month6 { get; set; }

        /// <summary>
        /// 应收业绩6
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Achievement6 { get; set; }

        /// <summary>
        /// 实收业绩6
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_ResultAchievement6 { get; set; }

        /// <summary>
        /// 应收业绩合计
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_AchievementSum { get; set; }

        /// <summary>
        /// 实收业绩合计
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_ResultAchievementSum { get; set; }

        /// <summary>
        /// 差异情况补充
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_DifferenceSituation { get; set; }


    }
}
