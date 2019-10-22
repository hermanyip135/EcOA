using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BorrowMoney_Import_Inherit : DA_OfficeAutomation_Document_BorrowMoney_Import_Operate
    {
       //DA_OfficeAutomation_Document_BorrowMoney_Import_Operate dal = new DA_OfficeAutomation_Document_BorrowMoney_Import_Operate();
       /// <summary>
       /// 根据流水号合计金额
       /// </summary>
       /// <param name="SerialNumber">流水号</param>
       /// <param name="type">借/冲</param>
       /// <returns></returns>
       public string getCalculationMoney(string SerialNumber,string type)
       {
           string sql = @" select isnull(sum(OfficeAutomation_Document_BorrowMoney_Import_Money),0) Money from t_OfficeAutomation_Document_BorrowMoney_Import
              where OfficeAutomation_Document_BorrowMoney_Import_ApplyID ='" + SerialNumber + "'and OfficeAutomation_Document_BorrowMoney_Import_Type ='" + type + "'";
           DataSet ds = RunSQL(sql);
         return  ds.Tables[0].Rows[0]["Money"].ToString();
       }
    }
}
