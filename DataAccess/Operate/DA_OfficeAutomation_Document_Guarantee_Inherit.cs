using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Guarantee_Inherit : DA_OfficeAutomation_Document_Guarantee_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Guarantee_ID]"
                           + "           ,[OfficeAutomation_Document_Guarantee_MainID]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Apply]"
                           + "           ,[OfficeAutomation_Document_Guarantee_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_Guarantee_ApplyID]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Department]"
                           + "           ,[OfficeAutomation_Document_Guarantee_ReceiveDP]"
                           + "           ,[OfficeAutomation_Document_Guarantee_CCDepartment]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Telephone]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Fax]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Subject]"
                           + "           ,[OfficeAutomation_Document_Guarantee_CaseNo]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Dealer]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Address]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Owner]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Buyer]"
                           + "           ,[OfficeAutomation_Document_Guarantee_LoanBank]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Cmoney]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Lmoney]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Dmoney]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Reason]"
                           + "           ,[OfficeAutomation_Document_Guarantee_CMPaier]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Ccoast]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Process]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Period]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Guarantee] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Guarantee_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Guarantee_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Guarantee_ID]"
                           + "           ,[OfficeAutomation_Document_Guarantee_MainID]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Apply]"
                           + "           ,[OfficeAutomation_Document_Guarantee_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_Guarantee_ApplyID]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Department]"
                           + "           ,[OfficeAutomation_Document_Guarantee_ReceiveDP]"
                           + "           ,[OfficeAutomation_Document_Guarantee_CCDepartment]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Telephone]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Fax]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Subject]"
                           + "           ,[OfficeAutomation_Document_Guarantee_CaseNo]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Dealer]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Address]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Owner]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Buyer]"
                           + "           ,[OfficeAutomation_Document_Guarantee_LoanBank]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Cmoney]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Lmoney]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Dmoney]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Reason]"
                           + "           ,[OfficeAutomation_Document_Guarantee_CMPaier]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Ccoast]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Process]"
                           + "           ,[OfficeAutomation_Document_Guarantee_Period]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Guarantee] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Guarantee_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Guarantee_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
