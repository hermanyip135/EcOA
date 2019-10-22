using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_OfficialSeal_FileSpecies_Inherit : DA_OfficeAutomation_Document_OfficialSeal_Operate
    {
        /// <summary>
        /// 查询事务种类
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectFileSpecies()
        {
            string sql = "SELECT  [t_OfficeAutomation_Document_OfficialSeal_FileSpecies_ID]"
                           + "           ,[t_OfficeAutomation_Document_OfficialSeal_FileSpecies_Name]"
                           + "           ,[t_OfficeAutomation_Document_OfficialSeal_FileSpecies_Kind]"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OfficialSeal_FileSpecies]";

            return RunSQL(sql);
        }
    }
}
