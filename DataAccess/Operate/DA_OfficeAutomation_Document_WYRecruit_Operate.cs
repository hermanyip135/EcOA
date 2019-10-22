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
    public class DA_OfficeAutomation_Document_WYRecruit_Operate : SqlInteractionBase
    {
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_WYRecruit> dal;
        public DA_OfficeAutomation_Document_WYRecruit_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_WYRecruit>();
        }

        #region 基本方法
        public DataSet SelectAll()
        {
            return dal.SelectAll();
        }

        public IList<T_OfficeAutomation_Document_WYRecruit> SelectAllList()
        {
            var ds = SelectAll();
            if (ds == null)
            {
                return null;
            }
            return SerializationHelper.GetEntities<T_OfficeAutomation_Document_WYRecruit>(ds.Tables[0]);
        }

        public T_OfficeAutomation_Document_WYRecruit Add(T_OfficeAutomation_Document_WYRecruit t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_WYRecruit Edit(T_OfficeAutomation_Document_WYRecruit t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_WYRecruit t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_WYRecruit GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_WYRecruit>(where);
        }

        public DataSet SelectByMainID(string mainID)
        {
            return dal.SelectByMainID(mainID); ;
        }

        public bool DelByMainID(string MainID)
        {
            return dal.DelByMainID(MainID);
        }

        public bool Delete(string mainID)
        {
            return dal.Delete(mainID);
        } 
        #endregion

        #region 自定义
        /// <summary>
        /// 根据id给对应物业部自主招聘申请表修改报销情况（实际报销金额、报销日期）。
        /// 2016/8/29 52100
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool AddReimbursement(string id, string amount, string date)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_WYRecruit]"
                                + "   SET [OfficeAutomation_Document_WYRecruit_ReimbursementAmount] = '" + amount + "'"
                                + "   ,[OfficeAutomation_Document_WYRecruit_ReimbursementDate] = '" + date + "'"
                                + " WHERE [OfficeAutomation_Document_WYRecruit_ID]='" + new Guid(id) + "'";

            return RunNoneSQL(sql);
        }
        #endregion
    }
}
