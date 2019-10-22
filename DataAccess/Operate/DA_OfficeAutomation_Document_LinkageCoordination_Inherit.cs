 using DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_LinkageCoordination_Inherit
    {
        private static DA_OfficeAutomation_Document_LinkageCoordination_Operate opr = new DA_OfficeAutomation_Document_LinkageCoordination_Operate();


        #region [整合增加、修改方法]
        /// <summary>
        /// 增加、修改方法
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="oprType"></param>
        /// <returns></returns>
        public static bool InsertOrModify(T_OfficeAutomation_Document_LinkageCoordination obj, string oprType)
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
                    //rValue = opr.Delete(obj.OfficeAutomation_Document_UtNewProj_New_Detail_MainID.ToString());
                    break;
            }

            return rValue;
        }
        #endregion

        #region [根据条件查询]
        /// <summary>
        /// 根据ID的类型，通过ID查询
        /// </summary>
        /// <param name="ID">GUID</param>
        /// <param name="IDType">ID的类型</param>
        /// <returns></returns>
        public static T_OfficeAutomation_Document_LinkageCoordination SelectByID(string ID, string IDType)
        {
            IList<T_OfficeAutomation_Document_LinkageCoordination> rList = opr.GetAll();
            T_OfficeAutomation_Document_LinkageCoordination rObj = null;
            switch (IDType)
            {
                case "Main":
                    rObj = rList.Where(t => t.OfficeAutomation_Document_LinkageCoordination_MainID.ToString().ToUpper().Equals(ID.ToUpper())).ToList()[0];
                    break;
                case "Primary":
                    rObj = rList.Where(t => t.OfficeAutomation_Document_LinkageCoordination_ID.ToString().ToUpper().Equals(ID.ToUpper())).ToList()[0];
                    break;
                default:
                    //rValue = opr.Delete(obj.OfficeAutomation_Document_UtNewProj_New_Detail_MainID.ToString());
                    break;
            }
            return rObj;
        } 
        #endregion
    }
}
