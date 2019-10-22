using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 通用申请后勤审批流程表
    /// </summary>
    public class T_OfficeAutomation_Document_GeneralApply_Detail
    {
        private Guid _OfficeAutomation_Document_GeneralApply_Detail_ID;
        /// <summary>
        /// 主键
        /// </summary>
        public Guid OfficeAutomation_Document_GeneralApply_Detail_ID
        {
            get { return _OfficeAutomation_Document_GeneralApply_Detail_ID; }
            set { _OfficeAutomation_Document_GeneralApply_Detail_ID = value; }
        }

        private Guid _OfficeAutomation_Document_GeneralApply_Detail_MainID;
        /// <summary>
        /// 申请表主键
        /// </summary>
        public Guid OfficeAutomation_Document_GeneralApply_Detail_MainID
        {
            get { return _OfficeAutomation_Document_GeneralApply_Detail_MainID; }
            set { _OfficeAutomation_Document_GeneralApply_Detail_MainID = value; }
        }

        private int _OfficeAutomation_Document_GeneralApply_Detail_Num;
        /// <summary>
        /// 流程序号
        /// </summary>
        public int OfficeAutomation_Document_GeneralApply_Detail_Num
        {
            get { return _OfficeAutomation_Document_GeneralApply_Detail_Num; }
            set { _OfficeAutomation_Document_GeneralApply_Detail_Num = value; }
        }

        private string _OfficeAutomation_Document_GeneralApply_Detail_Department;
        /// <summary>
        /// 部门名称
        /// </summary>
        public string OfficeAutomation_Document_GeneralApply_Detail_Department
        {
            get { return _OfficeAutomation_Document_GeneralApply_Detail_Department; }
            set { _OfficeAutomation_Document_GeneralApply_Detail_Department = value; }
        }

        private string _OfficeAutomation_Document_GeneralApply_Detail_Branch;
        /// <summary>
        /// 环节号
        /// </summary>
        public string OfficeAutomation_Document_GeneralApply_Detail_Branch
        {
            get { return _OfficeAutomation_Document_GeneralApply_Detail_Branch; }
            set { _OfficeAutomation_Document_GeneralApply_Detail_Branch = value; }
        }

        private bool _OfficeAutomation_Document_GeneralApply_Detail_Cmodel;
        /// <summary>
        /// 审批模式
        /// </summary>
        public bool OfficeAutomation_Document_GeneralApply_Detail_Cmodel
        {
            get { return _OfficeAutomation_Document_GeneralApply_Detail_Cmodel; }
            set { _OfficeAutomation_Document_GeneralApply_Detail_Cmodel = value; }
        }

        private bool _OfficeAutomation_Document_GeneralApply_Detail_IsOpen;
        /// <summary>
        /// 该环节是否开启
        /// </summary>
        public bool OfficeAutomation_Document_GeneralApply_Detail_IsOpen
        {
            get { return _OfficeAutomation_Document_GeneralApply_Detail_IsOpen; }
            set { _OfficeAutomation_Document_GeneralApply_Detail_IsOpen = value; }
        }

        private int _OfficeAutomation_Document_GeneralApply_Detail_Sign;
        /// <summary>
        /// 标号
        /// </summary>
        public int OfficeAutomation_Document_GeneralApply_Detail_Sign
        {
            get { return _OfficeAutomation_Document_GeneralApply_Detail_Sign; }
            set { _OfficeAutomation_Document_GeneralApply_Detail_Sign = value; }
        }
    }
}
