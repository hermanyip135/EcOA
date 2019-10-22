using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_Dic_OfficeAutomation_SoftSystem_Operate : SqlInteractionBase
    {
        public override DataSet SelectAll()
        {
            string sql = "SELECT [OfficeAutomation_SoftSystem_ID]"
                            + "         ,[OfficeAutomation_SoftSystem_Name]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_SoftSystem]";

            return RunSQL(sql);
        }

        public DataSet SelectAllbyCache()
        {
            var l = ECOA.Common.CacheHelper.GetCache("SoftSystems");
            if (l == null)
            {
                DataSet ds = this.SelectAll();
                ECOA.Common.CacheHelper.SetCache("SoftSystems", ds);
                return ds;
            }
            else
            {
                return (DataSet)l;
            }
        }
    }
}
