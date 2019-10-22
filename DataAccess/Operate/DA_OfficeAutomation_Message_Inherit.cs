using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Message_Inherit : DA_OfficeAutomation_Message_Operate
    {
        public DataSet SelectUnSendMessage()
        {
            string sql = "SELECT [OfficeAutomation_Message_ID]"
                       + "              ,[OfficeAutomation_Message_Title]"
                       + "              ,[OfficeAutomation_Message_Body]"
                       + "              ,[OfficeAutomation_Message_MessBody]"
                       + "              ,[OfficeAutomation_Message_ToEmail]"
                       + "              ,[OfficeAutomation_Message_HtmlFlag]"
                       + "              ,[OfficeAutomation_Message_PostFlag]"
                       + "              ,[OfficeAutomation_Message_PostDate]"
                       + "              ,[OfficeAutomation_Message_CreateDate]"
                       + "     FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Message]"
                       + "   WHERE [OfficeAutomation_Message_PostFlag] = 0 AND [OfficeAutomation_Message_ToEmail] !=''"
                       + "   and OfficeAutomation_Message_ToEmail like '%@centaline.com.cn'";

            return RunSQL(sql);
        }

        public void DeleteUnSendMessage()
        {
            string sql = "DELETE FROM [t_OfficeAutomation_Message] WHERE [OfficeAutomation_Message_Title]='审批已完成' and [OfficeAutomation_Message_ToEmail]='huangxm@centaline.com.cn' and [OfficeAutomation_Message_PostFlag]=0 ";
            RunSQL(sql);
        }


        /// <summary>
        /// 当发送成功时更新发送标识，及发送日期
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateWhenPostSuccess(string id)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Message]"
                          + "       SET [OfficeAutomation_Message_PostFlag] = 'True'"
                          + "             ,[OfficeAutomation_Message_PostDate] = '" + DateTime.Now + "'"
                          + "  WHERE [OfficeAutomation_Message_ID] = " + id;

            return RunNoneSQL(sql);
        }



        public DataSet SelectMainNotBackUp()
        {
            string sql = "SELECT [OfficeAutomation_Main_ID]"
                       + "              ,[OfficeAutomation_SerialNumber]"
                       + "              ,[OfficeAutomation_DocumentID]"
                       + "              ,[OfficeAutomation_Main_FlowStateID]"
                       + "              ,[OfficeAutomation_Main_AuditorIDsSum]"
                       + "              ,[OfficeAutomation_Main_AuditorNamesSum]"
                       + "              ,[OfficeAutomation_Main_IsBackUp]"
                       + "     FROM DB_EcOfficeAutomation.[dbo].[t_OfficeAutomation_Main]"
                       + "     WHERE OfficeAutomation_Main_FlowStateID = 3 AND"
                       + "     (OfficeAutomation_Main_IsBackUp = 0 "
                       + "     OR OfficeAutomation_Main_IsBackUp IS NULL)";
            return RunSQL(sql);
        }

        public bool UpdateMainBackUp(Guid id)
        {
            string sql = "UPDATE DB_EcOfficeAutomation.[dbo].[t_OfficeAutomation_Main]"
                          + "       SET [OfficeAutomation_Main_IsBackUp] = 1"
                          + "  WHERE [OfficeAutomation_Main_ID] = '" + id + "'";

            return RunNoneSQL(sql);
        }



        public DataSet SelectAnotherTableBackUp(Guid id)
        {
            string sql = "SELECT [OfficeAutomation_Document_ID]"
                       + "              ,[OfficeAutomation_Document_Name]"
                       + "              ,[OfficeAutomation_Document_TableName]"
                       + "              ,[OfficeAutomation_Document_DocumentTypeID]"
                       + "              ,[OfficeAutomation_Document_OrderID]"
                       + "     FROM DB_EcOfficeAutomation.[dbo].[t_Dic_OfficeAutomation_Document] WHERE OfficeAutomation_Document_ID = ("
                       + "     SELECT OfficeAutomation_DocumentID FROM DB_EcOfficeAutomation.[dbo].[t_OfficeAutomation_Main]"
                       + "     WHERE t_OfficeAutomation_Main.OfficeAutomation_Main_ID = '" + id + "')";
            return RunSQL(sql);
        }

        public bool InsertAnotherTableBackUp(string tname, Guid id)
        {
            string stm = tname.Remove(0, 28);
            string sql = "INSERT INTO DB_ECOA_BACK.[dbo].[" + tname + "]"
                          + "  SELECT * FROM " + tname
                          + "  WHERE OfficeAutomation_Document_" + stm + "_MainID = '" + id + "'";

            return RunNoneSQL(sql);
        }



        public DataSet SelectTableByMainID(string tname, Guid id)
        {
            string stm = tname.Remove(0, 28);
            string sql = "SELECT * FROM " + tname
                       + "  WHERE OfficeAutomation_Document_" + stm + "_MainID = '" + id + "'";
            return RunSQL(sql);
        }

        public bool InsertDetailsBUp(string details, string tname, Guid id)
        {
            string stm = tname.Remove(0, 28);
            string sql = "INSERT INTO DB_ECOA_BACK.[dbo].[" + tname + details + "]"
                          + "  SELECT * FROM " + tname + details
                          + "  WHERE OfficeAutomation_Document_" + stm + details + "_MainID = '" + id + "'";

            return RunNoneSQL(sql);
        }

        public DataSet SelectMessageOverD1() //M_20150619
        {
            //string sql = "SELECT TOP 1 MAX(f.OfficeAutomation_Flow_AuditDate)"
            //              + "  ,m.OfficeAutomation_SerialNumber SerialNumber"
            //              + "  ,m.OfficeAutomation_Main_Creater  Aut"
            //              + "  ,m.OfficeAutomation_Main_CrTime"
            //              + "  FROM t_OfficeAutomation_Main m"
            //              + "  LEFT JOIN t_OfficeAutomation_Flow f"
            //              + "  ON m.OfficeAutomation_Main_ID = f.OfficeAutomation_Flow_MainID"
            //              + "  WHERE m.OfficeAutomation_Main_FlowStateID = 2"
            //              + "  AND f.OfficeAutomation_Flow_Audit = 1"
            //              + "  AND m.OfficeAutomation_Main_CrTime IS NOT NULL"
            //              + "  AND f.OfficeAutomation_Flow_EmployeeID != '0001'"
            //              + "  GROUP BY f.OfficeAutomation_Flow_MainID"
            //              + "  ,m.OfficeAutomation_SerialNumber "
            //              + "  ,m.OfficeAutomation_Main_Creater "
            //              + "  ,m.OfficeAutomation_Main_CrTime "
            //              + "  ,f.OfficeAutomation_Flow_AuditDate"
            //              + "  HAVING DATEDIFF(hh,MAX(f.OfficeAutomation_Flow_AuditDate),GETDATE()) > 72"
            //              + "  ORDER BY f.OfficeAutomation_Flow_AuditDate DESC";

            string sql = "SELECT * FROM [dbo].[AduitDateOver3Days]()";

            return RunSQL(sql);
        }
        public DataSet SelectMessageOverD2() //M_20150619
        {
            string sql = "SELECT OfficeAutomation_Main_Creater Aut"
                          + "  ,OfficeAutomation_Main_CrTime"
                          + "  ,OfficeAutomation_SerialNumber SerialNumber"
                          + "  FROM t_OfficeAutomation_Main"
                          + "  WHERE DATEDIFF(hh,OfficeAutomation_Main_CrTime,GETDATE()) > 72"
                          + "  AND OfficeAutomation_Main_CrTime IS NOT NULL"
                          + "  AND OfficeAutomation_Main_FlowStateID = 1 AND OfficeAutomation_Main_IsDelete=0";

            return RunSQL(sql);
        }

        public bool UpdateMessageOverD(string s) //M_20150619
        {
            string sql = "UPDATE t_OfficeAutomation_Main"
                          + "  SET OfficeAutomation_Main_CrTime = null"
                          + "  WHERE OfficeAutomation_SerialNumber = '" + s + "'";

            return RunNoneSQL(sql);
        }

        public bool InsertFlowsBUp(Guid id)
        {
            string sql = "INSERT INTO DB_ECOA_BACK.[dbo].[t_OfficeAutomation_Flow]"
                          + "  SELECT [OfficeAutomation_Flow_ID]"
                          + "              ,[OfficeAutomation_Flow_MainID]"
                          + "              ,[OfficeAutomation_Flow_Employee]"
                          + "              ,[OfficeAutomation_Flow_EmployeeID]"
                          + "              ,[OfficeAutomation_Flow_Idx]"
                          + "              ,[OfficeAutomation_Flow_Audit]"
                          + "              ,[OfficeAutomation_Flow_Suggestion]"
                          + "              ,[OfficeAutomation_Flow_AuditDate]"
                          + "              ,[OfficeAutomation_Flow_Auditor]"
                          + "              ,[OfficeAutomation_Flow_AuditorID]"
                          + "              ,[OfficeAutomation_Flow_IsAgree]"
                          + "     FROM DB_EcOfficeAutomation.[dbo].[t_OfficeAutomation_Flow]"
                          + "  WHERE OfficeAutomation_Flow_MainID = '" + id + "'";

            return RunNoneSQL(sql);
        }

        public bool InsertDeletedFlowsBUp(Guid id)
        {
            string sql = "INSERT INTO DB_ECOA_BACK.[dbo].[t_OfficeAutomation_DeletedFlow]"
                          + "  SELECT [OfficeAutomation_DeletedFlow_ID]"
                          + "              ,[OfficeAutomation_DeletedFlow_MainID]"
                          + "              ,[OfficeAutomation_DeletedFlow_Employee]"
                          + "              ,[OfficeAutomation_DeletedFlow_EmployeeID]"
                          + "              ,[OfficeAutomation_DeletedFlow_Idx]"
                          + "              ,[OfficeAutomation_DeletedFlow_Audit]"
                          + "              ,[OfficeAutomation_DeletedFlow_Suggestion]"
                          + "              ,[OfficeAutomation_DeletedFlow_AuditDate]"
                          + "              ,[OfficeAutomation_DeletedFlow_Auditor]"
                          + "              ,[OfficeAutomation_DeletedFlow_AuditorID]"
                          + "              ,[OfficeAutomation_DeletedFlow_IsAgree]"
                          + "     FROM DB_EcOfficeAutomation.[dbo].[t_OfficeAutomation_DeletedFlow]"
                          + "  WHERE OfficeAutomation_DeletedFlow_MainID = '" + id + "'";

            return RunNoneSQL(sql);
        }

        public bool InsertAttachBUp(Guid id)
        {
            string sql = "INSERT INTO DB_ECOA_BACK.[dbo].[t_OfficeAutomation_Attach]"
                          + "  SELECT [OfficeAutomation_Attach_ID]"
                          + "              ,[OfficeAutomation_Attach_MainID]"
                          + "              ,[OfficeAutomation_Attach_Name]"
                          + "              ,[OfficeAutomation_Attach_Path]"
                          + "     FROM DB_EcOfficeAutomation.[dbo].[t_OfficeAutomation_Attach]"
                          + "  WHERE OfficeAutomation_Attach_MainID = '" + id + "'";

            return RunNoneSQL(sql);
        }

        public bool InsertAddFlows(Guid id)
        {
            string sql = "INSERT INTO DB_ECOA_BACK.[dbo].[t_OfficeAutomation_Document_GeneralApply_Detail]"
                       + "SELECT [OfficeAutomation_Document_GeneralApply_Detail_ID]"
                       + "              ,[OfficeAutomation_Document_GeneralApply_Detail_MainID]"
                       + "              ,[OfficeAutomation_Document_GeneralApply_Detail_Num]"
                       + "              ,[OfficeAutomation_Document_GeneralApply_Detail_Department]"
                       + "              ,[OfficeAutomation_Document_GeneralApply_Detail_Branch]"
                       + "              ,[OfficeAutomation_Document_GeneralApply_Detail_Cmodel]"
                       + "              ,[OfficeAutomation_Document_GeneralApply_Detail_IsOpen]"
                       + "              ,[OfficeAutomation_Document_GeneralApply_Detail_Sign]"
                       + "     FROM DB_EcOfficeAutomation.[dbo].[t_OfficeAutomation_Document_GeneralApply_Detail]"
                       + "     WHERE OfficeAutomation_Document_GeneralApply_Detail_MainID = '" + id + "'";
            return RunNoneSQL(sql);
        }






        public DataSet SelectMainByMainID()
        {
            string sql = "SELECT [OfficeAutomation_Main_ID]"
                       + "              ,[OfficeAutomation_SerialNumber]"
                       + "              ,[OfficeAutomation_DocumentID]"
                       + "              ,[OfficeAutomation_Main_FlowStateID]"
                       + "              ,[OfficeAutomation_Main_AuditorIDsSum]"
                       + "              ,[OfficeAutomation_Main_AuditorNamesSum]"
                       + "              ,[OfficeAutomation_Main_IsBackUp]"
                       + "     FROM DB_ECOA_BACK.[dbo].[t_OfficeAutomation_Main]"
                       + "     WHERE OfficeAutomation_Main_FlowStateID = 3 AND"
                       + "     (OfficeAutomation_Main_IsBackUp = 0 "
                       + "     OR OfficeAutomation_Main_IsBackUp IS NULL)";
            return RunSQL(sql);
        }
        public bool DeleteMainBup(Guid id)
        {
            string sql = "DELETE FROM DB_ECOA_BACK.[dbo].[t_OfficeAutomation_Main]"
                          + "  WHERE OfficeAutomation_Main_ID = '" + id + "'";
            return RunNoneSQL(sql);
        }
        public bool DeleteFlowsBup(Guid id)
        {
            string sql = "DELETE FROM DB_ECOA_BACK.[dbo].[t_OfficeAutomation_Flow]"
                          + "  WHERE OfficeAutomation_Flow_MainID = '" + id + "'";
            return RunNoneSQL(sql);
        }
        public bool DeleteDeletedFlowsBup(Guid id)
        {
            string sql = "DELETE FROM DB_ECOA_BACK.[dbo].[t_OfficeAutomation_DeletedFlow]"
                          + "  WHERE OfficeAutomation_DeletedFlow_MainID = '" + id + "'";
            return RunNoneSQL(sql);
        }
        public bool DeleteAttachBup(Guid id)
        {
            string sql = "DELETE FROM DB_ECOA_BACK.[dbo].[t_OfficeAutomation_Attach]"
                          + "  WHERE OfficeAutomation_Attach_MainID = '" + id + "'";
            return RunNoneSQL(sql);
        }
        public bool DeleteTableBUp(string tname, Guid id)
        {
            string stm = tname.Remove(0, 28);
            string sql = "DELETE FROM DB_ECOA_BACK.[dbo].[" + tname + "]"
                          + "  WHERE OfficeAutomation_Document_" + stm + "_MainID = '" + id + "'";
            return RunNoneSQL(sql);
        }
        public bool DeleteDetailsBUp(string details, string tname, Guid id)
        {
            string stm = tname.Remove(0, 28);
            string sql = "DELETE FROM DB_ECOA_BACK.[dbo].[" + tname + details + "]"
                          + "  WHERE OfficeAutomation_Document_" + stm + details + "_MainID = '" + id + "'";
            return RunNoneSQL(sql);
        }

        //public bool InsertMainBackUp(string id, string SerialNumber, string DocumentID, string FlowStateID, string AuditorIDsSum, string AuditorNamesSum, string IsBackUp)
        //{
        //    string sql = "INSERT INTO DB_ECOA_BACK.[dbo].[t_OfficeAutomation_Main]"
        //                  + "  values('" + id + "','" + SerialNumber + "','" + DocumentID + "','" + FlowStateID + "','" + AuditorIDsSum + "','" + AuditorNamesSum + "','" + IsBackUp + "')";
        //    return RunNoneSQL(sql);
        //}
    }
}
