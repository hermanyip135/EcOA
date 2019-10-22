using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_LastSure_Inherit : SqlInteractionBase
    {
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public bool InsertD(string mid,string t)
        {
            string sql = "INSERT INTO t_OfficeAutomation_Document_LastSure"
                           + "           (OfficeAutomation_Document_LastSure_MainID,OfficeAutomation_Document_LastSure_Time)"
                           + "           VALUES('" + mid + "','" + t + "')";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public bool UpdateD(string mid, string t)
        {
            string sql = "UPDATE t_OfficeAutomation_Document_LastSure"
                           + "           SET OfficeAutomation_Document_LastSure_Time = '" + t + "'"
                           + "           WHERE OfficeAutomation_Document_LastSure_MainID = '" + mid + "'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID查找数据
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMid(string mid)
        {
            string sql = "SELECT OfficeAutomation_Document_LastSure_MainID,"
                           + "           OfficeAutomation_Document_LastSure_Time,"
                           + "           OfficeAutomation_Document_LastSure_Summary"
                           + "           FROM t_OfficeAutomation_Document_LastSure"
                           + "           WHERE OfficeAutomation_Document_LastSure_MainID = '" + mid + "'";
            return RunSQL(sql);
        }
    }
}
