using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class T_OfficeAutomation_Document_NewPersInterests_Detail
    {
        private Guid _OfficeAutomation_Document_NewPersInterests_Detail_ID;

        public Guid OfficeAutomation_Document_NewPersInterests_Detail_ID
        {
            get { return _OfficeAutomation_Document_NewPersInterests_Detail_ID; }
            set { _OfficeAutomation_Document_NewPersInterests_Detail_ID = value; }
        }

        private Guid _OfficeAutomation_Document_NewPersInterests_Detail_MainID;

        public Guid OfficeAutomation_Document_NewPersInterests_Detail_MainID
        {
            get { return _OfficeAutomation_Document_NewPersInterests_Detail_MainID; }
            set { _OfficeAutomation_Document_NewPersInterests_Detail_MainID = value; }
        }

        private string _OfficeAutomation_Document_NewPersInterests_Detail_RelativesName;

        public string OfficeAutomation_Document_NewPersInterests_Detail_RelativesName
        {
            get { return _OfficeAutomation_Document_NewPersInterests_Detail_RelativesName; }
            set { _OfficeAutomation_Document_NewPersInterests_Detail_RelativesName = value; }
        }

        private string _OfficeAutomation_Document_NewPersInterests_Detail_InDepartment;

        public string OfficeAutomation_Document_NewPersInterests_Detail_InDepartment
        {
            get { return _OfficeAutomation_Document_NewPersInterests_Detail_InDepartment; }
            set { _OfficeAutomation_Document_NewPersInterests_Detail_InDepartment = value; }
        }

        private string _OfficeAutomation_Document_NewPersInterests_Detail_Position;

        public string OfficeAutomation_Document_NewPersInterests_Detail_Position
        {
            get { return _OfficeAutomation_Document_NewPersInterests_Detail_Position; }
            set { _OfficeAutomation_Document_NewPersInterests_Detail_Position = value; }
        }

        private string _OfficeAutomation_Document_NewPersInterests_Detail_Relationship;

        public string OfficeAutomation_Document_NewPersInterests_Detail_Relationship
        {
            get { return _OfficeAutomation_Document_NewPersInterests_Detail_Relationship; }
            set { _OfficeAutomation_Document_NewPersInterests_Detail_Relationship = value; }
        }
        /// <summary>
        /// 是否在职
        /// </summary>
        public string OfficeAutomation_Document_NewPersInterests_Detail_rdInApply { get; set; }
        /// <summary>
        /// 在职工号
        /// </summary>
        public string OfficeAutomation_Document_NewPersInterests_Detail_ApplyForID { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string OfficeAutomation_Document_NewPersInterests_Detail_txtTfid { get; set; }
        //private string _OfficeAutomation_Document_NewPersInterests_Detail_RelationshipOne;
        //public string OfficeAutomation_Document_NewPersInterests_Detail_RelationshipOne
        //{
        //    get { return _OfficeAutomation_Document_NewPersInterests_Detail_RelationshipOne; }
        //    set { _OfficeAutomation_Document_NewPersInterests_Detail_RelationshipOne = value; }
        //}

        //private string _OfficeAutomation_Document_NewPersInterests_Detail_RelationshipTwo;
        //public string OfficeAutomation_Document_NewPersInterests_Detail_RelationshipTwo
        //{
        //    get { return _OfficeAutomation_Document_NewPersInterests_Detail_RelationshipTwo; }
        //    set { _OfficeAutomation_Document_NewPersInterests_Detail_RelationshipTwo = value; }
        //}
    }
}
