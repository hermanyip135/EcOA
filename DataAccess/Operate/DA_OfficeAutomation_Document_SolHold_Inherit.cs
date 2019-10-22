using System;
using System.Collections.Generic;
using System.Text;
using DataEntity;
using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SolHold_Inherit : DA_OfficeAutomation_Document_SolHold_Operate
    {
        private DAL.DalBase<DataEntity.T_OfficeAutomation_Document_SolHold> dal;
        public DA_OfficeAutomation_Document_SolHold_Inherit()
        {
            dal = new DAL.DalBase<DataEntity.T_OfficeAutomation_Document_SolHold>();
        }
        /// <summary>
        /// 通过MainID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT  *"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SolHold] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SolHold_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_SolHold_MainID='" + mainID + "'";

            return RunSQL(sql);
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            string sql = "SELECT  [OfficeAutomation_Document_SolHold_ID]"
                           + "           ,[OfficeAutomation_Document_SolHold_MainID]"
                           + "           ,[OfficeAutomation_Document_SolHold_Apply]"
                           + "           ,[OfficeAutomation_Document_SolHold_ApplyDate]"
                           + "           ,[OfficeAutomation_Document_SolHold_ApplyID]"
                           + "           ,[OfficeAutomation_Document_SolHold_Department]"
                           + "           ,[OfficeAutomation_Document_SolHold_Phone]"
                           + "           ,[OfficeAutomation_Document_SolHold_Address]"
                           + "           ,[OfficeAutomation_Document_SolHold_No]"
                           + "           ,[OfficeAutomation_Document_SolHold_Kind]"
                           + "           ,[OfficeAutomation_Document_SolHold_DealDate]"
                           + "           ,[OfficeAutomation_Document_SolHold_Money]"
                           + "           ,[OfficeAutomation_Document_SolHold_Reason]"
                           + "           ,[OfficeAutomation_Document_SolHold_Summary]"
                           + "           ,toam.OfficeAutomation_SerialNumber"
                           + "           ,tdoad.OfficeAutomation_Document_Name"
                           + "           ,toam.OfficeAutomation_Main_FlowStateID"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SolHold] todi"
                           + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_SolHold_MainID"
                           + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                           + " WHERE OfficeAutomation_Document_SolHold_ID='" + ID + "'";

            return RunSQL(sql);
        }

        #region 自定义方法
        public T_OfficeAutomation_Document_SolHold Add(T_OfficeAutomation_Document_SolHold t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_SolHold Edit(T_OfficeAutomation_Document_SolHold t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_SolHold t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_SolHold GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_SolHold>(where);
        }
        #endregion
    }
}
