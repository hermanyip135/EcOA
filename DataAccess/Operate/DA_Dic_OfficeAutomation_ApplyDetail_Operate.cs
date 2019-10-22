using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_Dic_OfficeAutomation_ApplyDetail_Operate : SqlInteractionBase
    {
        public DataSet SelectAll(int documentid)
        {
            string sql = "SELECT [OfficeAutomation_ApplyDetail_ID]"
                            + "         ,[OfficeAutomation_ApplyDetail_Name]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_ApplyDetail]"
                            + "  WHERE [OfficeAutomation_ApplyDetail_IsDisplay]=1"
                            + "      AND [OfficeAutomation_ApplyDetail_DocumentID]=" + documentid
                            +"      ORDER BY  [OfficeAutomation_ApplyDetail_Sort]";
            return RunSQL(sql);
        }
    }
}
