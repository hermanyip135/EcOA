using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 资产借调申请表
    /// </summary>
    public class T_OfficeAutomation_Document_Secondment
    {
        private Guid _OfficeAutomation_Document_Secondment_ID;
        /// <summary>
        /// 主键
        /// </summary>
        public Guid OfficeAutomation_Document_Secondment_ID
        {
            get { return _OfficeAutomation_Document_Secondment_ID; }
            set { _OfficeAutomation_Document_Secondment_ID = value; }
        }

        private Guid _OfficeAutomation_Document_Secondment_MainID;
        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_Secondment_MainID
        {
            get { return _OfficeAutomation_Document_Secondment_MainID; }
            set { _OfficeAutomation_Document_Secondment_MainID = value; }
        }

        private string _OfficeAutomation_Document_Secondment_Apply;
        /// <summary>
        /// 申请人
        /// </summary>
        public string OfficeAutomation_Document_Secondment_Apply
        {
            get { return _OfficeAutomation_Document_Secondment_Apply; }
            set { _OfficeAutomation_Document_Secondment_Apply = value; }
        }

        private DateTime _OfficeAutomation_Document_Secondment_ApplyDate;
        /// <summary>
        /// 发文日期
        /// </summary>
        public DateTime OfficeAutomation_Document_Secondment_ApplyDate
        {
            get { return _OfficeAutomation_Document_Secondment_ApplyDate; }
            set { _OfficeAutomation_Document_Secondment_ApplyDate = value; }
        }

        private string _OfficeAutomation_Document_Secondment_ApplyID;
        /// <summary>
        /// 资产编号
        /// </summary>
        public string OfficeAutomation_Document_Secondment_ApplyID
        {
            get { return _OfficeAutomation_Document_Secondment_ApplyID; }
            set { _OfficeAutomation_Document_Secondment_ApplyID = value; }
        }

        private string _OfficeAutomation_Document_Secondment_BorrowDepartment;

        public string OfficeAutomation_Document_Secondment_BorrowDepartment
        {
            get { return _OfficeAutomation_Document_Secondment_BorrowDepartment; }
            set { _OfficeAutomation_Document_Secondment_BorrowDepartment = value; }
        }

        private string _OfficeAutomation_Document_Secondment_Department;
        /// <summary>
        /// 借出部门
        /// </summary>
        public string OfficeAutomation_Document_Secondment_Department
        {
            get { return _OfficeAutomation_Document_Secondment_Department; }
            set { _OfficeAutomation_Document_Secondment_Department = value; }
        }

        private string _OfficeAutomation_Document_Secondment_InDptm;
        /// <summary>
        /// 借入部门
        /// </summary>
        public string OfficeAutomation_Document_Secondment_InDptm
        {
            get { return _OfficeAutomation_Document_Secondment_InDptm; }
            set { _OfficeAutomation_Document_Secondment_InDptm = value; }
        }

        private string _OfficeAutomation_Document_Secondment_InDptmContact;
        /// <summary>
        /// 借入部门联系人
        /// </summary>
        public string OfficeAutomation_Document_Secondment_InDptmContact
        {
            get { return _OfficeAutomation_Document_Secondment_InDptmContact; }
            set { _OfficeAutomation_Document_Secondment_InDptmContact = value; }
        }

        private string _OfficeAutomation_Document_Secondment_AssetsName;
        /// <summary>
        /// 借调资产名称
        /// </summary>
        public string OfficeAutomation_Document_Secondment_AssetsName
        {
            get { return _OfficeAutomation_Document_Secondment_AssetsName; }
            set { _OfficeAutomation_Document_Secondment_AssetsName = value; }
        }

        private string _OfficeAutomation_Document_Secondment_TheMessage;
        /// <summary>
        /// 借调资产规格、型号
        /// </summary>
        public string OfficeAutomation_Document_Secondment_TheMessage
        {
            get { return _OfficeAutomation_Document_Secondment_TheMessage; }
            set { _OfficeAutomation_Document_Secondment_TheMessage = value; }
        }

        private string _OfficeAutomation_Document_Secondment_Number;
        /// <summary>
        /// 数量
        /// </summary>
        public string OfficeAutomation_Document_Secondment_Number
        {
            get { return _OfficeAutomation_Document_Secondment_Number; }
            set { _OfficeAutomation_Document_Secondment_Number = value; }
        }

        private string _OfficeAutomation_Document_Secondment_BorrowDate;
        /// <summary>
        /// 借调日期
        /// </summary>
        public string OfficeAutomation_Document_Secondment_BorrowDate
        {
            get { return _OfficeAutomation_Document_Secondment_BorrowDate; }
            set { _OfficeAutomation_Document_Secondment_BorrowDate = value; }
        }

        private string _OfficeAutomation_Document_Secondment_ExpectReturnDate;
        /// <summary>
        /// 归还日期（预计）
        /// </summary>
        public string OfficeAutomation_Document_Secondment_ExpectReturnDate
        {
            get { return _OfficeAutomation_Document_Secondment_ExpectReturnDate; }
            set { _OfficeAutomation_Document_Secondment_ExpectReturnDate = value; }
        }

        private string _OfficeAutomation_Document_Secondment_SalesDate;
        /// <summary>
        /// 出仓日期
        /// </summary>
        public string OfficeAutomation_Document_Secondment_SalesDate
        {
            get { return _OfficeAutomation_Document_Secondment_SalesDate; }
            set { _OfficeAutomation_Document_Secondment_SalesDate = value; }
        }

        private string _OfficeAutomation_Document_Secondment_Sales;
        /// <summary>
        /// 出仓人
        /// </summary>
        public string OfficeAutomation_Document_Secondment_Sales
        {
            get { return _OfficeAutomation_Document_Secondment_Sales; }
            set { _OfficeAutomation_Document_Secondment_Sales = value; }
        }

        private string _OfficeAutomation_Document_Secondment_ReturnDate;
        /// <summary>
        /// 归还日期
        /// </summary>
        public string OfficeAutomation_Document_Secondment_ReturnDate
        {
            get { return _OfficeAutomation_Document_Secondment_ReturnDate; }
            set { _OfficeAutomation_Document_Secondment_ReturnDate = value; }
        }

        private string _OfficeAutomation_Document_Secondment_Returner;
        /// <summary>
        /// 归还人
        /// </summary>
        public string OfficeAutomation_Document_Secondment_Returner
        {
            get { return _OfficeAutomation_Document_Secondment_Returner; }
            set { _OfficeAutomation_Document_Secondment_Returner = value; }
        }

        private string _OfficeAutomation_Document_Secondment_Reason;
        /// <summary>
        /// 借调原因
        /// </summary>
        public string OfficeAutomation_Document_Secondment_Reason
        {
            get { return _OfficeAutomation_Document_Secondment_Reason; }
            set { _OfficeAutomation_Document_Secondment_Reason = value; }
        }
    }
}
