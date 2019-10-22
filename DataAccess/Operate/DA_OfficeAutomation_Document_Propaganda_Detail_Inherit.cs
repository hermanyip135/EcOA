using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Propaganda_Detail_Inherit : DA_OfficeAutomation_Document_Propaganda_Detail_Operate
    {
        /// <summary>
        /// 根据资产调动表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_Propaganda_Detail_ID]"
                    + "            ,[OfficeAutomation_Document_Propaganda_Detail_MainID]"
                    + "            ,[OfficeAutomation_Document_Propaganda_Detail_No]"
                    + "            ,[OfficeAutomation_Document_Propaganda_Detail_Department]"
                    + "            ,[OfficeAutomation_Document_Propaganda_Detail_Count]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Propaganda_Detail]"
                    + "      WHERE [OfficeAutomation_Document_Propaganda_Detail_MainID]='" + id + "'"
                    + "  ORDER BY [OfficeAutomation_Document_Propaganda_Detail_No] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据资产调动表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_Propaganda_Detail_ID]"
                    + "            ,[OfficeAutomation_Document_Propaganda_Detail_MainID]"
                    + "            ,[OfficeAutomation_Document_Propaganda_Detail_No]"
                    + "            ,[OfficeAutomation_Document_Propaganda_Detail_Department]"
                    + "            ,[OfficeAutomation_Document_Propaganda_Detail_Count]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Propaganda_Detail]"
                    + "      WHERE [OfficeAutomation_Document_Propaganda_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_Propaganda_ID"
                    + "                                                                                                FROM   t_OfficeAutomation_Document_Propaganda toads"
                    + "                                                                                               WHERE  toads.OfficeAutomation_Document_Propaganda_MainID = '" + mainID + "')"
                    + "  ORDER BY [OfficeAutomation_Document_Propaganda_Detail_No] ASC";

            return RunSQL(sql);
        }
    }
}
