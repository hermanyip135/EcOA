using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_WirelessFixedLine_Detail_Inherit : DA_OfficeAutomation_Document_WirelessFixedLine_Detail_Operate
    {
        /// <summary>
        /// 根据主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_WirelessFixedLine_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_WirelessFixedLine_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_WirelessFixedLine_Detail_Division]"
                          + "            ,[OfficeAutomation_Document_WirelessFixedLine_Detail_Name]"
                          + "            ,[OfficeAutomation_Document_WirelessFixedLine_Detail_Number]"
                          + "            ,[OfficeAutomation_Document_WirelessFixedLine_Detail_Time]"
                          + "            ,[OfficeAutomation_Document_WirelessFixedLine_Detail_EndTime]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_WirelessFixedLine_Detail]"
                          + " WHERE [OfficeAutomation_Document_WirelessFixedLine_Detail_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_WirelessFixedLine_Detail_Time] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_WirelessFixedLine_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_WirelessFixedLine_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_WirelessFixedLine_Detail_Division]"
                          + "            ,[OfficeAutomation_Document_WirelessFixedLine_Detail_Name]"
                          + "            ,[OfficeAutomation_Document_WirelessFixedLine_Detail_Number]"
                          + "            ,[OfficeAutomation_Document_WirelessFixedLine_Detail_Time]"
                          + "            ,[OfficeAutomation_Document_WirelessFixedLine_Detail_EndTime]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_WirelessFixedLine_Detail]"
                          + " WHERE [OfficeAutomation_Document_WirelessFixedLine_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_WirelessFixedLine_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_WirelessFixedLine toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_WirelessFixedLine_MainID = '" + mainID + "')"
                          + " ORDER BY [OfficeAutomation_Document_WirelessFixedLine_Detail_Time] ASC";

            return RunSQL(sql);
        }
    }
}
