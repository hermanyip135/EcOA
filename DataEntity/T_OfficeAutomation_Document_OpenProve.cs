using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_OpenProve
    {
        private Guid _OfficeAutomation_Document_OpenProve_ID;

        [CProperty("Key")]
        public Guid OfficeAutomation_Document_OpenProve_ID
        {
            get { return _OfficeAutomation_Document_OpenProve_ID; }
            set { _OfficeAutomation_Document_OpenProve_ID = value; }
        }

        private Guid _OfficeAutomation_Document_OpenProve_MainID;

        public Guid OfficeAutomation_Document_OpenProve_MainID
        {
            get { return _OfficeAutomation_Document_OpenProve_MainID; }
            set { _OfficeAutomation_Document_OpenProve_MainID = value; }
        }

        private string _OfficeAutomation_Document_OpenProve_Apply;

        public string OfficeAutomation_Document_OpenProve_Apply
        {
            get { return _OfficeAutomation_Document_OpenProve_Apply; }
            set { _OfficeAutomation_Document_OpenProve_Apply = value; }
        }

        private DateTime _OfficeAutomation_Document_OpenProve_ApplyDate;

        public DateTime OfficeAutomation_Document_OpenProve_ApplyDate
        {
            get { return _OfficeAutomation_Document_OpenProve_ApplyDate; }
            set { _OfficeAutomation_Document_OpenProve_ApplyDate = value; }
        }

        private string _OfficeAutomation_Document_OpenProve_ApplyID;

        public string OfficeAutomation_Document_OpenProve_ApplyID
        {
            get { return _OfficeAutomation_Document_OpenProve_ApplyID; }
            set { _OfficeAutomation_Document_OpenProve_ApplyID = value; }
        }

        private string _OfficeAutomation_Document_OpenProve_Department;

        public string OfficeAutomation_Document_OpenProve_Department
        {
            get { return _OfficeAutomation_Document_OpenProve_Department; }
            set { _OfficeAutomation_Document_OpenProve_Department = value; }
        }

        private string _OfficeAutomation_Document_OpenProve_Code;

        public string OfficeAutomation_Document_OpenProve_Code
        {
            get { return _OfficeAutomation_Document_OpenProve_Code; }
            set { _OfficeAutomation_Document_OpenProve_Code = value; }
        }

        private string _OfficeAutomation_Document_OpenProve_Name;

        public string OfficeAutomation_Document_OpenProve_Name
        {
            get { return _OfficeAutomation_Document_OpenProve_Name; }
            set { _OfficeAutomation_Document_OpenProve_Name = value; }
        }

        private string _OfficeAutomation_Document_OpenProve_EnterDate;

        public string OfficeAutomation_Document_OpenProve_EnterDate
        {
            get { return _OfficeAutomation_Document_OpenProve_EnterDate; }
            set { _OfficeAutomation_Document_OpenProve_EnterDate = value; }
        }

        private string _OfficeAutomation_Document_OpenProve_Position;

        public string OfficeAutomation_Document_OpenProve_Position
        {
            get { return _OfficeAutomation_Document_OpenProve_Position; }
            set { _OfficeAutomation_Document_OpenProve_Position = value; }
        }

        private string _OfficeAutomation_Document_OpenProve_Rank;

        public string OfficeAutomation_Document_OpenProve_Rank
        {
            get { return _OfficeAutomation_Document_OpenProve_Rank; }
            set { _OfficeAutomation_Document_OpenProve_Rank = value; }
        }
        //联系电话
        public string OfficeAutomation_Document_OpenProve_Phone { get; set; }
        //签收方式 
        public string OfficeAutomation_Document_OpenProve_SignMode { get; set; }
        //签收快递地址
        public string OfficeAutomation_Document_OpenProve_SignAddress { get; set; }
        //签收联系电话
        public string OfficeAutomation_Document_OpenProve_SignPhone { get; set; }
        //签收人
        public string OfficeAutomation_Document_OpenProve_Recipient { get; set; }
        //特殊情况说明
        public string OfficeAutomation_Document_OpenProve_ExceptionalCase { get; set; }
    }
}
