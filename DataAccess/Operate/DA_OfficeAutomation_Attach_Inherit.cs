using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Attach_Inherit : DA_OfficeAutomation_Attach_Operate
    {
        public DA_OfficeAutomation_Attach_Inherit()
        {

        }

        /// <summary>
        /// 通过MainID获取该单附件列表
        /// </summary>
        /// <param name="maintainID">Maintain_ID</param>
        /// <returns></returns>
        public DataSet GetAttachByMainID(string mainID)
        {
            string sSql = "select * from t_OfficeAutomation_Attach where OfficeAutomation_Attach_MainID='" + mainID + "' ORDER BY OfficeAutomation_Attach_Name";

            return RunSQL(sSql);
        }

        /// <summary>
        /// 获取指定日期后的所有附件列表
        /// </summary>
        /// <param name="date">date</param>
        /// <returns></returns>
        public DataSet GetAttachByDate(DateTime date)
        {
            string sSql = @" select [OfficeAutomation_Attach_ID]
      ,[OfficeAutomation_Attach_MainID]
      ,[OfficeAutomation_Attach_Name]
      ,[OfficeAutomation_Attach_Path]
  from [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Main],[DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Attach]
  where [OfficeAutomation_Attach_MainID]=[OfficeAutomation_Main_ID] and [OfficeAutomation_Main_CrTime] between '" + date + "' and '" + DateTime.Now.AddDays(1) + "'order by [OfficeAutomation_Main_CrTime]";

            return RunSQL(sSql);
        }


        /// <summary>
        /// 通过MainID获取该单附件列表（排除特殊处理过的 //M_AssetAlter：20150827
        /// </summary>
        /// <param name="maintainID">Maintain_ID</param>
        /// <returns></returns>
        public DataSet GetAttachBesidessSp(string mainID)
        {
            string sSql = "select * from t_OfficeAutomation_Attach where OfficeAutomation_Attach_MainID='" + mainID + "' AND OfficeAutomation_Attach_Name NOT LIKE 'SpecialUplX%' ORDER BY OfficeAutomation_Attach_Name";

            return RunSQL(sSql);
        }

        /// <summary>
        /// 通过MainID获取特殊处理过的附件列表 //M_AssetAlter：20150827
        /// </summary>
        /// <param name="maintainID">Maintain_ID</param>
        /// <returns></returns>
        public DataSet GetAttachSp(string mainID)
        {
            string sSql = "select TOP 1 * from t_OfficeAutomation_Attach where OfficeAutomation_Attach_MainID='" + mainID + "' AND OfficeAutomation_Attach_Name LIKE 'SpecialUplX%'";

            return RunSQL(sSql);
        }

        /// <summary>
        /// 通过MainID删除特殊处理过的附件 //M_AssetAlter：20150827
        /// </summary>
        /// <param name="maintainID">Maintain_ID</param>
        /// <returns></returns>
        public bool DeleteAttachSp(string mainID)
        {
            string sSql = "DELETE FROM t_OfficeAutomation_Attach where OfficeAutomation_Attach_MainID='" + mainID + "' AND OfficeAutomation_Attach_Name LIKE 'SpecialUplX%'";

            return RunNoneSQL(sSql);
        }

        public override DataSet SelectAll()
        {
            string sSql = "SELECT * FROM t_OfficeAutomation_Attach";
            return RunSQL(sSql);
        }
        /// <summary>
        /// 通过MainID删除附件，用户保存汇瀚类中的网签变更、特殊申请表，删除所有的，然后重新保存
        /// </summary>
        /// <returns></returns>
        public bool DeleteAttachByMain(string mainID)
        {
            string sSql = "DELETE FROM t_OfficeAutomation_Attach where OfficeAutomation_Attach_MainID='" + mainID + "' and LEFT(OfficeAutomation_Attach_Name,2) like '%[_]%'";

            return RunNoneSQL(sSql);
        }

    }
}
