using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_OndutyVacation
    {
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_OndutyVacation_ID { get; set; }

        /// <summary>
        /// 关联主表ID
        /// </summary>
        public Guid OfficeAutomation_Document_OndutyVacation_MainID { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Document_OndutyVacation_Apply { get; set; }

        /// <summary>
        /// 填写时间
        /// </summary>
        public DateTime? OfficeAutomation_Document_OndutyVacation_ApplyDate { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string OfficeAutomation_Document_OndutyVacation_ApplyForName { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string OfficeAutomation_Document_OndutyVacation_ApplyForCode { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>
        //public DateTime? OfficeAutomation_Document_OndutyVacation_ApplyForDate { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string OfficeAutomation_Document_OndutyVacation_Position { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string OfficeAutomation_Document_OndutyVacation_ApplyForDept { get; set; }

        /// <summary>
        /// 请假类型
        /// </summary>
        public string OfficeAutomation_Document_OndutyVacation_Type { get; set; }

        /// <summary>
        /// 请假其他类型
        /// </summary>
        public string OfficeAutomation_Document_OndutyVacation_OtherType { get; set; }

        /// <summary>
        /// 请假时限开始日
        /// </summary>
        public string OfficeAutomation_Document_OndutyVacation_BeDDDate { get; set; }

        /// <summary>
        /// 请假时限开始时
        /// </summary>
        public string OfficeAutomation_Document_OndutyVacation_BeSSDate { get; set; }

        /// <summary>
        /// 请假时限开始分
        /// </summary>
        public string OfficeAutomation_Document_OndutyVacation_BeMMDate { get; set; }

        /// <summary>
        /// 请假时限结束日
        /// </summary>
        public string OfficeAutomation_Document_OndutyVacation_EndDDDate { get; set; }

        /// <summary>
        /// 请假时限结束时
        /// </summary>
        public string OfficeAutomation_Document_OndutyVacation_EndSSDate { get; set; }

        /// <summary>
        /// 请假时限结束分
        /// </summary>
        public string OfficeAutomation_Document_OndutyVacation_EndMMDate { get; set; }

        /// <summary>
        /// 请假事由
        /// </summary>
        public string OfficeAutomation_Document_OndutyVacation_Explain { get; set; }

        /// <summary>
        /// HR填写合共小时
        /// </summary>
        public string OfficeAutomation_Document_OndutyVacation_HRSumSS { get; set; }

        /// <summary>
        /// HR填写合共天数
        /// </summary>
        public string OfficeAutomation_Document_OndutyVacation_HRSumDD { get; set; }

        /// <summary>
        /// HR填写1有薪 2扣薪
        /// </summary>
        public string OfficeAutomation_Document_OndutyVacation_Salary { get; set; }

        /// <summary>
        /// HR填写1全勤 2
        /// </summary>
        public string OfficeAutomation_Document_OndutyVacation_FullDate { get; set; }

    }

}
