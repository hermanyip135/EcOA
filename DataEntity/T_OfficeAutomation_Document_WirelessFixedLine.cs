using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 无线固话申请表
    /// </summary>
    public class T_OfficeAutomation_Document_WirelessFixedLine
    {
        private Guid _OfficeAutomation_Document_WirelessFixedLine_ID;
        /// <summary>
        /// 主键
        /// </summary>
        public Guid OfficeAutomation_Document_WirelessFixedLine_ID
        {
            get { return _OfficeAutomation_Document_WirelessFixedLine_ID; }
            set { _OfficeAutomation_Document_WirelessFixedLine_ID = value; }
        }

        private Guid _OfficeAutomation_Document_WirelessFixedLine_MainID;
        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_WirelessFixedLine_MainID
        {
            get { return _OfficeAutomation_Document_WirelessFixedLine_MainID; }
            set { _OfficeAutomation_Document_WirelessFixedLine_MainID = value; }
        }

        private string _OfficeAutomation_Document_WirelessFixedLine_Apply;
        /// <summary>
        /// 发文人员
        /// </summary>
        public string OfficeAutomation_Document_WirelessFixedLine_Apply
        {
            get { return _OfficeAutomation_Document_WirelessFixedLine_Apply; }
            set { _OfficeAutomation_Document_WirelessFixedLine_Apply = value; }
        }

        private DateTime _OfficeAutomation_Document_WirelessFixedLine_ApplyDate;
        /// <summary>
        /// 发文日期
        /// </summary>
        public DateTime OfficeAutomation_Document_WirelessFixedLine_ApplyDate
        {
            get { return _OfficeAutomation_Document_WirelessFixedLine_ApplyDate; }
            set { _OfficeAutomation_Document_WirelessFixedLine_ApplyDate = value; }
        }

        private string _OfficeAutomation_Document_WirelessFixedLine_SumNumber;
        /// <summary>
        /// 合计数量
        /// </summary>
        public string OfficeAutomation_Document_WirelessFixedLine_SumNumber
        {
            get { return _OfficeAutomation_Document_WirelessFixedLine_SumNumber; }
            set { _OfficeAutomation_Document_WirelessFixedLine_SumNumber = value; }
        }

        private string _OfficeAutomation_Document_WirelessFixedLine_ApplyID;
        /// <summary>
        /// 发文编号
        /// </summary>
        public string OfficeAutomation_Document_WirelessFixedLine_ApplyID
        {
            get { return _OfficeAutomation_Document_WirelessFixedLine_ApplyID; }
            set { _OfficeAutomation_Document_WirelessFixedLine_ApplyID = value; }
        }
    }
}
