using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
   public class T_OfficeAutomation_Document_HousingFundBaseAdjust_Detail
    {
        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_HousingFundBaseAdjust_Detail_ID { get; set; }

        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid? OfficeAutomation_Document_HousingFundBaseAdjust_Detail_MainID { get; set; }

        /// <summary>
        /// 申请人姓名
        /// </summary>
        public string OfficeAutomation_Document_HousingFundBaseAdjust_Detail_Name { get; set; }

        /// <summary>
        /// 申请人现任职部门
        /// </summary>
        public string OfficeAutomation_Document_HousingFundBaseAdjust_Detail_Dep { get; set; }

        /// <summary>
        /// 申请人工号
        /// </summary>
        public string OfficeAutomation_Document_HousingFundBaseAdjust_Detail_Code { get; set; }

        /// <summary>
        /// 申请人入职日期
        /// </summary>
        public string OfficeAutomation_Document_HousingFundBaseAdjust_Detail_InDate { get; set; }

        /// <summary>
        /// 申请人现职位
        /// </summary>
        public string OfficeAutomation_Document_HousingFundBaseAdjust_Detail_Pos { get; set; }

        /// <summary>
        /// 申请人现职级
        /// </summary>
        public string OfficeAutomation_Document_HousingFundBaseAdjust_Detail_Grade { get; set; }

        /// <summary>
        /// 申请时年份
        /// </summary>
        public string OfficeAutomation_Document_HousingFundBaseAdjust_Detail_PayMonth { get; set; }

        /// <summary>
        /// 调整原因
        /// </summary>
        public string OfficeAutomation_Document_HousingFundBaseAdjust_Detail_Reason { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? OfficeAutomation_Document_HousingFundBaseAdjust_Detail_Addtime { get; set; }

        /// <summary>
        /// 等级显示基数内容
        /// </summary>
        public string OfficeAutomation_Document_HousingFundBaseAdjust_Detail_BaseText { get; set; }

        /// <summary>
        /// 选择调整基数
        /// </summary>
        public string OfficeAutomation_Document_HousingFundBaseAdjust_Detail_ChoiceBase { get; set; }

    }
}
