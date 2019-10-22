using DataAccess.Operate;
using DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_UtNewProj_New_Inherit : DA_OfficeAutomation_Document_UtNewProj_New_Operate
    {
        private static DA_OfficeAutomation_Document_UtNewProj_New_Operate dal = new DA_OfficeAutomation_Document_UtNewProj_New_Operate();

        #region [整合增加、修改、删除方法]
        /// <summary>
        /// 增加、修改、删除方法
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="opr"></param>
        /// <returns></returns>
        public static bool InsertOrModifyOrDeleteOne(T_OfficeAutomation_Document_UtNewProj_New obj, string opr)
        {
            bool rValue = false;
            switch (opr)
            {
                case "Insert":
                    rValue = dal.Insert(obj);
                    break;
                case "Modify":
                    rValue = dal.Update(obj);
                    break;
                default:
                    rValue = dal.Delete(obj.OfficeAutomation_Document_UtNewProj_New_MainID.ToString());
                    break;
            }

            return rValue;
        }
        #endregion

        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public static T_OfficeAutomation_Document_UtNewProj_New SelectByMainID(string mainID)
        {
            IList<T_OfficeAutomation_Document_UtNewProj_New> allList = dal.GetAll();
            var rList = allList.Where(t => t.OfficeAutomation_Document_UtNewProj_New_MainID.ToString().ToUpper().Equals(mainID.ToUpper())).ToList();
            T_OfficeAutomation_Document_UtNewProj_New result = null;
            if (rList.Count > 0)
            {
                result = rList.Count > 0 ? rList[0] : null;
            }
            return result;
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public static T_OfficeAutomation_Document_UtNewProj_New SelectByID(string ID)
        {
            IList<T_OfficeAutomation_Document_UtNewProj_New> allList = dal.GetAll();
            var rList = allList.Where(t => t.OfficeAutomation_Document_UtNewProj_New_ID.ToString().ToUpper().Equals(ID.ToUpper())).ToList();
            T_OfficeAutomation_Document_UtNewProj_New result = null;
            if (rList.Count > 0)
            {
                result = rList.Count > 0 ? rList[0] : null;
            }
            return result;
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public static T_OfficeAutomation_Document_UtNewProj_New SelectByProjectNameAndMainID(string mainID, string projectName)
        {
            IList<T_OfficeAutomation_Document_UtNewProj_New> allList = dal.GetAll();
            var rList = allList.Where(t => t.OfficeAutomation_Document_UtNewProj_New_Project.ToString().Contains(projectName) && t.OfficeAutomation_Document_UtNewProj_New_MainID.ToString().ToUpper().Equals(mainID.ToUpper())).ToList();
            T_OfficeAutomation_Document_UtNewProj_New result = null;
            if (rList.Count > 0)
            {
                result = rList.Count > 0 ? rList[0] : null;
            }

            return result;
        }

        #region 自定义
        //插入或者修改关键内容
        public static bool HandleBase(T_OfficeAutomation_Document_UtNewProj_New obj)
        {
            if (obj == null || obj.OfficeAutomation_Document_UtNewProj_New_MainID == null)
            { return false; }

            var Baseobj = new DataEntity.T_OfficeAutomation_Document_UtNewProj_New();
            Baseobj.OfficeAutomation_Document_UtNewProj_New_ID = obj.OfficeAutomation_Document_UtNewProj_New_ID;
            Baseobj.OfficeAutomation_Document_UtNewProj_New_MainID = obj.OfficeAutomation_Document_UtNewProj_New_MainID;
            Baseobj.OfficeAutomation_Document_UtNewProj_New_ApplyEmpCode = obj.OfficeAutomation_Document_UtNewProj_New_ApplyEmpCode;
            Baseobj.OfficeAutomation_Document_UtNewProj_New_ApplyEmpName = obj.OfficeAutomation_Document_UtNewProj_New_ApplyEmpName;
            Baseobj.OfficeAutomation_Document_UtNewProj_New_ApplyDate = obj.OfficeAutomation_Document_UtNewProj_New_ApplyDate;
            Baseobj.OfficeAutomation_Document_UtNewProj_New_ApplyDeptID = obj.OfficeAutomation_Document_UtNewProj_New_ApplyDeptID;
            Baseobj.OfficeAutomation_Document_UtNewProj_New_ProjectAddress = obj.OfficeAutomation_Document_UtNewProj_New_ProjectAddress;


            //obj是否已经存在
            var where = "[OfficeAutomation_Document_UtNewProj_New_MainID]='" + obj.OfficeAutomation_Document_UtNewProj_New_MainID.ToString() + "'";
            T_OfficeAutomation_Document_UtNewProj_New resultobj;
            if (dal.Exist(where))
            {
                //Edit
                resultobj = dal.Edit(Baseobj);
            }
            else
            {
                //Add
                resultobj = dal.Add(Baseobj);
            }
            return resultobj != null;
        }

        #endregion

    }
}
