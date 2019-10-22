using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using DataEntity;

namespace DataAccess.Operate
{
    public partial class DA_OfficeAutomation_Document_CoopCost_Inherit : DA_OfficeAutomation_Document_CoopCost_Operate
    {
        public DA_OfficeAutomation_Document_CoopCost_Inherit()
        { }

        /// <summary>
        /// 通过MainID查询员工合作费申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT todi.*"
                             + "         ,toam.OfficeAutomation_SerialNumber"
                             + "         ,tdoad.OfficeAutomation_Document_Name"
                             + "         ,toam.OfficeAutomation_Main_FlowStateID"
                             + "         ,tdodot.OfficeAutomation_DepartmentType_Name"
                             + "         ,tdodt.OfficeAutomation_DealType_Name"
                             + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CoopCost] todi"
                             + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_CoopCost_MainID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_DepartmentType tdodot ON tdodot.OfficeAutomation_DepartmentType_ID = todi.OfficeAutomation_Document_CoopCost_DepartmentTypeID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_DealType tdodt ON tdodt.OfficeAutomation_DealType_ID = todi.OfficeAutomation_Document_CoopCost_DealTypeID"
                             + " WHERE OfficeAutomation_Document_CoopCost_MainID='" + mainID + "'";
            return DbHelperSQL.Query(sql);
        }

        #region 自定义
        //插入或者修改关键内容
        public bool HandleBase(DataEntity.T_OfficeAutomation_Document_CoopCost obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_CoopCost_MainID == null)
            { return false; }

            var Baseobj = new DataEntity.T_OfficeAutomation_Document_CoopCost();
            #region 关键内容
            Baseobj.OfficeAutomation_Document_CoopCost_ID = obj.OfficeAutomation_Document_CoopCost_ID;
            Baseobj.OfficeAutomation_Document_CoopCost_MainID = obj.OfficeAutomation_Document_CoopCost_MainID;
            Baseobj.OfficeAutomation_Document_CoopCost_Apply = obj.OfficeAutomation_Document_CoopCost_Apply;
            Baseobj.OfficeAutomation_Document_CoopCost_ApplyForName = obj.OfficeAutomation_Document_CoopCost_ApplyForName;
            Baseobj.OfficeAutomation_Document_CoopCost_ApplyForCode = obj.OfficeAutomation_Document_CoopCost_ApplyForCode;
            Baseobj.OfficeAutomation_Document_CoopCost_Department = obj.OfficeAutomation_Document_CoopCost_Department;
            Baseobj.OfficeAutomation_Document_CoopCost_DepartmentID = obj.OfficeAutomation_Document_CoopCost_DepartmentID;
            Baseobj.OfficeAutomation_Document_CoopCost_ApplyDate = obj.OfficeAutomation_Document_CoopCost_ApplyDate;
            Baseobj.OfficeAutomation_Document_CoopCost_ReplyPhone = obj.OfficeAutomation_Document_CoopCost_ReplyPhone;
            Baseobj.OfficeAutomation_Document_CoopCost_DepartmentTypeID = obj.OfficeAutomation_Document_CoopCost_DepartmentTypeID;
            Baseobj.OfficeAutomation_Document_CoopCost_DealDate = obj.OfficeAutomation_Document_CoopCost_DealDate;
            Baseobj.OfficeAutomation_Document_CoopCost_PropertyName = obj.OfficeAutomation_Document_CoopCost_PropertyName;
            Baseobj.OfficeAutomation_Document_CoopCost_ReportID = obj.OfficeAutomation_Document_CoopCost_ReportID;
            Baseobj.OfficeAutomation_Document_CoopCost_DealTypeID = obj.OfficeAutomation_Document_CoopCost_DealTypeID;
            Baseobj.OfficeAutomation_Document_CoopCost_Area = obj.OfficeAutomation_Document_CoopCost_Area;
            Baseobj.OfficeAutomation_Document_CoopCost_DealPrice = obj.OfficeAutomation_Document_CoopCost_DealPrice;
            Baseobj.OfficeAutomation_Document_CoopCost_OwnerComm = obj.OfficeAutomation_Document_CoopCost_OwnerComm;
            Baseobj.OfficeAutomation_Document_CoopCost_OwnerScale = obj.OfficeAutomation_Document_CoopCost_OwnerScale;
            Baseobj.OfficeAutomation_Document_CoopCost_ClientComm = obj.OfficeAutomation_Document_CoopCost_ClientComm;
            Baseobj.OfficeAutomation_Document_CoopCost_ClientScale = obj.OfficeAutomation_Document_CoopCost_ClientScale;
            Baseobj.OfficeAutomation_Document_CoopCost_TotalComm = obj.OfficeAutomation_Document_CoopCost_TotalComm;
            Baseobj.OfficeAutomation_Document_CoopCost_TotalScale = obj.OfficeAutomation_Document_CoopCost_TotalScale;
            Baseobj.OfficeAutomation_Document_CoopCost_BillTypeOwner = obj.OfficeAutomation_Document_CoopCost_BillTypeOwner;
            Baseobj.OfficeAutomation_Document_CoopCost_OwnerName = obj.OfficeAutomation_Document_CoopCost_OwnerName;
            Baseobj.OfficeAutomation_Document_CoopCost_IsOwner = obj.OfficeAutomation_Document_CoopCost_IsOwner;
            Baseobj.OfficeAutomation_Document_CoopCost_OwnerCoopCondition = obj.OfficeAutomation_Document_CoopCost_OwnerCoopCondition;
            Baseobj.OfficeAutomation_Document_CoopCost_OwnerCoopMoney = obj.OfficeAutomation_Document_CoopCost_OwnerCoopMoney;
            Baseobj.OfficeAutomation_Document_CoopCost_OwnerCoopScale = obj.OfficeAutomation_Document_CoopCost_OwnerCoopScale;
            Baseobj.OfficeAutomation_Document_CoopCost_OwnerCoopTotalScale = obj.OfficeAutomation_Document_CoopCost_OwnerCoopTotalScale;
            Baseobj.OfficeAutomation_Document_CoopCost_BillTypeClient = obj.OfficeAutomation_Document_CoopCost_BillTypeClient;
            Baseobj.OfficeAutomation_Document_CoopCost_ClientName = obj.OfficeAutomation_Document_CoopCost_ClientName;
            Baseobj.OfficeAutomation_Document_CoopCost_IsClient = obj.OfficeAutomation_Document_CoopCost_IsClient;
            Baseobj.OfficeAutomation_Document_CoopCost_ClientCoopCondition = obj.OfficeAutomation_Document_CoopCost_ClientCoopCondition;
            Baseobj.OfficeAutomation_Document_CoopCost_ClientCoopMoney = obj.OfficeAutomation_Document_CoopCost_ClientCoopMoney;
            Baseobj.OfficeAutomation_Document_CoopCost_ClientCoopScale = obj.OfficeAutomation_Document_CoopCost_ClientCoopScale;
            Baseobj.OfficeAutomation_Document_CoopCost_ClientCoopTotalScale = obj.OfficeAutomation_Document_CoopCost_ClientCoopTotalScale;
            Baseobj.OfficeAutomation_Document_CoopCost_CoopMoney = obj.OfficeAutomation_Document_CoopCost_CoopMoney;
            Baseobj.OfficeAutomation_Document_CoopCost_CoopTotalScale = obj.OfficeAutomation_Document_CoopCost_CoopTotalScale;
            Baseobj.OfficeAutomation_Document_CoopCost_ActualComm = obj.OfficeAutomation_Document_CoopCost_ActualComm;
            Baseobj.OfficeAutomation_Document_CoopCost_ActualCommScale = obj.OfficeAutomation_Document_CoopCost_ActualCommScale;
            #endregion
            //obj是否已经存在
            var where = "[OfficeAutomation_Document_CoopCost_MainID]='" + obj.OfficeAutomation_Document_CoopCost_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_CoopCost resultobj;
            if (Exist(where))
            {
                //Edit
                resultobj = TemEdit(Baseobj);
            }
            else
            {
                //Add
                resultobj = TemAdd(Baseobj);
            }
            return resultobj != null;
        }

        #endregion
    }
}

