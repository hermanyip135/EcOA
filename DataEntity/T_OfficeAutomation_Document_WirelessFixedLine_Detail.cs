using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 无线固话申请明细表
    /// </summary>
    public class T_OfficeAutomation_Document_WirelessFixedLine_Detail
    {
        private Guid _OfficeAutomation_Document_WirelessFixedLine_Detail_ID;
        /// <summary>
        /// 主键
        /// </summary>
        public Guid OfficeAutomation_Document_WirelessFixedLine_Detail_ID
        {
            get { return _OfficeAutomation_Document_WirelessFixedLine_Detail_ID; }
            set { _OfficeAutomation_Document_WirelessFixedLine_Detail_ID = value; }
        }

        private Guid _OfficeAutomation_Document_WirelessFixedLine_Detail_MainID;
        /// <summary>
        /// 申请表主键
        /// </summary>
        public Guid OfficeAutomation_Document_WirelessFixedLine_Detail_MainID
        {
            get { return _OfficeAutomation_Document_WirelessFixedLine_Detail_MainID; }
            set { _OfficeAutomation_Document_WirelessFixedLine_Detail_MainID = value; }
        }

        private string _OfficeAutomation_Document_WirelessFixedLine_Detail_Division;
        /// <summary>
        /// 所属事业部
        /// </summary>
        public string OfficeAutomation_Document_WirelessFixedLine_Detail_Division
        {
            get { return _OfficeAutomation_Document_WirelessFixedLine_Detail_Division; }
            set { _OfficeAutomation_Document_WirelessFixedLine_Detail_Division = value; }
        }

        private string _OfficeAutomation_Document_WirelessFixedLine_Detail_Name;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string OfficeAutomation_Document_WirelessFixedLine_Detail_Name
        {
            get { return _OfficeAutomation_Document_WirelessFixedLine_Detail_Name; }
            set { _OfficeAutomation_Document_WirelessFixedLine_Detail_Name = value; }
        }

        private string _OfficeAutomation_Document_WirelessFixedLine_Detail_Number;
        /// <summary>
        /// 租用数量
        /// </summary>
        public string OfficeAutomation_Document_WirelessFixedLine_Detail_Number
        {
            get { return _OfficeAutomation_Document_WirelessFixedLine_Detail_Number; }
            set { _OfficeAutomation_Document_WirelessFixedLine_Detail_Number = value; }
        }

        private DateTime? _OfficeAutomation_Document_WirelessFixedLine_Detail_Time;
        /// <summary>
        /// 租用起始时间
        /// </summary>
        public DateTime? OfficeAutomation_Document_WirelessFixedLine_Detail_Time
        {
            get { return _OfficeAutomation_Document_WirelessFixedLine_Detail_Time; }
            set { _OfficeAutomation_Document_WirelessFixedLine_Detail_Time = value; }
        }

        private DateTime? _OfficeAutomation_Document_WirelessFixedLine_Detail_EndTime;
        /// <summary>
        /// 租用结束时间
        /// </summary>
        public DateTime? OfficeAutomation_Document_WirelessFixedLine_Detail_EndTime
        {
            get { return _OfficeAutomation_Document_WirelessFixedLine_Detail_EndTime; }
            set { _OfficeAutomation_Document_WirelessFixedLine_Detail_EndTime = value; }
        }
    }
}
