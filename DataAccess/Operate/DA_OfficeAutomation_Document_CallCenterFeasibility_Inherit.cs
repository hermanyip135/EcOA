using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity;
using System.Data;
using System.Data.SqlClient;
using SqlDatabase;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_CallCenterFeasibility_Inherit : SqlInteractionBase
    {
        DAL.DalBase<T_OfficeAutomation_Document_CallCenterFeasibility> dal;
        public DA_OfficeAutomation_Document_CallCenterFeasibility_Inherit()
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_CallCenterFeasibility>();
        }

        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT * "
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CallCenterFeasibility] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_CallCenterFeasibility_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_CallCenterFeasibility_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        public T_OfficeAutomation_Document_CallCenterFeasibility Add(T_OfficeAutomation_Document_CallCenterFeasibility obj)
        {
            return dal.Add(obj);
        }

        public T_OfficeAutomation_Document_CallCenterFeasibility Edit(T_OfficeAutomation_Document_CallCenterFeasibility obj)
        {
            return dal.Edit(obj);
        }
        public bool Del(string MainID)
        {
            return dal.DelByMainID(MainID);
        }
        #region 删除记录
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <returns></returns>
        public bool Delete(string mainID)
        {
            string sql = "[pr_CallCenterFeasibility_Delete]";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@sMainID", SqlDbType.NVarChar, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, mainID));
            int i = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, sql, parameters.ToArray());

            return i > 0;
        }
        #endregion
    }
    
}
