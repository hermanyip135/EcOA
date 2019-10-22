using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SqlDatabase;
using System.Data;

public partial class UpdateTools : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    string conn = SqlHelper.ConnectionString;
    
    /// <summary>
    /// 更新OfficeAutomation_Main_Department，OfficeAutomation_Main_Apply，OfficeAutomation_Main_ApplyDate等冗余字段
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = "SELECT [OfficeAutomation_Document_TableName] AS TableName FROM t_Dic_OfficeAutomation_Document";
        DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);     //获取全部申请表名称
        if (ds != null)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string tableName = dr["TableName"].ToString();
                string departmentName = tableName.Substring(2, tableName.Length - 2) + "_Department";
                string applyName = tableName.Substring(2, tableName.Length - 2) + "_Apply";
                string applyDate = tableName.Substring(2, tableName.Length - 2) + "_ApplyDate";
                string mainIDName = tableName.Substring(2, tableName.Length - 2) + "_MainID";
                string updateSql =
@"UPDATE m SET m.OfficeAutomation_Main_Department=d.{0},m.OfficeAutomation_Main_Apply=d.{3},m.OfficeAutomation_Main_ApplyDate=d.{4},m.OfficeAutomation_Main_Summary={5}
FROM t_OfficeAutomation_Main m
LEFT JOIN {1} d ON d.{2}=m.OfficeAutomation_Main_ID
WHERE EXISTS (SELECT 1 FROM {1} WHERE {2}=m.OfficeAutomation_Main_ID)
";
                if (tableName != "t_OfficeAutomation_Document_CommissionAdjust")
                    continue;
                string summaryName = "";
                switch (tableName)
                {
                    case "t_OfficeAutomation_Document_AfterCommission":
                        summaryName = "d.OfficeAutomation_Document_AfterCommission_Subject";
                        break;
                    case "t_OfficeAutomation_Document_ITPower":
                        summaryName = "d.OfficeAutomation_Document_ITPower_Deal";
                        break;
                    case "t_OfficeAutomation_Document_SysReq":
                        summaryName = "(SELECT OfficeAutomation_SoftSystem_Name FROM t_Dic_OfficeAutomation_SoftSystem f WHERE f.OfficeAutomation_SoftSystem_ID = d.OfficeAutomation_Document_SysReq_SystemName)";
                        break;
                    case "t_OfficeAutomation_Document_SysPower":
                        summaryName = "d.OfficeAutomation_Document_SysPower_Deal";
                        break;
                    case "t_OfficeAutomation_Document_Scrap":
                        summaryName = "d.[OfficeAutomation_Document_Scrap_UserName],m.[OfficeAutomation_Main_Sremark]=d.[OfficeAutomation_Document_Scrap_Remark]";
                        break;
                    case "t_OfficeAutomation_Document_AssetTransfer":
                        summaryName = "'',m.[OfficeAutomation_Main_Sremark]=d.[OfficeAutomation_Document_AssetTransfer_Remark]";
                        break;
                    case "t_OfficeAutomation_Document_DealOffice":
                        summaryName = "''";
                        break;
                    case "t_OfficeAutomation_Document_ITBuy":
                        summaryName = "d.[OfficeAutomation_Document_ITBuy_ApplyID],m.[OfficeAutomation_Main_Sremark]=d.[OfficeAutomation_Document_ITBuy_Remark]";
                        break;
                    case "t_OfficeAutomation_Document_PersInterests":
                        summaryName = "d.OfficeAutomation_Document_PersInterests_Remark";
                        break;
                    case "t_OfficeAutomation_Document_NewPersInterests":
                        summaryName = "d.OfficeAutomation_Document_NewPersInterests_Building";
                        break;
                    case "t_OfficeAutomation_Document_BuyBuilding":
                        summaryName = "d.OfficeAutomation_Document_BuyBuilding_ApplyForName";
                        break;
                    case "t_OfficeAutomation_Document_CarAllowance":
                        summaryName = "d.OfficeAutomation_Document_CarAllowance_ApplyForName";
                        break;
                    case "t_OfficeAutomation_Document_BackComm":
                        summaryName = "'',m.[OfficeAutomation_Main_Sremark]=d.OfficeAutomation_Document_BackComm_Remark";
                        break;
                    case "t_OfficeAutomation_Document_BadDebts":
                        summaryName = "'',m.[OfficeAutomation_Main_Sremark]=d.OfficeAutomation_Document_BadDebts_Remark";
                        break;
                    case "t_OfficeAutomation_Document_ReduceComm":
                        summaryName = "d.OfficeAutomation_Document_ReduceComm_Subject";
                        break;
                    case "t_OfficeAutomation_Document_ProjCost":
                        summaryName = "d.[OfficeAutomation_Document_ProjCost_Project],m.[OfficeAutomation_Main_Sremark]=d.[OfficeAutomation_Document_ProjCost_Remark]";
                        break;
                    case "t_OfficeAutomation_Document_CoopCost":
                        summaryName = "d.OfficeAutomation_Document_CoopCost_PropertyName";
                        break;
                    case "t_OfficeAutomation_Document_UndertakeProj":
                        summaryName = "d.OfficeAutomation_Document_UndertakeProj_Project";
                        break;
                    case "t_OfficeAutomation_Document_ExtraBonus":
                        summaryName = "d.OfficeAutomation_Document_ExtraBonus_Project";
                        break;
                    case "t_OfficeAutomation_Document_ResumeBusi":
                        summaryName = "d.[OfficeAutomation_Document_ResumeBusi_DepartmentName]";
                        break;
                    case "t_OfficeAutomation_Document_WithdrawShop":
                        summaryName = "d.[OfficeAutomation_Document_WithdrawShop_DepartmentName]";
                        break;
                    case "t_OfficeAutomation_Document_SuspendBusi":
                        summaryName = "d.[OfficeAutomation_Document_SuspendBusi_DepartmentName]";
                        break;
                    case "t_OfficeAutomation_Document_ProjAgentClause":
                        summaryName = "d.[OfficeAutomation_Document_ProjAgentClause_ProjName]";
                        break;
                    case "t_OfficeAutomation_Document_ProjWorkCloth":
                        summaryName = "d.[OfficeAutomation_Document_ProjWorkCloth_ProjName]";
                        break;
                    case "t_OfficeAutomation_Document_ProjDormSubsiby":
                        summaryName = "d.[OfficeAutomation_Document_ProjDormSubsiby_ProjName]";
                        break;
                    case "t_OfficeAutomation_Document_ProjRepoData":
                        summaryName = "d.[OfficeAutomation_Document_ProjRepoData_ProjName]";
                        break;
                    case "t_OfficeAutomation_Document_ChangeData":
                        summaryName = "d.[OfficeAutomation_Document_ChangeData_Reason]";
                        break;
                    case "t_OfficeAutomation_Document_CommissionAdjust":
                        summaryName = "(d.[OfficeAutomation_Document_CommissionAdjust_Building] + ' 坏账：' + d.[OfficeAutomation_Document_CommissionAdjust_AjustComm]),m.[OfficeAutomation_Main_Sremark]=d.OfficeAutomation_Document_CommissionAdjust_Remark";
                        break;
                    case "t_OfficeAutomation_Document_WirelessFixedLine":
                        summaryName = "d.OfficeAutomation_Document_WirelessFixedLine_ApplyID";
                        break;
                    case "t_OfficeAutomation_Document_FurtherEducation":
                        summaryName = "d.OfficeAutomation_Document_FurtherEducation_ApplyID";
                        break;
                    case "t_OfficeAutomation_Document_SpecialNumber":
                        summaryName = "d.OfficeAutomation_Document_SpecialNumber_Subject";
                        break;
                    case "t_OfficeAutomation_Document_OfficialSeal":
                        summaryName = "(CASE WHEN d.OfficeAutomation_Document_OfficialSeal_SureCommissioner !='' THEN '(√★)' ELSE '' END  + (SELECT dd.OfficeAutomation_Document_OfficialSeal_Detail_BN + '，' FROM t_OfficeAutomation_Document_OfficialSeal_Detail dd WHERE dd.OfficeAutomation_Document_OfficialSeal_Detail_MainID = d.OfficeAutomation_Document_OfficialSeal_ID FOR XML PATH('')) + CASE WHEN d.OfficeAutomation_Document_OfficialSeal_SureCommissioner !='' THEN ISNULL(d.OfficeAutomation_Document_OfficialSeal_SureData,'') ELSE '' END)";
                        break;
                    case "t_OfficeAutomation_Document_BranchContract":
                        summaryName = "d.OfficeAutomation_Document_BranchContract_Name";
                        break;
                    case "t_OfficeAutomation_Document_Tourism":
                        summaryName = "d.OfficeAutomation_Document_Tourism_ActivityPlace";
                        break;
                    case "t_OfficeAutomation_Document_OweSubmit":
                        summaryName = "d.OfficeAutomation_Document_OweSubmit_Name";
                        break;
                    case "t_OfficeAutomation_Document_TotalRev":
                        summaryName = "d.OfficeAutomation_Document_TotalRev_Subject";
                        break;
                    case "t_OfficeAutomation_Document_Feasibility":
                        summaryName = "d.OfficeAutomation_Document_Feasibility_Branch";
                        break;
                    case "t_OfficeAutomation_Document_LegalCommission":
                        summaryName = "d.OfficeAutomation_Document_LegalCommission_Subject";
                        break;
                    case "t_OfficeAutomation_Document_GeneralApply":
                        summaryName = "d.OfficeAutomation_Document_GeneralApply_Subject";
                        break;
                    case "t_OfficeAutomation_Document_ContractTerms":
                        summaryName = "d.OfficeAutomation_Document_ContractTerms_Subject";
                        break;
                    case "t_OfficeAutomation_Document_NetSign":
                        summaryName = "d.OfficeAutomation_Document_NetSign_BudingAddress";
                        break;
                    case "t_OfficeAutomation_Document_CommissionOfMonth":
                        summaryName = "(d.[OfficeAutomation_Document_CommissionOfMonth_Name] + '，' + ISNULL((SELECT dd.OfficeAutomation_Document_CommissionOfMonth_Detail_Name + '，' FROM t_OfficeAutomation_Document_CommissionOfMonth_Detail dd WHERE dd.OfficeAutomation_Document_CommissionOfMonth_Detail_MainID = d.OfficeAutomation_Document_CommissionOfMonth_ID FOR XML PATH('')),''))";
                        break;
                    case "t_OfficeAutomation_Document_Marketing":
                        summaryName = "d.OfficeAutomation_Document_Marketing_Subject";
                        break;
                    case "t_OfficeAutomation_Document_Secondment":
                        summaryName = "d.OfficeAutomation_Document_Secondment_AssetsName";
                        break;
                    case "t_OfficeAutomation_Document_CostOfActivity":
                        summaryName = "d.OfficeAutomation_Document_CostOfActivity_Subject";
                        break;
                    case "t_OfficeAutomation_Document_PunishTerms":
                        summaryName = "d.OfficeAutomation_Document_PunishTerms_Contract";
                        break;
                    case "t_OfficeAutomation_Document_ChangeNS":
                        summaryName = "d.OfficeAutomation_Document_ChangeNS_Location";
                        break;
                    case "t_OfficeAutomation_Document_SpecialCase":
                        summaryName = "d.OfficeAutomation_Document_SpecialCase_Location";
                        break;
                    case "t_OfficeAutomation_Document_SocialSecurity":
                        summaryName = "d.OfficeAutomation_Document_SocialSecurity_Results";
                        break;
                    case "t_OfficeAutomation_Document_ProjectCarAllowance":
                        summaryName = "d.OfficeAutomation_Document_ProjectCarAllowance_ApplyForName";
                        break;
                    case "t_OfficeAutomation_Document_Maintenance":
                        summaryName = "d.OfficeAutomation_Document_Maintenance_Subject";
                        break;
                    case "t_OfficeAutomation_Document_Repair":
                        summaryName = "d.OfficeAutomation_Document_Repair_ApplyID";
                        break;
                    case "t_OfficeAutomation_Document_Propaganda":
                        summaryName = "d.OfficeAutomation_Document_Propaganda_Summary";
                        break;
                    case "t_OfficeAutomation_Document_Budgetab":
                        summaryName = "d.OfficeAutomation_Document_Budgetab_Phone";
                        break;
                    case "t_OfficeAutomation_Document_EBAdjuct":
                        summaryName = "d.OfficeAutomation_Document_EBAdjuct_ApplyID";
                        break;
                    case "t_OfficeAutomation_Document_Guarantee":
                        summaryName = "d.OfficeAutomation_Document_Guarantee_Subject";
                        break;
                    case "t_OfficeAutomation_Document_SignedG":
                        summaryName = "d.OfficeAutomation_Document_SignedG_Subject";
                        break;
                    case "t_OfficeAutomation_Document_PullafewRd":
                        summaryName = "d.OfficeAutomation_Document_PullafewRd_ApplyID";
                        break;
                    case "t_OfficeAutomation_Document_PullafewTwo":
                        summaryName = "d.OfficeAutomation_Document_PullafewTwo_ApplyID";
                        break;
                    case "t_OfficeAutomation_Document_UtContract":
                        summaryName = "(d.[OfficeAutomation_Document_UtContract_Name1] + d.[OfficeAutomation_Document_UtContract_Name2])";
                        break;
                    case "t_OfficeAutomation_Document_UtNewProj":
                        summaryName = "d.[OfficeAutomation_Document_UtNewProj_Project]";
                        break;
                    case "t_OfficeAutomation_Document_ProjReDaAdd":
                        summaryName = "d.[OfficeAutomation_Document_ProjReDaAdd_ProjName]";
                        break;
                    case "t_OfficeAutomation_Document_WrongSave":
                        summaryName = "d.[OfficeAutomation_Document_WrongSave_Address]";
                        break;
                    case "t_OfficeAutomation_Document_BuyBudiData":
                        summaryName = "d.[OfficeAutomation_Document_BuyBudiData_Area]";
                        break;
                    case "t_OfficeAutomation_Document_ProjBaComm":
                        summaryName = "(d.[OfficeAutomation_Document_ProjBaComm_Building] + CONVERT(nvarchar(80),d.OfficeAutomation_Document_ProjBaComm_MoneyCount) + ISNULL(d.OfficeAutomation_Document_ProjBaComm_Remark,''))";
                        break;
                    case "t_OfficeAutomation_Document_BorrowMoney":
                        summaryName = "d.OfficeAutomation_Document_BorrowMoney_ApplyID";
                        break;
                    case "t_OfficeAutomation_Document_SpecialAdd":
                        summaryName = "d.OfficeAutomation_Document_SpecialAdd_Subject";
                        break;
                    case "t_OfficeAutomation_Document_OpenProve":
                        summaryName = "d.OfficeAutomation_Document_OpenProve_Name";
                        break;
                    case "t_OfficeAutomation_Document_PartTime":
                        summaryName = "d.OfficeAutomation_Document_PartTime_2taC";
                        break;
                    case "t_OfficeAutomation_Document_SysLogist":
                        summaryName = "(SELECT dd.OfficeAutomation_SoftSystem_Name FROM t_Dic_OfficeAutomation_SoftSystem dd WHERE dd.OfficeAutomation_SoftSystem_ID = d.OfficeAutomation_Document_SysLogist_SystemName)";
                        break;
                    case "t_OfficeAutomation_Document_SolHold":
                        summaryName = "d.OfficeAutomation_Document_SolHold_FinText";
                        break;
                    case "t_OfficeAutomation_Document_HoldCoisn":
                        summaryName = "d.OfficeAutomation_Document_HoldCoisn_Address";
                        break;
                    case "t_OfficeAutomation_Document_Record":
                        summaryName = "d.OfficeAutomation_Document_Record_Address";
                        break;
                    case "t_OfficeAutomation_Document_CallCenterFeasibility":
                        summaryName = "d.OfficeAutomation_Document_CallCenterFeasibility_Address";
                        break;
                    case "t_OfficeAutomation_Document_WYRecruit":
                        summaryName = "d.OfficeAutomation_Document_WYRecruit_Remark";
                        break;
                    case "t_OfficeAutomation_Document_Recruit":
                        summaryName = "d.OfficeAutomation_Document_Recruit_Remark";
                        break;
                    case "t_OfficeAutomation_Document_CommissionAssign":
                        summaryName = "d.OfficeAutomation_Document_CommissionAssign_ProName";
                        break;
                    case "t_OfficeAutomation_Document_HousingFundChange":
                        summaryName = "[dbo].Fun_Sum_HousingFundChangeDetailName(d.[OfficeAutomation_Document_HousingFundChange_ID])";
                        break;
                    case "t_OfficeAutomation_Document_StaffDataCheck":
                        summaryName = "d.OfficeAutomation_Document_StaffDataCheck_DifferenceSituation";
                        break;
                    case "t_OfficeAutomation_Document_ProjGeneralApply":
                        summaryName = "d.OfficeAutomation_Document_ProjGeneralApply_Subject";
                        break;
                    case "t_OfficeAutomation_Document_CPNShoot":
                        summaryName = "d.OfficeAutomation_Document_CPNShoot_ShootAddress";
                        break;
                    case "t_OfficeAutomation_Document_HousingFundAdjustment":
                        summaryName = "[dbo].Fun_Sum_HousingFundAdjustDetailName(d.[OfficeAutomation_Document_HousingFundAdjustment_ID])";
                        break;
                    case "t_OfficeAutomation_Document_Loan":
                        summaryName = "''";
                        break;
                    case "t_OfficeAutomation_Document_ProjLinkRepoData":
                        summaryName = "d.OfficeAutomation_Document_ProjLinkRepoData_ProjName";
                        break;
                }
                updateSql = string.Format(updateSql, departmentName, tableName, mainIDName, applyName, applyDate, summaryName);

                //无线固话申请表 此申请比较特殊没有Department字段
                if (tableName == "t_OfficeAutomation_Document_WirelessFixedLine")
                {
                    updateSql =
@"UPDATE t_OfficeAutomation_Main SET t_OfficeAutomation_Main.OfficeAutomation_Main_Department='{0}',t_OfficeAutomation_Main.OfficeAutomation_Main_Apply=d.{3},t_OfficeAutomation_Main.OfficeAutomation_Main_ApplyDate=d.{4},t_OfficeAutomation_Main.OfficeAutomation_Main_Summary={5}
FROM t_OfficeAutomation_Main m
LEFT JOIN {1} d ON d.{2}=m.OfficeAutomation_Main_ID
WHERE EXISTS (SELECT 1 FROM {1} WHERE {2}=m.OfficeAutomation_Main_ID)
";
                    updateSql = string.Format(updateSql, "项目部", tableName, mainIDName, applyName, applyDate, summaryName);
                }
                //T_OfficeAutomation_Document_SpecialCase 还没有被使用
                if (tableName == "T_OfficeAutomation_Document_SpecialCase")
                { continue; }

                if (tableName != "t_OfficeAutomation_Document_Loan")
                    SqlHelper.ExecuteNonQuery(conn, CommandType.Text, updateSql);
            }
        }
    }
}