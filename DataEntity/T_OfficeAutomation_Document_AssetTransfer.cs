using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 资产调动表
    /// </summary>
    public class T_OfficeAutomation_Document_AssetTransfer
    {
        private Guid officeAutomation_Document_AssetTransfer_ID;
        /// <summary>
        ///资产调动主键
        /// </summary>
        public Guid OfficeAutomation_Document_AssetTransfer_ID
        {
            get { return officeAutomation_Document_AssetTransfer_ID; }
            set { officeAutomation_Document_AssetTransfer_ID = value; }
        }
        private Guid officeAutomation_Document_AssetTransfer_MainID;
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_AssetTransfer_MainID
        {
            get { return officeAutomation_Document_AssetTransfer_MainID; }
            set { officeAutomation_Document_AssetTransfer_MainID = value; }
        }

        private string officeAutomation_Document_AssetTransfer_Department;
        /// <summary>
        /// 申请部门
        /// </summary>
        public string OfficeAutomation_Document_AssetTransfer_Department
        {
            get { return officeAutomation_Document_AssetTransfer_Department; }
            set { officeAutomation_Document_AssetTransfer_Department = value; }
        }

        private string officeAutomation_Document_AssetTransfer_Apply;
        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Document_AssetTransfer_Apply
        {
            get { return officeAutomation_Document_AssetTransfer_Apply; }
            set { officeAutomation_Document_AssetTransfer_Apply = value; }
        }

        private string officeAutomation_Document_AssetTransfer_ExportDepartment;
        /// <summary>
        /// 调出部门
        /// </summary>
        public string OfficeAutomation_Document_AssetTransfer_ExportDepartment
        {
            get { return officeAutomation_Document_AssetTransfer_ExportDepartment; }
            set { officeAutomation_Document_AssetTransfer_ExportDepartment = value; }
        }

        private string officeAutomation_Document_AssetTransfer_ImportDepartment;
        /// <summary>
        /// 接收部门
        /// </summary>
        public string OfficeAutomation_Document_AssetTransfer_ImportDepartment
        {
            get { return officeAutomation_Document_AssetTransfer_ImportDepartment; }
            set { officeAutomation_Document_AssetTransfer_ImportDepartment = value; }
        }

        private string officeAutomation_Document_AssetTransfer_ExportContacts;
        /// <summary>
        /// 调出联系人
        /// </summary>
        public string OfficeAutomation_Document_AssetTransfer_ExportContacts
        {
            get { return officeAutomation_Document_AssetTransfer_ExportContacts; }
            set { officeAutomation_Document_AssetTransfer_ExportContacts = value; }
        }

        private string officeAutomation_Document_AssetTransfer_ImportContacts;
        /// <summary>
        /// 接收联系人
        /// </summary>
        public string OfficeAutomation_Document_AssetTransfer_ImportContacts
        {
            get { return officeAutomation_Document_AssetTransfer_ImportContacts; }
            set { officeAutomation_Document_AssetTransfer_ImportContacts = value; }
        }

        private DateTime officeAutomation_Document_AssetTransfer_ApplyDate;
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime OfficeAutomation_Document_AssetTransfer_ApplyDate
        {
            get { return officeAutomation_Document_AssetTransfer_ApplyDate; }
            set { officeAutomation_Document_AssetTransfer_ApplyDate = value; }
        }

        private string officeAutomation_Document_AssetTransfer_ExportPlace;
        /// <summary>
        /// 调出摆放地点

        /// </summary>
        public string OfficeAutomation_Document_AssetTransfer_ExportPlace
        {
            get { return officeAutomation_Document_AssetTransfer_ExportPlace; }
            set { officeAutomation_Document_AssetTransfer_ExportPlace = value; }
        }

        private string officeAutomation_Document_AssetTransfer_ImportPlace;
        /// <summary>
        /// 接收摆放地点
        /// </summary>
        public string OfficeAutomation_Document_AssetTransfer_ImportPlace
        {
            get { return officeAutomation_Document_AssetTransfer_ImportPlace; }
            set { officeAutomation_Document_AssetTransfer_ImportPlace = value; }
        }

        private string officeAutomation_Document_AssetTransfer_TransferReason;
        /// <summary>
        /// 资产调动原因
        /// </summary>
        public string OfficeAutomation_Document_AssetTransfer_TransferReason
        {
            get { return officeAutomation_Document_AssetTransfer_TransferReason; }
            set { officeAutomation_Document_AssetTransfer_TransferReason = value; }
        }
        /// <summary>
        /// 申请人工号
        /// </summary>
        public string OfficeAutomation_Document_AssetTransfer_ApplyID { get; set; }
    }
}
