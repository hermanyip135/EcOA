using DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
   public class DA_OfficeAutomation_Document_Loan_Inherit : DA_OfficeAutomation_Document_Loan_Operate
    {
       private DA_OfficeAutomation_Document_Loan_Operate bll = new DA_OfficeAutomation_Document_Loan_Operate();
       public DataSet SelectByReportNO(string sReportNO)
       {
           string sql = @"select 
                            Report_Main_Price,
                            Report_Detail_Client1+ ISNULL(','+Report_Detail_Client2,'')+ ISNULL(','+Report_Detail_Client3,'') as Report_Detail_Client1,
                            Report_Main_Address 
                        from [GZS-FINECCDB01].[DB_EcCommission].dbo.t_Report_Main m
                        inner join [GZS-FINECCDB01].[DB_EcCommission].dbo.t_Report_Detail d on d.Report_Detail_ReportMainID =m.Report_Main_ID
                        where 
                            Report_Main_ReportNO ='" + sReportNO + "'";

           return RunSQL(sql);
       }
       /// 通过MainID查询
       /// </summary>
       /// <param name="mainID"></param>
       /// <returns></returns>
       public DataSet SelectByMainID(string mainID)
       {
           string sql = @"SELECT * 
                                 ,toam.OfficeAutomation_SerialNumber
                                 ,tdoad.OfficeAutomation_Document_Name
                                 ,toam.OfficeAutomation_Main_FlowStateID
                           FROM [DB_EcOfficeAutomation].[dbo].t_OfficeAutomation_Document_Loan todi
                           LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Loan_MainID
                           LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID
                           WHERE OfficeAutomation_Document_Loan_MainID='" + mainID + "'";

           return RunSQL(sql);
       }
       public T_OfficeAutomation_Document_Loan GetModel(string mainid)
       {
           string where = "OfficeAutomation_Document_Loan_MainID ='" + mainid+"'";
           return bll.GetModel(where);
       }
       /// <summary>
       /// 修改备注
       /// </summary>
       /// <param name="mainId"></param>
       /// <param name="Remarks"></param>
       public void updateLoanRemarks(string mainId, string Remarks )
       {

//           string checksql = @"select OfficeAutomation_Document_Loan_Remarks from t_OfficeAutomation_Document_Loan
//                            where  OfficeAutomation_Document_Loan_MainID ='" + mainId + "'";
//           DataTable dt = RunSQL(checksql).Tables[0];
          string sql = null;
           
//           if (!string.IsNullOrEmpty(dt.Rows[0]["OfficeAutomation_Document_Loan_Remarks"].ToString()))
//           {
//               if ("▲".Equals(dt.Rows[0]["OfficeAutomation_Document_Loan_Remarks"].ToString()) && Remarks != "▲")
//               {
//                   sql = @"update t_OfficeAutomation_Document_Loan 
//                    set OfficeAutomation_Document_Loan_Remarks =OfficeAutomation_Document_Loan_Remarks + '" + Remarks + "' where  OfficeAutomation_Document_Loan_MainID  ='" + mainId + "'";
//               }
//               else if (dt.Rows[0]["OfficeAutomation_Document_Loan_Remarks"].ToString().Contains("▲") && Remarks != "▲" && !dt.Rows[0]["OfficeAutomation_Document_Loan_Remarks"].ToString().Contains("已导出"))
//               {
//                   sql = @"update t_OfficeAutomation_Document_Loan 
//                    set OfficeAutomation_Document_Loan_Remarks ='" + '▲' + Remarks + "' where  OfficeAutomation_Document_Loan_MainID  ='" + mainId + "'";
//               }
//               else if (dt.Rows[0]["OfficeAutomation_Document_Loan_Remarks"].ToString().Contains("▲") && Remarks != "▲")
//               {
//                   sql = @"update t_OfficeAutomation_Document_Loan 
//                    set OfficeAutomation_Document_Loan_Remarks ='" + '▲' + Remarks + "' where  OfficeAutomation_Document_Loan_MainID  ='" + mainId + "'";
//               }
//               else
//               {
//                   sql = @"update t_OfficeAutomation_Document_Loan 
//                    set OfficeAutomation_Document_Loan_Remarks =" + Remarks + " where  OfficeAutomation_Document_Loan_MainID  ='" + mainId + "'";
//               }
       ///    }
      //     else
    //       {
               sql = @"update t_OfficeAutomation_Document_Loan 
                    set OfficeAutomation_Document_Loan_Remarks ='" + Remarks + "' where  OfficeAutomation_Document_Loan_MainID  ='" + mainId + "'";
     //      }
         if(!string.IsNullOrEmpty(sql))
         {
             RunSQL(sql);
         }
             
       }

       public DataSet exportLoanWrongSave(string Main_ID)
       {
           string sql = @"select * from (
                        select (OfficeAutomation_Document_Loan_Department 
                                                  +(case  when OfficeAutomation_Document_Loan_LoanReason like '%1%' then '代收款'
	                                                      when OfficeAutomation_Document_Loan_LoanReason like '%2%' then '代收款' 
			                                              when OfficeAutomation_Document_Loan_LoanReason like '%3%' then '代收款' 
			                                              when OfficeAutomation_Document_Loan_LoanReason like '%4%' then '借支' 
			                                              when OfficeAutomation_Document_Loan_LoanReason like '%5%' then '佣金' 
                                                    end)) as '分行'
		                                            ,OfficeAutomation_Document_Loan_PayeeName as '收款人'
		                                            ,OfficeAutomation_Document_Loan_PayeeNum as '帐号'
							                        ,convert(varchar(20),(select sum(OfficeAutomation_Document_Loan_Detail_LoanMoney) from t_OfficeAutomation_Document_Loan_Detail where OfficeAutomation_Document_Loan_Detail_MainID = l.OfficeAutomation_Document_Loan_ID)) as '金额'
		                                            ,OfficeAutomation_Document_Loan_PayeeBankName as '开户行'
							                        ,m.OfficeAutomation_Main_CrTime
                                                    ,OfficeAutomation_SerialNumber as 交易编号
                                             from t_OfficeAutomation_Document_Loan l
					                         inner join t_OfficeAutomation_Main m on m.OfficeAutomation_Main_ID= l.OfficeAutomation_Document_Loan_MainID
                                            where  OfficeAutomation_Main_IsDelete=0 and OfficeAutomation_Main_Summary not like '%已导出%' and OfficeAutomation_Main_ID in('" + Main_ID + @"')
                                            AND ( SELECT TOP 1 [OfficeAutomation_Flow_Audit]
                                        FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]
                                         WHERE [OfficeAutomation_Flow_MainID] =m.OfficeAutomation_Main_ID order by OfficeAutomation_Flow_Idx desc) =1

                        union 
	                        select 
		                        OfficeAutomation_Document_WrongSave_Department+'错存佣金' as '分行'
		                        ,OfficeAutomation_Document_WrongSave_PayeeName as '收款人'
		                        ,OfficeAutomation_Document_WrongSave_PayeeNum as '帐号'
		                        ,OfficeAutomation_Document_WrongSave_SmallSMoney  as '金额'
		                        ,OfficeAutomation_Document_WrongSave_PayeeBankName as '开户行'
		                        ,m.OfficeAutomation_Main_CrTime
                                ,OfficeAutomation_SerialNumber as 交易编号
	                        from t_OfficeAutomation_Document_WrongSave s
	                         inner join t_OfficeAutomation_Main m on m.OfficeAutomation_Main_ID= s.OfficeAutomation_Document_WrongSave_MainID
                                            where OfficeAutomation_Main_IsDelete=0 and OfficeAutomation_Main_Sremark not like '%已导出%'  and OfficeAutomation_Main_ID in('" + Main_ID + @"')
                                	and 	 (SELECT top 1 [OfficeAutomation_Flow_Audit]
                            FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]
                          WHERE [OfficeAutomation_Flow_MainID] =m.OfficeAutomation_Main_ID order by OfficeAutomation_Flow_Idx desc) =1
					                        ) a order by a.OfficeAutomation_Main_CrTime desc";
          DataSet ds = RunSQL(sql);
           return ds;
       }
       /// <summary>
       /// 修改已导出的放款跟错存数据
       /// </summary>
       /// <returns></returns>
       public DataSet UpdateLoanWrongSaveRemarks(string sMainID)
       {
           string sql = @"update t_OfficeAutomation_Main 
	                          set  OfficeAutomation_Main_Summary = (case  when OfficeAutomation_DocumentID = 85 then '已导出' else OfficeAutomation_Main_Summary end),
                                   OfficeAutomation_Main_Sremark = (case  when OfficeAutomation_DocumentID = 65 then '已导出'else OfficeAutomation_Main_Sremark end)
		                        where OfficeAutomation_Main_ID in (
	                        select m.OfficeAutomation_Main_ID
	                         from t_OfficeAutomation_Main m 
	                         where   OfficeAutomation_Main_IsDelete=0  
	                         AND OfficeAutomation_Main_ID in ('" + sMainID + @"')
	                           AND (
			                        SELECT top 1 [OfficeAutomation_Flow_Audit]
                                     FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]
                                     WHERE [OfficeAutomation_Flow_MainID] =m.OfficeAutomation_Main_ID 
			                          order by OfficeAutomation_Flow_Idx desc) =1
			                         )";
           DataSet ds = RunSQL(sql);
           return ds;
       }

       /// <summary>
       /// 申请人之后是否有被审核
       /// </summary>
       /// <param name="MainID"></param>
       /// <returns></returns>
       public bool IsApplyAudit(string MainID)
       {
           string sql = "SELECT 1 FROM t_OfficeAutomation_Flow WHERE OfficeAutomation_Flow_MainID='" + MainID + "' AND OfficeAutomation_Flow_Audit=1 AND OfficeAutomation_Flow_Idx > 1";
           DataSet ds = RunSQL(sql);
           if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0][0].ToString() == "1")
                   return true;
           }
           return false;
       }
    }
}
