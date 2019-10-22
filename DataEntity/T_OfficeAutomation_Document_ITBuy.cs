using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 计算机及相关设备购买申请表
    /// </summary>
    public class T_OfficeAutomation_Document_ITBuy
    {
        private Guid officeAutomation_Document_ITBuy_ID;
        /// <summary>
        ///计算机及相关设备购买申请主键
        /// </summary>
        public Guid OfficeAutomation_Document_ITBuy_ID
        {
            get { return officeAutomation_Document_ITBuy_ID; }
            set { officeAutomation_Document_ITBuy_ID = value; }
        }
        private Guid officeAutomation_Document_ITBuy_MainID;
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_ITBuy_MainID
        {
            get { return officeAutomation_Document_ITBuy_MainID; }
            set { officeAutomation_Document_ITBuy_MainID = value; }
        }

        private string officeAutomation_Document_ITBuy_Department;
        /// <summary>
        /// 申请部门
        /// </summary>
        public string OfficeAutomation_Document_ITBuy_Department
        {
            get { return officeAutomation_Document_ITBuy_Department; }
            set { officeAutomation_Document_ITBuy_Department = value; }
        }

        private string officeAutomation_Document_ITBuy_ApplyID;
        /// <summary>
        /// 申请编号
        /// </summary>
        public string OfficeAutomation_Document_ITBuy_ApplyID
        {
            get { return officeAutomation_Document_ITBuy_ApplyID; }
            set { officeAutomation_Document_ITBuy_ApplyID = value; }
        }

        private string officeAutomation_Document_ITBuy_Apply;
        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Document_ITBuy_Apply
        {
            get { return officeAutomation_Document_ITBuy_Apply; }
            set { officeAutomation_Document_ITBuy_Apply = value; }
        }

        private DateTime officeAutomation_Document_ITBuy_ApplyDate;
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime OfficeAutomation_Document_ITBuy_ApplyDate
        {
            get { return officeAutomation_Document_ITBuy_ApplyDate; }
            set { officeAutomation_Document_ITBuy_ApplyDate = value; }
        }

        private string officeAutomation_Document_ITBuy_ReplyPhone;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string OfficeAutomation_Document_ITBuy_ReplyPhone
        {
            get { return officeAutomation_Document_ITBuy_ReplyPhone; }
            set { officeAutomation_Document_ITBuy_ReplyPhone = value; }
        }

        private string officeAutomation_Document_ITBuy_Buy1;
        /// <summary>
        /// 申购项目1
        /// </summary>
        public string OfficeAutomation_Document_ITBuy_Buy1
        {
            get { return officeAutomation_Document_ITBuy_Buy1; }
            set { officeAutomation_Document_ITBuy_Buy1 = value; }
        }

        private string officeAutomation_Document_ITBuy_Unit1;
        /// <summary>
        /// 数量1
        /// </summary>
        public string OfficeAutomation_Document_ITBuy_Unit1
        {
            get { return officeAutomation_Document_ITBuy_Unit1; }
            set { officeAutomation_Document_ITBuy_Unit1 = value; }
        }

        private string officeAutomation_Document_ITBuy_Buy2;
        /// <summary>
        /// 申购项目2
        /// </summary>
        public string OfficeAutomation_Document_ITBuy_Buy2
        {
            get { return officeAutomation_Document_ITBuy_Buy2; }
            set { officeAutomation_Document_ITBuy_Buy2 = value; }
        }

        private string officeAutomation_Document_ITBuy_Unit2;
        /// <summary>
        /// 数量2
        /// </summary>
        public string OfficeAutomation_Document_ITBuy_Unit2
        {
            get { return officeAutomation_Document_ITBuy_Unit2; }
            set { officeAutomation_Document_ITBuy_Unit2 = value; }
        }

        private string officeAutomation_Document_ITBuy_Buy3;
        /// <summary>
        /// 申购项目3
        /// </summary>
        public string OfficeAutomation_Document_ITBuy_Buy3
        {
            get { return officeAutomation_Document_ITBuy_Buy3; }
            set { officeAutomation_Document_ITBuy_Buy3 = value; }
        }

        private string officeAutomation_Document_ITBuy_Unit3;
        /// <summary>
        /// 数量3
        /// </summary>
        public string OfficeAutomation_Document_ITBuy_Unit3
        {
            get { return officeAutomation_Document_ITBuy_Unit3; }
            set { officeAutomation_Document_ITBuy_Unit3 = value; }
        }

        private int officeAutomation_Document_ITBuy_ReasonTypeID;
        /// <summary>
        /// 申购原因类型ID
        /// </summary>
        public int OfficeAutomation_Document_ITBuy_ReasonTypeID
        {
            get { return officeAutomation_Document_ITBuy_ReasonTypeID; }
            set { officeAutomation_Document_ITBuy_ReasonTypeID = value; }
        }

        private string officeAutomation_Document_ITBuy_Reason;
        /// <summary>
        /// 申购原因
        /// </summary>
        public string OfficeAutomation_Document_ITBuy_Reason
        {
            get { return officeAutomation_Document_ITBuy_Reason; }
            set { officeAutomation_Document_ITBuy_Reason = value; }
        }

        private string officeAutomation_Document_ITBuy_ScrapURL;
        /// <summary>
        /// 报废申请表地址
        /// </summary>
        public string OfficeAutomation_Document_ITBuy_ScrapURL
        {
            get { return officeAutomation_Document_ITBuy_ScrapURL; }
            set { officeAutomation_Document_ITBuy_ScrapURL = value; }
        }
    }
}
