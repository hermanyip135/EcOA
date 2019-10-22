using System;

using DataAccess.Operate;

public partial class _Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
        string apply = txtToEmail.Text;
        string email = apply;
        Alert(email);
        //Common.SendMessageEX(false, email, "测试邮件", DateTime.Now.ToString(), "测试");
    }
}
