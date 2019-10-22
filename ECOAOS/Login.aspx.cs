using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataAccess;
using DataAccess.Operate;

public partial class Login :Page //: BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        ////测试邮箱拉取问题
        //var ds1 = Common.GetHRTreeByDepartmentID("dd2b1ff0-9f5d-4503-bc32-7433e3189f73").Split('|');
        //var dd = Common.GetHRTreeByDepartmentID("8b2d94ee-5955-47ca-8283-e92725393d60").Split('|');
        //DataAccess.Operate.DA_Employee_Inherit d = new DataAccess.Operate.DA_Employee_Inherit();
        //string str = d.getDomainUserEmail("张莹A");
        //return;
        try
        {
            if (Request.QueryString["htmltopdf"] == "Yes")
            {
                wsKDHR.Service wsKDHRMS = new wsKDHR.Service();
                DataSet ds = new DataSet();
                string UserName = Request.QueryString["EPID"];
                ds = wsKDHRMS.FindEmployeesByEmpCodeOnly(UserName);
                //Session["EmployeeID"] = UserName;
                //Session["EmployeeName"] = ds.Tables[0].Rows[0]["EmpName"].ToString();
                //Session["EmployeeID"] = "34498";
                //Session["EmployeeName"] = "吴卓霖";

                if (!string.IsNullOrEmpty(Request.QueryString["backurl"]))
                    this.Response.Redirect(Request.QueryString["backurl"] + "&htmltopdf=Yes");
            }
            //else
            //    Response.Redirect("http://gzs-terminal01/EcSystemPowerManage/EcPS/FrmMain.aspx"); //内网正式平台用，测试时可注释
        }
        catch
        {
        }
    }

    /// <summary>
    /// 登录按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void loginsubmit_Click(object sender, ImageClickEventArgs e)
    {
        string UserName = txtUserName.Text.Trim();
        string UserPwd = txtUserPwd.Text.Trim();
        if (UserName.Equals("") || UserPwd.Equals(""))
        {
            lbMsg.Text = "请输入您要登录用户名或密码";
        }
        //else if (this.ddlSystem.SelectedValue == "0")
        //{
        //    lbMsg.Text = "请选择你要进入的系统";
        //    this.ddlSystem.Focus();
        //}
        else
        {
            ECOA.Common.Cookie.ClearCookie("LoginUser");
            ECOA.Common.Cookie.ClearCookie("Purview");
            ECOA.Common.Cookie.ClearCookie("DocIDs");

            DataAccess.Operate.DA_Login_Inherit Login_Inherit = new DataAccess.Operate.DA_Login_Inherit();
            DataAccess.Operate.DA_User_Permission_Inherit User_Permission_Inherit = new DataAccess.Operate.DA_User_Permission_Inherit();
            bool bLogin_IsBusiness;
            int iLogin_ID;
            DataTable dt;
            string sPurview = "";

            try
            {
                //连接至权限系统数据库进行登录验证
                if (Login_Inherit.Login_Check(UserName, UserPwd, out bLogin_IsBusiness, out iLogin_ID) == true)
                {
                    wsKDHR.Service wsKDHRMS = new wsKDHR.Service();
                    DataSet ds = new DataSet();

                    //通过工号获取员工基本信息
                    ds = wsKDHRMS.FindEmployeesByEmpCodeOnly(UserName);
                    //try
                    //{
                    //    if (Session["EmployeeID"].ToString() == UserName)
                    //    {
                    //        Alert("一个工号只能打开一个审批。");
                    //        return;
                    //    }
                    //}
                    //catch
                    //{
                    //}

                    //Session["EmployeeID"] = UserName;
                    //Session["EmployeeName"] = ds.Tables[0].Rows[0]["EmpName"].ToString();
                    //Session["UnitID"] = ds.Tables[0].Rows[0]["UnitName"].ToString();//所属部门ID
                    //Session["Unit"] = ds.Tables[0].Rows[0]["Unit"].ToString();//所属部门
                    //Session["Login_ID"] = iLogin_ID;
                    //Session["IsBusiness"] = bLogin_IsBusiness;
                    Session["MainID"] = "";//公文主表主键
                    Session["ID"] = "";//公文主键

                    //连接至权限系统数据库，根据LoginID获取员工权限
                    dt = User_Permission_Inherit.getUserPurview(iLogin_ID);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            sPurview = sPurview + dt.Rows[i]["Permission_Module_Purview"].ToString() + ",";
                        }
                    }
                    
                    //Session["Purview"] = sPurview;
                    Session["AdministrationID"] = "";
                    Session["iType"] = "";
                    Session["FormType"] = "";
                    Session["openType"] = "";
                    UserInfo user = new UserInfo();
                    user.EmpID = UserName;
                    user.EmpName = ds.Tables[0].Rows[0]["EmpName"].ToString();
                    user.UnitID = ds.Tables[0].Rows[0]["UnitName"].ToString();//所属部门ID
                    user.Unit = ds.Tables[0].Rows[0]["Unit"].ToString();//所属部门
                    user.LoginID = iLogin_ID;
                    user.IsBusiness = bLogin_IsBusiness;
                    user.AdminSearch = sPurview.IndexOf("OA_Search_002,") > -1;
                    user.AdminDel = sPurview.IndexOf("OA_Search_003,") > -1;
                    user.KeyWordAllTB = sPurview.IndexOf("OA_Search_004,") > -1;

                    //获取代理人信息
                    DA_OfficeAutomation_Agent_Inherit agentbll = new DA_OfficeAutomation_Agent_Inherit();
                    var agentds = agentbll.GetMyAgencyForAgent_II(user.EmpName, user.EmpID);
                    if (agentds != null && agentds.Tables[0].Rows.Count > 0)
                    {
                        List<Agent> agents = new List<Agent>();
                        foreach (DataRow i in agentds.Tables[0].Rows)
                        {
                            agents.Add(new Agent {
                                AgentEmpID = i["OfficeAutomation_Agent_AuditorID"].ToString(),
                                AgentEmpName = i["OfficeAutomation_Agent_Auditor"].ToString()
                            });
                        }
                        user.Agents = agents;
                    }
                    
                    //user.Purview = sPurview;
                    Common.SignIn(user, 0, sPurview);

                    if (!string.IsNullOrEmpty(Request.QueryString["backurl"]))
                        this.Response.Redirect(Request.QueryString["backurl"]);
                    else
                        this.Response.Redirect("~/Apply/Apply.aspx", true);
                        //this.Response.Redirect("LoginForECPS.aspx?hf_EmpCode=" + UserName + "&hf_EmpPwd=" + UserPwd + "");
                }
                else
                {
                    lbMsg.Text = "您输入的用户名或密码不正确";
                }
            }
            catch(Exception ex)
            {
                //throw new Exception(ex.Message.ToString());
            }
            finally
            {
                Login_Inherit = null;
                User_Permission_Inherit = null;
            }
        }
    }
}
