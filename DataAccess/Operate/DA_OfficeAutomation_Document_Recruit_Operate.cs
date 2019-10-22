using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlDatabase;
using DataEntity;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Recruit_Operate : SqlInteractionBase
    {
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_Recruit> dal;
        public DA_OfficeAutomation_Document_Recruit_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_Recruit>();
        }

        #region 自定义方法
        public T_OfficeAutomation_Document_Recruit Add(T_OfficeAutomation_Document_Recruit t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_Recruit Edit(T_OfficeAutomation_Document_Recruit t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_Recruit t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_Recruit GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_Recruit>(where);
        }
        #endregion

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
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Recruit] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Recruit_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_Recruit_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        

        #region 删除记录
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <returns></returns>
        public bool Delete(string mainID)
        {
            string sql = "[pr_Recruit_Delete]";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@sMainID", SqlDbType.NVarChar, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, mainID));
            int i = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, sql, parameters.ToArray());

            return i > 0;
        } 
        #endregion
    }
}
