using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Common_User_AutoComplete : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["t"] != null)
        {
            this.Mode = Request.QueryString["t"].ToString();
        }
    }
    /// <summary>
    /// 文本框输入的内容
    /// </summary>
    public string Data
    {
        get
        {
            return this.txtData.Text.Trim();
        }
        set
        {
            this.txtData.Text = value;
        }
    }
    /// <summary>
    /// 对应的ID
    /// </summary>
    public string Key
    {
        get
        {
            return this.hfKey.Value;
        }
        set
        {
            this.hfKey.Value = value;
        }
    }

    private string _mode;
    /// <summary>
    /// 模式,默认为dep模式,搜索部门
    /// </summary>
    public string Mode
    {
        get
        {
            if (string.IsNullOrEmpty(this._mode))
            {
                this._mode = "dep";
            }
            return _mode;
        }
        set
        {
            _mode = value;
        }
    }

    /// <summary>
    /// 根目录路径
    /// </summary>
    public string RootPath
    {
        get
        {
            return "http://" + Request.Url.Authority + "/";
        }
    }

    public bool Selected
    {
        get
        {
            return !string.IsNullOrEmpty(this.hfKey.Value);
        }
    }

    private int _width = 200;

    public int Width
    {
        get { return _width; }
        set { _width = value; }
    }

    private string onSelected = "";

    public string OnSelected
    {
        get { return onSelected; }
        set { onSelected = value; }
    }

}
