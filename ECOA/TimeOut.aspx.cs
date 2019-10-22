using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TimeOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 获得指定Url参数的值
    /// </summary>
    /// <param name="strName">Url参数</param>
    /// <returns>Url参数的值</returns>
    public static string GetQueryString(string strName)
    {
        if (HttpContext.Current.Request.QueryString[strName] == null)
            return "";

        return HttpContext.Current.Request.QueryString[strName];
    }
}
