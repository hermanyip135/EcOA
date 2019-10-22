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
    public class DA_OfficeAutomation_Document_CommissionAssign_Operate : SqlInteractionBase
    {
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_CommissionAssign> dal;
        public DA_OfficeAutomation_Document_CommissionAssign_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_CommissionAssign>();
        }

        #region 自定义方法
        public T_OfficeAutomation_Document_CommissionAssign Add(T_OfficeAutomation_Document_CommissionAssign t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_CommissionAssign Edit(T_OfficeAutomation_Document_CommissionAssign t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_CommissionAssign t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_CommissionAssign GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_CommissionAssign>(where);
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
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CommissionAssign] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_CommissionAssign_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_CommissionAssign_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        #region 删除记录
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <returns></returns>
        public bool Delete(string mainID)
        {
            string sql = "[pr_CommissionAssign_Delete]";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@sMainID", SqlDbType.NVarChar, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, mainID));
            int i = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, sql, parameters.ToArray());

            return i > 0;
        } 
        #endregion

        #region 自定义
        //插入或者修改关键内容
        public bool HandleBase(T_OfficeAutomation_Document_CommissionAssign obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_CommissionAssign_MainID == null)
            { return false; }

            //var Baseobj = new DataEntity.T_OfficeAutomation_Document_GeneralApply();
            //Baseobj.OfficeAutomation_Document_GeneralApply_ID = obj.OfficeAutomation_Document_GeneralApply_ID;
            //Baseobj.OfficeAutomation_Document_GeneralApply_MainID = obj.OfficeAutomation_Document_GeneralApply_MainID;
            //Baseobj.OfficeAutomation_Document_GeneralApply_Apply = obj.OfficeAutomation_Document_GeneralApply_Apply;
            //Baseobj.OfficeAutomation_Document_GeneralApply_ApplyDate = obj.OfficeAutomation_Document_GeneralApply_ApplyDate;
            //Baseobj.OfficeAutomation_Document_GeneralApply_ApplyID = obj.OfficeAutomation_Document_GeneralApply_ApplyID;
            //Baseobj.OfficeAutomation_Document_GeneralApply_Department = obj.OfficeAutomation_Document_GeneralApply_Department;

            //Baseobj.OfficeAutomation_Document_GeneralApply_Subject = obj.OfficeAutomation_Document_GeneralApply_Subject;
            //Baseobj.OfficeAutomation_Document_GeneralApply_ReplyPhone = obj.OfficeAutomation_Document_GeneralApply_ReplyPhone;
            //Baseobj.OfficeAutomation_Document_GeneralApply_Fax = obj.OfficeAutomation_Document_GeneralApply_Fax;
            //Baseobj.OfficeAutomation_Document_GeneralApply_ReceiveDepartment = obj.OfficeAutomation_Document_GeneralApply_ReceiveDepartment;
            //Baseobj.OfficeAutomation_Document_GeneralApply_CCDepartment = obj.OfficeAutomation_Document_GeneralApply_CCDepartment;
            //Baseobj.OfficeAutomation_Document_GeneralApply_Describe = obj.OfficeAutomation_Document_GeneralApply_Describe;

            //Baseobj.OfficeAutomation_Document_GeneralApply_CanSeeEmployeeID = obj.OfficeAutomation_Document_GeneralApply_CanSeeEmployeeID;
            //Baseobj.OfficeAutomation_Document_GeneralApply_CanSeeEmployeeName = obj.OfficeAutomation_Document_GeneralApply_CanSeeEmployeeName;

            //obj是否已经存在
            var where = "[OfficeAutomation_Document_CommissionAssign_MainID]='" + obj.OfficeAutomation_Document_CommissionAssign_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_CommissionAssign resultobj;
            if (Exist(where))
            {
                //Edit
                resultobj = Edit(obj);
            }
            else
            {
                //Add
                resultobj = Add(obj);
            }
            return resultobj != null;
        }

        #endregion

    }
}
