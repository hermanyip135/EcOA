using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 报废申请明细表
    /// </summary>
    public class T_OfficeAutomation_Document_Scrap_Detail
    {
        private Guid officeAutomation_Document_Scrap_Detail_ID;
        /// <summary>
        ///报废申请明细主键
        /// </summary>
        public Guid OfficeAutomation_Document_Scrap_Detail_ID
        {
            get { return officeAutomation_Document_Scrap_Detail_ID; }
            set { officeAutomation_Document_Scrap_Detail_ID = value; }
        }
        private Guid officeAutomation_Document_Scrap_Detail_MainID;
        /// <summary>
        /// 报废申请主键
        /// </summary>
        public Guid OfficeAutomation_Document_Scrap_Detail_MainID
        {
            get { return officeAutomation_Document_Scrap_Detail_MainID; }
            set { officeAutomation_Document_Scrap_Detail_MainID = value; }
        }
        private int officeAutomation_Document_Scrap_Detail_AssetTypeID;
        /// <summary>
        /// 物品类型
        /// </summary>
        public int OfficeAutomation_Document_Scrap_Detail_AssetTypeID
        {
            get { return officeAutomation_Document_Scrap_Detail_AssetTypeID; }
            set { officeAutomation_Document_Scrap_Detail_AssetTypeID = value; }
        }
        private string officeAutomation_Document_Scrap_Detail_AssetTag;
        /// <summary>
        /// 财务编号
        /// </summary>
        public string OfficeAutomation_Document_Scrap_Detail_AssetTag
        {
            get { return officeAutomation_Document_Scrap_Detail_AssetTag; }
            set { officeAutomation_Document_Scrap_Detail_AssetTag = value; }
        }
        private string officeAutomation_Document_Scrap_Detail_Model;
        /// <summary>
        /// 规格型号
        /// </summary>
        public string OfficeAutomation_Document_Scrap_Detail_Model
        {
            get { return officeAutomation_Document_Scrap_Detail_Model; }
            set { officeAutomation_Document_Scrap_Detail_Model = value; }
        }
        private string officeAutomation_Document_Scrap_Detail_Number;
        /// <summary>
        /// 数量
        /// </summary>
        public string OfficeAutomation_Document_Scrap_Detail_Number
        {
            get { return officeAutomation_Document_Scrap_Detail_Number; }
            set { officeAutomation_Document_Scrap_Detail_Number = value; }
        }

        private DateTime officeAutomation_Document_Scrap_Detail_BuyDate;
        /// <summary>
        /// 购买时间
        /// </summary>
        public DateTime OfficeAutomation_Document_Scrap_Detail_BuyDate
        {
            get { return officeAutomation_Document_Scrap_Detail_BuyDate; }
            set { officeAutomation_Document_Scrap_Detail_BuyDate = value; }
        }
        private string officeAutomation_Document_Scrap_Detail_SurplusValue;
        /// <summary>
        /// 折旧摊分剩余费用
        /// </summary>
        public string OfficeAutomation_Document_Scrap_Detail_SurplusValue
        {
            get { return officeAutomation_Document_Scrap_Detail_SurplusValue; }
            set { officeAutomation_Document_Scrap_Detail_SurplusValue = value; }
        }

        private string _OfficeAutomation_Document_Scrap_Detail_AssetName;

        public string OfficeAutomation_Document_Scrap_Detail_AssetName
        {
            get { return _OfficeAutomation_Document_Scrap_Detail_AssetName; }
            set { _OfficeAutomation_Document_Scrap_Detail_AssetName = value; }
        }

        private string _OfficeAutomation_Document_Scrap_Detail_AssetAID;

        public string OfficeAutomation_Document_Scrap_Detail_AssetAID
        {
            get { return _OfficeAutomation_Document_Scrap_Detail_AssetAID; }
            set { _OfficeAutomation_Document_Scrap_Detail_AssetAID = value; }
        }

        private string _OfficeAutomation_Document_Scrap_Detail_PlaceRec;

        public string OfficeAutomation_Document_Scrap_Detail_PlaceRec
        {
            get { return _OfficeAutomation_Document_Scrap_Detail_PlaceRec; }
            set { _OfficeAutomation_Document_Scrap_Detail_PlaceRec = value; }
        }
        //调出部门
        private string _OfficeAutomation_Document_Scrap_Detail_DpmExp;

        public string OfficeAutomation_Document_Scrap_Detail_DpmExp
        {
            get { return _OfficeAutomation_Document_Scrap_Detail_DpmExp; }
            set { _OfficeAutomation_Document_Scrap_Detail_DpmExp = value; }
        }
        //调出地点
        private string _OfficeAutomation_Document_Scrap_Detail_PlaceExp;

        public string OfficeAutomation_Document_Scrap_Detail_PlaceExp
        {
            get { return _OfficeAutomation_Document_Scrap_Detail_PlaceExp; }
            set { _OfficeAutomation_Document_Scrap_Detail_PlaceExp = value; }
        }

        private int _OfficeAutomation_Document_Scrap_Detail_PlaceExpId;

        public int OfficeAutomation_Document_Scrap_Detail_PlaceExpId
        {
            get { return _OfficeAutomation_Document_Scrap_Detail_PlaceExpId; }
            set { _OfficeAutomation_Document_Scrap_Detail_PlaceExpId = value; }
        }

        //接收部门
        private string _OfficeAutomation_Document_Scrap_Detail_DpmRec;

        public string OfficeAutomation_Document_Scrap_Detail_DpmRec
        {
            get { return _OfficeAutomation_Document_Scrap_Detail_DpmRec; }
            set { _OfficeAutomation_Document_Scrap_Detail_DpmRec = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime _OfficeAutomation_Document_Scrap_Detail_CreateTime;

        public DateTime OfficeAutomation_Document_Scrap_Detail_CreateTime
        {
            get { return _OfficeAutomation_Document_Scrap_Detail_CreateTime; }
            set { _OfficeAutomation_Document_Scrap_Detail_CreateTime = value; }
        }

        /// <summary>
        /// 资产购买时间
        /// </summary>
        //public string _OfficeAutomation_Document_Scrap_Detail_BuyTime;

        //public string OfficeAutomation_Document_Scrap_Detail_BuyTime
        //{
        //    get { return _OfficeAutomation_Document_Scrap_Detail_BuyTime; }
        //    set { _OfficeAutomation_Document_Scrap_Detail_BuyTime = value; }
        //}

        /// <summary>
        /// 折旧摊分剩余费用
        /// </summary>
        private decimal _OfficeAutomation_Document_Scrap_Detail_Cost;

        public decimal OfficeAutomation_Document_Scrap_Detail_Cost
        {
            get { return _OfficeAutomation_Document_Scrap_Detail_Cost; }
            set { _OfficeAutomation_Document_Scrap_Detail_Cost = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        //public string _OfficeAutomation_Document_Scrap_Detail_Memo;

        //public string OfficeAutomation_Document_Scrap_Detail_Memo
        //{
        //    get { return _OfficeAutomation_Document_Scrap_Detail_Memo; }
        //    set { _OfficeAutomation_Document_Scrap_Detail_Memo = value; }
        //}

        /// <summary>
        /// 是否IT类资产
        /// </summary>
        private string _OfficeAutomation_Document_Scrap_Detail_CV;
        public string OfficeAutomation_Document_Scrap_Detail_CV
        {
            get { return _OfficeAutomation_Document_Scrap_Detail_CV; }
            set { _OfficeAutomation_Document_Scrap_Detail_CV = value; }
        }

        private Guid _OfficeAutomation_Document_Scrap_Detail_AdjustmentID;
        public Guid OfficeAutomation_Document_Scrap_Detail_AdjustmentID
        {
            get { return _OfficeAutomation_Document_Scrap_Detail_AdjustmentID; }
            set { _OfficeAutomation_Document_Scrap_Detail_AdjustmentID = value; }
        }

        private string _OfficeAutomation_Document_Scrap_Detail_Type;
        public string OfficeAutomation_Document_Scrap_Detail_Type
        {
            get { return _OfficeAutomation_Document_Scrap_Detail_Type; }
            set { _OfficeAutomation_Document_Scrap_Detail_Type = value; }
        }

    }
}
