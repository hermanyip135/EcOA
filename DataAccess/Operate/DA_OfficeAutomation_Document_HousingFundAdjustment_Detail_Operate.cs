using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlDatabase;
using DataEntity;
using System.Data;
using System.Data.SqlClient;
using ECOA.Common;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_HousingFundAdjustment_Detail_Operate : SqlInteractionBase
    {
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_HousingFundAdjustment_Detail> dal;
        public DA_OfficeAutomation_Document_HousingFundAdjustment_Detail_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_HousingFundAdjustment_Detail>();
        }

        #region 基本方法
        public DataSet SelectAll()
        {
            return dal.SelectAll();
        }

        public IList<T_OfficeAutomation_Document_HousingFundAdjustment_Detail> SelectAllList()
        {
            var ds = SelectAll();
            if (ds == null)
            {
                return null;
            }
            return SerializationHelper.GetEntities<T_OfficeAutomation_Document_HousingFundAdjustment_Detail>(ds.Tables[0]);
        }

        public T_OfficeAutomation_Document_HousingFundAdjustment_Detail Add(T_OfficeAutomation_Document_HousingFundAdjustment_Detail t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_HousingFundAdjustment_Detail Edit(T_OfficeAutomation_Document_HousingFundAdjustment_Detail t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_HousingFundAdjustment_Detail t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_HousingFundAdjustment_Detail GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_HousingFundAdjustment_Detail>(where);
        }

        public bool DelByMainID(string MainID)
        {
            return dal.DelByMainID(MainID);
        }

        public bool Delete(string mainID)
        {
            return dal.Delete(mainID);
        }

        /// <summary>
        /// 根据主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT * "
                    + "        FROM [t_OfficeAutomation_Document_HousingFundAdjustment_Detail]"
                    + "      WHERE [OfficeAutomation_Document_HousingFundAdjustment_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_HousingFundAdjustment_ID"
                    + "                                                                                                FROM   t_OfficeAutomation_Document_HousingFundAdjustment toads"
                    + "                                                                                               WHERE  toads.OfficeAutomation_Document_HousingFundAdjustment_MainID = '" + mainID + "')"
                    + "  ORDER BY [OfficeAutomation_Document_HousingFundAdjustment_Detail_Addtime] ASC";

            return RunSQL(sql);
        }

        public List<T_OfficeAutomation_Document_HousingFundAdjustment_Detail> SelectListByMainID(string mainID)
        {
            var ds = SelectByMainID(mainID);
            if (ds == null || ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            return ECOA.Common.SerializationHelper.GetEntities<T_OfficeAutomation_Document_HousingFundAdjustment_Detail>(ds.Tables[0]).ToList();
        }


        public void DeleteByMainID(string mainID)
        {
            string sql = "Delete "
                               + "        FROM [t_OfficeAutomation_Document_HousingFundAdjustment_Detail]"
                               + "      WHERE [OfficeAutomation_Document_HousingFundAdjustment_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_HousingFundAdjustment_ID"
                               + "                                                                                                FROM  t_OfficeAutomation_Document_HousingFundAdjustment toads"
                               + "                                                                                               WHERE  toads.OfficeAutomation_Document_HousingFundAdjustment_MainID = '" + mainID + "')";

            RunSQL(sql);
        }
        #endregion
    }
}
