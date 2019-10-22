using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using DataEntity;

namespace DataAccess.Operate
{
    public partial class DA_OfficeAutomation_Document_ProjReDaAdd_Inherit : DA_OfficeAutomation_Document_ProjReDaAdd_Operate
    {
        public DA_OfficeAutomation_Document_ProjReDaAdd_Inherit()
        { }

        /// <summary>
        /// 通过MainID查询申请表
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT todi.*"
                             + "         ,toam.OfficeAutomation_SerialNumber"
                             + "         ,tdoad.OfficeAutomation_Document_Name"
                             + "         ,toam.OfficeAutomation_Main_FlowStateID"
                             + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjReDaAdd] todi"
                             + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_ProjReDaAdd_MainID"
                             + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                             + " WHERE OfficeAutomation_Document_ProjReDaAdd_MainID='" + mainID + "'";

            return DbHelperSQL.Query(sql);
        }

        //插入或者修改关键内容
        public bool HandleBase(DataEntity.PageModel.T_OfficeAutomation_Document_ProjReDaAdd_M obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_ProjReDaAdd_MainID == null)
            { return false; }

            var Baseobj = new DataEntity.T_OfficeAutomation_Document_ProjReDaAdd();
            Baseobj.OfficeAutomation_Document_ProjReDaAdd_ID = new Guid(obj.OfficeAutomation_Document_ProjReDaAdd_ID);
            Baseobj.OfficeAutomation_Document_ProjReDaAdd_MainID = new Guid(obj.OfficeAutomation_Document_ProjReDaAdd_MainID);
            Baseobj.OfficeAutomation_Document_ProjReDaAdd_Apply = obj.OfficeAutomation_Document_ProjReDaAdd_Apply;
            Baseobj.OfficeAutomation_Document_ProjReDaAdd_ApplyDate = Convert.ToDateTime(obj.OfficeAutomation_Document_ProjReDaAdd_ApplyDate);
            Baseobj.OfficeAutomation_Document_ProjReDaAdd_Department = obj.OfficeAutomation_Document_ProjReDaAdd_Department;

            //obj是否已经存在
            var where = "[OfficeAutomation_Document_ProjReDaAdd_MainID]='" + obj.OfficeAutomation_Document_ProjReDaAdd_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_ProjReDaAdd resultobj;
            if (Exist(where))
            {
                //Edit
                resultobj = Edit(Baseobj);
            }
            else
            {
                //Add
                resultobj = Insert(Baseobj);
            }
            return resultobj != null;
        }
    }
}

