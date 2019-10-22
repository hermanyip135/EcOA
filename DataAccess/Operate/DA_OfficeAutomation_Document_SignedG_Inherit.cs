using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SignedG_Inherit : DA_OfficeAutomation_Document_SignedG_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_SignedG_ID]"
                           + "           ,[OfficeAutomation_Document_SignedG_MainID]"
                           + "           ,[OfficeAutomation_Document_SignedG_Apply]"
                           + "           ,[OfficeAutomation_Document_SignedG_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_SignedG_ApplyID]"
                           + "           ,[OfficeAutomation_Document_SignedG_Department]"
                           + "           ,[OfficeAutomation_Document_SignedG_ReceiveDP]"
                           + "           ,[OfficeAutomation_Document_SignedG_CCDepartment]"
                           + "           ,[OfficeAutomation_Document_SignedG_Telephone]"
                           + "           ,[OfficeAutomation_Document_SignedG_Fax]"
                           + "           ,[OfficeAutomation_Document_SignedG_Subject]"
                           + "           ,[OfficeAutomation_Document_SignedG_CaseNo]"
                           + "           ,[OfficeAutomation_Document_SignedG_Dealer]"
                           + "           ,[OfficeAutomation_Document_SignedG_Address]"
                           + "           ,[OfficeAutomation_Document_SignedG_Owner]"
                           + "           ,[OfficeAutomation_Document_SignedG_Buyer]"
                           + "           ,[OfficeAutomation_Document_SignedG_LoanBank]"
                           + "           ,[OfficeAutomation_Document_SignedG_Lmoney]"
                           + "           ,[OfficeAutomation_Document_SignedG_Dmoney]"
                           + "           ,[OfficeAutomation_Document_SignedG_Cmoney]"
                           + "           ,[OfficeAutomation_Document_SignedG_Reason]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SignedG] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SignedG_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_SignedG_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_SignedG_ID]"
                           + "           ,[OfficeAutomation_Document_SignedG_MainID]"
                           + "           ,[OfficeAutomation_Document_SignedG_Apply]"
                           + "           ,[OfficeAutomation_Document_SignedG_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_SignedG_ApplyID]"
                           + "           ,[OfficeAutomation_Document_SignedG_Department]"
                           + "           ,[OfficeAutomation_Document_SignedG_ReceiveDP]"
                           + "           ,[OfficeAutomation_Document_SignedG_CCDepartment]"
                           + "           ,[OfficeAutomation_Document_SignedG_Telephone]"
                           + "           ,[OfficeAutomation_Document_SignedG_Fax]"
                           + "           ,[OfficeAutomation_Document_SignedG_Subject]"
                           + "           ,[OfficeAutomation_Document_SignedG_CaseNo]"
                           + "           ,[OfficeAutomation_Document_SignedG_Dealer]"
                           + "           ,[OfficeAutomation_Document_SignedG_Address]"
                           + "           ,[OfficeAutomation_Document_SignedG_Owner]"
                           + "           ,[OfficeAutomation_Document_SignedG_Buyer]"
                           + "           ,[OfficeAutomation_Document_SignedG_LoanBank]"
                           + "           ,[OfficeAutomation_Document_SignedG_Lmoney]"
                           + "           ,[OfficeAutomation_Document_SignedG_Dmoney]"
                           + "           ,[OfficeAutomation_Document_SignedG_Cmoney]"
                           + "           ,[OfficeAutomation_Document_SignedG_Reason]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SignedG] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SignedG_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_SignedG_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
