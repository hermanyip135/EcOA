using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 主要的竞争对手布点及业绩情况表
    /// </summary>
    public class T_OfficeAutomation_Document_Feasibility_Competitors
    {
        private Guid _OfficeAutomation_Document_Feasibility_Competitors_ID;
        /// <summary>
        /// 主键
        /// </summary>
        public Guid OfficeAutomation_Document_Feasibility_Competitors_ID
        {
            get { return _OfficeAutomation_Document_Feasibility_Competitors_ID; }
            set { _OfficeAutomation_Document_Feasibility_Competitors_ID = value; }
        }

        private Guid _OfficeAutomation_Document_Feasibility_Competitors_MainID;
        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_Feasibility_Competitors_MainID
        {
            get { return _OfficeAutomation_Document_Feasibility_Competitors_MainID; }
            set { _OfficeAutomation_Document_Feasibility_Competitors_MainID = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_Competitors_BusinessName;
        /// <summary>
        /// 行家名称
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_Competitors_BusinessName
        {
            get { return _OfficeAutomation_Document_Feasibility_Competitors_BusinessName; }
            set { _OfficeAutomation_Document_Feasibility_Competitors_BusinessName = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_Competitors_WitchBranch;
        /// <summary>
        /// 分行名称
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_Competitors_WitchBranch
        {
            get { return _OfficeAutomation_Document_Feasibility_Competitors_WitchBranch; }
            set { _OfficeAutomation_Document_Feasibility_Competitors_WitchBranch = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_Competitors_SetUpTime;
        /// <summary>
        /// 设点时间
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_Competitors_SetUpTime
        {
            get { return _OfficeAutomation_Document_Feasibility_Competitors_SetUpTime; }
            set { _OfficeAutomation_Document_Feasibility_Competitors_SetUpTime = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_Competitors_Results;
        /// <summary>
        /// 近期每月业绩
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_Competitors_Results
        {
            get { return _OfficeAutomation_Document_Feasibility_Competitors_Results; }
            set { _OfficeAutomation_Document_Feasibility_Competitors_Results = value; }
        }
    }
}
