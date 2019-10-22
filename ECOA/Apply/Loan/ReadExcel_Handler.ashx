<%@ WebHandler Language="C#" Class="ReadExcel_Handler" %>

using System;
using System.Web;
using System.Collections.Generic;
using DataEntity;

public class ReadExcel_Handler : IHttpHandler {
   
    public void ProcessRequest(HttpContext context)
    {
        
        context.Response.ContentType = "text/plain";

        if (!string.IsNullOrEmpty(context.Request.QueryString["MainID"]) && !string.IsNullOrEmpty(context.Request.Form["path"]))
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["UploadPath"];
            path = path + context.Request.Form["path"].Replace("/", "\\");
            var ds = NPOIExcel.NPOIImportExcels(path);//读取数据
            T_OfficeAutomation_Document_LoanReadExcel _LoanReadExcel = new T_OfficeAutomation_Document_LoanReadExcel();
            _LoanReadExcel.T_OfficeAutomation_Document_Loan_Detail = new List<T_OfficeAutomation_Document_Loan_Detail>();
            List<T_OfficeAutomation_Document_Loan_Detail> DetailList = _LoanReadExcel.T_OfficeAutomation_Document_Loan_Detail;
            if (ds.Tables.Count > 0)
            {
                for (int q = 0; q < ds.Tables.Count; q++)
                {
                    if (ds.Tables[q] != null && ds.Tables[q].Rows.Count > 0)
                    {
                        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[0-9]");
                        var j = 0;
                        for (int i = 4; i < ds.Tables[q].Rows.Count; i++)
                        {
                            //读取列表
                            if (!string.IsNullOrEmpty(ds.Tables[q].Rows[i]["放款申请表"].ToString()) && regex.IsMatch(ds.Tables[q].Rows[i]["放款申请表"].ToString()))//判断是否是数字
                            {
                                var obj = new DataEntity.T_OfficeAutomation_Document_Loan_Detail();
                                obj.OfficeAutomation_Document_Loan_Detail_ReceiptNum = ds.Tables[q].Rows[i]["Column2"].ToString();//收据编号
                                obj.OfficeAutomation_Document_Loan_Detail_Address = ds.Tables[q].Rows[i]["Column3"].ToString();//成交单位地址
                                obj.OfficeAutomation_Document_Loan_Detail_PaymentName = ds.Tables[q].Rows[i]["Column4"].ToString();//交款人姓名
                                obj.OfficeAutomation_Document_Loan_Detail_TransactionNum = ds.Tables[q].Rows[i]["Column6"].ToString(); //交易编号
                                obj.OfficeAutomation_Document_Loan_Detail_BorrowMoney = Convert.ToDecimal(ds.Tables[q].Rows[i]["Column7"].ToString() == "" ? "0" : ds.Tables[q].Rows[i]["Column7"].ToString());//(借)金额(元)
                                obj.OfficeAutomation_Document_Loan_Detail_LoanMoney = Convert.ToDecimal(ds.Tables[q].Rows[i]["Column8"].ToString() == "" ? "0" : ds.Tables[q].Rows[i]["Column8"].ToString());//(贷)金额(元)
                                obj.OfficeAutomation_Document_Loan_Detail_FinanceConf = ds.Tables[q].Rows[i]["Column9"].ToString();//财务确认   
                                //LogCommonFunction.AddLog("放款" +obj.OfficeAutomation_Document_Loan_Detail_Address, "放款申请");                     
                                DetailList.Add(obj);
                            }
                             if(q==0)
                             {
                               //读取收款人名称  、收款银行及开户支行名称、收款帐号
                           if (ds.Tables[q].Rows[i]["放款申请表"].ToString().Contains("收款人名称"))
                            {
                                string PayeeName = ds.Tables[q].Rows[i]["放款申请表"].ToString();
                                int num = PayeeName.IndexOf("：") + 1;
                                PayeeName = PayeeName.Substring(num, PayeeName.Length - num).Trim();
                                _LoanReadExcel.T_OfficeAutomation_Document_LoanReadExcel_PayeeName = PayeeName;
                            }
                            else if (ds.Tables[q].Rows[i]["放款申请表"].ToString().Contains("收款银行及开户支行名称"))
                            {
                                string PayeeBankName = ds.Tables[q].Rows[i]["放款申请表"].ToString();
                                int num = PayeeBankName.IndexOf("：") + 1;
                                PayeeBankName = PayeeBankName.Substring(num, PayeeBankName.Length - num).Trim();
                                _LoanReadExcel.T_OfficeAutomation_Document_LoanReadExcel_PayeeBankName = PayeeBankName;
                            }
                            else if (ds.Tables[q].Rows[i]["放款申请表"].ToString().Contains("收款帐号"))
                            {
                                string PayeeNum = ds.Tables[q].Rows[i]["放款申请表"].ToString();
                                int num = PayeeNum.IndexOf("：") + 1;
                                PayeeNum = PayeeNum.Substring(num, PayeeNum.Length - num).Trim();
                                _LoanReadExcel.T_OfficeAutomation_Document_LoanReadExcel_PayeeNum = PayeeNum;
                            }
                             }
                          
                        }

                    }
                }
            }
           
            //var dt1 = NPOIExcel.NPOIImportExcels(path, 1);//读取数据
            //AddList(dt1, DetailList);
            //var dt2 = NPOIExcel.NPOIImportExcels(path, 2);//读取数据
            //AddList(dt2, DetailList);
            
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(_LoanReadExcel));
            context.Response.End();
        }
    }
    public void AddList(System.Data.DataTable dt, List<T_OfficeAutomation_Document_Loan_Detail> DetailList)
    { 
    
            if (dt != null && dt.Rows.Count>0)
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[0-9]");
                var j = 0;
                for (int i = 4; i < dt.Rows.Count; i++)
                {
                    //读取列表
                    if (!string.IsNullOrEmpty(dt.Rows[i]["放款申请表"].ToString()) && regex.IsMatch(dt.Rows[i]["放款申请表"].ToString()))//判断是否是数字
                    {
                        var obj = new DataEntity.T_OfficeAutomation_Document_Loan_Detail();
                        obj.OfficeAutomation_Document_Loan_Detail_ReceiptNum = dt.Rows[i]["Column2"].ToString();//收据编号
                        obj.OfficeAutomation_Document_Loan_Detail_Address = dt.Rows[i]["Column3"].ToString();//成交单位地址
                        obj.OfficeAutomation_Document_Loan_Detail_PaymentName = dt.Rows[i]["Column4"].ToString();//交款人姓名
                        obj.OfficeAutomation_Document_Loan_Detail_TransactionNum = dt.Rows[i]["Column6"].ToString(); //交易编号
                        obj.OfficeAutomation_Document_Loan_Detail_BorrowMoney = Convert.ToDecimal(dt.Rows[i]["Column7"].ToString() == "" ? "0" : dt.Rows[i]["Column7"].ToString());//(借)金额(元)
                        obj.OfficeAutomation_Document_Loan_Detail_LoanMoney = Convert.ToDecimal(dt.Rows[i]["Column8"].ToString() == "" ? "0" : dt.Rows[i]["Column8"].ToString());//(贷)金额(元)
                        obj.OfficeAutomation_Document_Loan_Detail_FinanceConf = dt.Rows[i]["Column9"].ToString();//财务确认   
                       // LogCommonFunction.AddLog("放款" +obj.OfficeAutomation_Document_Loan_Detail_Address, "放款申请");                     
                        DetailList.Add(obj);
                    }
                }
                }
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

   
}
public class T_OfficeAutomation_Document_LoanReadExcel
{
    public string T_OfficeAutomation_Document_LoanReadExcel_PayeeName { get; set; }
    public string T_OfficeAutomation_Document_LoanReadExcel_PayeeBankName { get; set; }
    public string T_OfficeAutomation_Document_LoanReadExcel_PayeeNum { get; set; }
    public System.Collections.Generic.List<DataEntity.T_OfficeAutomation_Document_Loan_Detail> T_OfficeAutomation_Document_Loan_Detail { get; set; }
}






