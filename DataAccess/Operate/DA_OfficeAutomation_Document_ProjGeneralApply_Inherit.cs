using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ProjGeneralApply_Inherit:DA_OfficeAutomation_Document_ProjGeneralApply_Operate
    {
        #region 自定义
        //插入或者修改关键内容
        public bool HandleBase(T_OfficeAutomation_Document_ProjGeneralApply obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_ProjGeneralApply_MainID == null)
            { return false; }

            var Baseobj = new DataEntity.T_OfficeAutomation_Document_ProjGeneralApply();
            Baseobj.OfficeAutomation_Document_ProjGeneralApply_ID = obj.OfficeAutomation_Document_ProjGeneralApply_ID;
            Baseobj.OfficeAutomation_Document_ProjGeneralApply_MainID = obj.OfficeAutomation_Document_ProjGeneralApply_MainID;
            Baseobj.OfficeAutomation_Document_ProjGeneralApply_Apply = obj.OfficeAutomation_Document_ProjGeneralApply_Apply;
            Baseobj.OfficeAutomation_Document_ProjGeneralApply_ApplyDate = obj.OfficeAutomation_Document_ProjGeneralApply_ApplyDate;
            Baseobj.OfficeAutomation_Document_ProjGeneralApply_ApplyID = obj.OfficeAutomation_Document_ProjGeneralApply_ApplyID;
            Baseobj.OfficeAutomation_Document_ProjGeneralApply_Department = obj.OfficeAutomation_Document_ProjGeneralApply_Department;

            Baseobj.OfficeAutomation_Document_ProjGeneralApply_Subject = obj.OfficeAutomation_Document_ProjGeneralApply_Subject;
            Baseobj.OfficeAutomation_Document_ProjGeneralApply_ReplyPhone = obj.OfficeAutomation_Document_ProjGeneralApply_ReplyPhone;
            Baseobj.OfficeAutomation_Document_ProjGeneralApply_Fax = obj.OfficeAutomation_Document_ProjGeneralApply_Fax;
            Baseobj.OfficeAutomation_Document_ProjGeneralApply_ReceiveDepartment = obj.OfficeAutomation_Document_ProjGeneralApply_ReceiveDepartment;
            Baseobj.OfficeAutomation_Document_ProjGeneralApply_CCDepartment = obj.OfficeAutomation_Document_ProjGeneralApply_CCDepartment;
            Baseobj.OfficeAutomation_Document_ProjGeneralApply_Describe = obj.OfficeAutomation_Document_ProjGeneralApply_Describe;

            Baseobj.OfficeAutomation_Document_ProjGeneralApply_CanSeeEmployeeID = obj.OfficeAutomation_Document_ProjGeneralApply_CanSeeEmployeeID;
            Baseobj.OfficeAutomation_Document_ProjGeneralApply_CanSeeEmployeeName = obj.OfficeAutomation_Document_ProjGeneralApply_CanSeeEmployeeName;

            //obj是否已经存在
            var where = "[OfficeAutomation_Document_ProjGeneralApply_MainID]='" + obj.OfficeAutomation_Document_ProjGeneralApply_MainID.ToString() + "'";
            DataEntity.T_OfficeAutomation_Document_ProjGeneralApply resultobj;
            if (Exist(where))
            {
                //Edit
                resultobj = Edit(Baseobj);
            }
            else
            {
                //Add
                resultobj = Add(Baseobj);
            }
            return resultobj != null;
        }

        #endregion

        #region 修改查阅人
        public bool UpdateCanSeeEmp(string id, string canseeempcode, string canseeemp)
        {
            string sql = "update t_OfficeAutomation_Document_ProjGeneralApply set OfficeAutomation_Document_ProjGeneralApply_CanSeeEmployeeID='" + canseeempcode + "',OfficeAutomation_Document_ProjGeneralApply_CanSeeEmployeeName='" + canseeemp + "'where OfficeAutomation_Document_ProjGeneralApply_ID='" + id + "'";
            return RunNoneSQL(sql);
        }
        #endregion
    }
}
