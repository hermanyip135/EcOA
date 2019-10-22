using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 申请内容表
    /// </summary>
    public class T_Dic_OfficeAutomation_ApplyDetail
    {
        private int officeAutomation_ApplyDetail_ID;
        /// <summary>
        /// 申请内容主键
        /// </summary>
        public int OfficeAutomation_ApplyDetail_ID
        {
            get { return officeAutomation_ApplyDetail_ID; }
            set { officeAutomation_ApplyDetail_ID = value; }
        }
        private string officeAutomation_ApplyDetail_Name;
        /// <summary>
        /// 申请内容
        /// </summary>
        public string OfficeAutomation_ApplyDetail_Name
        {
            get { return officeAutomation_ApplyDetail_Name; }
            set { officeAutomation_ApplyDetail_Name = value; }
        }
    }
}
