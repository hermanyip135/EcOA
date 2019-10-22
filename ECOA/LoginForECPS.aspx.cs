using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using DataAccess;
using DataAccess.Operate;

public partial class LoginForECPS : Page //: BasePage
{
    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
         
        Login();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
 
    public void Login()
    {
        if (Request.Form["hf_EmpCode"] != null && Request.Form["hf_EmpPwd"] != null)
        {
            ECOA.Common.Cookie.ClearCookie("LoginUser");
            ECOA.Common.Cookie.ClearCookie("Purview");
            ECOA.Common.Cookie.ClearCookie("DocIDs");
            //string UserPwd = "zy111111";
            //string UserName = "39151";
            string UserName = Request.Form["hf_EmpCode"].ToString();
            string UserPwd = Request.Form["hf_EmpPwd"].ToString();

            //string UserName = Request.QueryString["hf_EmpCode"].ToString();
            //string UserPwd = Request.QueryString["hf_EmpPwd"].ToString();

            DataAccess.Operate.DA_Login_Inherit Login_Inherit = new DataAccess.Operate.DA_Login_Inherit();
            DataAccess.Operate.DA_User_Permission_Inherit User_Permission_Inherit = new DataAccess.Operate.DA_User_Permission_Inherit();
            bool bLogin_IsBusiness;
            int iLogin_ID;
            DataTable dt;
            string sPurview = "";

            try
            {

                #region [2019-08-28 CREATE BY HERMAN：连接至权限系统数据库进行登录验证_旧方法返回bool，弃用]
                //连接至权限系统数据库进行登录验证
                //if (Login_Inherit.Login_Check(UserName, UserPwd, out bLogin_IsBusiness, out iLogin_ID) == true)
                //{
                //    wsKDHR.Service wsKDHRMS = new wsKDHR.Service();
                //    DataSet ds = new DataSet();

                //    //通过工号获取员工基本信息
                //    ds = wsKDHRMS.FindEmployeesByEmpCodeOnly(UserName);

                //    //Session["EmployeeID"] = UserName;
                //    //Session["EmployeeName"] = ds.Tables[0].Rows[0]["EmpName"].ToString();
                //    //Session["EmployeeID"] = "34498";
                //    //Session["EmployeeName"] = "吴卓霖";
                //    //Session["UnitID"] = ds.Tables[0].Rows[0]["UnitName"].ToString();//所属部门ID
                //    //Session["Unit"] = ds.Tables[0].Rows[0]["Unit"].ToString();//所属部门
                //    //Session["Login_ID"] = iLogin_ID;
                //    //Session["IsBusiness"] = bLogin_IsBusiness;
                //    Session["MainID"] = "";//公文主表主键
                //    Session["ID"] = "";//公文主键

                //    //连接至权限系统数据库，根据LoginID获取员工权限
                //    dt = User_Permission_Inherit.getUserPurview(iLogin_ID);
                //    if (dt.Rows.Count > 0)
                //    {
                //        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                //        {
                //            sPurview = sPurview + dt.Rows[i]["Permission_Module_Purview"].ToString() + ",";
                //        }
                //    }
                //    //Session["Purview"] = sPurview;
                //    //Session["AdministrationID"] = "";
                //    Session["iType"] = "";
                //    Session["FormType"] = "";
                //    Session["openType"] = "";

                //    UserInfo user = new UserInfo();
                //    user.EmpID = UserName;
                //    user.EmpName = ds.Tables[0].Rows[0]["EmpName"].ToString();
                //    user.UnitID = ds.Tables[0].Rows[0]["UnitName"].ToString();//所属部门ID
                //    user.Unit = ds.Tables[0].Rows[0]["Unit"].ToString();//所属部门
                //    user.LoginID = iLogin_ID;
                //    user.IsBusiness = bLogin_IsBusiness;
                //    user.AdminSearch = sPurview.IndexOf("OA_Search_002,") > -1;
                //    user.AdminDel = sPurview.IndexOf("OA_Search_003,") > -1;
                //    user.KeyWordAllTB = sPurview.IndexOf("OA_Search_004,") > -1;

                //    //获取代理人信息
                //    DA_OfficeAutomation_Agent_Inherit agentbll = new DA_OfficeAutomation_Agent_Inherit();
                //    var agentds = agentbll.GetMyAgencyForAgent_II(user.EmpName, user.EmpID);
                //    if (agentds != null && agentds.Tables[0].Rows.Count > 0)
                //    {
                //        List<Agent> agents = new List<Agent>();
                //        foreach (DataRow i in agentds.Tables[0].Rows)
                //        {
                //            agents.Add(new Agent
                //            {
                //                AgentEmpID = i["OfficeAutomation_Agent_AuditorID"].ToString(),
                //                AgentEmpName = i["OfficeAutomation_Agent_Auditor"].ToString()
                //            });
                //        }
                //        user.Agents = agents;
                //    }
                //    Common.SignIn(user, 120, sPurview);

                //    if (!string.IsNullOrEmpty(Request.QueryString["backurl"]))
                //        this.Response.Redirect(Request.QueryString["backurl"]);
                //    else
                //    {

                //        Response.Write("<script>window.open('/Apply/Apply_Search.aspx?','ecoa','');  window.open('','_top');     window.top.close();    </script>");
                //        //   this.Response.Redirect("/Apply/Apply_Search.aspx");
                //        //this.Page.ClientScript.RegisterStartupScript(typeof(Page), "", "<script>showWin('/Apply/Apply_Search.aspx');</script>");
                //        //this.Page.ClientScript.RegisterStartupScript(GetType(), "", "<script><script>showWin('/Apply/Apply_Search.aspx');</script>");
                //    }
                //} 
                #endregion

                #region [2019-08-28 CREATE BY HERMAN：连接至权限系统数据库进行登录验证_新方法返回dataset]
                ////连接至权限系统数据库进行登录验证
                DataSet ds = Login_Inherit.Login_Check(UserName, UserPwd);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    iLogin_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["Login_ID"].ToString());
                    bLogin_IsBusiness = Convert.ToBoolean(ds.Tables[0].Rows[0]["Login_IsBusiness"].ToString());
                    //连接至权限系统数据库，根据LoginID获取员工权限
                    dt = User_Permission_Inherit.getUserPurview(iLogin_ID);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            sPurview = sPurview + dt.Rows[i]["Permission_Module_Purview"].ToString() + ",";
                        }
                    }

                    Session["MainID"] = "";//公文主表主键
                    Session["ID"] = "";//公文主键
                    Session["AdministrationID"] = "";
                    Session["iType"] = "";
                    Session["FormType"] = "";
                    Session["openType"] = "";

                    UserInfo user = new UserInfo();
                    user.EmpID = UserName;
                    user.EmpName = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
                    user.UnitID = ds.Tables[0].Rows[0]["UnitID"].ToString();//所属部门ID
                    user.Unit = ds.Tables[0].Rows[0]["UnitName"].ToString();//所属部门
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
                            agents.Add(new Agent
                            {
                                AgentEmpID = i["OfficeAutomation_Agent_AuditorID"].ToString(),
                                AgentEmpName = i["OfficeAutomation_Agent_Auditor"].ToString()
                            });
                        }
                        user.Agents = agents;
                    }

                    //user.Purview = sPurview;
                    Common.SignIn(user, 120, sPurview);

                    if (!string.IsNullOrEmpty(Request.QueryString["backurl"]))
                        this.Response.Redirect(Request.QueryString["backurl"]);
                    else
                    {

                        Response.Write("<script>window.open('/Apply/Apply_Search.aspx?','ecoa','');  window.open('','_top'); window.top.close();    </script>");
                        
                    }
                }
                #endregion
                else
                {
                    //Alert("您输入的用户名或密码不正确");
                    Response.Write("<script>alert('您输入的用户名或密码不正确');</script>");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                Login_Inherit = null;
                User_Permission_Inherit = null;
            }
        }
        //else
        //{
        //    Alert("!!!");
        //}
    }
}
