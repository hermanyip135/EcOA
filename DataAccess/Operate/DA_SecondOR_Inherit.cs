using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using DataEntity;

namespace DataAccess.Operate
{
    public class DA_SecondOR_Inherit : SqlInteractionBase
    {
        public DataSet SelectSecondOR()
        {
            string sql = "SELECT * FROM [c_c(ys)].[dbo].[project_M]";

            return RunSQLSecondOR(sql);
        }
    }
}
