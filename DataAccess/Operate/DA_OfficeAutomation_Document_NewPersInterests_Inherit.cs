using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_NewPersInterests_Inherit : DA_OfficeAutomation_Document_NewPersInterests_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_NewPersInterests_ID]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_MainID]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Apply]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_ApplyID]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Department]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_DepartmentTypeID]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_ApplyForID]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Phone]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_InterestsTypeID]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_ApplyContent]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_DealKind]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_DealProperty]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_FollowerNo]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_PropertyHander]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_MeAndHim]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Relationship]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_RelationName]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Building]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Square]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_PriceScope]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_LeaseTerm]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_PayWay]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Requirements]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_FollowWay]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_ApplySomething]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_GiftName]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_GiftPrice]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_CrashOrCard]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_AnotherName]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_AnotherPrice]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_GiverOrCompany]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Entrust]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_BuildingKind]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_AnotherBuilding]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_EntrustNo]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_AnotherActivity]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Investment]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Ipossition]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_AnotherSummary]"
                           +"            ,OfficeAutomation_Document_NewPersInterests_IsInApply"
                           +"            ,OfficeAutomation_Document_NewPersInterests_Relationship1"
                           +"            ,OfficeAutomation_Document_NewPersInterests_IsCompanyStaff"
                           +"            ,OfficeAutomation_Document_NewPersInterests_AddressNum"
                           +"            ,OfficeAutomation_Document_NewPersInterests_txtTfid1"
                           +"            ,OfficeAutomation_Document_NewPersInterests_possition"
                           +"            ,OfficeAutomation_Document_NewPersInterests_EntryDate"
                           + "           ,OfficeAutomation_Document_NewPersInterests_ProbationDate"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_Creater"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_NewPersInterests] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_NewPersInterests_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_NewPersInterests_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_NewPersInterests_ID]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_MainID]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Apply]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_ApplyID]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Department]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_DepartmentTypeID]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_ApplyForID]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Phone]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_InterestsTypeID]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_ApplyContent]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_DealKind]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_DealProperty]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_FollowerNo]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_PropertyHander]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_MeAndHim]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Relationship]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_RelationName]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Building]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Square]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_PriceScope]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_LeaseTerm]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_PayWay]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Requirements]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_FollowWay]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_ApplySomething]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_GiftName]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_GiftPrice]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_CrashOrCard]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_AnotherName]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_AnotherPrice]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_GiverOrCompany]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Entrust]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_BuildingKind]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_AnotherBuilding]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_EntrustNo]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_AnotherActivity]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Investment]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_Ipossition]"
                           + "           ,[OfficeAutomation_Document_NewPersInterests_AnotherSummary]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_NewPersInterests] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_NewPersInterests_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_NewPersInterests_ID='" + ID + "'";

            return RunSQL(sql);
        }
        /// <summary>
        /// 根据物业地址查之前已经上多少次
        /// </summary>
        /// <param name="sBuilding"></param>
        /// <returns></returns>
        public int SearchBuildingNum(string sBuilding,string MainID)
        {
            string sql = @"SELECT OfficeAutomation_Document_NewPersInterests_ID FROM t_OfficeAutomation_Document_NewPersInterests n WITH(TABLOCKX)
                            INNER JOIN t_OfficeAutomation_Main m on m.OfficeAutomation_Main_ID = n.OfficeAutomation_Document_NewPersInterests_MainID
                            where OfficeAutomation_Main_IsDelete !=1
                         AND OfficeAutomation_Document_NewPersInterests_Building ='" + sBuilding + "' AND OfficeAutomation_Document_NewPersInterests_MainID != '" + MainID + "'";
            DataSet ds = RunSQL(sql);
            return Convert.ToInt32(ds.Tables[0].Rows.Count);
            
        }
    }
}
