using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ITTest_Inherit : DA_OfficeAutomation_Document_ITTest_Operate
    {

        /// <summary>
        /// 通过MainID查询软件系统测试需求申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_ITTest_ID]"
                           + "           ,[OfficeAutomation_Document_ITTest_MainID]"
                           + "           ,[OfficeAutomation_Document_ITTest_Apply]"
                           + "           ,[OfficeAutomation_Document_ITTest_HopeDate]"
                           + "           ,[OfficeAutomation_Document_ITTest_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_ITTest_ReqContent]"
                           + "           ,[OfficeAutomation_Document_ITTest_ReqReply]"
                           + "           ,[OfficeAutomation_Document_ITTest_ReqReplyDate]"
                           + "           ,[OfficeAutomation_Document_ITTest_SystemName]"
                           + "           ,[OfficeAutomation_Document_ITTest_DepartmentID]"
                           + "           ,[officeAutomation_Document_ITTest_Department]"
                           + "           ,[OfficeAutomation_Document_ITTest_Receiver]"
                           + "          ,toam.OfficeAutomation_SerialNumber"
                           + "          ,tdoad.OfficeAutomation_Document_Name"
                           + "          ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITTest] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ITTest_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_ITTest_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        public bool ReqReplyITTest(string reqReply,string mainId)
        {
            string sql = string.Format("update [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITTest] set  OfficeAutomation_Document_ITTest_ReqReply='{0}' where OfficeAutomation_Document_ITTest_MainID='{1}' ", reqReply, mainId);
            return RunNoneSQL(sql);
        }

    }
}
