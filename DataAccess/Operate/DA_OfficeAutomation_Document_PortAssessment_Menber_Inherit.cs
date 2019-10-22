using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_PortAssessment_Menber_Inherit : DA_OfficeAutomation_Document_PortAssessment_Menber_Operate
    {
        /// <summary>
        /// 根据获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_PortAssessment_Menber_ID]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_MainID]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridAx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridBx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridCx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridDx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridEx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridFx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridGx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridHx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridIx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridJx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridKx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridLx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridMx]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PortAssessment_Menber]"
                          + " WHERE [OfficeAutomation_Document_PortAssessment_Menber_MainID]='" + id + "'"
                          + " ORDER BY CAST(OfficeAutomation_Document_PortAssessment_Menber_GridKx as DATETIME) DESC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_PortAssessment_Menber_ID]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_MainID]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridAx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridBx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridCx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridDx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridEx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridFx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridGx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridHx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridIx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridJx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridKx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridLx]"
                          + "            ,[OfficeAutomation_Document_PortAssessment_Menber_GridMx]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PortAssessment_Menber]"
                          + " WHERE [OfficeAutomation_Document_PortAssessment_Menber_MainID]= (SELECT toads.OfficeAutomation_Document_PortAssessment_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_PortAssessment toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_PortAssessment_MainID = '" + mainID + "')"
                          + " ORDER BY CAST(OfficeAutomation_Document_PortAssessment_Menber_GridKx as DATETIME) DESC";

            return RunSQL(sql);
        }
    }
}
