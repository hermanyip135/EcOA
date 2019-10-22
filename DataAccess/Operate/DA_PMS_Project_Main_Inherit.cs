using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_PMS_Project_Main_Inherit : DA_PMS_Project_Main_Operate
    {
        /// <summary>
        /// 获取PMS所有项目名
        /// </summary>
        /// <returns></returns>
        public DataSet fnGetALLProject()
        {
//            string sql = @"SELECT project_id, project_name
//                          FROM [10.3.19.39].[DB_PMS].[dbo].[Project_Main]
//                          WHERE [is_delete]=0";
            string sql = @"SELECT project_id,Undertake_ProjectName project_name
                          FROM [10.3.19.39].[DB_PMS].[dbo].[Project_Main]
                          WHERE [is_delete]=0";
            DataSet ds = RunSQL(sql);
            return ds;
        }
        /// <summary>
        /// PMS所有项目名转字符串
        /// </summary>
        /// <returns></returns>
        public string fnGetALLProjectListString()
        {
            StringBuilder sReturn = new StringBuilder("[");
            DataSet ds =  fnGetALLProject();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                sReturn.Append("{'id':'");
                sReturn.Append(row["project_id"].ToString());
                sReturn.Append("','value':'");
                sReturn.Append(row["project_name"].ToString());
                sReturn.Append("'},");
            }
            string result = sReturn.ToString().TrimEnd(new char[] { ',' });
            result = result + "]";

            //return js.Serialize(jsonOut.Obj.rows.Select(m => new { EstateID = m.EstateID, EstateName = m.EstateName }).ToList());
            return result;
        }
    }
}
