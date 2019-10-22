using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_OfficialSeal_Inherit : DA_OfficeAutomation_Document_OfficialSeal_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_OfficialSeal_ID]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_MainID]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_Apply]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_ApplyID]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_Department]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_Species]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_AnotherSeal]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_FileSpecies]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_AnotherFile]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_FileCount]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_RecyclingData]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_SureDepartment]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_SureMenber]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_SureData]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_BranchPhone]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_SurePhone]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_SureCommissioner]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OfficialSeal] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_OfficialSeal_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_OfficialSeal_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_OfficialSeal_ID]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_MainID]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_Apply]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_ApplyID]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_Department]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_Species]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_AnotherSeal]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_FileSpecies]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_AnotherFile]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_FileCount]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_RecyclingData]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_SureDepartment]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_SureMenber]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_SureData]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_BranchPhone]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_SurePhone]"
                           + "           ,[OfficeAutomation_Document_OfficialSeal_SureCommissioner]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OfficialSeal] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_OfficialSeal_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_OfficialSeal_ID='" + ID + "'";

            return RunSQL(sql);
        }

        public DataSet GetOverdueOfficialSealList()
        {
            string sql = "select * from t_OfficeAutomation_Document_OfficialSeal as o left join t_OfficeAutomation_Main as m on o.OfficeAutomation_Document_OfficialSeal_MainID=m.OfficeAutomation_Main_ID where DATEDIFF(DD,OfficeAutomation_Document_OfficialSeal_ApplyDate,GETDATE())>=30 and m.OfficeAutomation_Main_FlowStateID in (1,2) order by OfficeAutomation_Document_OfficialSeal_ApplyDate desc";
            return RunSQL(sql);
        }
    }
}
