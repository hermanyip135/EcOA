using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_OpenProve_Detail_Inherit : DA_OfficeAutomation_Document_OpenProve_Detail_Operate
    {
        /// <summary>
        /// 根据退佣申请表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_OpenProve_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_Prove]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_No]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_Reasondb]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_Address]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_Sdate]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_Edate]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_AnotherR]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_Kind]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_AnotherKind]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OpenProve_Detail]"
                          + " WHERE [OfficeAutomation_Document_OpenProve_Detail_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_OpenProve_Detail_No] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_OpenProve_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_Prove]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_No]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_Reasondb]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_Address]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_Sdate]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_Edate]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_AnotherR]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_Kind]"
                          + "            ,[OfficeAutomation_Document_OpenProve_Detail_AnotherKind]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OpenProve_Detail]"
                          + " WHERE [OfficeAutomation_Document_OpenProve_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_OpenProve_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_OpenProve toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_OpenProve_MainID = '" + mainID + "')"
                          + " ORDER BY [OfficeAutomation_Document_OpenProve_Detail_No] ASC";

            return RunSQL(sql);
        }

        public DataEntity.T_OfficeAutomation_Document_OpenProve_Detail Add(DataEntity.T_OfficeAutomation_Document_OpenProve_Detail obj)
        {
            DAL.DalBase<DataEntity.T_OfficeAutomation_Document_OpenProve_Detail> dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_OpenProve_Detail>();
            return dal.Add(obj);
        }
    }
}
