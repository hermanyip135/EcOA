using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SysPower_Detail_Apply_Inherit : DA_OfficeAutomation_Document_SysPower_Detail_Apply_Operate
    {
        /// <summary>
        /// 查询申请内容明细
        /// </summary>
        /// <param name="mainID">(汇瀚/二级市场/后勤)IT权限申请明细表主键</param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_SysPower_Detail_Apply_ID]"
                          + "             ,[OfficeAutomation_Document_SysPower_Detail_Apply_MainID]"
                          + "             ,[OfficeAutomation_Document_SysPower_Detail_Apply_ApplyDetailID]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysPower_Detail_Apply]"
                          + " WHERE [OfficeAutomation_Document_SysPower_Detail_Apply_MainID]='" + mainID + "'";

            return RunSQL(sql);
        }
    }
}
