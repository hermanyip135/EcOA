using DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
   public class DA_OfficeAutomation_Document_UtContract_PlanScale_Inherit
    {
       DA_OfficeAutomation_Document_UtContract_PlanScale_Operate dal = new DA_OfficeAutomation_Document_UtContract_PlanScale_Operate();
       public T_OfficeAutomation_Document_UtContract_PlanScale Add(T_OfficeAutomation_Document_UtContract_PlanScale t)
        {
            return dal.Add(t);
        }
        public DataSet SelectByMainID(string MainID)
        {
            string sql = @"SELECT
                            OfficeAutomation_Document_UtContract_PlanScale_ID
                            ,OfficeAutomation_Document_UtContract_PlanScale_MainID
                            ,OfficeAutomation_Document_UtContract_PlanScale_EmployeeID
                            ,OfficeAutomation_Document_UtContract_PlanScale_EmployeeName
                            ,OfficeAutomation_Document_UtContract_PlanScale_UnitName
                            ,OfficeAutomation_Document_UtContract_PlanScale_Scale
                            ,CONVERT(varchar(100), OfficeAutomation_Document_UtContract_PlanScale_BeginDate, 23) OfficeAutomation_Document_UtContract_PlanScale_BeginDate
                            ,CONVERT(varchar(100), OfficeAutomation_Document_UtContract_PlanScale_EndDate, 23) OfficeAutomation_Document_UtContract_PlanScale_EndDate
                            ,OfficeAutomation_Document_UtContract_PlanScale_Sort
                            ,OfficeAutomation_Document_UtContract_PlanScale_AddDate 
                             FROM T_OfficeAutomation_Document_UtContract_PlanScale 
                            WHERE OfficeAutomation_Document_UtContract_PlanScale_MainID ='" + MainID+"'AND OfficeAutomation_Document_UtContract_PlanScale_IsDelete != 1";
            return dal.OperationSQL(sql);
        }
        public T_OfficeAutomation_Document_UtContract_PlanScale Edit(T_OfficeAutomation_Document_UtContract_PlanScale t)
        {
            return dal.Edit(t);
        }
        public bool DelByMainID(string MainID)
        {
            return dal.DelByMainID(MainID);
        }
        public IList<T_OfficeAutomation_Document_UtContract_PlanScale> SelectListByMainID(string mainID)
        {
            DataTable dt = SelectByMainID(mainID).Tables[0];
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            DataTable dtCopy = dt.Copy();

            DataView dv = dt.DefaultView;
            dv.Sort = "OfficeAutomation_Document_UtContract_PlanScale_Sort";
            dtCopy = dv.ToTable();
            return ECOA.Common.SerializationHelper.GetEntities<T_OfficeAutomation_Document_UtContract_PlanScale>(dtCopy);
        }
    }
}
