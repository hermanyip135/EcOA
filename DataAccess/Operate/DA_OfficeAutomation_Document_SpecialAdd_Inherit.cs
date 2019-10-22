using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SpecialAdd_Inherit : DA_OfficeAutomation_Document_SpecialAdd_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_SpecialAdd_ID]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_MainID]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Apply]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_ApplyID]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Department]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_ReceiveD]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_CCDpm]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Subject]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Phone]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Fax]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Group]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Year1]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Year2]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Year3]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Year4]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Year5]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Month1]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Month2]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Month3]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Month4]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Month5]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Results1]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Results2]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Results3]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Results4]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Results5]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Profits1]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Profits2]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Profits3]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Profits4]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Profits5]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumFear1]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumFear2]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumFear3]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumFear4]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumFear5]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_BDLost1]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_BDLost2]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_BDLost3]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_BDLost4]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_BDLost5]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_HoldRat]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_GPlace]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumBuild]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_CountComplete]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_CompleteRat]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_RentYearStart]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_RentMonthStart]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_RentYearEnd]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_RentMonthEnd]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_UseRat]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumCount]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumGzspsNum]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumGzspsRate]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumEveryNum]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumEveryRate]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumRichNum]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumRichRate]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumYuFengNum]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumYuFengRate]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumFreeNum]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumFreeRate]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumOtherNum]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumOtherRate]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumQFangNum]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumQFangRate]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_AddOne]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Reason]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SecHand1]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SecHand2]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SecHand3]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SecHand4]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SecHand5]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_IsTG1]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_IsTG2]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_IsTG3]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_IsTG4]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_IsTG5]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_KeyCount]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SpecialAdd] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SpecialAdd_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_SpecialAdd_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_SpecialAdd_ID]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_MainID]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Apply]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_ApplyID]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Department]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_ReceiveD]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_CCDpm]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Subject]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Phone]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Fax]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Group]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Year1]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Year2]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Year3]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Year4]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Year5]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Month1]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Month2]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Month3]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Month4]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Month5]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Results1]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Results2]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Results3]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Results4]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Results5]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Profits1]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Profits2]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Profits3]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Profits4]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Profits5]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumFear1]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumFear2]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumFear3]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumFear4]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumFear5]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_BDLost1]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_BDLost2]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_BDLost3]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_BDLost4]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_BDLost5]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_HoldRat]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_GPlace]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumBuild]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_CountComplete]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_CompleteRat]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_RentYearStart]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_RentMonthStart]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_RentYearEnd]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_RentMonthEnd]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_UseRat]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumCount]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumGzspsNum]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumGzspsRate]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumEveryNum]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumEveryRate]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumRichNum]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumRichRate]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumYuFengNum]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumYuFengRate]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumFreeNum]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumFreeRate]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumOtherNum]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumOtherRate]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumQFangNum]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SumQFangRate]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_AddOne]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_Reason]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SecHand1]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SecHand2]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SecHand3]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SecHand4]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_SecHand5]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_IsTG1]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_IsTG2]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_IsTG3]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_IsTG4]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_IsTG5]"
                           + "           ,[OfficeAutomation_Document_SpecialAdd_KeyCount]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SpecialAdd] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SpecialAdd_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_SpecialAdd_ID='" + ID + "'";

            return RunSQL(sql);
        }

        #region 自定义
        
        //插入或者修改关键内容
        public bool HandleBase(DataEntity.T_OfficeAutomation_Document_SpecialAdd obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_SpecialAdd_MainID == null)
            { return false; }

            var Baseobj = new DataEntity.T_OfficeAutomation_Document_SpecialAdd();
            Baseobj.OfficeAutomation_Document_SpecialAdd_ID = obj.OfficeAutomation_Document_SpecialAdd_ID;
            Baseobj.OfficeAutomation_Document_SpecialAdd_MainID = obj.OfficeAutomation_Document_SpecialAdd_MainID;
            Baseobj.OfficeAutomation_Document_SpecialAdd_Apply = obj.OfficeAutomation_Document_SpecialAdd_Apply;
            Baseobj.OfficeAutomation_Document_SpecialAdd_ApplyDate = obj.OfficeAutomation_Document_SpecialAdd_ApplyDate;
            Baseobj.OfficeAutomation_Document_SpecialAdd_Department = obj.OfficeAutomation_Document_SpecialAdd_Department;
            
            //obj是否已经存在
            var where = "[OfficeAutomation_Document_SpecialAdd_MainID]='" + obj.OfficeAutomation_Document_SpecialAdd_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_SpecialAdd resultobj;
            if (Exist(where))
            {
                //Edit
                resultobj = Edit(Baseobj);
            }
            else
            {
                //Add
                resultobj = Add(Baseobj);
            }
            return resultobj != null;
        }

        #endregion
    }
}
