using System;
using System.Linq;
using System.Text;
using SqlDatabase;
using DataEntity;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Recruit_Detail_Operate : SqlInteractionBase
    {
        private DAL.DalDetailBase<DataEntity.T_OfficeAutomation_Document_Recruit_Detail> dal;
        public DA_OfficeAutomation_Document_Recruit_Detail_Operate()
        {
            dal = new DAL.DalDetailBase<DataEntity.T_OfficeAutomation_Document_Recruit_Detail>("t_OfficeAutomation_Document_Recruit");
        }

        #region 自定义方法
        public T_OfficeAutomation_Document_Recruit_Detail Add(T_OfficeAutomation_Document_Recruit_Detail t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_Recruit_Detail Edit(T_OfficeAutomation_Document_Recruit_Detail t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_Recruit_Detail t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_Recruit_Detail GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_Recruit_Detail>(where);
        }
        #endregion

        /// <summary>
        /// 根据主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT * "
                    + "        FROM [t_OfficeAutomation_Document_Recruit_Detail]"
                    + "      WHERE [OfficeAutomation_Document_Recruit_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_Recruit_ID"
                    + "                                                                                                FROM   t_OfficeAutomation_Document_Recruit toads"
                    + "                                                                                               WHERE  toads.OfficeAutomation_Document_Recruit_MainID = '" + mainID + "')"
                    + "  ORDER BY [OfficeAutomation_Document_Recruit_Detail_AddTime] ASC";

            return RunSQL(sql);
            //return dal.SelectByMainID(mainID);
        }

        public List<T_OfficeAutomation_Document_Recruit_Detail> SelectListByMainID(string mainID)
        {
            var ds = SelectByMainID(mainID);
            if (ds == null || ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            return ECOA.Common.SerializationHelper.GetEntities<T_OfficeAutomation_Document_Recruit_Detail>(ds.Tables[0]).ToList();
        }

        public void DeleteByMainID(string mainID)
        {
            string sql = "Delete "
                               + "        FROM [t_OfficeAutomation_Document_Recruit_Detail]"
                               + "      WHERE [OfficeAutomation_Document_Recruit_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_Recruit_ID"
                               + "                                                                                                FROM   t_OfficeAutomation_Document_Recruit toads"
                               + "                                                                                               WHERE  toads.OfficeAutomation_Document_Recruit_MainID = '" + mainID + "')";

            RunSQL(sql);
        }
    }
}
