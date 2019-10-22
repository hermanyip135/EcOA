using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.DirectoryServices;

namespace DataAccess.Operate
{
    public class DA_Employee_Inherit:SqlInteractionBase
    {

        /// <summary>
        /// 根据工号查在职劳务和正职
        /// </summary>
        /// <param name="sEmployeeID"></param>
        /// <returns></returns>
        public DataSet GetEmployeeAndLabour(string sEmployeeID)
        {
            string sql = @"SELECT * FROM (
                            SELECT 
                                  [Code],[EmployeeName],[CardID],[UnitName],[UnitID],[PositionName],[EnterDate],[InDueDate]
                            FROM 
                                 [GZS-HRDB01].DB_EcHR.dbo.v_Report_WorkInfoNotIncludeBeiWang where Code='" + sEmployeeID+"'";
                         sql+= @"UNION 
                            SELECT Labour_SerialNO,Labour_EmployeeName,Labour_IDNO,Labour_Apply_Department,Labour_Apply_DepartmentID,'劳务',Labour_Apply_Begin,''
	                            FROM [GZS-HRDB01].DB_EcHR.dbo.v_Labour_WorkInfo 
	                            WHERE Labour_SerialNO NOT IN (
		                            SELECT rwinibw.Code FROM [GZS-HRDB01].DB_EcHR.dbo.v_Report_WorkInfoNotIncludeBeiWang AS rwinibw
	                            ) AND Labour_SerialNO ='" + sEmployeeID+"')A";
            return RunSQL(sql);
        }
        /// <summary>
        /// 通过工号获取相应员工信息，连接hrdb01的在职人员视图
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public DataSet GetEmployeeInfoByEmployeeID(string employeeID)
        {
            string sql = "SELECT [EM_ID],[EmployeeName],[Code],[Sex],[CardID],[UnitID],[UnitName],[UnitCode],[BusinessGroupName],[CompanyName],[CompanyCode],[DepartmentName]"
                          + " ,[DepartmentCode],[PositionID],[PositionName],[PositionCode],[JobName],[JobID],[JobCategoryID],[JobCategoryName],[JobClassName],[JobClassNameID],[JobGrade]"
                          + " ,[JobGradeID],[JobGradeLevel],[Speciality],[SpecialityCatergory],[SpecialityCode],[SpecialityLevel],[EmployeeType],[EnterDate],[InDueDate],[DimissionTime],[ServicePeriod]"
                          + " ,[FullName],[K3UnitCode],[EMail],[Telphone] FROM [GZS-HRDB01].DB_EcHR.dbo.v_Report_WorkInfoNotIncludeBeiWang where Code='" + employeeID + "'";
            return RunSQL(sql);
        }

        /// <summary>
        /// 通过姓名获取相应员工信息，连接hrdb01的在职人员视图
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public DataSet GetEmployeeInfoByEmployeeNames(string sName)
        {
            string sql = "SELECT [EM_ID],[EmployeeName],[Code],[CardID],[UnitID],[UnitName],[UnitCode],[BusinessGroupName],[CompanyName],[CompanyCode],[DepartmentName]"
                          + " ,[DepartmentCode],[PositionID],[PositionName],[PositionCode],[JobName],[JobID],[JobCategoryID],[JobCategoryName],[JobClassName],[JobClassNameID],[JobGrade]"
                          + " ,[JobGradeID],[JobGradeLevel],[Speciality],[SpecialityCatergory],[SpecialityCode],[SpecialityLevel],[EmployeeType],[EnterDate],[InDueDate],[DimissionTime],[ServicePeriod]"
                          + " ,[FullName],[K3UnitCode],[EMail],[Telphone] FROM [GZS-HRDB01].DB_EcHR.dbo.v_Report_WorkInfoNotIncludeBeiWang where EmployeeName='" + sName + "'";
            return RunSQL(sql);
        }

        /// <summary>
        /// 通过部门名称获取相关信息，连接hrdb01的在职人员视图
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public DataSet GetEmployeeInfoByUnitName(string UnitName)
        {
            string sql = "SELECT [EM_ID],[EmployeeName],[Code],[CardID],[UnitID],[UnitName],[UnitCode],[BusinessGroupName],[CompanyName],[CompanyCode],[DepartmentName]"
                          + " ,[DepartmentCode],[PositionID],[PositionName],[PositionCode],[JobName],[JobID],[JobCategoryID],[JobCategoryName],[JobClassName],[JobClassNameID],[JobGrade]"
                          + " ,[JobGradeID],[JobGradeLevel],[Speciality],[SpecialityCatergory],[SpecialityCode],[SpecialityLevel],[EmployeeType],[EnterDate],[InDueDate],[DimissionTime],[ServicePeriod]"
                          + " ,[FullName],[K3UnitCode],[EMail],[Telphone] FROM [GZS-HRDB01].DB_EcHR.dbo.v_Report_WorkInfoNotIncludeBeiWang where UnitName='" + UnitName + "'";
            return RunSQL(sql);
        }

        /// <summary>
        /// 通过EMail获取相应员工信息，连接hrdb01的在职人员视图
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public DataSet GetEmployeeInfoByEmployeeEMail(string EMail)
        {
            string sql = "SELECT [EM_ID],[EmployeeName],[Code],[CardID],[UnitID],[UnitName],[UnitCode],[BusinessGroupName],[CompanyName],[CompanyCode],[DepartmentName]"
                          + " ,[DepartmentCode],[PositionID],[PositionName],[PositionCode],[JobName],[JobID],[JobCategoryID],[JobCategoryName],[JobClassName],[JobClassNameID],[JobGrade]"
                          + " ,[JobGradeID],[JobGradeLevel],[Speciality],[SpecialityCatergory],[SpecialityCode],[SpecialityLevel],[EmployeeType],[EnterDate],[InDueDate],[DimissionTime],[ServicePeriod]"
                          + " ,[FullName],[K3UnitCode],[EMail],[Telphone] FROM [GZS-HRDB01].DB_EcHR.dbo.v_Report_WorkInfoNotIncludeBeiWang where EMail='" + EMail + "'";
            return RunSQL(sql);
        }

        /// <summary>
        /// 通过姓名获取相应工号，连接hrdb01的在职人员视图
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public DataSet GetEmployeeInfoByEmployeeName(string employeenames)
        {
            //string sql = "SELECT [EmployeeName],[Code] FROM [GZS-HRDB01].DB_EcHR.dbo.v_Report_WorkInfoNotIncludeBeiWang where EmployeeName in (" + employeenames + ")";
            ////2014-3-25 改为去除物业部营业类1到3级人员
            //string sql = "SELECT [EmployeeName],[Code] FROM [GZS-HRDB01].DB_EcHR.dbo.v_Report_WorkInfoNotIncludeBeiWang where EmployeeName in (" + employeenames + ") and NOT (UnitCode like '%KD01.0001.0001%' AND UnitName != '项目部秘书组' AND (JobGradeLevel=1 OR JobGradeLevel=2 OR JobGradeLevel=3) AND JobCategoryName='营业类' )";
            //2014-4-15 增加去除行业备忘部的人的条件
            string sql = "SELECT [EmployeeName],[Code] FROM [GZS-HRDB01].DB_EcHR.dbo.v_Report_WorkInfoNotIncludeBeiWang where EmployeeName in (" + employeenames + ") AND NOT UnitName='行业备忘部'";
            return RunSQL(sql);
        }

        /// <summary>
        /// 通过姓名获取相应工号，连接hrdb01的在职人员视图，并按职级排列
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public DataSet GetEmployeeInfoByEmployeeName2(string employeenames)
        {
            //string sql = "SELECT [EmployeeName],[Code] FROM [GZS-HRDB01].DB_EcHR.dbo.v_Report_WorkInfoNotIncludeBeiWang where EmployeeName in (" + employeenames + ")";
            ////2014-3-25 改为去除物业部营业类1到3级人员
            //string sql = "SELECT [EmployeeName],[Code] FROM [GZS-HRDB01].DB_EcHR.dbo.v_Report_WorkInfoNotIncludeBeiWang where EmployeeName in (" + employeenames + ") and NOT (UnitCode like '%KD01.0001.0001%' AND UnitName != '项目部秘书组' AND (JobGradeLevel=1 OR JobGradeLevel=2 OR JobGradeLevel=3) AND JobCategoryName='营业类' )";
            //2014-4-15 增加去除行业备忘部的人的条件
            string sql = "SELECT [EmployeeName],[Code] FROM [GZS-HRDB01].DB_EcHR.dbo.v_Report_WorkInfoNotIncludeBeiWang where EmployeeName in (" + employeenames + ") AND NOT UnitName='行业备忘部' AND Code not like 'F%' ORDER BY JobGradeLevel,PositionCode";
            return RunSQL(sql);
        }

        #region 变量定义（域用户登录设置）
        private string[] sUser = { "5000public", "IT..168" }; //域用户登录
        #endregion

        #region 根据姓名取当前用户的Email
        /// <summary>
        /// 根据姓名取当前用户的Email
        /// </summary>
        /// <returns></returns>
        private string getUserEmail(string sName)
        {
            //string sSql = "select EMail from [gzs-hrdb01].AIS20050623105602.dbo.HM_Employees " +
            //        "where Name='" + sName + "'";
            string sSql = "select Email ";
            sSql += " from [gzs-hrdb01].Onduty.[dbo].[Employee] ";
            sSql += " where EmpName='" + sName + "'";
            DataSet ds = RunSQL(sSql);

            if (ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0]["Email"].ToString();
            else
                return "";
        }
        #endregion

        #region 根据姓名获取K3的Email
        /// <summary>
        /// 根据姓名获取K3的Email
        /// </summary>
        /// <returns></returns>
        private string getSTEmail(string sName)
        {
            //string sSql = "select EMail from [gzs-hrdb01].AIS20050623105602.dbo.HM_Employees " +
            //        "where Name='" + sName + "'";
            DataSet ds = GetEmployeeInfoByEmployeeNames(sName);
            if (ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0]["EMail"].ToString();
            else
                return "";
        }
        #endregion










        #region 根据Email取当前用户的工号
        /// <summary>
        /// 根据Email取当前用户的工号
        /// </summary>
        /// <returns></returns>
        public string getUserNameByEmail(string Email)
        {
            string sSql = "select EmpName";
            sSql += " from [gzs-hrdb01].Onduty.[dbo].[Employee] ";
            sSql += " where Email ='" + Email + "'";
            DataSet ds = RunSQL(sSql);

            if (ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0]["Code"].ToString();
            else
                return "";
        }
        #endregion

        #region 根据Email获取K3的工号
        /// <summary>
        /// 根据Email获取K3的工号
        /// </summary>
        /// <returns></returns>
        public string getSTByEmail(string Email)
        {
            //string sSql = "select EMail from [gzs-hrdb01].AIS20050623105602.dbo.HM_Employees " +
            //        "where Name='" + sName + "'";
            DataSet ds = GetEmployeeInfoByEmployeeEMail(Email);
            if (ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0]["Code"].ToString();
            else
                return "";
        }
        #endregion











        #region 获取邮箱（先从域用户中查找用户邮箱，如果没有，再从K3查找）
        /// <summary>
        /// 获取邮箱（先从人事系统找，再从域用户中查找用户邮箱，如果没有，再从K3查找）
        /// </summary>
        /// <returns></returns>
        public string getDomainUserEmail(string username)
        {
            string email = "";
            email = getUserEmail(username);
            if (string.IsNullOrEmpty(email))
            {
                try
                {
                    if (username != "")
                    {
                        string ADPath = "LDAP:// CENTALINE";

                        using (DirectoryEntry root = new DirectoryEntry(ADPath, sUser[0], sUser[1], AuthenticationTypes.Secure))
                        {
                            DirectorySearcher ds = new DirectorySearcher(root);
                            ds.Filter = "(&(objectClass=user)(Name=" + username + "))";
                            ds.PropertiesToLoad.Add("description");
                            ds.PropertiesToLoad.Add("memberOf");

                            foreach (SearchResult res in ds.FindAll())
                            {
                                bool flag = false;
                                if (null != res)
                                {
                                    if ((res.Properties["description"][0]).ToString().Trim().Substring(0, 2) == "AD")
                                    {
                                        foreach (string s in res.Properties["memberOf"])
                                        {
                                            if (s.Contains("广州"))
                                            {
                                                email = res.GetDirectoryEntry().Properties["mail"].Value.ToString();
                                                flag = true;
                                                break;
                                            }
                                        }
                                    }
                                }

                                if (flag)
                                    break;
                            }

                            //如果按原姓名找不到域用户的邮箱，则如果原姓名包含ABC，则替换为空再找域用户。
                            if (string.IsNullOrEmpty(email))
                            {
                                email = getUserEmail(username);
                                if (string.IsNullOrEmpty(email))
                                    email = getSTEmail(username);
                            }
                        }
                    }
                    return email;

                }
                catch
                {
                    //return getUserEmail(username);
                    return getSTEmail(username);
                }
            }
            else
                return email;

        }
        #endregion

        public string GetDepByCode(string code)
        {
            var ds = GetEmployeeInfoByEmployeeID(code);
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                System.Data.DataRow dr = ds.Tables[0].Rows[0];
                return dr["DepartmentName"].ToString();
            }
            else
            {
                return "";
            }
        }

        #region 根据员工姓名模糊查询
        public DataSet getEmpInfoByEmpName(string empname) 
        {
            string sql = "SELECT [EmployeeName],[Code] FROM [GZS-HRDB01].DB_EcHR.dbo.v_Report_WorkInfoNotIncludeBeiWang where EmployeeName like '%" + empname + "%'";
            return RunSQL(sql);
        }
        #endregion
    }
}
