using System;
using System.Collections.Generic;
using System.Text;
using DataEntity;
using System.Data;
using ECOA.Common;

namespace DataAccess.Operate
{
    public class DA_Dic_OfficeAutomation_Document_Inherit : DA_Dic_OfficeAutomation_Document_Operate
    {
        private DAL.DalBase<T_Dic_OfficeAutomation_Document> dal;
        public DA_Dic_OfficeAutomation_Document_Inherit()
        {
            dal = new DAL.DalBase<T_Dic_OfficeAutomation_Document>();
        }

        //public DataSet SelectAll()
        //{
        //    return SelectAll();
        //}

        public List<T_Dic_OfficeAutomation_Document> SelectAllList()
        {
            var ds = SelectAll();
            if (ds == null)
            {
                return null;
            }
            List<T_Dic_OfficeAutomation_Document> list = new List<T_Dic_OfficeAutomation_Document>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new T_Dic_OfficeAutomation_Document {
                    OfficeAutomatifon_Document_ID = Convert.ToInt32(dr["OfficeAutomation_Document_ID"]),
                    OfficeAutomation_Document_Name = dr["OfficeAutomation_Document_Name"].ToString(),
                    OfficeAutomation_Document_TableName = dr["OfficeAutomation_Document_TableName"].ToString()
                });
            }
            return list;
        }

        public List<T_Dic_OfficeAutomation_Document> SelectAllListInCache()
        {
            var c = CacheHelper.GetCache("ECOADocument");
            if (c == null)
            {
                var l = SelectAllList();
                TimeSpan span = DateTime.Now - DateTime.Now.AddMinutes(-10);
                CacheHelper.SetCache("ECOADocument", l, span);
                return l;
            }
            else
                return (List<T_Dic_OfficeAutomation_Document>)c;
        }
    }
}
