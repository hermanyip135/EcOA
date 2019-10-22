using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using DataAccess.Operate;
using DataEntity;

public partial class SysSetting_Agent_Setting : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    /// <summary>
    /// 绑定数据
    /// </summary>
    public void BindData()
    {
        DataSet ds = new DataSet();
        DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();

        ds = da_OfficeAutomation_Agent_Inherit.SelectByAuditorID(EmployeeID);

        gvData.DataSource = ds;
        gvData.DataBind();
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
            T_OfficeAutomation_Agent t_OfficeAutomation_Agent = new T_OfficeAutomation_Agent();

            t_OfficeAutomation_Agent.OfficeAutomation_Agent_AuditorID = EmployeeID;
            t_OfficeAutomation_Agent.OfficeAutomation_Agent_Auditor = EmployeeName;
            t_OfficeAutomation_Agent.OfficeAutomation_Agent_AgentID = this.txtAgentID.Value;
            t_OfficeAutomation_Agent.OfficeAutomation_Agent_Agent = this.txtAgent.Value;
            t_OfficeAutomation_Agent.OfficeAutomation_Agent_Start = DateTime.Parse(this.txtStart.Value);
            t_OfficeAutomation_Agent.OfficeAutomation_Agent_End = DateTime.Parse(this.txtEnd.Value);
            t_OfficeAutomation_Agent.OfficeAutomation_Agent_IsEnable = rdbYES.Checked;

            da_OfficeAutomation_Agent_Inherit.Insert(t_OfficeAutomation_Agent);

            Alert("创建成功！");
            BindData();
        }
        catch (Exception ex)
        {
            Alert("创建代理人失败！错误代码：" + ex.Message);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
            T_OfficeAutomation_Agent t_OfficeAutomation_Agent = new T_OfficeAutomation_Agent();

            t_OfficeAutomation_Agent.OfficeAutomation_Agent_ID = int.Parse(this.hdID.Value);
            t_OfficeAutomation_Agent.OfficeAutomation_Agent_AgentID = this.txtAgentID.Value;
            t_OfficeAutomation_Agent.OfficeAutomation_Agent_Agent = this.txtAgent.Value;
            t_OfficeAutomation_Agent.OfficeAutomation_Agent_Start = DateTime.Parse(this.txtStart.Value);
            t_OfficeAutomation_Agent.OfficeAutomation_Agent_End = DateTime.Parse(this.txtEnd.Value);
            t_OfficeAutomation_Agent.OfficeAutomation_Agent_IsEnable = rdbYES.Checked;

            da_OfficeAutomation_Agent_Inherit.Update(t_OfficeAutomation_Agent);

            Alert("修改成功！");
            BindData();
        }
        catch (Exception ex)
        {
            Alert("修改代理人失败！错误代码：" + ex.Message);
        }
    }

    #region GridView事件
    /// <summary>
    /// gvData行数据绑定事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (e.Row.RowIndex > -1)
            {
                if (drv.Row["OfficeAutomation_Agent_IsEnable"].ToString() == "True")
                    e.Row.Cells[5].Text = "开启";
                else
                    e.Row.Cells[5].Text = "关闭";
            }
        }
    }

    /// <summary>
    /// gvData行命令事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
        string commType = e.CommandName.ToString();
        switch (commType)
        {
            //case "Del":
            //    Alert("删除记录" + (da_OfficeAutomation_Agent_Inherit.Delete(e.CommandArgument.ToString()) ? "成功!" : "失败!"));
            //    break;
            case "EditAgent":
                DataSet ds = da_OfficeAutomation_Agent_Inherit.SelectByID(e.CommandArgument.ToString());
                DataRow dr = ds.Tables[0].Rows[0];
                this.hdID.Value = dr["OfficeAutomation_Agent_ID"].ToString();
                this.txtAgent.Value = dr["OfficeAutomation_Agent_Agent"].ToString();
                this.txtAgentID.Value = dr["OfficeAutomation_Agent_AgentID"].ToString();
                this.txtStart.Value = DateTime.Parse(dr["OfficeAutomation_Agent_Start"].ToString()).ToString("yyyy-MM-dd");
                this.txtEnd.Value = DateTime.Parse(dr["OfficeAutomation_Agent_End"].ToString()).ToString("yyyy-MM-dd");
                if (dr["OfficeAutomation_Agent_IsEnable"].ToString() == "True")
                    rdbYES.Checked = true;
                else
                    rdbNO.Checked = true;
                this.btnSave.Visible = true;

                break;
        }

        if (this.gvData.PageIndex + 1 > this.gvData.PageCount)
        {
            this.gvData.PageIndex = this.gvData.PageCount - 1;
        }
        BindData();
    }

    /// <summary>
    /// gvData页码改变事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // 得到该控件
        GridView theGrid = sender as GridView;
        int newPageIndex = 0;
        if (e.NewPageIndex == -3)
        {
            newPageIndex = StrToInt(hdPagerNum.Value, 1) - 1;
        }
        else
        {
            //点击了其他的按钮
            newPageIndex = e.NewPageIndex;
        }
        //防止新索引溢出
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;

        //得到新的值
        theGrid.PageIndex = newPageIndex;

        //重新绑定
        BindData();
    }

    #endregion
}
