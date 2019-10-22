using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using DataAccess.Operate;
using DataEntity;
using System.Data;

public partial class Apply_DeleteDialog : BasePage
{
    #region Page_Load

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["url"].ToString() == "Nothing")
            {
                lbA7.Text = "意见：";
                btnSendDeleteMessage.Visible = false;
            }
            else
            {
                lbA7.Text = "请填写删除原因：";
                btnAgreeD.Visible = false;
                btnNotAgreeD.Visible = false;
            }
        }
    }

    #endregion
    protected void btnSendDeleteMessage_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtDeleteMessage.Text.Trim() == "")
            {
                Alert("请填写删除原因。");
                return;
            }
            DataSet ds = new DataSet();
            string mainid = Request.QueryString["mainID"];
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
            try
            {
                da_OfficeAutomation_Flow_Inherit.InsertFlowsByDelete(mainid);
                //ds = da_OfficeAutomation_Flow_Inherit.SelectDeleteFlows(mainid); //填写人不用发表删除意见
                //if (ds.Tables[0].Rows[0]["OfficeAutomation_DeletedFlow_Auditor"].ToString() == EmployeeName)
                //    da_OfficeAutomation_Flow_Inherit.DeleteDFlowsByMIDAndName(mainid, EmployeeName); 
            }
            catch
            {
                RunJS("alert('删除请求已发送，请耐心等待！');window.returnValue='success';window.close();");
                return;
            }
            t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(mainid);
            t_OfficeAutomation_Main.OfficeAutomation_Main_WillDelete = true; //置位删除标志
            da_OfficeAutomation_Main_Inherit.UpdateWillDelete(t_OfficeAutomation_Main);

            string[] employnames;
            string email;
            string msnBody;
            ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid); 
            string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
            string employname;
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
            string applyUrl = "/Apply/" + Request.QueryString["url"];
            applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;
                        
            //通知已审批的全部人员
            ds = da_OfficeAutomation_Flow_Inherit.SelectDeleteFlowsByMID(mainid);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                employname = dr["OfficeAutomation_DeletedFlow_Auditor"].ToString();
                employnames = employname.Split(',');
                for (int i2 = 0; i2 < employnames.Length; i2++)
                {
                    msnBody = "您好" + employnames[i2] + "，" + EmployeeName + "需要删除您已审理过的编号为" + serialNumber + "的" + documentName + "，删除原因：<br />" + txtDeleteMessage.Text + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>" + "<br /><br />操作方法：点击左上方的“有__份申请需删除”链接后打开申请列表，进入其中一份后点击红色标题下面的“是否同意删除？”按钮即可发表相关意见。";
                    email = employnames[i2];if(email != "")
                    Common.SendMessageEX(false, email, "是否同意" + EmployeeName + "删除" + documentName, msnBody, msnBody);
                    ds = da_Employee_Inherit.GetEmployeeInfoByEmployeeNames(email);
                    Common.PushByDelete(documentName, serialNumber, EmployeeName, ds.Tables[0].Rows[0]["Code"].ToString()); //手机推送
                }
            }
            //通知下一步需要审批的人员
            employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(mainid);
            employnames = employname.Split(',');
            for (int i = 0; i < employnames.Length; i++)
            {
                email = employnames[i];
                msnBody = "您好" + employnames[i] + "，由于" + EmployeeName + "需要删除编号为：" + serialNumber + "的" + documentName + "，所以该表现在暂停审理操作，删除原因：<br />" + txtDeleteMessage.Text + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>";
                Common.SendMessageEX(true, documentName, email, documentName + "因需删除而暂停审理", msnBody, msnBody, mainid);
            }
            RunJS("alert('删除请求已发送，请耐心等待。');window.returnValue='success';window.close();");
        }
        catch (Exception ex)
        {
            RunJS("alert('删除失败，错误原因：" + ex.Message + "');window.returnValue='fail';window.close();");
        }
    }
    protected void btnAgreeD_Click(object sender, EventArgs e)
    {
        try
        {
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();

            string mainid = Request.QueryString["mainID"];
            string namesA, idsA;
            int idx;
            DataSet ds = new DataSet();
            try
            {
                ds = da_OfficeAutomation_Flow_Inherit.SelectDeleteFlowsByAM(mainid, EmployeeID);
                idsA = ds.Tables[0].Rows[0]["OfficeAutomation_DeletedFlow_AuditorID"].ToString();
                namesA = ds.Tables[0].Rows[0]["OfficeAutomation_DeletedFlow_Auditor"].ToString();
                idx = int.Parse(ds.Tables[0].Rows[0]["OfficeAutomation_DeletedFlow_Idx"].ToString());
            }
            catch
            {
                RunJS("alert('操作成功！');window.returnValue='success';window.close();");
                return;
            }
            if (idsA.IndexOf(',') != -1)
            {
                if (idsA.IndexOf(EmployeeID + ',') != -1)
                {
                    idsA = idsA.Replace((EmployeeID + ','), string.Empty);
                    //namesA = namesA.Replace((EmployeeName + ','), string.Empty);
                }
                else
                {
                    idsA = idsA.Replace((',' + EmployeeID), string.Empty);
                    //namesA = namesA.Replace((',' + EmployeeName), string.Empty);
                }
                da_OfficeAutomation_Flow_Inherit.UpdateDeletFByMainIDAndIdxs(mainid, idx, namesA, idsA);
            }
            else
                da_OfficeAutomation_Flow_Inherit.UpdateDFAfterByMainIDAndIdxs(mainid, idx);

            //通知申请人
            string ms = "";
            if (txtDeleteMessage.Text.Trim() != "")
                ms = "<br /><br />理由是：" + txtDeleteMessage.Text;
            ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid);
            string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
            if (documentName == "软件系统开发需求申请表")
                documentName = "软件需求申请表";
            else if (documentName == "物业部成交商铺/写字楼备案申请表")
                documentName = "物业部成交商铺/写字楼备忘申请";
            else if (documentName == "公章使用申请表")
                documentName = "公章使用申请明细表";
            else if (documentName == "物业部承接项目报备申请表")
                documentName = "物业部承接一手项目报备申请表";
            string did = da_OfficeAutomation_Flow_Inherit.GetModuleIDByMainID(documentName);
            string apply = Request.QueryString["apply"];
            apply = apply.Remove(apply.Length - 1);
            string messageBody = "您好" + apply + "，" + EmployeeName + "同意您删除编号为" + serialNumber + "的" + documentName + "。" + ms;
            
            ds = da_OfficeAutomation_Flow_Inherit.SelectDeleteFlowsByMID(mainid);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
                ds = da_Employee_Inherit.GetEmployeeInfoByEmployeeNames(apply);
                da_OfficeAutomation_Flow_Inherit.DDeleteFlows(mainid);
                messageBody = "您好" + apply + "，" + EmployeeName + "同意您删除编号为" + serialNumber + "的" + documentName + "，由于已审批人员都全部同意，所以该表删除成功。" + ms;
                Common.SendMessageEX(false, apply, documentName + "已删除", messageBody, messageBody);
                try
                {
                    Common.AddLog(ds.Tables[0].Rows[0]["Code"].ToString(), apply, int.Parse(did), new Guid(mainid), 3);
                }
                catch
                {
                }

                if (documentName == "资产调动表")
                {
                    DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit = new DA_OfficeAutomation_Document_AssetTransfer_Detail_Inherit();
                    DataSet dsDetail = new DataSet();
                    dsDetail = da_OfficeAutomation_Document_AssetTransfer_Detail_Inherit.SelectByMainID(mainid);
                    foreach (DataRow dr in dsDetail.Tables[0].Rows)
                    {
                        wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
                        string s = dr["OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID"].ToString();
                        if (!string.IsNullOrEmpty(s))
                        {
                            ws.AssetAdjustmentReject(dr["OfficeAutomation_Document_AssetTransfer_Detail_AdjustmentID"].ToString());
                        }
                    }
                }
                if (documentName == "报废申请表")
                {
                    DA_OfficeAutomation_Document_Scrap_Detail_Inherit da_OfficeAutomation_Document_Scrap_Detail_Inherit = new DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
                    DataSet dsDetail = new DataSet();
                    dsDetail = da_OfficeAutomation_Document_Scrap_Detail_Inherit.SelectByMainID(mainid);
                    foreach (DataRow dr in dsDetail.Tables[0].Rows)
                    {
                        wsAsset.GetAssetDic ws = new wsAsset.GetAssetDic();
                        string s = dr["OfficeAutomation_Document_Scrap_Detail_AdjustmentID"].ToString();
                        if (!string.IsNullOrEmpty(s))
                        {
                            ws.AssetAdjustmentReject(dr["OfficeAutomation_Document_Scrap_Detail_AdjustmentID"].ToString());
                        }
                    }
                }

                if (documentName == "资产借调申请表")
                {
                    DA_OfficeAutomation_Document_Secondment_Inherit da_OfficeAutomation_Document_Secondment_Inherit = new DA_OfficeAutomation_Document_Secondment_Inherit();
                    DataSet dst = da_OfficeAutomation_Document_Secondment_Inherit.SelectByMainID(mainid);
                    DA_OfficeAutomation_Document_Assets_Inherit da_OfficeAutomation_Document_Assets_Inherit = new DA_OfficeAutomation_Document_Assets_Inherit();
                    da_OfficeAutomation_Document_Assets_Inherit.UpdateToggleZero(dst.Tables[0].Rows[0]["OfficeAutomation_Document_Secondment_ApplyID"].ToString(), 1);
                }

                RunJS("alert('申请表" + (da_OfficeAutomation_Main_Inherit.LogicDelete(mainid) ? "现已删除成功!" : "删除失败!") + "');window.returnValue='deleted';window.close();");
            }
            else
            {
                Common.SendMessageEX(false, apply, EmployeeName + "同意了您的删除请求", messageBody, messageBody);
                RunJS("alert('操作成功。');window.returnValue='success';window.close();");
            }
        }
        catch (Exception ex)
        {
            RunJS("alert('操作失败，错误原因："+ ex.Message +"');window.returnValue='fail';window.close();");
        }
    }
    protected void btnNotAgreeD_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtDeleteMessage.Text.Trim() == "")
            {
                Alert("请填写不同意删除的原因。");
                return;
            }
            string mainid = Request.QueryString["mainID"];
            DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
            T_OfficeAutomation_Main t_OfficeAutomation_Main = new T_OfficeAutomation_Main();
            DA_OfficeAutomation_Main_Inherit da_OfficeAutomation_Main_Inherit = new DA_OfficeAutomation_Main_Inherit();
            t_OfficeAutomation_Main.OfficeAutomation_Main_ID = new Guid(mainid);
            t_OfficeAutomation_Main.OfficeAutomation_Main_WillDelete = false;
            da_OfficeAutomation_Main_Inherit.UpdateWillDelete(t_OfficeAutomation_Main); //设0删除标志

            DA_OfficeAutomation_Document_LastSure_Inherit da_OfficeAutomation_Document_LastSure_Inherit = new DA_OfficeAutomation_Document_LastSure_Inherit();
            try
            {
                da_OfficeAutomation_Document_LastSure_Inherit.InsertD(mainid, DateTime.Now.ToString("yyyy-MM-dd"));
            }
            catch
            {
                da_OfficeAutomation_Document_LastSure_Inherit.UpdateD(mainid, DateTime.Now.ToString("yyyy-MM-dd"));
            }

            string ms = "<br /><br />不同意原因是：" + txtDeleteMessage.Text;
            DataSet ds = new DataSet();
            string[] employnames;
            string email;
            string msnBody;
            ds = da_OfficeAutomation_Main_Inherit.SelectByMainID(mainid);
            string serialNumber = ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"].ToString();
            string employname;
            string documentName = da_OfficeAutomation_Flow_Inherit.GetDocumentNameByMainID(mainid);
            string apply = Request.QueryString["apply"];
            string apply2 = apply;
            apply = apply.Remove(apply.Length - 1);
            string applyUrl = Request.QueryString["href"];
            applyUrl = applyUrl.Substring(applyUrl.IndexOf("/Apply/"));
            applyUrl = "内部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["InternalURL"] + applyUrl;
                        //+ "<br />外部网地址：" + System.Configuration.ConfigurationSettings.AppSettings["ExternalURL"] + applyUrl;

            //通知下一步需要审批的人员
            employname = da_OfficeAutomation_Flow_Inherit.GetWaitForAuditorByMainID(mainid);
            employnames = employname.Split(',');
            for (int i = 0; i < employnames.Length; i++)
            {
                email = employnames[i];
                msnBody = "您好" + employnames[i] + "，由于" + EmployeeName + "不同意" + apply + "删除编号为：" + serialNumber + "的" + documentName + "，所以现在需要您继续审理。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>" + ms;
                Common.SendMessageEX(true, documentName, email, documentName + "需要您继续审理", msnBody, msnBody,mainid);
            }
            //通知申请人
            msnBody = "您好" + apply2 + "，" + EmployeeName + "不同意您删除编号为" + serialNumber + "的" + documentName + "。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>" + ms;
            Common.SendMessageEX(false, apply, EmployeeName + "不同意您删除" + documentName, msnBody, msnBody);

            //通知已同意的全部人员
            ds = da_OfficeAutomation_Flow_Inherit.SelectDeleteFlows(mainid);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                employname = dr["OfficeAutomation_DeletedFlow_Auditor"].ToString();
                employnames = employname.Split(',');
                for (int i2 = 0; i2 < employnames.Length; i2++)
                {
                    if (employnames[i2] == EmployeeName) //M_nWarning+：不发送给不同意的人员，发布时需开启
                        continue; //M_nWarning-
                    msnBody = "您好" + employnames[i2] + "，由于" + EmployeeName + "不同意" + apply + "删除编号" + serialNumber + "的" + documentName + "，所以该表未被删除。<br />申请表" + applyUrl + "<br /><br /><span style=\"font-weight: bolder\">注意：该链接需要登陆门户系统并打开电子审批系统后才能进入，否则只能跳到登陆页面。</span>" + ms;
                    email = employnames[i2];if(email != "")
                    Common.SendMessageEX(false, email, EmployeeName + "不同意删除" + documentName, msnBody, msnBody);
                }
            }
            da_OfficeAutomation_Flow_Inherit.DDeleteFlows(mainid);
            RunJS("alert('操作成功，稍后系统会把您的意见发送给相关人员。');window.returnValue='deleted';window.close();");
        }
        catch (Exception ex)
        {
            RunJS("alert('操作失败，错误原因：" + ex.Message + "');window.returnValue='fail';window.close();");
        }
    }
}
