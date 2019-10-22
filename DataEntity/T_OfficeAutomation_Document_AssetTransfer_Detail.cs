using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 资产调动明细表
    /// </summary>
    public class T_OfficeAutomation_Document_AssetTransfer_Detail
    {
        private Guid officeAutomation_Document_AssetTransfer_Detail_ID;
        /// <summary>
        ///资产调动明细主键
        /// </summary>
        public Guid OfficeAutomation_Document_AssetTransfer_Detail_ID
        {
            get { return officeAutomation_Document_AssetTransfer_Detail_ID; }
            set { officeAutomation_Document_AssetTransfer_Detail_ID = value; }
        }
        private Guid officeAutomation_Document_AssetTransfer_Detail_MainID;
        /// <summary>
        /// 资产调动主键
        /// </summary>
        public Guid OfficeAutomation_Document_AssetTransfer_Detail_MainID
        {
            get { return officeAutomation_Document_AssetTransfer_Detail_MainID; }
            set { officeAutomation_Document_AssetTransfer_Detail_MainID = value; }
        }
        private int officeAutomation_Document_AssetTransfer_Detail_AssetTypeID;
        /// <summary>
        /// 物品类型
        /// </summary>
        public int OfficeAutomation_Document_AssetTransfer_Detail_AssetTypeID
        {
            get { return officeAutomation_Document_AssetTransfer_Detail_AssetTypeID; }
            set { officeAutomation_Document_AssetTransfer_Detail_AssetTypeID = value; }
        }
        private string officeAutomation_Document_AssetTransfer_Detail_AssetTag;
        /// <summary>
        /// 财务编号
        /// </summary>
        public string OfficeAutomation_Document_AssetTransfer_Detail_AssetTag
        {
            get { return officeAutomation_Document_AssetTransfer_Detail_AssetTag; }
            set { officeAutomation_Document_AssetTransfer_Detail_AssetTag = value; }
        }
        private string officeAutomation_Document_AssetTransfer_Detail_Model;
        /// <summary>
        /// 规格型号
        /// </summary>
        public string OfficeAutomation_Document_AssetTransfer_Detail_Model
        {
            get { return officeAutomation_Document_AssetTransfer_Detail_Model; }
            set { officeAutomation_Document_AssetTransfer_Detail_Model = value; }
        }
        private string officeAutomation_Document_AssetTransfer_Detail_Number;
        /// <summary>
        /// 数量
        /// </summary>
        public string OfficeAutomation_Document_AssetTransfer_Detail_Number
        {
            get { return officeAutomation_Document_AssetTransfer_Detail_Number; }
            set { officeAutomation_Document_AssetTransfer_Detail_Number = value; }
        }
        //调出部门
        private string _OfficeAutomation_Document_AssetTransfer_Detail_DpmExp;
       
        public string OfficeAutomation_Document_AssetTransfer_Detail_DpmExp
        {
            get { return _OfficeAutomation_Document_AssetTransfer_Detail_DpmExp; }
            set { _OfficeAutomation_Document_AssetTransfer_Detail_DpmExp = value; }
        }
        //调出地点
        private string _OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp;

        public string OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp
        {
            get { return _OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp; }
            set { _OfficeAutomation_Document_AssetTransfer_Detail_PlaceExp = value; }
        }


        //接收部门
        private string _OfficeAutomation_Document_AssetTransfer_Detail_DpmRec;

        public string OfficeAutomation_Document_AssetTransfer_Detail_DpmRec
        {
            get { return _OfficeAutomation_Document_AssetTransfer_Detail_DpmRec; }
            set { _OfficeAutomation_Document_AssetTransfer_Detail_DpmRec = value; }
        }
        //接收地点
        private string _OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec;

        public string OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec
        {
            get { return _OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec; }
            set { _OfficeAutomation_Document_AssetTransfer_Detail_PlaceRec = value; }
        }

        //资产名称
        private string _OfficeAutomation_Document_AssetTransfer_Detail_AssetName;

        public string OfficeAutomation_Document_AssetTransfer_Detail_AssetName
        {
            get { return _OfficeAutomation_Document_AssetTransfer_Detail_AssetName; }
            set { _OfficeAutomation_Document_AssetTransfer_Detail_AssetName = value; }
        }

        //资产ID
        private string _OfficeAutomation_Document_AssetTransfer_Detail_AssetAID;

        public string OfficeAutomation_Document_AssetTransfer_Detail_AssetAID
        {
            get { return _OfficeAutomation_Document_AssetTransfer_Detail_AssetAID; }
            set { _OfficeAutomation_Document_AssetTransfer_Detail_AssetAID = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime _OfficeAutomation_Document_AssetTransfer_Detail_CreateTime;

        public DateTime OfficeAutomation_Document_AssetTransfer_Detail_CreateTime
        {
            get { return _OfficeAutomation_Document_AssetTransfer_Detail_CreateTime; }
            set { _OfficeAutomation_Document_AssetTransfer_Detail_CreateTime = value; }
        }

        /// <summary>
        /// 是否IT类资产
        /// </summary>
        private string _OfficeAutomation_Document_AssetTransfer_Detail_CV;
        public string OfficeAutomation_Document_AssetTransfer_Detail_CV
        {
            get { return _OfficeAutomation_Document_AssetTransfer_Detail_CV; }
            set { _OfficeAutomation_Document_AssetTransfer_Detail_CV = value; }
        }

        //调动ID
        private Guid _OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID;

        public Guid OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID
        {
            get { return _OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID; }
            set { _OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID = value; }
        }
        //归属
        public string OfficeAutomation_Document_AssetTransfer_Detail_TxtType { get; set; }
    }
}
