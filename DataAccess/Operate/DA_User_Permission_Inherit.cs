using System;
using System.Data;
using System.Xml;
using System.Collections;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess.Operate
{
    public class DA_User_Permission_Inherit : SqlInteractionBase
    {
        #region 取某人的权限 连接权限系统
        /// <summary>
        /// 取某人的权限 连接权限系统
        /// </summary>
        /// <param name="iLogin"></param>
        /// <returns></returns>
        public DataTable getUserPurview(int iLogin)
        {
            string strSQL = "select Permission_Module_Purview from t_System_Permission where Permission_LoginID=@iLogin";
            AppSettingsReader _configReader = new AppSettingsReader();

            SqlDataAdapter dsCommand = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                dsCommand.SelectCommand = new SqlCommand();
                dsCommand.SelectCommand.Connection = new SqlConnection(_configReader.GetValue("Main.ConnectionString1", typeof(string)).ToString());

                dsCommand.SelectCommand.CommandText = strSQL;
                dsCommand.SelectCommand.CommandType = CommandType.Text;
                dsCommand.SelectCommand.CommandTimeout = 0;
                dsCommand.SelectCommand.Parameters.Add(new SqlParameter("@iLogin", iLogin));

                if (dsCommand.SelectCommand.Connection.State != ConnectionState.Open)
                    dsCommand.SelectCommand.Connection.Open();

                dsCommand.SelectCommand.ExecuteNonQuery();
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

            return ds.Tables[0];
        }
        #endregion

        public DataTable getUserRegion(string code)
        {
            string sql = @"
                            select 
                            EmpCode,
                            EmpName,
                            case when AreaName ='工商铺总经理(罗思源)'then '工商铺一部' 
                            when AreaName ='海珠区'then '大海珠区'
                            when AreaName ='白云区'then '大白云区'
                            when AreaName ='越秀区'then '大越秀区'
                            when AreaName ='番禺区'then '番禺一部'        
                            else AreaName end AreaName,
                            UnitID,
                            UnitName,
                            UnitCode
                             from (
                            SELECT T.EmpCode, T.EmpName,MAX(AreaName) AreaName, T.UnitID, T.UnitName, T.UnitCode  FROM (
	                        SELECT rwinibw.Code AS EmpCode, rwinibw.EmployeeName AS EmpName, rwinibw.UnitID AS UnitID,
		                           rwinibw.UnitName AS UnitName, rwinibw.DepartmentCode AS UnitCode, gafk.Code AS AreaCode,
		                           gafk.AreaName AS AreaName
	                        FROM [GZS-HRDB01].DB_EcHR.dbo.v_Report_WorkInfoNotIncludeBeiWang AS rwinibw  
	                          LEFT JOIN [GZS-HRDB01].DB_EcHR.dbo.v_GetAreaFromK3 AS gafk ON rwinibw.DepartmentCode LIKE gafk.Code +'%'
                        ) AS T
                        WHERE T.EmpCode='{0}'  group by  EmpCode,EmpName,UnitID,UnitName,UnitCode
                        )T1";
            sql = string.Format(sql, code);
           DataTable dt= RunSQL(sql).Tables[0];
           return dt;
        }
    }
}
