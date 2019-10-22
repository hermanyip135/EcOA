using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 新分行周边的主要楼盘情况表
    /// </summary>
    public class T_OfficeAutomation_Document_Feasibility_BuildingSituation
    {
        private Guid _OfficeAutomation_Document_Feasibility_BuildingSituation_ID;
        /// <summary>
        /// 主键
        /// </summary>
        public Guid OfficeAutomation_Document_Feasibility_BuildingSituation_ID
        {
            get { return _OfficeAutomation_Document_Feasibility_BuildingSituation_ID; }
            set { _OfficeAutomation_Document_Feasibility_BuildingSituation_ID = value; }
        }

        private Guid _OfficeAutomation_Document_Feasibility_BuildingSituation_MainID;
        /// <summary>
        /// 主表主键
        /// </summary>
        public Guid OfficeAutomation_Document_Feasibility_BuildingSituation_MainID
        {
            get { return _OfficeAutomation_Document_Feasibility_BuildingSituation_MainID; }
            set { _OfficeAutomation_Document_Feasibility_BuildingSituation_MainID = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_BuildingSituation_BuildingName;
        /// <summary>
        /// 楼盘名称
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_BuildingSituation_BuildingName
        {
            get { return _OfficeAutomation_Document_Feasibility_BuildingSituation_BuildingName; }
            set { _OfficeAutomation_Document_Feasibility_BuildingSituation_BuildingName = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_BuildingSituation_Csell;
        /// <summary>
        /// 可售盘量
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_BuildingSituation_Csell
        {
            get { return _OfficeAutomation_Document_Feasibility_BuildingSituation_Csell; }
            set { _OfficeAutomation_Document_Feasibility_BuildingSituation_Csell = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_BuildingSituation_MainSquare;
        /// <summary>
        /// 主要户型面积
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_BuildingSituation_MainSquare
        {
            get { return _OfficeAutomation_Document_Feasibility_BuildingSituation_MainSquare; }
            set { _OfficeAutomation_Document_Feasibility_BuildingSituation_MainSquare = value; }
        }

        private string _OfficeAutomation_Document_Feasibility_BuildingSituation_AvarageCoast;
        /// <summary>
        /// 均价
        /// </summary>
        public string OfficeAutomation_Document_Feasibility_BuildingSituation_AvarageCoast
        {
            get { return _OfficeAutomation_Document_Feasibility_BuildingSituation_AvarageCoast; }
            set { _OfficeAutomation_Document_Feasibility_BuildingSituation_AvarageCoast = value; }
        }

        private bool _OfficeAutomation_Document_Feasibility_BuildingSituation_IsMain;
        /// <summary>
        /// 是否新分行的主打盘
        /// </summary>
        public bool OfficeAutomation_Document_Feasibility_BuildingSituation_IsMain
        {
            get { return _OfficeAutomation_Document_Feasibility_BuildingSituation_IsMain; }
            set { _OfficeAutomation_Document_Feasibility_BuildingSituation_IsMain = value; }
        }
    }
}
