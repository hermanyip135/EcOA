using DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_LinkageCoordination_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_LinkageCoordination _objMessage = null;
        private DAL.DalBase<T_OfficeAutomation_Document_LinkageCoordination> dal;
        public DA_OfficeAutomation_Document_LinkageCoordination_Operate()
        {
            dal = new DAL.DalBase<T_OfficeAutomation_Document_LinkageCoordination>();
        }
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "pr_OfficeAutomation_Document_LinkageCoordination_InsertOrUpdate";

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (T_OfficeAutomation_Document_LinkageCoordination)obj;

            try
            {
                #region [公共字段]
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_RecordType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_RecordType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Apply", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_ApplyDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_EmpCode", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_EmpCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_EmpName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_EmpName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Remark", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Remark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_ZSSupervisor", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_ZSSupervisor));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_LSSupervisor", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_LSSupervisor));
                #endregion

                #region [入职申请字段]
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDepartmentID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_PositionID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_PositionID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDepartment", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_Position", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_PosGrade", SqlDbType.NChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_PosGrade));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_BasicSalary", SqlDbType.Decimal, 18, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_BasicSalary));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDate", SqlDbType.DateTime, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_EccRole", SqlDbType.NVarChar, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_EccRole));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_WorkNature", SqlDbType.NVarChar, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_WorkNature));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_LastComm", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_LastComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_Relationship", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_Relationship));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_OtherCompanyComm", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_OtherCompanyComm));
                #endregion

                #region [离职申请字段]
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_DepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_DepartmentID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_PositionID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_PositionID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_Department", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_Position", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_PosGrade", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_PosGrade));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_Type", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_Reason", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_ReasonRemark", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_ReasonRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_ApplyDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_LastDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_LastDate));
                #endregion

                #region [调动申请字段]
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_DepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_DepartmentID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_PositionID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_PositionID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_Department", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_Position", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_PosGrade", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_PosGrade));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_BasicSalary", SqlDbType.Decimal, 18, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_BasicSalary));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_ZSSupervisor", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_ZSSupervisor));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_LSSupervisor", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_ZSSupervisor));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_EccRole", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_EccRole));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_WorkNature", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_WorkNature));

                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_DepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_DepartmentID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_PositionID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_PositionID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_Department", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_Position", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_PosGrade", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_PosGrade));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_BasicSalary", SqlDbType.Decimal, 18, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_BasicSalary));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_ZSSupervisor", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_ZSSupervisor));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_LSSupervisor", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_LSSupervisor));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_EccRole", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_EccRole));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_WorkNature", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_WorkNature));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_EffectiveDate", SqlDbType.DateTime, 18, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_EffectiveDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_ChangType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_ChangType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_ChangTypeRemark", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_ChangTypeRemark));
                #endregion


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

            cmdToExecute.CommandText = "pr_OfficeAutomation_Document_LinkageCoordination_InsertOrUpdate";

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (T_OfficeAutomation_Document_LinkageCoordination)obj;

            try
            {

                #region [公共字段]
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_RecordType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_RecordType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Apply", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_EmpCode", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_EmpCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_EmpName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_EmpName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Remark", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Remark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_ZSSupervisor", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_ZSSupervisor));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_LSSupervisor", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_LSSupervisor));
                #endregion

                #region [入职申请字段]
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDepartmentID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_PositionID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_PositionID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDepartment", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_Position", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_PosGrade", SqlDbType.NChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_PosGrade));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_BasicSalary", SqlDbType.Decimal, 18, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_BasicSalary));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDate", SqlDbType.DateTime, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_EccRole", SqlDbType.NChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_EccRole));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_WorkNature", SqlDbType.NChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_WorkNature));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_LastComm", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_LastComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_Relationship", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_Relationship));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Inservice_OtherCompanyComm", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Inservice_OtherCompanyComm));
                #endregion

                #region [离职申请字段]
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_DepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_DepartmentID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_PositionID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_PositionID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_Department", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_Position", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_PosGrade", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_PosGrade));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_Type", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_Reason", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_ReasonRemark", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_ReasonRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_ApplyDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_Dimission_LastDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_Dimission_LastDate));
                #endregion

                #region [调动申请字段]
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_DepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_DepartmentID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_PositionID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_PositionID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_Department", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_Position", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_PosGrade", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_PosGrade));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_BasicSalary", SqlDbType.Decimal, 18, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_BasicSalary));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_ZSSupervisor", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_ZSSupervisor));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_LSSupervisor", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_ZSSupervisor));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_EccRoleID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_EccRoleID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_WorkNatureID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_WorkNatureID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_EccRole", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_EccRole));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_WorkNature", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_WorkNature));

                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_DepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_DepartmentID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_PositionID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_PositionID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_Department", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_Position", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_PosGrade", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_PosGrade));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_BasicSalary", SqlDbType.Decimal, 18, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_BasicSalary));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_ZSSupervisor", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_ZSSupervisor));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_LSSupervisor", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_LSSupervisor));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_EccRoleID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_EccRoleID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_WorkNatureID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_WorkNatureID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_EccRole", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_EccRole));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_WorkNature", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_WorkNature));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_EffectiveDate", SqlDbType.DateTime, 18, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_EffectiveDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_ChangType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_ChangType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_PersonalChange_ChangTypeRemark", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LinkageCoordination_PersonalChange_ChangTypeRemark));
                #endregion


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

            cmdToExecute.CommandText = @"
                UPDATE toadlc
                SET [OfficeAutomation_Document_LinkageCoordination_IsDelete] = 1
                FROM t_OfficeAutomation_Document_LinkageCoordination AS toadlc
                WHERE toadlc.OfficeAutomation_Document_LinkageCoordination_MainID = @OfficeAutomation_Document_LinkageCoordination_MainID
            ";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LinkageCoordination_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

        #region [查询所有数据]
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public IList<T_OfficeAutomation_Document_LinkageCoordination> GetAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();

            //            cmdToExecute.CommandText = @"SELECT * FROM t_OfficeAutomation_Document_LinkageCoordination 
            //                                         WHERE OfficeAutomation_Document_LinkageCoordination_IsDelete = 0 ";

            cmdToExecute.CommandText = @" SELECT * FROM t_OfficeAutomation_Document_LinkageCoordination ";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            IList<T_OfficeAutomation_Document_LinkageCoordination> rList = new List<T_OfficeAutomation_Document_LinkageCoordination>();
            T_OfficeAutomation_Document_LinkageCoordination obj = null;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            try
            {


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

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        obj = new T_OfficeAutomation_Document_LinkageCoordination();

                        obj.OfficeAutomation_Document_LinkageCoordination_ID = new Guid(dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_ID"].ToString());
                        obj.OfficeAutomation_Document_LinkageCoordination_MainID = new Guid(dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_MainID"].ToString());
                        obj.OfficeAutomation_Document_LinkageCoordination_RecordType = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_RecordType"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_Apply = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Apply"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_ApplyDate = Convert.ToDateTime(dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_ApplyDate"].ToString());
                        obj.OfficeAutomation_Document_LinkageCoordination_EmpCode = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_EmpCode"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_EmpName = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_EmpName"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_Remark = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Remark"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_ZSSupervisor = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_ZSSupervisor"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_LSSupervisor = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_LSSupervisor"].ToString();

                        //obj.OfficeAutomation_Document_LinkageCoordination_IsDelete = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_IsDelete"].ToString();
                        #region [入职申请]
                        //obj.OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDepartmentID = new Guid(dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDepartmentID"].ToString());
                        //obj.OfficeAutomation_Document_LinkageCoordination_Inservice_PositionID = new Guid(dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Inservice_PositionID"].ToString());

                        obj.OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDepartment = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDepartment"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_Inservice_Position = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Inservice_Position"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_Inservice_PosGrade = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Inservice_PosGrade"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_Inservice_BasicSalary = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Inservice_BasicSalary"] == DBNull.Value ? 0 : Convert.ToDecimal(dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Inservice_BasicSalary"].ToString());
                        obj.OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDate = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Inservice_EnterDate"].ToString());
                        obj.OfficeAutomation_Document_LinkageCoordination_Inservice_EccRole = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Inservice_EccRole"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_Inservice_WorkNature = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Inservice_WorkNature"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_Inservice_LastComm = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Inservice_LastComm"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_Inservice_Relationship = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Inservice_Relationship"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_Inservice_OtherCompanyComm = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Inservice_OtherCompanyComm"].ToString();
                        #endregion

                        #region [离职申请]
                        //obj.OfficeAutomation_Document_LinkageCoordination_Dimission_DepartmentID = new Guid(dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Dimission_DepartmentID"].ToString());
                        //obj.OfficeAutomation_Document_LinkageCoordination_Dimission_PositionID = new Guid(dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Dimission_PositionID"].ToString());

                        obj.OfficeAutomation_Document_LinkageCoordination_Dimission_Department = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Dimission_Department"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_Dimission_Position = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Dimission_Position"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_Dimission_PosGrade = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Dimission_PosGrade"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_Dimission_Type = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Dimission_Type"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_Dimission_Reason = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Dimission_Reason"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_Dimission_ReasonRemark = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Dimission_ReasonRemark"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_Dimission_ApplyDate = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Dimission_ApplyDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Dimission_ApplyDate"].ToString());
                        obj.OfficeAutomation_Document_LinkageCoordination_Dimission_LastDate = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Dimission_LastDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_Dimission_LastDate"].ToString());
                        #endregion

                        #region [人事调动申请]
                        #region [调动前人事资料]
                        //obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_DepartmentID = new Guid(dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_DepartmentID"].ToString());
                        //obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_PositionID = new Guid(dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_PositionID"].ToString());

                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_Department = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_Department"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_Position = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_Position"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_PosGrade = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_PosGrade"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_BasicSalary = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_BasicSalary"] == DBNull.Value ? 0 : Convert.ToDecimal(dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_BasicSalary"].ToString());
                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_ZSSupervisor = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_ZSSupervisor"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_LSSupervisor = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_LSSupervisor"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_EccRole = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_EccRole"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_WorkNature = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_Old_WorkNature"].ToString();
                        #endregion

                        #region [调动后人事资料]
                        //obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_DepartmentID = new Guid(dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_DepartmentID"].ToString());
                        //obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_PositionID = new Guid(dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_PositionID"].ToString());

                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_Department = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_Department"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_Position = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_Position"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_PosGrade = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_PosGrade"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_BasicSalary = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_BasicSalary"] == DBNull.Value ? 0 : Convert.ToDecimal(dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_BasicSalary"].ToString());
                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_ZSSupervisor = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_ZSSupervisor"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_LSSupervisor = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_LSSupervisor"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_EccRole = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_EccRole"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_WorkNature = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_New_WorkNature"].ToString();
                        #endregion

                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_EffectiveDate = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_EffectiveDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_EffectiveDate"].ToString());
                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_ChangType = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_ChangType"].ToString();
                        obj.OfficeAutomation_Document_LinkageCoordination_PersonalChange_ChangTypeRemark = dt.Rows[i]["OfficeAutomation_Document_LinkageCoordination_PersonalChange_ChangTypeRemark"].ToString();
                        #endregion


                        rList.Add(obj);
                    }


                }

                return rList;
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

        #region 自定义
        public T_OfficeAutomation_Document_LinkageCoordination Add(T_OfficeAutomation_Document_LinkageCoordination t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_Document_LinkageCoordination Edit(T_OfficeAutomation_Document_LinkageCoordination t)
        {
            return dal.Edit(t);
        }

        public bool Exist(T_OfficeAutomation_Document_LinkageCoordination t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public T_OfficeAutomation_Document_LinkageCoordination GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_Document_LinkageCoordination>(where);
        }
        #endregion
    }
}
