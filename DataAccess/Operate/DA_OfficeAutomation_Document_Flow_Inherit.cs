using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Flow_Inherit : DA_OfficeAutomation_Document_Flow_Operate
    {
        /// <summary>
        /// 通过公文流转主键获取指定的公文流转流程
        /// </summary>
        /// <param name="mainID">公文流转主表主键</param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT OfficeAutomation_Document_Flow_ID,"
                        + "              OfficeAutomation_Document_Flow_MainID,"
                        + "              OfficeAutomation_Document_Flow_Idx,"
                        + "              OfficeAutomation_Document_Flow_PositionID,"
                        + "              OfficeAutomation_Document_Flow_Position,"
                        + "              OfficeAutomation_Document_Flow_AuditName,"
                        + "              OfficeAutomation_Document_Flow_AuditCode,"
                        + "              OfficeAutomation_Document_Flow_AllowEdit"
                        + "    FROM t_OfficeAutomation_Document_Flow"
                        + "  WHERE OfficeAutomation_Document_Flow_MainID = ("
                        + "                SELECT OfficeAutomation_DocumentID"
                        + "                 FROM t_OfficeAutomation_Main"
                        + "                WHERE OfficeAutomation_Main_ID = '" + mainID + "' ) "
                        + "  ORDER BY OfficeAutomation_Document_Flow_Idx ASC";
            return RunSQL(sql);
        }

        /// <summary>
        /// 通过公文名称表主键获取指定的公文流转流程
        /// </summary>
        /// <param name="documentID">公文名称表主键</param>
        /// <returns></returns>
        public DataSet SelectByDocumentID(int documentID)
        {
            string sql = "SELECT OfficeAutomation_Document_Flow_ID,"
                        + "              OfficeAutomation_Document_Flow_MainID,"
                        + "              OfficeAutomation_Document_Flow_Idx,"
                        + "              OfficeAutomation_Document_Flow_PositionID,"
                        + "              OfficeAutomation_Document_Flow_Position,"
                        + "              OfficeAutomation_Document_Flow_AuditName,"
                        + "              OfficeAutomation_Document_Flow_AuditCode,"
                        + "              OfficeAutomation_Document_Flow_AllowEdit"
                        + "    FROM t_OfficeAutomation_Document_Flow"
                        + "  WHERE OfficeAutomation_Document_Flow_MainID = " + documentID
                        + "  ORDER BY OfficeAutomation_Document_Flow_Idx ASC ";
            return RunSQL(sql);
        }

        /// <summary>
        /// 通过公文名称获取指定的公文流转流程中固定审批人的项的IDx
        /// </summary>
        /// <param name="documentName">公文名称</param>
        /// <returns></returns>
        public DataSet SelectIDxByDocumentName(string documentName)
        {
            string sql = "SELECT [OfficeAutomation_Document_Flow_Idx] AS idx"
                         + " FROM   [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Flow]"
                         + " WHERE  OfficeAutomation_Document_Flow_MainID = (SELECT [OfficeAutomation_Document_ID]"
                         + "                                                 FROM   [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_Document]"
                         + "                                                 WHERE  OfficeAutomation_Document_Name ='" + documentName + "')"
                         + "              AND OfficeAutomation_Document_Flow_AuditName IS NOT NULL"
                         + " ORDER  BY OfficeAutomation_Document_Flow_Idx ASC ";
             return RunSQL(sql);
        }
    }
}
