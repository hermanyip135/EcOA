using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Feasibility_Menber_Inherit : DA_OfficeAutomation_Document_Feasibility_Menber_Operate
    {
        /// <summary>
        /// 获取人员架构1
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_Feasibility_Menber_ID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_MainID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_SeniorDirector]"
                          //+ "            ,[OfficeAutomation_Document_Feasibility_Menber_RegionalDirector]"
                          //+ "            ,[OfficeAutomation_Document_Feasibility_Menber_RegionalDeputyDirector]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_AreaManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_SeniorManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_UpperManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_businessManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_Name]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_Num]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_Menber]"
                          + " WHERE [OfficeAutomation_Document_Feasibility_Menber_MainID]='" + id + "' AND [OfficeAutomation_Document_Feasibility_Menber_SeniorManager] = '1'"
                          + " ORDER BY [OfficeAutomation_Document_Feasibility_Menber_AreaManager],[OfficeAutomation_Document_Feasibility_Menber_SeniorManager] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 获取人员架构2
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID2(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_Feasibility_Menber_ID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_MainID]"
                + "            ,[OfficeAutomation_Document_Feasibility_Menber_SeniorDirector]"
                //+ "            ,[OfficeAutomation_Document_Feasibility_Menber_RegionalDirector]"
                //+ "            ,[OfficeAutomation_Document_Feasibility_Menber_RegionalDeputyDirector]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_AreaManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_SeniorManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_UpperManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_businessManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_Name]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_Num]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_Menber]"
                          + " WHERE [OfficeAutomation_Document_Feasibility_Menber_MainID]='" + id + "' AND [OfficeAutomation_Document_Feasibility_Menber_SeniorManager] = '2'"
                          + " ORDER BY [OfficeAutomation_Document_Feasibility_Menber_AreaManager],[OfficeAutomation_Document_Feasibility_Menber_SeniorManager] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 获取人员架构3
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID3(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_Feasibility_Menber_ID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_MainID]"
                + "            ,[OfficeAutomation_Document_Feasibility_Menber_SeniorDirector]"
                //+ "            ,[OfficeAutomation_Document_Feasibility_Menber_RegionalDirector]"
                //+ "            ,[OfficeAutomation_Document_Feasibility_Menber_RegionalDeputyDirector]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_AreaManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_SeniorManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_UpperManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_businessManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_Name]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_Num]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_Menber]"
                          + " WHERE [OfficeAutomation_Document_Feasibility_Menber_MainID]='" + id + "' AND [OfficeAutomation_Document_Feasibility_Menber_SeniorManager] = '3'"
                          + " ORDER BY [OfficeAutomation_Document_Feasibility_Menber_AreaManager],[OfficeAutomation_Document_Feasibility_Menber_SeniorManager] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 获取人员架构4
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID4(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_Feasibility_Menber_ID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_MainID]"
                + "            ,[OfficeAutomation_Document_Feasibility_Menber_SeniorDirector]"
                //+ "            ,[OfficeAutomation_Document_Feasibility_Menber_RegionalDirector]"
                //+ "            ,[OfficeAutomation_Document_Feasibility_Menber_RegionalDeputyDirector]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_AreaManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_SeniorManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_UpperManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_businessManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_Name]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_Num]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_Menber]"
                          + " WHERE [OfficeAutomation_Document_Feasibility_Menber_MainID]='" + id + "' AND [OfficeAutomation_Document_Feasibility_Menber_SeniorManager] = '4'"
                          + " ORDER BY [OfficeAutomation_Document_Feasibility_Menber_AreaManager],[OfficeAutomation_Document_Feasibility_Menber_SeniorManager] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 获取人员架构2
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID5(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_Feasibility_Menber_ID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_MainID]"
                + "            ,[OfficeAutomation_Document_Feasibility_Menber_SeniorDirector]"
                //+ "            ,[OfficeAutomation_Document_Feasibility_Menber_RegionalDirector]"
                //+ "            ,[OfficeAutomation_Document_Feasibility_Menber_RegionalDeputyDirector]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_AreaManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_SeniorManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_UpperManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_businessManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_Name]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_Num]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_Menber]"
                          + " WHERE [OfficeAutomation_Document_Feasibility_Menber_MainID]='" + id + "' AND [OfficeAutomation_Document_Feasibility_Menber_SeniorManager] = '5'"
                          + " ORDER BY [OfficeAutomation_Document_Feasibility_Menber_AreaManager],[OfficeAutomation_Document_Feasibility_Menber_SeniorManager] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_Feasibility_Menber_ID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_MainID]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_SeniorDirector]"
                          //+ "            ,[OfficeAutomation_Document_Feasibility_Menber_RegionalDirector]"
                          //+ "            ,[OfficeAutomation_Document_Feasibility_Menber_RegionalDeputyDirector]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_AreaManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_SeniorManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_UpperManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_businessManager]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_Name]"
                          + "            ,[OfficeAutomation_Document_Feasibility_Menber_Num]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_Menber]"
                          + " WHERE [OfficeAutomation_Document_Feasibility_Menber_MainID]= (SELECT toads.OfficeAutomation_Document_Feasibility_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_Feasibility toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_Feasibility_MainID = '" + mainID + "')"
                          + " ORDER BY [OfficeAutomation_Document_Feasibility_Menber_AreaManager],[OfficeAutomation_Document_Feasibility_Menber_SeniorManager] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet FeasibilityMenber_Auto(string aid)
        {
            string sql = "select c.Code AS EmployeeID,c.Name AS EmployeeName,b.Name AS PositionName,i.HRMS_UserField_3 AS Licensed"
                          + " FROM [GZS-HRDB01].AIS20050623105602.dbo.ORG_Position_Employee a"
                          + " INNER JOIN [GZS-HRDB01].AIS20050623105602.dbo.ORG_Position b ON a.PositionID=b.[ID]"
                          + " INNER JOIN [GZS-HRDB01].AIS20050623105602.dbo.HM_Employees c ON a.EMID=c.EM_ID"
                          + " LEFT JOIN [GZS-HRDB01].AIS20050623105602.dbo.HM_EM_Certificate i ON i.EM_ID=c.EM_ID"
                          + " WHERE c.Code = '" + aid + "'";
            return RunSQL(sql);
        }
    }
}
