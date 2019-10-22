using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_MCOA_Attach_Operate
    {
        private DAL.DalBase<T_OfficeAutomation_MCOA_Attach> dal = new DAL.DalBase<T_OfficeAutomation_MCOA_Attach>();

        public DataEntity.T_OfficeAutomation_MCOA_Attach Add(DataEntity.T_OfficeAutomation_MCOA_Attach t)
        {
            return dal.Add(t);
        }

        public T_OfficeAutomation_MCOA_Attach Edit(T_OfficeAutomation_MCOA_Attach t)
        {
            return dal.Edit(t);
        }

        public bool Exist(DataEntity.T_OfficeAutomation_MCOA_Attach t)
        {
            return dal.Exist(t);
        }

        public bool Exist(string where)
        {
            return dal.Exist(where);
        }

        public DataEntity.T_OfficeAutomation_MCOA_Attach GetModel(string where)
        {
            return dal.GetModel<T_OfficeAutomation_MCOA_Attach>(where);
        }
    }
}
