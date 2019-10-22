using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SpecialCase_Inherit : DA_OfficeAutomation_Document_SpecialCase_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_SpecialCase_ID]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_MainID]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Apply]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_ApplyID]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Department]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_BranchNo]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Phone]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_FollowDepartment]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_FollowSomebody]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Location]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Master]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Buyer]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Loan]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_QuickPut]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_GuaranteeCompany]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_PayWay]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_ApplyNo]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_TimeoutApply]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_ForPeople]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_AutoHandle]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_CaseRemark]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_HousingTransactions]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_DealWithProgress]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Midway]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_PutUp]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_AnotherPutUp]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_4PointGuaranteeCompany]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_CompanyEarnings]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_EarningsAmount]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_TheKindOfFormalities]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Certificate]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_NotarialDeed]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_CommissionedPersonnel]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Clause]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_NotNeat]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_JieFeeDate]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_credit]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Another]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Situation]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_BorrowDate]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_BorrowS]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_ReturnDate]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SpecialCase] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SpecialCase_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_SpecialCase_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_SpecialCase_ID]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_MainID]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Apply]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_ApplyID]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Department]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_BranchNo]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Phone]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_FollowDepartment]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_FollowSomebody]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Location]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Master]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Buyer]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Loan]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_QuickPut]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_GuaranteeCompany]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_PayWay]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_ApplyNo]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_TimeoutApply]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_ForPeople]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_AutoHandle]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_CaseRemark]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_HousingTransactions]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_DealWithProgress]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Midway]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_PutUp]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_AnotherPutUp]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_4PointGuaranteeCompany]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_CompanyEarnings]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_EarningsAmount]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_TheKindOfFormalities]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Certificate]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_NotarialDeed]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_CommissionedPersonnel]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Clause]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_NotNeat]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_JieFeeDate]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_credit]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Another]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_Situation]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_BorrowDate]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_BorrowS]"
                           + "           ,[OfficeAutomation_Document_SpecialCase_ReturnDate]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SpecialCase] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SpecialCase_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_SpecialCase_ID='" + ID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过业务部门名称查找相关信息
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectBusinessDpm(string dpm)
        {
            string sql = "SELECT * FROM [gzs-hrdb01].[AIS20050623105602].[dbo].[v_Report_WorkInfo] WHERE UnitName = '" + dpm + "' and EmployeeName not like '%(财务用)%'";
            return RunSQL(sql);
        }
    }
}
