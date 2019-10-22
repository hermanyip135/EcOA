using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 申请内容明细表
    /// </summary>
    public class T_OfficeAutomation_Document_SysPower_Detail_Apply
    {
        private Guid officeAutomation_Document_SysPower_Detail_Apply_ID;
        /// <summary>
        /// 申请内容明细主键
        /// </summary>
        public Guid OfficeAutomation_Document_SysPower_Detail_Apply_ID
        {
            get { return officeAutomation_Document_SysPower_Detail_Apply_ID; }
            set { officeAutomation_Document_SysPower_Detail_Apply_ID = value; }
        }
        private Guid officeAutomation_Document_SysPower_Detail_Apply_MainID;
        /// <summary>
        /// (汇瀚/二级市场/后勤)IT权限申请明细表主键
        /// </summary>
        public Guid OfficeAutomation_Document_SysPower_Detail_Apply_MainID
        {
            get { return officeAutomation_Document_SysPower_Detail_Apply_MainID; }
            set { officeAutomation_Document_SysPower_Detail_Apply_MainID = value; }
        }
        private int officeAutomation_Document_SysPower_Detail_Apply_ApplyDetailID;
        /// <summary>
        /// 申请内容ID
        /// </summary>
        public int OfficeAutomation_Document_SysPower_Detail_Apply_ApplyDetailID
        {
            get { return officeAutomation_Document_SysPower_Detail_Apply_ApplyDetailID; }
            set { officeAutomation_Document_SysPower_Detail_Apply_ApplyDetailID = value; }
        }
    }
}
