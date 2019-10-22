using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
  public class DA_OfficeAutomation_Document_ProjectOfficialSeal_Inherit : DA_OfficeAutomation_Document_ProjectOfficialSeal_Operate
    {
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_ProjectOfficialSeal_ID]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_MainID]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_Apply]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_ApplyID]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_Department]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_Species]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_AnotherSeal]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_FileSpecies]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_AnotherFile]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_FileCount]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_RecyclingData]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_SureDepartment]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_SureMenber]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_SureData]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_BranchPhone]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_SurePhone]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_SureCommissioner]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjectOfficialSeal] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ProjectOfficialSeal_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_ProjectOfficialSeal_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_ProjectOfficialSeal_ID]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_MainID]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_Apply]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_ApplyID]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_Department]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_Species]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_AnotherSeal]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_FileSpecies]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_AnotherFile]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_FileCount]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_RecyclingData]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_SureDepartment]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_SureMenber]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_SureData]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_BranchPhone]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_SurePhone]"
                           + "           ,[OfficeAutomation_Document_ProjectOfficialSeal_SureCommissioner]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjectOfficialSeal] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ProjectOfficialSeal_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_ProjectOfficialSeal_ID='" + ID + "'";

            return RunSQL(sql);
        }

        public DataSet GetOverdueOfficialSealList()
        {
            string sql = "select * from t_OfficeAutomation_Document_ProjectOfficialSeal as o left join t_OfficeAutomation_Main as m on o.OfficeAutomation_Document_ProjectOfficialSeal_MainID=m.OfficeAutomation_Main_ID where DATEDIFF(DD,OfficeAutomation_Document_ProjectOfficialSeal_ApplyDate,GETDATE())>=30 and m.OfficeAutomation_Main_FlowStateID in (1,2) order by OfficeAutomation_Document_ProjectOfficialSeal_ApplyDate desc";
            return RunSQL(sql);
        }
    }
}
