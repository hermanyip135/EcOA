
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using DataEntity;

namespace DataAccess.Operate
{
	/// <summary>
	/// 数据访问类:DA_OfficeAutomation_Document_ExtraBonus_Detail
	/// </summary>
    public partial class DA_OfficeAutomation_Document_ExtraBonus_Detail_Inherit : DA_OfficeAutomation_Document_ExtraBonus_Detail_Operate
	{
        public DA_OfficeAutomation_Document_ExtraBonus_Detail_Inherit()
		{}

        public DataSet SelectByApplyID(string ID)
        {
            string sWhere = "OfficeAutomation_Document_ExtraBonus_Detail_MainID ='" + ID +"'"
                + " order by OfficeAutomation_Document_ExtraBonus_Detail_OrderBy asc";
            return GetList(sWhere);
        }
    }
}

