using System;
using System.Data;
using System.Xml;
using System.Collections;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess.Operate
{
    public class DA_Login_Inherit : SqlInteractionBase
    {
        #region 身份验证 连接至权限系统
        /// <summary>
        /// 身份验证 连接至权限系统数据库
        /// </summary>
        /// <param name="sLoginID"></param>
        /// <param name="sPassword"></param>
        /// <param name="bLogin_IsBusiness"></param>
        /// <param name="iLogin_ID"></param>
        /// <returns></returns>
        public bool Login_Check(string sLoginID, string sPassword, out bool bLogin_IsBusiness, out int iLogin_ID)
        {
            KDHR.Service Service = new KDHR.Service();
            string sKDHR;
            bLogin_IsBusiness = false;
            iLogin_ID = 0;
            bool isReturn = false;
           
            sKDHR = Service.getEmployeeStatus(sLoginID);
            //潘宇馥变成劳务需要通过以下情况才登陆系统
            if ("1909".Equals(sLoginID))
            {
                sKDHR = "927fa0ab-c918-41f7-ad1c-d2cf8d1abbe0";
            }
            if (sKDHR == "")
            {
                return false;
            }

            AppSettingsReader _configReader = new AppSettingsReader();

            SqlDataAdapter dsCommand = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                dsCommand.SelectCommand = new SqlCommand();
                dsCommand.SelectCommand.Connection = new SqlConnection(_configReader.GetValue("Main.ConnectionString1", typeof(string)).ToString());

                dsCommand.SelectCommand.CommandText = "dbo.[pr_EC_Login_Check]";
                dsCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
                dsCommand.SelectCommand.CommandTimeout = 0;
                dsCommand.SelectCommand.Parameters.Add(new SqlParameter("@guidLogin_KDHRID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(sKDHR)));
                dsCommand.SelectCommand.Parameters.Add(new SqlParameter("@sLogin_Password", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, sPassword));
                dsCommand.SelectCommand.Parameters.Add(new SqlParameter("@bLogin_IsBusiness", SqlDbType.Bit, 1, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, bLogin_IsBusiness));
                dsCommand.SelectCommand.Parameters.Add(new SqlParameter("@iLogin_ID", SqlDbType.Int, 8, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, iLogin_ID));

                if (dsCommand.SelectCommand.Connection.State != ConnectionState.Open)
                    dsCommand.SelectCommand.Connection.Open();

                _rowsAffected = dsCommand.SelectCommand.ExecuteNonQuery();

                if (_rowsAffected == 1)
                {
                    bLogin_IsBusiness = Convert.ToBoolean(dsCommand.SelectCommand.Parameters["@bLogin_IsBusiness"].Value.ToString());
                    iLogin_ID = Convert.ToInt32(dsCommand.SelectCommand.Parameters["@iLogin_ID"].Value.ToString());
                    isReturn = true;
                }
                dsCommand.Fill(ds);

                return isReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dsCommand != null)
                {
                    if (dsCommand.SelectCommand != null)
                    {
                        if (dsCommand.SelectCommand.Connection != null)
                            dsCommand.SelectCommand.Connection.Dispose();
                        dsCommand.SelectCommand.Dispose();
                    }
                    dsCommand.Dispose();
                    dsCommand = null;
                }
            }
        }

        /// <summary>
        /// 2019-08-28 身份验证 连接至权限系统数据库
        /// </summary>
        /// <param name="sLoginID"></param>
        /// <param name="sPassword"></param>
        /// <param name="bLogin_IsBusiness"></param>
        /// <param name="iLogin_ID"></param>
        /// <returns></returns>
        public DataSet Login_Check(string sLoginID, string sPassword)
        {
            AppSettingsReader _configReader = new AppSettingsReader();

            SqlDataAdapter dsCommand = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                dsCommand.SelectCommand = new SqlCommand();
                dsCommand.SelectCommand.Connection = new SqlConnection(_configReader.GetValue("Main.ConnectionString1", typeof(string)).ToString());

                dsCommand.SelectCommand.CommandText = "dbo.[pr_LoginCheck]";
                dsCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
                dsCommand.SelectCommand.CommandTimeout = 0;
                dsCommand.SelectCommand.Parameters.Add(new SqlParameter("@sEmpCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, sLoginID));
                dsCommand.SelectCommand.Parameters.Add(new SqlParameter("@sPwd", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, sPassword));
                

                if (dsCommand.SelectCommand.Connection.State != ConnectionState.Open)
                    dsCommand.SelectCommand.Connection.Open();

                dsCommand.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dsCommand != null)
                {
                    if (dsCommand.SelectCommand != null)
                    {
                        if (dsCommand.SelectCommand.Connection != null)
                            dsCommand.SelectCommand.Connection.Dispose();
                        dsCommand.SelectCommand.Dispose();
                    }
                    dsCommand.Dispose();
                    dsCommand = null;
                }
            }

            return ds;
        }
        #endregion

        #region 密码修改
        public bool Pwd_Change(string sKDHRID, string sPassword, bool bLogin_IsBusiness)
        {
            AppSettingsReader _configReader = new AppSettingsReader();
            SqlDataAdapter dsCommand = new SqlDataAdapter();

            try
            {
                dsCommand.SelectCommand = new SqlCommand();
                dsCommand.SelectCommand.Connection = new SqlConnection(_configReader.GetValue("Main.ConnectionString1", typeof(string)).ToString());

                dsCommand.SelectCommand.CommandText = "dbo.[pr_t_Login_Update]";
                dsCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
                dsCommand.SelectCommand.CommandTimeout = 0;
                dsCommand.SelectCommand.Parameters.Add(new SqlParameter("@guidLogin_KDHRID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(sKDHRID)));
                dsCommand.SelectCommand.Parameters.Add(new SqlParameter("@sLogin_Password", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, sPassword));
                dsCommand.SelectCommand.Parameters.Add(new SqlParameter("@bLogin_IsBusiness", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, bLogin_IsBusiness));

                if (dsCommand.SelectCommand.Connection.State != ConnectionState.Open)
                    dsCommand.SelectCommand.Connection.Open();

                _rowsAffected = dsCommand.SelectCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dsCommand != null)
                {
                    if (dsCommand.SelectCommand != null)
                    {
                        if (dsCommand.SelectCommand.Connection != null)
                            dsCommand.SelectCommand.Connection.Dispose();
                        dsCommand.SelectCommand.Dispose();
                    }
                    dsCommand.Dispose();
                    dsCommand = null;
                }
            }
        }
        #endregion
    }
}
