using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_Department_Inherit : SqlInteractionBase
    {
        #region 根据部门id获取部门信息
        public DataSet GetDepartmentInfoByDeptId(string deptId)
        {
            string sql = "SELECT * FROM [gzs-systemdb02].[DB_FKB_SERVICE].[dbo].[base_department] where dept_id='" + deptId + "'";
            return RunSQL(sql);
        }
        #endregion

        #region 根据部门名称获取部门信息
        public DataSet GetDepartmentInfoByDeptName(string deptName)
        {
            string sql = "SELECT * FROM [gzs-systemdb02].[DB_FKB_SERVICE].[dbo].[base_department] where dept_name='" + deptName + "'";
            return RunSQL(sql);
        }
        #endregion

        #region 获取所有部门
        public DataSet GetDepartmentList()
        {
            string sql = "SELECT DISTINCT [dept_id],[dept_name] FROM [gzs-systemdb02].[DB_FKB_SERVICE].[dbo].[base_department] WHERE  [full_dept_code] LIKE 'KD01.0001%' or full_dept_code like'%KD01.0007%' union all select  '108E0F54-5070-4745-A491-37F15D5A86CD', '董事总经理' ORDER  BY [dept_name]";
            return RunSQL(sql);
        }
        #endregion
    }
}
