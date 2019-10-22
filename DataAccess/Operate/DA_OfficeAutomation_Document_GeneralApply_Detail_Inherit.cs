using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;//52100

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_GeneralApply_Detail_Inherit : DA_OfficeAutomation_Document_GeneralApply_Detail_Operate
    {
        #region 自定义变量-52100
        private DataEntity.T_OfficeAutomation_Document_GeneralApply_Detail _objMessage = null;
        #endregion

        /// <summary>
        /// 根据主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_Document_GeneralApply_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_GeneralApply_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_GeneralApply_Detail_Num]"
                          + "            ,[OfficeAutomation_Document_GeneralApply_Detail_Department]"
                          + "            ,[OfficeAutomation_Document_GeneralApply_Detail_Branch]"
                          + "            ,[OfficeAutomation_Document_GeneralApply_Detail_Cmodel]"
                          + "            ,[OfficeAutomation_Document_GeneralApply_Detail_IsOpen]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_GeneralApply_Detail]"
                          + " WHERE [OfficeAutomation_Document_GeneralApply_Detail_MainID]='" + id + "'"
                          + " ORDER BY [OfficeAutomation_Document_GeneralApply_Detail_Num] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情（倒序）
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMIDDesc(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_GeneralApply_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_GeneralApply_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_GeneralApply_Detail_Num]"
                          + "            ,[OfficeAutomation_Document_GeneralApply_Detail_Department]"
                          + "            ,[OfficeAutomation_Document_GeneralApply_Detail_Branch]"
                          + "            ,[OfficeAutomation_Document_GeneralApply_Detail_Cmodel]"
                          + "            ,[OfficeAutomation_Document_GeneralApply_Detail_IsOpen]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_GeneralApply_Detail]"
                          + " WHERE [OfficeAutomation_Document_GeneralApply_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_GeneralApply_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_GeneralApply toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_GeneralApply_MainID = '" + mainID + "')"
                          + " ORDER BY [OfficeAutomation_Document_GeneralApply_Detail_Num] DESC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据主表主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Document_GeneralApply_Detail_ID]"
                          + "            ,[OfficeAutomation_Document_GeneralApply_Detail_MainID]"
                          + "            ,[OfficeAutomation_Document_GeneralApply_Detail_Num]"
                          + "            ,[OfficeAutomation_Document_GeneralApply_Detail_Department]"
                          + "            ,[OfficeAutomation_Document_GeneralApply_Detail_Branch]"
                          + "            ,[OfficeAutomation_Document_GeneralApply_Detail_Cmodel]"
                          + "            ,[OfficeAutomation_Document_GeneralApply_Detail_IsOpen]"
                          + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_GeneralApply_Detail]"
                          + " WHERE [OfficeAutomation_Document_GeneralApply_Detail_MainID]= (SELECT toads.OfficeAutomation_Document_GeneralApply_ID"
                          + "                                                                                                     FROM t_OfficeAutomation_Document_GeneralApply toads"
                          + "                                                                                                   WHERE toads.OfficeAutomation_Document_GeneralApply_MainID = '" + mainID + "')"
                          + " ORDER BY [OfficeAutomation_Document_GeneralApply_Detail_Num] ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 把num及其后面的流程号增加after个数量
        /// </summary>
        /// <returns></returns>
        public int AddAnotherFlow(string mainid, int num, int after)
        {
            string sSql = "UPDATE t_OfficeAutomation_Document_GeneralApply_Detail ";
            sSql += " SET OfficeAutomation_Document_GeneralApply_Detail_Num = OfficeAutomation_Document_GeneralApply_Detail_Num + " + after;
            //sSql += " ,OfficeAutomation_Document_GeneralApply_Detail_Sign = OfficeAutomation_Document_GeneralApply_Detail_Sign + " + after;
            sSql += " WHERE OfficeAutomation_Document_GeneralApply_Detail_Num >= " + num;
            sSql += " AND OfficeAutomation_Document_GeneralApply_Detail_MainID = '" + mainid + "'";
            RunSQL(sSql);
            return 0;
        }

        /// <summary>
        /// 把流程号作为标号
        /// </summary>
        /// <returns></returns>
        public int SignNum(string mainid, int num)
        {
            string sSql = "UPDATE t_OfficeAutomation_Document_GeneralApply_Detail ";
            sSql += " SET OfficeAutomation_Document_GeneralApply_Detail_Sign = " + num;
            sSql += " WHERE OfficeAutomation_Document_GeneralApply_Detail_Num = " + num;
            sSql += " AND OfficeAutomation_Document_GeneralApply_Detail_MainID = '" + mainid + "'";
            RunSQL(sSql);
            return 0;
        }

        /// <summary>
        /// 更新标号
        /// </summary>
        /// <returns></returns>
        public int UpdateSignNum(string mainid, int num)
        {
            string sSql = "UPDATE t_OfficeAutomation_Document_GeneralApply_Detail ";
            sSql += " SET OfficeAutomation_Document_GeneralApply_Detail_Sign = OfficeAutomation_Document_GeneralApply_Detail_Sign +  " + num;
            sSql += " WHERE OfficeAutomation_Document_GeneralApply_Detail_Sign >=(  ";
            sSql += " SELECT TOP 1 OfficeAutomation_Document_GeneralApply_Detail_Sign FROM t_OfficeAutomation_Document_GeneralApply_Detail ";
            sSql += " WHERE OfficeAutomation_Document_GeneralApply_Detail_Department = '后勤事务部' ";
            sSql += " AND OfficeAutomation_Document_GeneralApply_Detail_MainID = '" + mainid + "' ";
            sSql += " ORDER BY OfficeAutomation_Document_GeneralApply_Detail_Num) ";
            RunSQL(sSql);
            return 0;
        }

        /// <summary>
        /// 删除所跳过的部门
        /// </summary>
        /// <returns></returns>
        public int DeleteByDpmAndMID(string mainid, string dpm)
        {
            string sSql = "DELETE FROM t_OfficeAutomation_Document_GeneralApply_Detail "
                       + " WHERE OfficeAutomation_Document_GeneralApply_Detail_MainID = "
                       + " (SELECT OfficeAutomation_Document_GeneralApply_ID FROM t_OfficeAutomation_Document_GeneralApply"
                       + " WHERE t_OfficeAutomation_Document_GeneralApply.OfficeAutomation_Document_GeneralApply_MainID = '" + mainid + "')"
                       + " AND OfficeAutomation_Document_GeneralApply_Detail_Department = '" + dpm + "'";
            RunSQL(sSql);
            return 0;
        }

        /// <summary>
        /// 删除所跳过的部门(用于通用申请表) 20170410
        /// </summary>
        /// <returns></returns>
        public int DeleteByDpmAndMIDForProj(string mainid, string dpm)
        {
            string sSql = "DELETE FROM t_OfficeAutomation_Document_GeneralApply_Detail "
                       + " WHERE OfficeAutomation_Document_GeneralApply_Detail_MainID = "
                       + " (SELECT OfficeAutomation_Document_ProjGeneralApply_ID FROM t_OfficeAutomation_Document_ProjGeneralApply"
                       + " WHERE t_OfficeAutomation_Document_ProjGeneralApply.OfficeAutomation_Document_ProjGeneralApply_MainID = '" + mainid + "')"
                       + " AND OfficeAutomation_Document_GeneralApply_Detail_Department = '" + dpm + "'";
            RunSQL(sSql);
            return 0;
        }

        /// <summary>
        /// 插入记录
        /// 优化之前的插入方法-2016/10/14-52100
        /// </summary>
        /// <returns></returns>
        public  bool NewInsert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_GeneralApply_Detail]"
                                                        + "           ([OfficeAutomation_Document_GeneralApply_Detail_ID]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_Detail_MainID]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_Detail_Num]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_Detail_Sign]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_Detail_Department]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_Detail_Branch]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_Detail_Cmodel]"
                                                        + "           ,[OfficeAutomation_Document_GeneralApply_Detail_IsOpen])"
                                                        + "     VALUES"
                                                        + "           (@OfficeAutomation_Document_GeneralApply_Detail_ID"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_Detail_MainID"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_Detail_Num"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_Detail_Sign"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_Detail_Department"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_Detail_Branch"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_Detail_Cmodel"
                                                        + "           ,@OfficeAutomation_Document_GeneralApply_Detail_IsOpen)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_GeneralApply_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_Num", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_Num));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_Sign", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_Sign));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_Branch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_Branch));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_Cmodel", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_Cmodel));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_GeneralApply_Detail_IsOpen", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_GeneralApply_Detail_IsOpen));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();

                    cmdToExecute.Transaction = _mainConnection.BeginTransaction();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                _rowsAffected = cmdToExecute.ExecuteNonQuery();

                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Rollback();
                }
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();
            }
        }
    }
}
