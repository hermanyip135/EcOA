using System;
using System.Collections.Generic;
using System.Text;
using DataEntity;
using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_HoldCoisn_Inherit : DA_OfficeAutomation_Document_HoldCoisn_Operate
    {
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_HoldCoisn> dal;
        public DA_OfficeAutomation_Document_HoldCoisn_Inherit()
		{
			dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_HoldCoisn>();
		}


        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  * "
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_HoldCoisn] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_HoldCoisn_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_HoldCoisn_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_HoldCoisn_ID]"
                           + "           ,[OfficeAutomation_Document_HoldCoisn_MainID]"
                           + "           ,[OfficeAutomation_Document_HoldCoisn_Apply]"
                           + "           ,[OfficeAutomation_Document_HoldCoisn_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_HoldCoisn_ApplyID]"
                           + "           ,[OfficeAutomation_Document_HoldCoisn_Department]"
                           + "           ,[OfficeAutomation_Document_HoldCoisn_Area]"
                           + "           ,[OfficeAutomation_Document_HoldCoisn_Clerk]"
                           + "           ,[OfficeAutomation_Document_HoldCoisn_DealDate]"
                           + "           ,[OfficeAutomation_Document_HoldCoisn_Address]"
                           + "           ,[OfficeAutomation_Document_HoldCoisn_Reason]"
                           + "           ,[OfficeAutomation_Document_HoldCoisn_TurnDate]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_HoldCoisn] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_HoldCoisn_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_HoldCoisn_ID='" + ID + "'";

            return RunSQL(sql);
        }

        #region 基本方法
        public DataSet SelectAll()
        {
            return dal.SelectAll();
        }

        public T_OfficeAutomation_Document_HoldCoisn Add(T_OfficeAutomation_Document_HoldCoisn t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_HoldCoisn Edit(T_OfficeAutomation_Document_HoldCoisn t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_HoldCoisn t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_HoldCoisn GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_HoldCoisn>(where);
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

    }
}
