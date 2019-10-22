using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity;
using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BusinessTravel_Inherit
    {
        DA_OfficeAutomation_Document_BusinessTravel_Operate dal = new DA_OfficeAutomation_Document_BusinessTravel_Operate();
        public T_OfficeAutomation_Document_BusinessTravel Add(T_OfficeAutomation_Document_BusinessTravel t)
        {
            return dal.Add(t);
        }
        public DataSet SelectByMainID(string MainID)
        {
            return dal.SelectByMainID(MainID);
        }
        public T_OfficeAutomation_Document_BusinessTravel Edit(T_OfficeAutomation_Document_BusinessTravel t)
        {
            return dal.Edit(t);
        }

    }
}
