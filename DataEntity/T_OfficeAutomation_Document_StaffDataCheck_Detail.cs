using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_StaffDataCheck_Detail
    {
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_StaffDataCheck_Detail_ID { get; set; }

        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_StaffDataCheck_Detail_MainID { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_Company { get; set; }

        /// <summary>
        /// 信息提供人职位
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_ProviderPosition { get; set; }

        /// <summary>
        /// 信息提供人
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_Provider { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_Phone { get; set; }

        /// <summary>
        /// 就职部门
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_Department { get; set; }

        /// <summary>
        /// 就职部门核查
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_DepartmentResult { get; set; }

        /// <summary>
        /// 就职部门核查其它
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_DepartmentRemark { get; set; }

        /// <summary>
        /// 职位核查
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_Position { get; set; }

        /// <summary>
        /// 职位核查其它
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_PositionResult { get; set; }

        /// <summary>
        /// 是否再次入职
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_PositionRemark { get; set; }

        /// <summary>
        /// 任职时间
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_PositionDate { get; set; }

        /// <summary>
        /// 任职时间核查
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_PositionDateResult { get; set; }

        /// <summary>
        /// 任职核查其它
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_PositionDateRemark { get; set; }

        /// <summary>
        /// 离职原因
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_LeaveReason { get; set; }

        /// <summary>
        /// 离职原因核查
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_LeaveReasonResult { get; set; }

        /// <summary>
        /// 离职原因其它
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_LeaveReasonRemark { get; set; }

        /// <summary>
        /// 是否有违规行为
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_Misdeeds { get; set; }

        /// <summary>
        /// 违规备注
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_MisdeedsRemark { get; set; }

        /// <summary>
        /// 业绩情况
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_Performance { get; set; }

        /// <summary>
        /// 业绩情况备注
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_PerformanceRemark { get; set; }

        /// <summary>
        /// 带领团队规模及时间
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_TeamNumAndDate { get; set; }

        /// <summary>
        /// 带领团队规模及时间备注
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_TeamNumAndDateRemark { get; set; }

        /// <summary>
        /// 团队管理能力
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_Ability { get; set; }

        /// <summary>
        /// 团队管理能力备注
        /// </summary>
        public string OfficeAutomation_Document_StaffDataCheck_Detail_AbilityRemark { get; set; }


    }
}
