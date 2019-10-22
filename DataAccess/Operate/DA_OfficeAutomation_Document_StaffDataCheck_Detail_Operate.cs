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
    public class DA_OfficeAutomation_Document_StaffDataCheck_Detail_Operate : SqlInteractionBase
    {
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_StaffDataCheck_Detail> dal;
        public DA_OfficeAutomation_Document_StaffDataCheck_Detail_Operate()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_StaffDataCheck_Detail>();
        }

        #region 基本方法
        public DataSet SelectAll()
        {
            return dal.SelectAll();
        }

        public IList<T_OfficeAutomation_Document_StaffDataCheck_Detail> SelectAllList()
        {
            var ds = SelectAll();
            if (ds == null)
            {
                return null;
            }
            return SerializationHelper.GetEntities<T_OfficeAutomation_Document_StaffDataCheck_Detail>(ds.Tables[0]);
        }

        public T_OfficeAutomation_Document_StaffDataCheck_Detail Add(T_OfficeAutomation_Document_StaffDataCheck_Detail t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_StaffDataCheck_Detail Edit(T_OfficeAutomation_Document_StaffDataCheck_Detail t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_StaffDataCheck_Detail t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_StaffDataCheck_Detail GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_StaffDataCheck_Detail>(where);
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

        /// <summary>
        /// 根据六级及以上营业人员入职资料核查表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_StaffDataCheck_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_Company]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_ProviderPosition]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_Provider]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_Phone]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_Department]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_DepartmentResult]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_DepartmentRemark]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_Position]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_PositionResult]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_PositionRemark]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_PositionDate]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_PositionDateResult]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_PositionDateRemark]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_LeaveReason]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_LeaveReasonResult]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_Misdeeds]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_MisdeedsRemark]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_Performance]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_PerformanceRemark]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_TeamNumAndDate]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_TeamNumAndDateRemark]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_Ability]"
                          + "            ,[OfficeAutomation_Document_StaffDataCheck_Detail_AbilityRemark]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_StaffDataCheck_Detail]"
                          + " WHERE [OfficeAutomation_Document_StaffDataCheck_Detail_MainID]='" + id + "'";

            return RunSQL(sql);
        }
        #endregion
    }
}
