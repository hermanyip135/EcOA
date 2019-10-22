using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Operate;

using System.Text;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public StringBuilder sbJS = new StringBuilder();
    public string employeeid = "";
    public string employeename = "";
    public string Purview = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["htmltopdf"] == "Yes")
            {
                sbJS.Append("<script type=\"text/javascript\">$(\"#masterpage_form\").hide();$(\"#masterpage_form_bottom\").hide();</script>");
                return;
            }
        }
        catch
        { }
        Session.Timeout = 300;
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();

        var user = Common.GetLoginUser();
        if (user != null)
        {
            employeeid = user.EmpID; //Session["EmployeeID"].ToString();
            employeename = user.EmpName;//Session["EmployeeName"].ToString();
        }
        else
        {
            Page.Response.Redirect("/Login.aspx");
        }

        int count = da_OfficeAutomation_Flow_Inherit.GetUnhandledApplyCount(employeeid, employeename, Common.ChangeAgentDtos(user.Agents));
        //int ll = da_OfficeAutomation_Flow_Inherit.GetUnhandledApplyCount(employeeid, employeename);
        if (count > 0)
        {
            lbtnUnhandledApplyCount.Text = "您有<span style=\"color:red\">" + count + "份</span>申请需要审批";
            sbJS.Append("<script type=\"text/javascript\">$(\"#divWaitForMe\").show();</script>");
        }

        count = da_OfficeAutomation_Flow_Inherit.GetDeleteD(employeeid, employeename);
        if (count > 0)
        {
            lbDeleteA.Text = "有<span style=\"color:red\">" + count + "份</span>申请需删除";
            sbJS.Append("<script type=\"text/javascript\">$(\"#divDeleteA\").show();</script>");
        }

        lblUser.Text = employeename;

        //if (Session["Purview"].ToString().Contains("OA_ITPower_002"))
        //    sbJS.Append("<script type='text/javascript'>$('#li7').show();</script>");

        if (employeeid == "1865"
            || employeeid == "6189"
            || employeeid == "13398"
            || employeeid == "13776"
            || employeeid == "30792"
            || employeeid == "17642"
            || employeeid == "8536"
            )
        {
            sbJS.Append("<script type=\"text/javascript\">");
            sbJS.Append("$('#li1').addClass('dir');$('#li1').html('查询<ul style=\"border:none;\"><li><a href=\"/Apply/Apply_Search.aspx?do=Lawer\">法律部查询</a></li><li><a href=\"/Apply/Apply_Search.aspx\">主界面</a></li></ul>');");
            sbJS.Append("</script>");
        }
        Purview = ECOA.Common.Cookie.GetCookie("Purview");
    }

    /// <summary>
    /// 待我审核按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnUnhandledApplyCount_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Apply/Apply_Search.aspx?do=waitforme");
    }
    protected void lbDeleteA_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Apply/Apply_Search.aspx?do=DeleteA");
    }
}
