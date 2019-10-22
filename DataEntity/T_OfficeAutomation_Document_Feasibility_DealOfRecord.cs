using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 区域过往在周边楼盘的成交记录表
    /// </summary>
    public class T_OfficeAutomation_Document_Feasibility_DealOfRecord
    {
        private Guid _OfficeAutomation_Document_Feasibility_DealOfRecord_ID;
        /// <summary>
        /// 主键
        /// </summary>
        public Guid OfficeAutomation_Document_Feasibility_DealOfRecord_ID
        {
            get { return _OfficeAutomation_Document_Feasibility_DealOfRecord_ID; }
            set { _OfficeAutomation_Document_Feasibility_DealOfRecord_ID = value; }
        }

        private Guid _OfficeAutomation_Document_Feasibility_DealOfRecord_MainID;
        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_Feasibility_DealOfRecord_MainID
        {
            get { return _OfficeAutomation_Document_Feasibility_DealOfRecord_MainID; }
            set { _OfficeAutomation_Document_Feasibility_DealOfRecord_MainID = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding;
        /// <summary>
        /// 楼盘
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding
        {
            get { return _OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding; }
            set { _OfficeAutomation_Document_Feasibility_DealOfRecord_WhatBuding = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_DealOfRecord_DealBeginDate;
        /// <summary>
        /// 成交起始时段
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_DealOfRecord_DealBeginDate
        {
            get { return _OfficeAutomation_Document_Feasibility_DealOfRecord_DealBeginDate; }
            set { _OfficeAutomation_Document_Feasibility_DealOfRecord_DealBeginDate = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_DealOfRecord_DealEndDate;
        /// <summary>
        /// 成交结束时段
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_DealOfRecord_DealEndDate
        {
            get { return _OfficeAutomation_Document_Feasibility_DealOfRecord_DealEndDate; }
            set { _OfficeAutomation_Document_Feasibility_DealOfRecord_DealEndDate = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_DealOfRecord_SumGet;
        /// <summary>
        /// 买卖宗数
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_DealOfRecord_SumGet
        {
            get { return _OfficeAutomation_Document_Feasibility_DealOfRecord_SumGet; }
            set { _OfficeAutomation_Document_Feasibility_DealOfRecord_SumGet = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_DealOfRecord_SumRent;
        /// <summary>
        /// 租赁宗数
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_DealOfRecord_SumRent
        {
            get { return _OfficeAutomation_Document_Feasibility_DealOfRecord_SumRent; }
            set { _OfficeAutomation_Document_Feasibility_DealOfRecord_SumRent = value; }
        }
    }
}
