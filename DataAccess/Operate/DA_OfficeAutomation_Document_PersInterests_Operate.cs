using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_PersInterests_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_PersInterests _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PersInterests]"
                                                        + "           ([OfficeAutomation_Document_PersInterests_ID]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_MainID]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_DepartmentTypeID]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_Department]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_Apply]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_ApplyForID]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_ApplyFor]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_ApplyForDate]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_InterestsTypeID]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_FollowerID]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_Follower]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_FollowerDepartment]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_Address]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_DealTypeID]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_Relative]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_RelativeDepartment]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_RelativePosition]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_RelativeRelation]"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_ApplyDetail])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_PersInterests_ID"
                                                        + "           ,@guidOfficeAutomation_Document_PersInterests_MainID"
                                                        + "           ,@iOfficeAutomation_Document_PersInterests_DepartmentTypeID"
                                                        + "           ,@sOfficeAutomation_Document_PersInterests_Department"
                                                        + "           ,@sOfficeAutomation_Document_PersInterests_Apply"
                                                        + "           ,@dtOfficeAutomation_Document_PersInterests_ApplyDate"
                                                        + "           ,@sOfficeAutomation_Document_PersInterests_ApplyForID"
                                                        + "           ,@sOfficeAutomation_Document_PersInterests_ApplyFor"
                                                        + "           ,@dtOfficeAutomation_Document_PersInterests_ApplyDateFor"
                                                        + "           ,@iOfficeAutomation_Document_PersInterests_InterestsTypeID"
                                                        + "           ,@sOfficeAutomation_Document_PersInterests_FollowerID"
                                                        + "           ,@sOfficeAutomation_Document_PersInterests_Follower"
                                                        + "           ,@sOfficeAutomation_Document_PersInterests_FollowerDepartment"
                                                        + "           ,@sOfficeAutomation_Document_PersInterests_Address"
                                                        + "           ,@iOfficeAutomation_Document_PersInterests_DealTypeID"
                                                        + "           ,@sOfficeAutomation_Document_PersInterests_Relative"
                                                        + "           ,@sOfficeAutomation_Document_PersInterests_RelativeDepartment"
                                                        + "           ,@sOfficeAutomation_Document_PersInterests_RelativePosition"
                                                        + "           ,@sOfficeAutomation_Document_PersInterests_RelativeRelation"
                                                        + "           ,@sOfficeAutomation_Document_PersInterests_ApplyDetail)";  

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_PersInterests)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_PersInterests_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_PersInterests_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_PersInterests_DepartmentTypeID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_DepartmentTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_PersInterests_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_ApplyForID", SqlDbType.NVarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_ApplyForID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_ApplyFor", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_ApplyFor));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_PersInterests_ApplyDateFor", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_ApplyForDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_PersInterests_InterestsTypeID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_InterestsTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_FollowerID", SqlDbType.NVarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_FollowerID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_Follower", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_Follower));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_FollowerDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_FollowerDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_Address", SqlDbType.NVarChar, 240, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_PersInterests_DealTypeID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_DealTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_Relative", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_Relative));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_RelativeDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_RelativeDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_RelativePosition", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_RelativePosition));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_RelativeRelation", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_RelativeRelation));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_ApplyDetail", SqlDbType.NVarChar, 800, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_ApplyDetail));
     
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
        #endregion

        #region 删除记录
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <returns></returns>
        public bool Delete(string mainID)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_PersInterests_Delete]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sMainID", SqlDbType.NVarChar, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, mainID));

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
        #endregion

        #region 更新记录
        public override bool Update(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PersInterests]"
                                                        + "   SET   [OfficeAutomation_Document_PersInterests_DepartmentTypeID]=@iOfficeAutomation_Document_PersInterests_DepartmentTypeID"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_Department]=@sOfficeAutomation_Document_PersInterests_Department"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_ApplyForID]=@sOfficeAutomation_Document_PersInterests_ApplyForID"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_ApplyFor]=@sOfficeAutomation_Document_PersInterests_ApplyFor"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_ApplyForDate]=@dtOfficeAutomation_Document_PersInterests_ApplyForDate"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_InterestsTypeID]=@iOfficeAutomation_Document_PersInterests_InterestsTypeID"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_FollowerID]=@sOfficeAutomation_Document_PersInterests_FollowerID"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_Follower]=@sOfficeAutomation_Document_PersInterests_Follower"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_FollowerDepartment]=@sOfficeAutomation_Document_PersInterests_FollowerDepartment"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_Address]=@sOfficeAutomation_Document_PersInterests_Address"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_DealTypeID]=@iOfficeAutomation_Document_PersInterests_DealTypeID"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_Relative]=@sOfficeAutomation_Document_PersInterests_Relative"
                                                        //+ "           ,[OfficeAutomation_Document_PersInterests_ReasonTypeID]=@iOfficeAutomation_Document_PersInterests_ReasonTypeID"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_RelativeDepartment]=@sOfficeAutomation_Document_PersInterests_RelativeDepartment"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_RelativePosition]=@sOfficeAutomation_Document_PersInterests_RelativePosition"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_RelativeRelation]=@sOfficeAutomation_Document_PersInterests_RelativeRelation"
                                                        + "           ,[OfficeAutomation_Document_PersInterests_ApplyDetail]=@sOfficeAutomation_Document_PersInterests_ApplyDetail"
                                                        + " WHERE [OfficeAutomation_Document_PersInterests_ID]=@guidOfficeAutomation_Document_PersInterests_ID"
                                                        + "     AND [OfficeAutomation_Document_PersInterests_MainID] = @guidOfficeAutomation_Document_PersInterests_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_PersInterests)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_PersInterests_DepartmentTypeID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_DepartmentTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_ApplyForID", SqlDbType.NVarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_ApplyForID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_ApplyFor", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_ApplyFor));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_PersInterests_ApplyForDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_ApplyForDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_PersInterests_InterestsTypeID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_InterestsTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_FollowerID", SqlDbType.NVarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_FollowerID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_Follower", SqlDbType.NVarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_Follower));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_FollowerDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_FollowerDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_Address", SqlDbType.NVarChar, 240, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_PersInterests_DealTypeID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_DealTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_Relative", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_Relative));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_RelativeDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_RelativeDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_RelativePosition", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_RelativePosition));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_RelativeRelation", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_RelativeRelation));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PersInterests_ApplyDetail", SqlDbType.NVarChar, 800, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_ApplyDetail));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_PersInterests_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_PersInterests_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PersInterests_MainID));
               
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
        #endregion
    }

    #region 字典表类库

    /// <summary>
    /// 申请部门性质字典表
    /// </summary>
    public class DA_Dic_OfficeAutomation_DepartmentType_Operate : SqlInteractionBase
    {
        public override DataSet SelectAll()
        {
            string sql = "SELECT [OfficeAutomation_DepartmentType_ID]"
                            + "         ,[OfficeAutomation_DepartmentType_Name]"
                            + "         ,[OfficeAutomation_DepartmentType_DocumentID]"
                            + "         ,[OfficeAutomation_DepartmentType_IsEnable]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_DepartmentType]";

            return RunSQL(sql);
        }

        public DataSet SelectByDocumentID(int documentID)
        {
            string sql = "SELECT [OfficeAutomation_DepartmentType_ID]"
                            + "         ,[OfficeAutomation_DepartmentType_Name]"
                            + "         ,[OfficeAutomation_DepartmentType_DocumentID]"
                            + "         ,[OfficeAutomation_DepartmentType_IsEnable]"
                            + "         ,[OfficeAutomation_DepartmentType_MajordomoName]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_DepartmentType]"
                            + "  where OfficeAutomation_DepartmentType_DocumentID = "+documentID
                            + "            and OfficeAutomation_DepartmentType_IsEnable = 1";

            return RunSQL(sql);
        }


        public DataSet SelectByDocumentIDCompatible(int documentID,int id)
        {
            string sql = "SELECT [OfficeAutomation_DepartmentType_ID]"
                            + "         ,[OfficeAutomation_DepartmentType_Name]"
                            + "         ,[OfficeAutomation_DepartmentType_DocumentID]"
                            + "         ,[OfficeAutomation_DepartmentType_IsEnable]"
                            + "         ,[OfficeAutomation_DepartmentType_MajordomoName]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_DepartmentType]"
                            + "  where OfficeAutomation_DepartmentType_DocumentID = " + documentID
                            + "            and (OfficeAutomation_DepartmentType_IsEnable = 1 or OfficeAutomation_DepartmentType_ID="+id+") ";

            return RunSQL(sql);
        }


        public DataSet SelectByDocumentIDAndName(int documentID, string na)
        {
            string sql = "SELECT [OfficeAutomation_DepartmentType_ID]"
                            + "         ,[OfficeAutomation_DepartmentType_Name]"
                            + "         ,[OfficeAutomation_DepartmentType_DocumentID]"
                            + "         ,[OfficeAutomation_DepartmentType_IsEnable]"
                            + "         ,[OfficeAutomation_DepartmentType_MajordomoCode]"
                            + "         ,[OfficeAutomation_DepartmentType_MajordomoName]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_DepartmentType]"
                            + "  where OfficeAutomation_DepartmentType_DocumentID = " + documentID
                            + "            and OfficeAutomation_DepartmentType_MajordomoName = '" + na + "'"
                            + "            and OfficeAutomation_DepartmentType_IsEnable = 1";

            return RunSQL(sql);
        }

        public DataSet SelectMajordomoByID(string id)
        {
            string sql = "SELECT [OfficeAutomation_DepartmentType_MajordomoCode]"
                            + "         ,[OfficeAutomation_DepartmentType_MajordomoName]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_DepartmentType]"
                            + "  where [OfficeAutomation_DepartmentType_ID] = " + id;

            return RunSQL(sql);
        }
    }

    /// <summary>
    /// 利益申报类别字典表
    /// </summary>
    public class DA_Dic_OfficeAutomation_PersInterestsType_Operate : SqlInteractionBase
    {
        public override DataSet SelectAll()
        {
            string sql = "SELECT [OfficeAutomation_PersInterestsType_ID]"
                            + "         ,[OfficeAutomation_PersInterestsType_Name]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_PersInterestsType]";

            return RunSQL(sql);
        }

        public string GetInterestsType(int intereststypeid)
        {
            string sql = "SELECT [OfficeAutomation_PersInterestsType_ID]"
                            + "         ,[OfficeAutomation_PersInterestsType_Name]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_PersInterestsType]"
                            + "   WHERE OfficeAutomation_PersInterestsType_ID=" + intereststypeid;

            DataSet ds= RunSQL(sql);
            string intereststypename = ds.Tables[0].Rows[0]["OfficeAutomation_PersInterestsType_Name"].ToString();
            return intereststypename;
        }
    }

    /// <summary>
    /// 房产成交性质字典表
    /// </summary>
    public class DA_Dic_OfficeAutomation_DealType_Operate : SqlInteractionBase
    {
        public override DataSet SelectAll()
        {
            string sql = "SELECT [OfficeAutomation_DealType_ID]"
                            + "         ,[OfficeAutomation_DealType_Name]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_DealType]";

            return RunSQL(sql);
        }

        //public DataSet SelectByDocumentID(int documentID)
        //{
        //    string sql = "SELECT [OfficeAutomation_DealType_ID]"
        //                    + "         ,[OfficeAutomation_DealType_Name]"
        //                    + "         ,[OfficeAutomation_DealType_DocumentID]"
        //                    + "         ,[OfficeAutomation_DealType_IsEnable]"
        //                    + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_DealType]"
        //                    + "  where OfficeAutomation_DealType_DocumentID = " + documentID
        //                    + "            and OfficeAutomation_DealType_IsEnable = 1";

        //    return RunSQL(sql);
        //}
    }
    public class DA_Dic_OfficeAutomation_DirectContractType_Operate : SqlInteractionBase
    {
        public override DataSet SelectAll()
        {
            string sql = "select OfficeAutomation_DirectContractType_ID,OfficeAutomation_DirectContractType_Name from t_Dic_OfficeAutomation_DirectContractType";

            return RunSQL(sql);
        }
    }
    #endregion
}
