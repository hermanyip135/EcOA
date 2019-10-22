using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BorrowMoney_Search_Inherit
    {
        DA_OfficeAutomation_Document_BorrowMoney_Operate dA_OfficeAutomation_Document_BorrowMoney_Operate = new DA_OfficeAutomation_Document_BorrowMoney_Operate();
        public DataSet getBorrowMoneyBalance(string sBeginDate, string sEndDate, string sDepartment, string sApply, string sApplyID)
        {
            string sql = @"SELECT 
                          ApplyID,Department,BalanceMoney,ImportDate 
                    FROM (
	                    SELECT 
		                    b.OfficeAutomation_Document_BorrowMoney_ApplyID ApplyID
		                    ,OfficeAutomation_Document_BorrowMoney_Department Department
		                    ,((SELECT  SUM(OfficeAutomation_Document_BorrowMoney_Import_Money)
			                      FROM T_OfficeAutomation_Document_BorrowMoney_Import 
			                       WHERE OfficeAutomation_Document_BorrowMoney_Import_ApplyID=b.OfficeAutomation_Document_BorrowMoney_ApplyID
			                       AND OfficeAutomation_Document_BorrowMoney_Import_Type ='借') 
		                     -(SELECT  isnull(sum(OfficeAutomation_Document_BorrowMoney_Import_Money),0)
			                      FROM T_OfficeAutomation_Document_BorrowMoney_Import 
			                      WHERE OfficeAutomation_Document_BorrowMoney_Import_ApplyID=b.OfficeAutomation_Document_BorrowMoney_ApplyID
			                     AND OfficeAutomation_Document_BorrowMoney_Import_Type ='冲') ) BalanceMoney 
		                     ,(SELECT TOP 1 OfficeAutomation_Document_BorrowMoney_Import_Date
			                    FROM T_OfficeAutomation_Document_BorrowMoney_Import 
			                    WHERE OfficeAutomation_Document_BorrowMoney_Import_ApplyID=b.OfficeAutomation_Document_BorrowMoney_ApplyID
		                        AND OfficeAutomation_Document_BorrowMoney_Import_Type ='借') ImportDate
	                     FROM t_OfficeAutomation_Document_BorrowMoney b
                        inner join t_OfficeAutomation_Main  m on b.OfficeAutomation_Document_BorrowMoney_MainID = m.OfficeAutomation_Main_ID
	                     WHERE b.OfficeAutomation_Document_BorrowMoney_ApplyID in(
			                    SELECT b1.OfficeAutomation_Document_BorrowMoney_ApplyID  
			                     FROM t_OfficeAutomation_Document_BorrowMoney b1
			                    LEFT JOIN  T_OfficeAutomation_Document_BorrowMoney_Import i on i.OfficeAutomation_Document_BorrowMoney_Import_ApplyID = b1.OfficeAutomation_Document_BorrowMoney_ApplyID
			                    WHERE i.OfficeAutomation_Document_BorrowMoney_Import_Date is not null and m.OfficeAutomation_Main_IsDelete !=1  AND OfficeAutomation_Document_BorrowMoney_Import_Type ='借'";
            if (!string.IsNullOrEmpty(sBeginDate) && !string.IsNullOrEmpty(sEndDate))
                sql += " AND OfficeAutomation_Document_BorrowMoney_Import_Date between '" + sBeginDate + "' and '" + sEndDate + "'";
            if (!string.IsNullOrEmpty(sApplyID))
                sql += " AND b.OfficeAutomation_Document_BorrowMoney_ApplyID ='" + sApplyID + "'";
            if (!string.IsNullOrEmpty(sDepartment))
                sql += "  AND b.OfficeAutomation_Document_BorrowMoney_Department ='" + sDepartment + "'";
            if (!string.IsNullOrEmpty(sApply))
                sql += " AND b.OfficeAutomation_Document_BorrowMoney_Apply ='" + sApply + "'";
            sql += @" GROUP BY b1.OfficeAutomation_Document_BorrowMoney_ApplyID
			                     )
                     ) b3 WHERE BalanceMoney is not null and BalanceMoney !=0.00
                    ";
            DataSet ds = dA_OfficeAutomation_Document_BorrowMoney_Operate.OperationSQL(sql);
            return ds;
        }
        public DataSet getBorrowMoneyDetail(string sBeginDate, string sEndDate, string DateType, string sDepartment, string sApply, string sApplyID)
        {
            string sql = @"SELECT
                               
                                b.OfficeAutomation_Document_BorrowMoney_ApplyID ApplyID
                                ,OfficeAutomation_Document_BorrowMoney_Department Department
                                ,(SELECT sum(Convert(money,isnull(OfficeAutomation_Document_BorrowMoney_Detail_UnitPrice,0))) FROM T_OfficeAutomation_Document_BorrowMoney_Detail WHERE OfficeAutomation_Document_BorrowMoney_Detail_MainID=b.OfficeAutomation_Document_BorrowMoney_ID and OfficeAutomation_Document_BorrowMoney_Detail_CostProject ='租金') Rent
                                ,(SELECT sum(Convert(money,isnull(OfficeAutomation_Document_BorrowMoney_Detail_UnitPrice,0))) FROM T_OfficeAutomation_Document_BorrowMoney_Detail WHERE OfficeAutomation_Document_BorrowMoney_Detail_MainID=b.OfficeAutomation_Document_BorrowMoney_ID and OfficeAutomation_Document_BorrowMoney_Detail_CostProject ='租金税费') RentTax
                                ,(SELECT sum(Convert(money,isnull(OfficeAutomation_Document_BorrowMoney_Detail_UnitPrice,0))) FROM T_OfficeAutomation_Document_BorrowMoney_Detail WHERE OfficeAutomation_Document_BorrowMoney_Detail_MainID=b.OfficeAutomation_Document_BorrowMoney_ID and OfficeAutomation_Document_BorrowMoney_Detail_CostProject ='管理费') ManaExpense
                                ,(SELECT sum(Convert(money,isnull(OfficeAutomation_Document_BorrowMoney_Detail_UnitPrice,0))) FROM T_OfficeAutomation_Document_BorrowMoney_Detail WHERE OfficeAutomation_Document_BorrowMoney_Detail_MainID=b.OfficeAutomation_Document_BorrowMoney_ID and OfficeAutomation_Document_BorrowMoney_Detail_CostProject ='电费') ElectricityFees
                                ,(SELECT sum(Convert(money,isnull(OfficeAutomation_Document_BorrowMoney_Detail_UnitPrice,0))) FROM T_OfficeAutomation_Document_BorrowMoney_Detail WHERE OfficeAutomation_Document_BorrowMoney_Detail_MainID=b.OfficeAutomation_Document_BorrowMoney_ID and OfficeAutomation_Document_BorrowMoney_Detail_CostProject ='水费') water
                                ,(SELECT sum(Convert(money,isnull(OfficeAutomation_Document_BorrowMoney_Detail_UnitPrice,0))) FROM T_OfficeAutomation_Document_BorrowMoney_Detail WHERE OfficeAutomation_Document_BorrowMoney_Detail_MainID=b.OfficeAutomation_Document_BorrowMoney_ID and OfficeAutomation_Document_BorrowMoney_Detail_CostProject ='其他') Other
                                FROM t_OfficeAutomation_Document_BorrowMoney b
                                INNER JOIN t_OfficeAutomation_Main  m on b.OfficeAutomation_Document_BorrowMoney_MainID = m.OfficeAutomation_Main_ID
                                WHERE m.OfficeAutomation_Main_IsDelete !=1 ";
            //选择类型系借或者冲
            if (!string.IsNullOrEmpty(DateType) && (DateType.Equals("借") || DateType.Equals("冲")))
            {
                sql += @" AND b.OfficeAutomation_Document_BorrowMoney_ApplyID IN(
	                                        SELECT OfficeAutomation_Document_BorrowMoney_Import_ApplyID from T_OfficeAutomation_Document_BorrowMoney_Import WHERE 1=1 ";
                if (!string.IsNullOrEmpty(sBeginDate) && !string.IsNullOrEmpty(sEndDate))
                {
                    sql += " AND OfficeAutomation_Document_BorrowMoney_Import_Date BETWEEN '" + sBeginDate + "' AND '" + sEndDate + "' ";
                }

                sql += " AND OfficeAutomation_Document_BorrowMoney_Import_Type ='" + DateType + "')";
            }
            //部门
            if (!string.IsNullOrEmpty(sDepartment))
                sql += " AND OfficeAutomation_Document_BorrowMoney_Department='" + sDepartment + "' ";
            //流水号
            if (!string.IsNullOrEmpty(sApplyID))
                sql += " AND b.OfficeAutomation_Document_BorrowMoney_ApplyID ='" + sApplyID + "'";
            //申请人
            if (!string.IsNullOrEmpty(sApply))
                sql += " AND OfficeAutomation_Document_BorrowMoney_Apply ='" + sApply + "'";
            //类型系申请 日期不为空
            if (!string.IsNullOrEmpty(DateType) && (DateType.Equals("申请")) && !string.IsNullOrEmpty(sBeginDate) && !string.IsNullOrEmpty(sEndDate))
                sql += " AND OfficeAutomation_Document_BorrowMoney_ApplyDate  BETWEEN '" + sBeginDate + "' AND '" + sEndDate + "' ";
            DataSet ds = dA_OfficeAutomation_Document_BorrowMoney_Operate.OperationSQL(sql);
            return ds;
        }

        /// <summary>
        /// 已收单未未付款
        /// </summary>
        /// <returns></returns>
        public DataSet SearchReceiptUnpaid()
        {
            string sql = @"SELECT   
                                b.OfficeAutomation_Document_BorrowMoney_ApplyID ApplyID
                                ,OfficeAutomation_Document_BorrowMoney_Department Department
                                ,REPLACE((SELECT 
                                         CASE WHEN OfficeAutomation_Document_BorrowMoney_Detail_CostProject ='其他' THEN OfficeAutomation_Document_BorrowMoney_Detail_CostProject+':'+OfficeAutomation_Document_BorrowMoney_Detail_Other ELSE 
                                         OfficeAutomation_Document_BorrowMoney_Detail_CostProject+':'++OfficeAutomation_Document_BorrowMoney_Detail_StartDate+' 至 '+OfficeAutomation_Document_BorrowMoney_Detail_EndDate END+'、'
                                        FROM T_OfficeAutomation_Document_BorrowMoney_Detail a
                                        WHERE a.OfficeAutomation_Document_BorrowMoney_Detail_MainID=b.OfficeAutomation_Document_BorrowMoney_ID FOR XML PATH(''))
	                               ,CHAR(10) ,'')AS abstract
                                ,(SELECT SUM(Convert(Decimal(18,2),OfficeAutomation_Document_BorrowMoney_Detail_UnitPrice)) FROM T_OfficeAutomation_Document_BorrowMoney_Detail a WHERE a.OfficeAutomation_Document_BorrowMoney_Detail_MainID=b.OfficeAutomation_Document_BorrowMoney_ID ) PriceSum
                                ,'已收单未付款'	BorrowMoneyState
                                ,OfficeAutomation_Document_BorrowMoney_AuditorDate  AuditorDate
                                ,(SELECT OfficeAutomation_Flow_Employee FROM t_OfficeAutomation_Flow WHERE OfficeAutomation_Flow_MainID =b.OfficeAutomation_Document_BorrowMoney_MainID AND OfficeAutomation_Flow_Idx=3 ) Person
                                ,OfficeAutomation_Document_BorrowMoney_Apply ApplyPoper
                                FROM t_OfficeAutomation_Document_BorrowMoney b
                                INNER JOIN t_OfficeAutomation_Main  m ON b.OfficeAutomation_Document_BorrowMoney_MainID = m.OfficeAutomation_Main_ID
                                WHERE m.OfficeAutomation_Main_IsDelete !=1 and m.OfficeAutomation_Main_WillDelete !=1
                                AND OfficeAutomation_Document_BorrowMoney_IsAgree=1
                                AND NOT EXISTS (select * FROM t_OfficeAutomation_Document_BorrowMoney_Import  WHERE OfficeAutomation_Document_BorrowMoney_Import_ApplyID= OfficeAutomation_Document_BorrowMoney_ApplyID) 
                                ";
            DataSet ds = dA_OfficeAutomation_Document_BorrowMoney_Operate.OperationSQL(sql);
            return ds;
        }
    }
}
