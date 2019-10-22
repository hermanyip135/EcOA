using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 公章使用申请明细表
    /// </summary>
    public class T_OfficeAutomation_Document_OfficialSeal_Detail
    {
        private Guid _OfficeAutomation_Document_OfficialSeal_Detail_ID;
        /// <summary>
        /// 主键
        /// </summary>
        public Guid OfficeAutomation_Document_OfficialSeal_Detail_ID
        {
            get { return _OfficeAutomation_Document_OfficialSeal_Detail_ID; }
            set { _OfficeAutomation_Document_OfficialSeal_Detail_ID = value; }
        }

        private Guid _OfficeAutomation_Document_OfficialSeal_Detail_MainID;
        /// <summary>
        /// 申请表主键
        /// </summary>
        public Guid OfficeAutomation_Document_OfficialSeal_Detail_MainID
        {
            get { return _OfficeAutomation_Document_OfficialSeal_Detail_MainID; }
            set { _OfficeAutomation_Document_OfficialSeal_Detail_MainID = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_Detail_TransFile;
        /// <summary>
        /// 事务文件
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_Detail_TransFile
        {
            get { return _OfficeAutomation_Document_OfficialSeal_Detail_TransFile; }
            set { _OfficeAutomation_Document_OfficialSeal_Detail_TransFile = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_Detail_FileName;
        /// <summary>
        /// 文件名称
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_Detail_FileName
        {
            get { return _OfficeAutomation_Document_OfficialSeal_Detail_FileName; }
            set { _OfficeAutomation_Document_OfficialSeal_Detail_FileName = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_Detail_AgentBeginData;
        /// <summary>
        /// 代理期开始时间
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_Detail_AgentBeginData
        {
            get { return _OfficeAutomation_Document_OfficialSeal_Detail_AgentBeginData; }
            set { _OfficeAutomation_Document_OfficialSeal_Detail_AgentBeginData = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_Detail_AgentEndData;
        /// <summary>
        /// 代理期结束时间
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_Detail_AgentEndData
        {
            get { return _OfficeAutomation_Document_OfficialSeal_Detail_AgentEndData; }
            set { _OfficeAutomation_Document_OfficialSeal_Detail_AgentEndData = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_Detail_BN;
        /// <summary>
        /// 项目（楼盘）名称/文件名称
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_Detail_BN
        {
            get { return _OfficeAutomation_Document_OfficialSeal_Detail_BN; }
            set { _OfficeAutomation_Document_OfficialSeal_Detail_BN = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_Detail_Company;
        /// <summary>
        /// 对方公司名称
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_Detail_Company
        {
            get { return _OfficeAutomation_Document_OfficialSeal_Detail_Company; }
            set { _OfficeAutomation_Document_OfficialSeal_Detail_Company = value; }
        }

        private string _OfficeAutomation_Document_OfficialSeal_Detail_Use;
        /// <summary>
        /// 用途
        /// </summary>
        public string OfficeAutomation_Document_OfficialSeal_Detail_Use
        {
            get { return _OfficeAutomation_Document_OfficialSeal_Detail_Use; }
            set { _OfficeAutomation_Document_OfficialSeal_Detail_Use = value; }
        }
    }
}
