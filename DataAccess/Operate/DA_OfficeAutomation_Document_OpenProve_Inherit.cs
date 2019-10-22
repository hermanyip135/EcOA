using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_OpenProve_Inherit : DA_OfficeAutomation_Document_OpenProve_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  "
                           //+ "             [OfficeAutomation_Document_OpenProve_ID]"
                           //+ "           ,[OfficeAutomation_Document_OpenProve_MainID]"
                           //+ "           ,[OfficeAutomation_Document_OpenProve_Apply]"
                           //+ "           ,[OfficeAutomation_Document_OpenProve_ApplyDate]"
                           //+ "           ,[OfficeAutomation_Document_OpenProve_ApplyID]"
                           //+ "           ,[OfficeAutomation_Document_OpenProve_Department]"
                           //+ "           ,[OfficeAutomation_Document_OpenProve_Code]"
                           //+ "           ,[OfficeAutomation_Document_OpenProve_Name]"
                           //+ "           ,[OfficeAutomation_Document_OpenProve_EnterDate]"
                           //+ "           ,[OfficeAutomation_Document_OpenProve_Position]"
                           //+ "           ,[OfficeAutomation_Document_OpenProve_Rank]"
                            + "           todi.*"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OpenProve] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_OpenProve_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_OpenProve_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_OpenProve_ID]"
                           + "           ,[OfficeAutomation_Document_OpenProve_MainID]"
                           + "           ,[OfficeAutomation_Document_OpenProve_Apply]"
                           + "           ,[OfficeAutomation_Document_OpenProve_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_OpenProve_ApplyID]"
                           + "           ,[OfficeAutomation_Document_OpenProve_Department]"
                           + "           ,[OfficeAutomation_Document_OpenProve_Code]"
                           + "           ,[OfficeAutomation_Document_OpenProve_Name]"
                           + "           ,[OfficeAutomation_Document_OpenProve_EnterDate]"
                           + "           ,[OfficeAutomation_Document_OpenProve_Position]"
                           + "           ,[OfficeAutomation_Document_OpenProve_Rank]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OpenProve] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_OpenProve_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_OpenProve_ID='" + ID + "'";

            return RunSQL(sql);
        }

        public DataEntity.T_OfficeAutomation_Document_OpenProve Add(DataEntity.T_OfficeAutomation_Document_OpenProve obj)
        {
            DAL.DalBase<DataEntity.T_OfficeAutomation_Document_OpenProve> dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_OpenProve>();
            return dal.Add(obj);
        }

        public DataEntity.T_OfficeAutomation_Document_OpenProve Edit(DataEntity.T_OfficeAutomation_Document_OpenProve obj)
        {
            DAL.DalBase<DataEntity.T_OfficeAutomation_Document_OpenProve> dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_OpenProve>();
            return dal.Edit(obj);
        }
    }
}
