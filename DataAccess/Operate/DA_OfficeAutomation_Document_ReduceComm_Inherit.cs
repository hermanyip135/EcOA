using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using DataEntity;

namespace DataAccess.Operate
{
    public partial class DA_OfficeAutomation_Document_ReduceComm_Inherit : DA_OfficeAutomation_Document_ReduceComm_Operate
    {
        public DA_OfficeAutomation_Document_ReduceComm_Inherit()
        { }

        /// <summary>
        /// 通过MainID查询员工减佣让佣申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT todi.*"
                             + "         ,toam.OfficeAutomation_SerialNumber"
                             + "         ,tdoad.OfficeAutomation_Document_Name"
                             + "         ,toam.OfficeAutomation_Main_FlowStateID"
                             + "         ,tdodt.OfficeAutomation_DepartmentType_Name"
                             + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ReduceComm] todi"
                             + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ReduceComm_MainID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_DepartmentType tdodt ON tdodt.OfficeAutomation_DepartmentType_ID = todi.OfficeAutomation_Document_ReduceComm_DepartmentTypeID"
                             + " WHERE OfficeAutomation_Document_ReduceComm_MainID='" + mainID + "'";


            return DbHelperSQL.Query(sql);
        }

        #region 自定义
        //插入或者修改关键内容
        public bool HandleBase(DataEntity.T_OfficeAutomation_Document_ReduceComm obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_ReduceComm_MainID == null)
            { return false; }

            var Baseobj = new DataEntity.T_OfficeAutomation_Document_ReduceComm();
            Baseobj = obj;
            //obj是否已经存在
            var where = "[OfficeAutomation_Document_ReduceComm_MainID]='" + obj.OfficeAutomation_Document_ReduceComm_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_ReduceComm resultobj;
            if (Exist(where))
            {
                //Edit
                resultobj = TemEdit(Baseobj);
            }
            else
            {
                //Add
                resultobj = TemAdd(Baseobj);
            }
            return resultobj != null;
        }

        #endregion
    }
}

