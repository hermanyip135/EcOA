using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Secondment_Inherit : DA_OfficeAutomation_Document_Secondment_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Secondment_ID]"
                           + "           ,[OfficeAutomation_Document_Secondment_MainID]"
                           + "           ,[OfficeAutomation_Document_Secondment_Apply]"
                           + "           ,[OfficeAutomation_Document_Secondment_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_Secondment_ApplyID]"
                           + "           ,[OfficeAutomation_Document_Secondment_Department]"
                           + "           ,[OfficeAutomation_Document_Secondment_BorrowDepartment]"
                           + "           ,[OfficeAutomation_Document_Secondment_InDptm]"
                           + "           ,[OfficeAutomation_Document_Secondment_InDptmContact]"
                           + "           ,[OfficeAutomation_Document_Secondment_AssetsName]"
                           + "           ,[OfficeAutomation_Document_Secondment_TheMessage]"
                           + "           ,[OfficeAutomation_Document_Secondment_Number]"
                           + "           ,[OfficeAutomation_Document_Secondment_BorrowDate]"
                           + "           ,[OfficeAutomation_Document_Secondment_ExpectReturnDate]"
                           + "           ,[OfficeAutomation_Document_Secondment_SalesDate]"
                           + "           ,[OfficeAutomation_Document_Secondment_Sales]"
                           + "           ,[OfficeAutomation_Document_Secondment_ReturnDate]"
                           + "           ,[OfficeAutomation_Document_Secondment_Returner]"
                           + "           ,[OfficeAutomation_Document_Secondment_Reason]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Secondment] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Secondment_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Secondment_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Secondment_ID]"
                           + "           ,[OfficeAutomation_Document_Secondment_MainID]"
                           + "           ,[OfficeAutomation_Document_Secondment_Apply]"
                           + "           ,[OfficeAutomation_Document_Secondment_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_Secondment_ApplyID]"
                           + "           ,[OfficeAutomation_Document_Secondment_Department]"
                           + "           ,[OfficeAutomation_Document_Secondment_BorrowDepartment]"
                           + "           ,[OfficeAutomation_Document_Secondment_InDptm]"
                           + "           ,[OfficeAutomation_Document_Secondment_InDptmContact]"
                           + "           ,[OfficeAutomation_Document_Secondment_AssetsName]"
                           + "           ,[OfficeAutomation_Document_Secondment_TheMessage]"
                           + "           ,[OfficeAutomation_Document_Secondment_Number]"
                           + "           ,[OfficeAutomation_Document_Secondment_BorrowDate]"
                           + "           ,[OfficeAutomation_Document_Secondment_ExpectReturnDate]"
                           + "           ,[OfficeAutomation_Document_Secondment_SalesDate]"
                           + "           ,[OfficeAutomation_Document_Secondment_Sales]"
                           + "           ,[OfficeAutomation_Document_Secondment_ReturnDate]"
                           + "           ,[OfficeAutomation_Document_Secondment_Returner]"
                           + "           ,[OfficeAutomation_Document_Secondment_Reason]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Secondment] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Secondment_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Secondment_ID='" + ID + "'";

            return RunSQL(sql);
        }
    }
}
