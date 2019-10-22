using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using DataEntity;

namespace DataAccess.Operate
{
    public partial class DA_OfficeAutomation_Document_WithdrawShop_Inherit : DA_OfficeAutomation_Document_WithdrawShop_Operate
    {
        public DA_OfficeAutomation_Document_WithdrawShop_Inherit()
        { }

        /// <summary>
        /// 通过MainID查询撤铺转铺申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT todi.*"
                             + "         ,toam.OfficeAutomation_SerialNumber"
                             + "         ,tdoad.OfficeAutomation_Document_Name"
                             + "         ,toam.OfficeAutomation_Main_FlowStateID"
                             + "         ,tdodt.OfficeAutomation_DepartmentType_Name"
                             + "         ,tdopp.OfficeAutomation_Majordomo_Name"
                             + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_WithdrawShop] todi"
                             + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_WithdrawShop_MainID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_DepartmentType tdodt ON tdodt.OfficeAutomation_DepartmentType_ID = todi.OfficeAutomation_Document_WithdrawShop_DepartmentTypeID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_Majordomo tdopp ON tdopp.OfficeAutomation_Majordomo_ID = todi.OfficeAutomation_Document_WithdrawShop_MajordomoID"
                             + " WHERE OfficeAutomation_Document_WithdrawShop_MainID='" + mainID + "'";

            return DbHelperSQL.Query(sql);
        }

        //插入或者修改关键内容
        public bool HandleBase(DataEntity.PageModel.T_OfficeAutomation_Document_WithdrawShop_M obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_WithdrawShop_MainID == null)
            { return false; }

            #region 必填字段
            var Baseobj = new DataEntity.T_OfficeAutomation_Document_WithdrawShop();
            Baseobj.OfficeAutomation_Document_WithdrawShop_ID = new Guid(obj.OfficeAutomation_Document_WithdrawShop_ID);
            Baseobj.OfficeAutomation_Document_WithdrawShop_MainID = new Guid(obj.OfficeAutomation_Document_WithdrawShop_MainID);
            Baseobj.OfficeAutomation_Document_WithdrawShop_Apply = obj.OfficeAutomation_Document_WithdrawShop_Apply;
            Baseobj.OfficeAutomation_Document_WithdrawShop_ApplyID = obj.OfficeAutomation_Document_WithdrawShop_ApplyID;
            Baseobj.OfficeAutomation_Document_WithdrawShop_Department = obj.OfficeAutomation_Document_WithdrawShop_Department;
            Baseobj.OfficeAutomation_Document_WithdrawShop_ApplyDate = Convert.ToDateTime(obj.OfficeAutomation_Document_WithdrawShop_ApplyDate);
            Baseobj.OfficeAutomation_Document_WithdrawShop_ReplyPhone = obj.OfficeAutomation_Document_WithdrawShop_ReplyPhone;
            Baseobj.OfficeAutomation_Document_WithdrawShop_ReplyFax = obj.OfficeAutomation_Document_WithdrawShop_ReplyFax;
            Baseobj.OfficeAutomation_Document_WithdrawShop_ApplyTypeID = Convert.ToInt32(obj.OfficeAutomation_Document_WithdrawShop_ApplyTypeID);
            Baseobj.OfficeAutomation_Document_WithdrawShop_DepartmentTypeID = Convert.ToInt32(obj.OfficeAutomation_Document_WithdrawShop_DepartmentTypeID);
            Baseobj.OfficeAutomation_Document_WithdrawShop_MajordomoID = Convert.ToInt32(obj.OfficeAutomation_Document_WithdrawShop_MajordomoID);
            Baseobj.OfficeAutomation_Document_WithdrawShop_DepartmentName = obj.OfficeAutomation_Document_WithdrawShop_DepartmentName;
            Baseobj.OfficeAutomation_Document_WithdrawShop_DepartmentAddress = obj.OfficeAutomation_Document_WithdrawShop_DepartmentAddress;
            Baseobj.OfficeAutomation_Document_WithdrawShop_ExpireDate = Convert.ToDateTime(obj.OfficeAutomation_Document_WithdrawShop_ExpireDate);
            Baseobj.OfficeAutomation_Document_WithdrawShop_PlanDate = Convert.ToDateTime(obj.OfficeAutomation_Document_WithdrawShop_PlanDate);
            Baseobj.OfficeAutomation_Document_WithdrawShop_Reason = obj.OfficeAutomation_Document_WithdrawShop_Reason;
            Baseobj.OfficeAutomation_Document_WithdrawShop_AssetHandleIDs = obj.OfficeAutomation_Document_WithdrawShop_AssetHandleIDs;
            Baseobj.OfficeAutomation_Document_WithdrawShop_PhoneHandleID = Convert.ToInt32(obj.OfficeAutomation_Document_WithdrawShop_PhoneHandleID);
            Baseobj.OfficeAutomation_Document_WithdrawShop_IsFlyLine = Convert.ToBoolean(obj.OfficeAutomation_Document_WithdrawShop_IsFlyLine);
            Baseobj.OfficeAutomation_Document_WithdrawShop_CanBackDeposit = Convert.ToBoolean(obj.OfficeAutomation_Document_WithdrawShop_CanBackDeposit);
            Baseobj.OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages = Convert.ToBoolean(obj.OfficeAutomation_Document_WithdrawShop_WillLiquidatedDamages);
            Baseobj.OfficeAutomation_Document_WithdrawShop_PaymentAmortizeEndDate = Convert.ToDateTime(obj.OfficeAutomation_Document_WithdrawShop_PaymentAmortizeEndDate);
            Baseobj.OfficeAutomation_Document_WithdrawShop_PaymentAmortizeRemaining = obj.OfficeAutomation_Document_WithdrawShop_PaymentAmortizeRemaining;

            Baseobj.OfficeAutomation_Document_WithdrawShop_StartDate = Convert.ToDateTime(obj.OfficeAutomation_Document_WithdrawShop_StartDate);
            Baseobj.OfficeAutomation_Document_WithdrawShop_TotalAmortizedBalance = obj.OfficeAutomation_Document_WithdrawShop_TotalAmortizedBalance;
            Baseobj.OfficeAutomation_Document_WithdrawShop_ComputerAmortizedRemaining = obj.OfficeAutomation_Document_WithdrawShop_ComputerAmortizedRemaining;
            Baseobj.OfficeAutomation_Document_WithdrawShop_ComputerAmortizeEndDate = Convert.ToDateTime(obj.OfficeAutomation_Document_WithdrawShop_ComputerAmortizeEndDate);
            Baseobj.OfficeAutomation_Document_WithdrawShop_AreaLastYear = obj.OfficeAutomation_Document_WithdrawShop_AreaLastYear;
            Baseobj.OfficeAutomation_Document_WithdrawShop_AreaLastYearResults = obj.OfficeAutomation_Document_WithdrawShop_AreaLastYearResults;
            Baseobj.OfficeAutomation_Document_WithdrawShop_AreaLastYearProfit = obj.OfficeAutomation_Document_WithdrawShop_AreaLastYearProfit;
            Baseobj.OfficeAutomation_Document_WithdrawShop_AreaThisYStartDate = Convert.ToDateTime(obj.OfficeAutomation_Document_WithdrawShop_AreaThisYStartDate);
            Baseobj.OfficeAutomation_Document_WithdrawShop_AreaThisYEndDate = Convert.ToDateTime(obj.OfficeAutomation_Document_WithdrawShop_AreaThisYEndDate);
            Baseobj.OfficeAutomation_Document_WithdrawShop_AreaThisYResults = obj.OfficeAutomation_Document_WithdrawShop_AreaThisYResults;
            Baseobj.OfficeAutomation_Document_WithdrawShop_AreaThisYProfit = obj.OfficeAutomation_Document_WithdrawShop_AreaThisYProfit;
            Baseobj.OfficeAutomation_Document_WithdrawShop_BranchLastYear = obj.OfficeAutomation_Document_WithdrawShop_BranchLastYear;
            Baseobj.OfficeAutomation_Document_WithdrawShop_BranchLastYResults = obj.OfficeAutomation_Document_WithdrawShop_BranchLastYResults;
            Baseobj.OfficeAutomation_Document_WithdrawShop_BranchLastYProfit = obj.OfficeAutomation_Document_WithdrawShop_AreaLastYearProfit;
            Baseobj.OfficeAutomation_Document_WithdrawShop_BranchThisYStartDate = Convert.ToDateTime(obj.OfficeAutomation_Document_WithdrawShop_BranchThisYStartDate);
            Baseobj.OfficeAutomation_Document_WithdrawShop_BranchThisYEndDate = Convert.ToDateTime(obj.OfficeAutomation_Document_WithdrawShop_BranchThisYEndDate);
            Baseobj.OfficeAutomation_Document_WithdrawShop_BranchThisYResults = obj.OfficeAutomation_Document_WithdrawShop_BranchThisYResults;
            Baseobj.OfficeAutomation_Document_WithdrawShop_BranchThisYProfit = obj.OfficeAutomation_Document_WithdrawShop_BranchThisYProfit;
            #endregion
            //obj是否已经存在
            var where = "[OfficeAutomation_Document_WithdrawShop_MainID]='" + obj.OfficeAutomation_Document_WithdrawShop_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_WithdrawShop resultobj;
            if (Exist(where))
            {
                //Edit
                resultobj = Edit(Baseobj);
            }
            else
            {
                //Add
                resultobj = Insert(Baseobj);
            }
            return resultobj != null;
        }
    }
}

