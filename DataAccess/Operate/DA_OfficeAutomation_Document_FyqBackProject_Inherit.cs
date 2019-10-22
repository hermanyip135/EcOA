using DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_FyqBackProject_Inherit 
    {
        DA_OfficeAutomation_Document_FyqBackProject_Operate dal = new DA_OfficeAutomation_Document_FyqBackProject_Operate();
        public T_OfficeAutomation_Document_FyqBackProject GetModel(string MainID)
        {
            string where = "OfficeAutomation_Document_FyqBackProject_MainId = '" + MainID+"'";
            return dal.GetModel(where);
        }
        public DataSet SelectByMainID(string mainID)
        {
            return dal.SelectByMainID(mainID); ;
        }
        public T_OfficeAutomation_Document_FyqBackProject Edit(T_OfficeAutomation_Document_FyqBackProject t)
        {
            return dal.Edit(t);
        }
        public T_OfficeAutomation_Document_FyqBackProject Add(T_OfficeAutomation_Document_FyqBackProject t)
        {
            return dal.Add(t);
        }
    }
}
