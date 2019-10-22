using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Repair_Detail_Inherit : DA_OfficeAutomation_Document_Repair_Detail_Operate
    {
        /// <summary>
        /// 根据资产调动表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_Repair_Detail_ID]"
                    + "            ,[OfficeAutomation_Document_Repair_Detail_MainID]"
                    + "            ,[OfficeAutomation_Document_Repair_Detail_No]"
                    + "            ,[OfficeAutomation_Document_Repair_Detail_Pname]"
                    + "            ,[OfficeAutomation_Document_Repair_Detail_Brand]"
                    + "            ,[OfficeAutomation_Document_Repair_Detail_Unit]"
                    + "            ,[OfficeAutomation_Document_Repair_Detail_Price]"
                    + "            ,[OfficeAutomation_Document_Repair_Detail_Num]"
                    + "            ,[OfficeAutomation_Document_Repair_Detail_Money]"
                    + "            ,[OfficeAutomation_Document_Repair_Detail_Summary]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Repair_Detail]"
                    + "      WHERE [OfficeAutomation_Document_Repair_Detail_MainID]='" + id + "'"
                    + "  ORDER BY [OfficeAutomation_Document_Repair_Detail_No] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据资产调动表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_Repair_Detail_ID]"
                    + "            ,[OfficeAutomation_Document_Repair_Detail_MainID]"
                    + "            ,[OfficeAutomation_Document_Repair_Detail_No]"
                    + "            ,[OfficeAutomation_Document_Repair_Detail_Pname]"
                    + "            ,[OfficeAutomation_Document_Repair_Detail_Brand]"
                    + "            ,[OfficeAutomation_Document_Repair_Detail_Unit]"
                    + "            ,[OfficeAutomation_Document_Repair_Detail_Price]"
                    + "            ,[OfficeAutomation_Document_Repair_Detail_Num]"
                    + "            ,[OfficeAutomation_Document_Repair_Detail_Money]"
                    + "            ,[OfficeAutomation_Document_Repair_Detail_Summary]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Repair_Detail]"
                    + "      WHERE [OfficeAutomation_Document_Repair_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_Repair_ID"
                    + "                                                                                                FROM   t_OfficeAutomation_Document_Repair toads"
                    + "                                                                                               WHERE  toads.OfficeAutomation_Document_Repair_MainID = '" + mainID + "')"
                    + "  ORDER BY [OfficeAutomation_Document_Repair_Detail_No] ASC";

            return RunSQL(sql);
        }
    }
}
