using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_Dic_OfficeAutomation_ITStaff_Operate : SqlInteractionBase
    {
        /// <summary>
        /// 根据组别获得对应旗下的IT同事
        /// </summary>
        /// <param name="team">1为软件组，2为系统维护组</param>
        /// <returns></returns>
        public DataSet SelectByTeam(int team)
        {
            string sql = "SELECT [OfficeAutomation_ITStaff_ID]"
                            + "         ,[OfficeAutomation_ITStaff_Code]"
                            + "         ,[OfficeAutomation_ITStaff_Name]"
                            + "         ,[OfficeAutomation_ITStaff_Team]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_ITStaff]"
                            + "  WHERE [OfficeAutomation_ITStaff_Team]=" + team;

            return RunSQL(sql);
        }
    }
}
