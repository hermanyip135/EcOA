using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysSetting_Pwd_Change : BasePage
{
    #region Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.lbtnSave.Attributes.Add("onclick", "return DataCheck();");
            this.lbtnReset.Attributes.Add("onclick", "Form1.reset();return false");
        }
    }
    #endregion

    #region 保存
    protected void lbtnSave_Click(object sender, EventArgs e)
    {
        string employeeid = this.txtAccount.Text;
        DataAccess.Operate.DA_Login_Inherit Login_Inherit = new DataAccess.Operate.DA_Login_Inherit();
        wsKDHR.Service wsKDHRMS = new wsKDHR.Service();
        string sKDHRID = wsKDHRMS.getEmployeeStatus(employeeid);
        int iloginId;
        bool bIsBusiness;

        if (Login_Inherit.Login_Check(employeeid, this.txtOld.Text, out bIsBusiness, out iloginId))
        {
            try
            {
                if (Login_Inherit.Pwd_Change(sKDHRID, this.txtNew1.Text.Trim(), bIsBusiness))
                    //DataAccess.Multi.System_Multi.addLog(this.txtAccount.Text, wsKDHRMS.FindEmployeesByEmpCodeOnly(employeeid).Tables[0].Rows[0]["EmpName"].ToString(), 4, new Guid(sKDHRID), 2);
                    Alert("密码修改成功！");
                else
                    Alert("密码修改失败！");
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message.ToString());
            }
            finally
            {
                Login_Inherit = null;
            }
        }
        else
        {
            Alert("工号或旧密码输入错误!");
        }

        return;

    }
    #endregion
}