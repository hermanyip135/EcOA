using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Loan_Detail_Inherit : DA_OfficeAutomation_Document_Loan_Detail_Operate
    {
        public Decimal SelectLoanMoneyByMainID(string sMainID)
        {
            Decimal money = 0;
            string sql = @"select 
                                 isnull(sum(OfficeAutomation_Document_Loan_Detail_LoanMoney),0)  as LoanMoney
                            from t_OfficeAutomation_Document_Loan_Detail 
                            where
                                OfficeAutomation_Document_Loan_Detail_MainID ='" + sMainID + "'";

            DataSet ds = RunSQL(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
              money =Convert.ToDecimal(ds.Tables[0].Rows[0]["LoanMoney"].ToString());
            }
            return money;
        }
        public Decimal LoanMoneyByMainID(string sMainID)
        {
            Decimal money = 0;
            string sql = @"select 
                                 isnull(sum(OfficeAutomation_Document_Loan_Detail_LoanMoney),0)  as LoanMoney
                            from t_OfficeAutomation_Document_Loan_Detail 
                            where
                                OfficeAutomation_Document_Loan_Detail_MainID =(
								select OfficeAutomation_Document_Loan_ID 
								from t_OfficeAutomation_Document_Loan 
								where OfficeAutomation_Document_Loan_MainID ='"+sMainID+"')";

            DataSet ds = RunSQL(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                money = Convert.ToDecimal(ds.Tables[0].Rows[0]["LoanMoney"].ToString());
            }
            return money;
        }
    }
}
