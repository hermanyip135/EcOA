using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_UtNewProj_Detail_Inherit : DA_OfficeAutomation_Document_UtNewProj_Detail_Operate
    {
        /// <summary>
        /// 根据资产调动表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id, int n)
        {
            string sql = "SELECT [OfficeAutomation_Document_UtNewProj_Detail_ID]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_MainID]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_CommType]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_SetNumberStart]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_SetNumberEnd]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_MoneyStart]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_MoneyEnd]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_Scale]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_PublishedScale]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_OwnerCommFloatKind]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_OrderBy]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UtNewProj_Detail]"
                    + "      WHERE [OfficeAutomation_Document_UtNewProj_Detail_MainID]='" + id + "'"
                    + "      AND [OfficeAutomation_Document_UtNewProj_Detail_CommType] = " + n
                    + "  ORDER BY [OfficeAutomation_Document_UtNewProj_Detail_OrderBy] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据资产调动表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_UtNewProj_Detail_ID]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_MainID]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_CommType]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_SetNumberStart]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_SetNumberEnd]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_MoneyStart]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_MoneyEnd]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_Scale]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_PublishedScale]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_OwnerCommFloatKind]"
                    + "            ,[OfficeAutomation_Document_UtNewProj_Detail_OrderBy]"
                    + "        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UtNewProj_Detail]"
                    + "      WHERE [OfficeAutomation_Document_UtNewProj_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_UtNewProj_ID"
                    + "                                                                                                FROM   t_OfficeAutomation_Document_UtNewProj toads"
                    + "                                                                                               WHERE  toads.OfficeAutomation_Document_UtNewProj_MainID = '" + mainID + "')"
                    + "  ORDER BY [OfficeAutomation_Document_UtNewProj_Detail_OrderBy] ASC";

            return RunSQL(sql);
        }
    }
}
