using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 申请性质表
    /// </summary>
    public class T_Dic_OfficeAutomation_ApplyType
    {
        private int officeAutomation_ApplyType_ID;
        /// <summary>
        /// 申请性质主键
        /// </summary>
        public int OfficeAutomation_ApplyType_ID
        {
            get { return officeAutomation_ApplyType_ID; }
            set { officeAutomation_ApplyType_ID = value; }
        }
        private int officeAutomation_ApplyType_Name;
        /// <summary>
        /// 申请性质
        /// </summary>
        public int OfficeAutomation_ApplyType_Name
        {
            get { return officeAutomation_ApplyType_Name; }
            set { officeAutomation_ApplyType_Name = value; }
        }
    }
}
