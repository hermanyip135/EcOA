using DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_UtNewProj_New_Detail_Inherit : DA_OfficeAutomation_Document_UtNewProj_New_Detail_Operate
    {
        private static DA_OfficeAutomation_Document_UtNewProj_New_Detail_Operate opr = new DA_OfficeAutomation_Document_UtNewProj_New_Detail_Operate();
        #region [整合增加、修改、删除方法]
        /// <summary>
        /// 增加、修改、删除方法
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="opr"></param>
        /// <returns></returns>
        public static bool InsertOrModifyOrDeleteOne(T_OfficeAutomation_Document_UtNewProj_New_Detail obj, string oprType)
        {
            
            bool rValue = false;
            switch (oprType)
            {
                case "Insert":
                    rValue = opr.Insert(obj);
                    break;
                case "Modify":
                    rValue = opr.Update(obj);
                    break;
                default:
                    rValue = opr.Delete(obj.OfficeAutomation_Document_UtNewProj_New_Detail_MainID.ToString());
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
        public static T_OfficeAutomation_Document_UtNewProj_New_Detail SelectByMainID(string mainID)
        {
            IList<T_OfficeAutomation_Document_UtNewProj_New_Detail> rList = opr.GetAll();
            T_OfficeAutomation_Document_UtNewProj_New_Detail result = rList.Where(t => t.OfficeAutomation_Document_UtNewProj_New_Detail_MainID.ToString().ToUpper().Equals(mainID.ToUpper())).ToList()[0];
            return result;
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public static T_OfficeAutomation_Document_UtNewProj_New_Detail SelectByID(string ID)
        {
            IList<T_OfficeAutomation_Document_UtNewProj_New_Detail> rList = opr.GetAll();
            T_OfficeAutomation_Document_UtNewProj_New_Detail result = rList.Where(t => t.OfficeAutomation_Document_UtNewProj_New_Detail_ID.ToString().ToUpper().Equals(ID.ToUpper())).ToList()[0];
            return result;
        }
    }
}
