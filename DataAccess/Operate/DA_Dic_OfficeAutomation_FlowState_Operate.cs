using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_Dic_OfficeAutomation_FlowState_Operate : SqlInteractionBase
    {
        public override DataSet SelectAll()
        {
            string sql = "SELECT [OfficeAutomation_FlowState_ID]"
                            + "         ,[OfficeAutomation_FlowState_Name]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_FlowState]";

            return RunSQL(sql);
        }
    }
}
