using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Fax_Detail_Flow_Inherit : DA_OfficeAutomation_Document_Fax_Detail_Flow_Operate
    {
        /// <summary>
        /// 根据主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_Fax_Detail_Flow_ID]"
                          + "            ,[OfficeAutomation_Document_Fax_Detail_Flow_MainID]"
                          + "            ,[OfficeAutomation_Document_Fax_Detail_Flow_Num]"
                          + "            ,[OfficeAutomation_Document_Fax_Detail_Flow_Department]"
                          + "            ,[OfficeAutomation_Document_Fax_Detail_Flow_Branch]"
                          + "            ,[OfficeAutomation_Document_Fax_Detail_Flow_Cmodel]"
                          + "            ,[OfficeAutomation_Document_Fax_Detail_Flow_IsOpen]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Fax_Detail_Flow]"
                          + " WHERE [OfficeAutomation_Document_Fax_Detail_Flow_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_Fax_Detail_Flow_Num] ASC";

            return OperationSQL(sql);
        }
    }
}
