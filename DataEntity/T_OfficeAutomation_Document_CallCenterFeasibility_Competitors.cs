using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_CallCenterFeasibility_Competitors
    {
        /// <summary>
        /// 主要的竞争对手布点及业绩情况表
        /// </summary>

        /// <summary>
        /// 主键
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_CallCenterFeasibility_Competitors_ID { get; set; }

        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_CallCenterFeasibility_Competitors_MainID { get; set; }

        /// <summary>
        /// 行家名称
        /// </summary>
        public string OfficeAutomation_Document_CallCenterFeasibility_Competitors_BusinessName { get; set; }

        /// <summary>
        /// 分行名称
        /// </summary>
        public string OfficeAutomation_Document_CallCenterFeasibility_Competitors_WitchBranch { get; set; }

        /// <summary>
        /// 设点时间
        /// </summary>
        public string OfficeAutomation_Document_CallCenterFeasibility_Competitors_SetUpTime { get; set; }

        /// <summary>
        /// 近期每月业绩
        /// </summary>
        public string OfficeAutomation_Document_CallCenterFeasibility_Competitors_Results { get; set; }
    }
}
