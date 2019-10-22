using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Assets_Inherit : SqlInteractionBase
    {
        /// <summary>
        /// 通过名称查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByName(string sname)
        {
            string sql = "SELECT  [OfficeAutomation_Document_Assets_Num]"
                           + "           ,[OfficeAutomation_Document_Assets_NAME]"
                           + "           ,[OfficeAutomation_Document_Assets_Scount]"
                           + "           ,[OfficeAutomation_Document_Assets_IsIT]"
                           + "           ,[OfficeAutomation_Document_Assets_Summary]"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Assets]"
                           + " WHERE OfficeAutomation_Document_Assets_NAME='" + sname + "'";
            return RunSQL(sql);
        }

        /// <summary>
        /// 通过名称找资产
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectInventory(string sname)
        {
            string sql = "SELECT MAX(OfficeAutomation_Document_Assets_FinancialNum) [Financial],OfficeAutomation_Document_Assets_NAME,OfficeAutomation_Document_Assets_Summary [Summary],COUNT(OfficeAutomation_Document_Assets_FinancialNum) [Count]"
                           + "           FROM t_OfficeAutomation_Document_Assets"
                           + "           WHERE OfficeAutomation_Document_Assets_NAME = '" + sname + "'"
                           + "           AND OfficeAutomation_Document_Assets_SCount != 0"
                           + "           GROUP BY OfficeAutomation_Document_Assets_NAME,OfficeAutomation_Document_Assets_Summary";
            return RunSQL(sql);
        }

        /// <summary>
        /// 查找最大编号的净资产
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectA()
        {
            string sql = "SELECT MAX(OfficeAutomation_Document_Assets_FinancialNum) [Financial],OfficeAutomation_Document_Assets_NAME"
                           + "           FROM t_OfficeAutomation_Document_Assets"
                           + "           WHERE OfficeAutomation_Document_Assets_SCount != 0"
                           + "           GROUP BY OfficeAutomation_Document_Assets_NAME";
            return RunSQL(sql);
        }

        /// <summary>
        /// 查找最大编号的所有资产
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectAt()
        {
            string sql = "SELECT MAX(OfficeAutomation_Document_Assets_FinancialNum) [Financial],OfficeAutomation_Document_Assets_NAME"
                           + "           FROM t_OfficeAutomation_Document_Assets"
                           + "           GROUP BY OfficeAutomation_Document_Assets_NAME";
            return RunSQL(sql);
        }

        /// <summary>
        /// 查找所有资产
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectAllAssets()
        {
            string sql = "SELECT  [OfficeAutomation_Document_Assets_Num]"
                           + "           ,[OfficeAutomation_Document_Assets_NAME]"
                           + "           ,[OfficeAutomation_Document_Assets_Scount]"
                           + "           ,[OfficeAutomation_Document_Assets_IsIT]"
                           + "           ,[OfficeAutomation_Document_Assets_Summary]"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Assets]";
            return RunSQL(sql);
        }

        /// <summary>
        /// 查找剩余资产
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectRemateAssets()
        {
            string sql = "SELECT  [OfficeAutomation_Document_Assets_Num]"
                           + "           ,[OfficeAutomation_Document_Assets_NAME]"
                           + "           ,[OfficeAutomation_Document_Assets_Scount]"
                           + "           ,[OfficeAutomation_Document_Assets_IsIT]"
                           + "           ,[OfficeAutomation_Document_Assets_Summary]"
                           + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Assets]"
                           + " WHERE OfficeAutomation_Document_Assets_Scount > 0";
            return RunSQL(sql);
        }

        /// <summary>
        /// 更新数量
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public bool UpdateScount(int count, string na)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Assets]"
                            + " SET OfficeAutomation_Document_Assets_Scount = " + count
                            + " WHERE OfficeAutomation_Document_Assets_NAME = '" + na + "'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 置位/设0数量
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public bool UpdateToggleZero(string na, int n)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Assets]"
                            + " SET OfficeAutomation_Document_Assets_Scount = " + n
                            + " WHERE OfficeAutomation_Document_Assets_FinancialNum = '" + na + "'";
            return RunNoneSQL(sql);
        }
    }
}
