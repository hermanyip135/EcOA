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
    public class DA_OfficeAutomation_Document_RecruitHRResult_Operate : SqlInteractionBase
    {
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_RecruitHRResult> dal;
        public DA_OfficeAutomation_Document_RecruitHRResult_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_RecruitHRResult>();
        }

        #region 自定义方法
        public T_OfficeAutomation_Document_RecruitHRResult Add(T_OfficeAutomation_Document_RecruitHRResult t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_RecruitHRResult Edit(T_OfficeAutomation_Document_RecruitHRResult t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_RecruitHRResult t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_RecruitHRResult GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_RecruitHRResult>(where);
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
                    + "        FROM [t_OfficeAutomation_Document_RecruitHRResult]"
                    + "      WHERE [OfficeAutomation_Document_RecruitHRResult_MainID]= (SELECT toads.OfficeAutomation_Document_Recruit_ID"
                    + "                                                                                                FROM   t_OfficeAutomation_Document_Recruit toads"
                    + "                                                                                               WHERE  toads.OfficeAutomation_Document_Recruit_MainID = '" + mainID + "')"
                    + "  ORDER BY [OfficeAutomation_Document_RecruitHRResult_AddTime] ASC";

            return RunSQL(sql);
        }

        public List<T_OfficeAutomation_Document_RecruitHRResult> SelectListByMainID(string mainID)
        {
            var ds = SelectByMainID(mainID);
            if (ds == null || ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            return ECOA.Common.SerializationHelper.GetEntities<T_OfficeAutomation_Document_RecruitHRResult>(ds.Tables[0]).ToList();
        }

        public List<T_OfficeAutomation_Document_RecruitHRResult> SelectByMainIDs(string mainIDs)
        {
            string sql = "SELECT * "
                    + "        FROM [t_OfficeAutomation_Document_RecruitHRResult]"
                    + "      WHERE [OfficeAutomation_Document_RecruitHRResult_MainID] IN (" + mainIDs + ")"
                    + "  ORDER BY [OfficeAutomation_Document_RecruitHRResult_AddTime] ASC";

            var ds = RunSQL(sql);
            var list = new List<T_OfficeAutomation_Document_RecruitHRResult>();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                list = ECOA.Common.SerializationHelper.GetEntities<T_OfficeAutomation_Document_RecruitHRResult>(ds.Tables[0]).ToList();
            }
            return list;
        }

        public void DeleteByMainID(string mainID)
        {
            string sql = "Delete "
                               + "        FROM [t_OfficeAutomation_Document_RecruitHRResult]"
                               + "      WHERE [OfficeAutomation_Document_RecruitHRResult_MainID]= (SELECT toads.OfficeAutomation_Document_Recruit_ID"
                               + "                                                                                                FROM   t_OfficeAutomation_Document_Recruit toads"
                               + "                                                                                               WHERE  toads.OfficeAutomation_Document_Recruit_MainID = '" + mainID + "')";

            RunSQL(sql);
        }
    }
}
