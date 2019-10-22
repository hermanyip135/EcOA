/*
* T_OfficeAutomation_Document_ResumeBusi.cs
*
* 功 能： 
* 类 名： T_OfficeAutomation_Document_ResumeBusi
*
* Ver     变更日期                    负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/15 10:47:31    张榕     初版
*
*/
using System;
namespace DataEntity
{
	/// <summary>
	/// 恢复营业申请表
	/// </summary>
    [Serializable]
    public partial class T_OfficeAutomation_Document_ResumeBusi
    {
        public T_OfficeAutomation_Document_ResumeBusi()
        { }
        #region Model
        private Guid _officeautomation_document_resumebusi_id;
        private Guid _officeautomation_document_resumebusi_mainid;
        private string _officeautomation_document_resumebusi_apply;
        private string _officeautomation_document_resumebusi_applyid;
        private DateTime _officeautomation_document_resumebusi_applydate;
        private string _officeautomation_document_resumebusi_department;
        private string _officeautomation_document_resumebusi_replyphone;
        private string _officeautomation_document_resumebusi_replyfax;
        private int _officeautomation_document_resumebusi_departmenttypeid;
        private int _officeautomation_document_resumebusi_majordomoid;
        private string _officeautomation_document_resumebusi_departmentname;
        private DateTime _officeautomation_document_resumebusi_plandate;
        private string _officeautomation_document_resumebusi_reason;
        private string _officeautomation_document_resumebusi_remark;
        /// <summary>
        /// 主键
        /// </summary>
        public Guid OfficeAutomation_Document_ResumeBusi_ID
        {
            set { _officeautomation_document_resumebusi_id = value; }
            get { return _officeautomation_document_resumebusi_id; }
        }
        /// <summary>
        /// 公文流转主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_ResumeBusi_MainID
        {
            set { _officeautomation_document_resumebusi_mainid = value; }
            get { return _officeautomation_document_resumebusi_mainid; }
        }
        /// <summary>
        /// 填写人
        /// </summary>
        public string OfficeAutomation_Document_ResumeBusi_Apply
        {
            set { _officeautomation_document_resumebusi_apply = value; }
            get { return _officeautomation_document_resumebusi_apply; }
        }
        /// <summary>
        /// 发文编号
        /// </summary>
        public string OfficeAutomation_Document_ResumeBusi_ApplyID
        {
            set { _officeautomation_document_resumebusi_applyid = value; }
            get { return _officeautomation_document_resumebusi_applyid; }
        }
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime OfficeAutomation_Document_ResumeBusi_ApplyDate
        {
            set { _officeautomation_document_resumebusi_applydate = value; }
            get { return _officeautomation_document_resumebusi_applydate; }
        }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string OfficeAutomation_Document_ResumeBusi_Department
        {
            set { _officeautomation_document_resumebusi_department = value; }
            get { return _officeautomation_document_resumebusi_department; }
        }
        /// <summary>
        /// 回复电话
        /// </summary>
        public string OfficeAutomation_Document_ResumeBusi_ReplyPhone
        {
            set { _officeautomation_document_resumebusi_replyphone = value; }
            get { return _officeautomation_document_resumebusi_replyphone; }
        }
        /// <summary>
        /// 回复传真
        /// </summary>
        public string OfficeAutomation_Document_ResumeBusi_ReplyFax
        {
            set { _officeautomation_document_resumebusi_replyfax = value; }
            get { return _officeautomation_document_resumebusi_replyfax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OfficeAutomation_Document_ResumeBusi_DepartmentTypeID
        {
            set { _officeautomation_document_resumebusi_departmenttypeid = value; }
            get { return _officeautomation_document_resumebusi_departmenttypeid; }
        }
        /// <summary>
        /// 总监
        /// </summary>
        public int OfficeAutomation_Document_ResumeBusi_MajordomoID
        {
            set { _officeautomation_document_resumebusi_majordomoid = value; }
            get { return _officeautomation_document_resumebusi_majordomoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_ResumeBusi_DepartmentName
        {
            set { _officeautomation_document_resumebusi_departmentname = value; }
            get { return _officeautomation_document_resumebusi_departmentname; }
        }
        /// <summary>
        /// 计划实行日期
        /// </summary>
        public DateTime OfficeAutomation_Document_ResumeBusi_PlanDate
        {
            set { _officeautomation_document_resumebusi_plandate = value; }
            get { return _officeautomation_document_resumebusi_plandate; }
        }
        /// <summary>
        /// 原因
        /// </summary>
        public string OfficeAutomation_Document_ResumeBusi_Reason
        {
            set { _officeautomation_document_resumebusi_reason = value; }
            get { return _officeautomation_document_resumebusi_reason; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string OfficeAutomation_Document_ResumeBusi_Remark
        {
            set { _officeautomation_document_resumebusi_remark = value; }
            get { return _officeautomation_document_resumebusi_remark; }
        }
        #endregion Model
    }
}

