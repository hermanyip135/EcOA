using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
   public class T_OfficeAutomation_Document_UIReq
    {
        /// <summary>
        /// UI需求申请主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_UIReq_ID { get; set; }

        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid? OfficeAutomation_Document_UIReq_MainID { get; set; }

        /// <summary>
        /// 发文部门
        /// </summary>
        public Guid? OfficeAutomation_Document_UIReq_DepartmentID { get; set; }

        /// <summary>
        /// 发文部门
        /// </summary>
        public string OfficeAutomation_Document_UIReq_Department { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Document_UIReq_Apply { get; set; }

        /// <summary>
        /// 申请部门主管
        /// </summary>
        public string OfficeAutomation_Document_UIReq_ApplyDepHeader { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime OfficeAutomation_Document_UIReq_ApplyDate { get; set; }

        /// <summary>
        /// 期望完成日期
        /// </summary>
        public DateTime? OfficeAutomation_Document_UIReq_HopeDate { get; set; }

        /// <summary>
        /// 需求内容
        /// </summary>
        public string OfficeAutomation_Document_UIReq_ReqContent { get; set; }

        /// <summary>
        /// 跟进人
        /// </summary>
        public string OfficeAutomation_Document_UIReq_Follower { get; set; }

        /// <summary>
        /// 预计完成时间
        /// </summary>
        public string OfficeAutomation_Document_UIReq_PlanTime { get; set; }

    }
}
