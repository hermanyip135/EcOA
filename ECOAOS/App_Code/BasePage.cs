using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Data;
using System.Text.RegularExpressions;
using System.Net;

public class BasePage : Page
{
    public BasePage()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public string MainID
    {
        get
        {
            try { return Session["MainID"].ToString(); }
            catch
            {
                Session["MainID"] = "";
                return Session["MainID"].ToString();
            }
        }
        set { Session["MainID"] = value; }
    }

    //public string ID
    //{
    //    get
    //    {
    //        try { return Session["ID"].ToString(); }
    //        catch
    //        {
    //            Session["ID"] = "";
    //            return Session["ID"].ToString();
    //        }
    //    }
    //    set { Session["ID"] = value; }
    //}

    //public string EmployeeID
    //{
    //    get 
    //    {
    //        try
    //        {
    //            return Session["EmployeeID"].ToString();
    //        }
    //        catch
    //        {
    //            return "";
    //        }
    //    }
    //}

    //public string EmployeeName
    //{
    //    get
    //    {
    //        try 
    //        { 
    //            return Session["EmployeeName"].ToString(); 
    //        }
    //        catch 
    //        {
    //            //Page.Response.Redirect("/TimeOut.aspx?backurl=" + GetUrl());
    //            Page.Response.Redirect("/Login.aspx?backurl=" + GetUrl());
    //            return "";
    //        }
    //    }
    //}


    public string EmployeeID = "";

    public string EmployeeName = "";

    public string UnitID = "";
    public string UnitName = "";

    public string Purview = "";

    public string DocIDs = "";

    public UserInfo LoginUser = new UserInfo();

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        try
        {
            if (!string.IsNullOrEmpty(GetQueryString("htmltopdf")))
            { return; }
            var user = Common.GetLoginUser();
            EmployeeID = user.EmpID;
            EmployeeName = user.EmpName;
            UnitID = user.UnitID;
            UnitName = user.Unit;
            Purview = user.Purview;
            DocIDs = user.DocIDs;
            LoginUser = user;
        }
        catch
        {
            Response.Redirect("~/Login.aspx");
            return;
        }
    }
    public UserInfo GetLoginUser()
    {
        return Common.GetLoginUser();
    }

    /// <summary>
    /// 是否是新申请
    /// </summary>
    public bool IsNewApply
    {
        get
        {
            try { return (bool)Session["IsNewApply"]; }
            catch
            {
                return false;
            }
        }
        set { Session["IsNewApply"] = value; }
    }

    //public string Purview
    //{
    //    get 
    //    {
    //        try
    //        {
    //            return Session["Purview"].ToString();
    //        }
    //        catch
    //        {
    //            return "";
    //        }
    //    }
    //}

    public static string SignImageURL = System.Configuration.ConfigurationManager.AppSettings["SignImageURL"];

    /// <summary>
    /// 弹出对话框
    /// </summary>
    /// <param name="msg"></param>
    public void Alert(string msg)
    {
        ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script type=\"text/javascript\">alert(\"" + msg + "\");</script>");
    }

    /// <summary>
    /// 执行JS
    /// </summary>
    /// <param name="msg"></param>
    public void RunJS(string js)
    {
        ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script type=\"text/javascript\">" + js + "</script>");
    }

    /// <summary>
    /// 执行确认对话框
    /// </summary>
    /// <param name="msg">确认信息</param>
    /// <param name="jsTrueDo">为真则执行js语句</param>
    /// <param name="jsFalseDo">为假则执行js语句</param>
    public void Confirm(string msg, string jsTrueDo, string jsFalseDo)
    {
        ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script type='text/javascript'>var r=confirm('" + msg + "');if(r==true){" + jsTrueDo + "}else{" + jsFalseDo + "}</script>");
    }

    #region 权限验证
    public bool isInPrev(string prev)
    {
        bool isReturn = false;
        try
        {
            if (Purview.IndexOf(prev) > -1)
            {
                isReturn = true;
            }
        }
        catch (System.Exception ex)
        {
            //throw new System.Exception(ex.Message.ToString());
        }

        return isReturn;

    }
    #endregion

    #region 绑定下拉列表控件（显示空行标题）
    /// <summary>
    /// 绑定下拉列表控件（显示空行标题）
    /// </summary>
    /// <param name="_ObjectName">控件ID</param>
    /// <param name="_dt">进行绑定的数据表</param>
    /// <param name="_ValueField">值字段</param>
    /// <param name="_TextField">显示字段</param>
    /// <param name="_SelectValue">选中的值</param>
    /// <param name="_Head">标题</param>
    public static void DropDownListBind(System.Web.UI.WebControls.DropDownList _ObjectName, DataTable _dt, string _ValueField,
        string _TextField, string _SelectValue, string _Head)
    {
        _ObjectName.DataSource = _dt;

        _ObjectName.DataTextField = _TextField;

        _ObjectName.DataValueField = _ValueField;

        _ObjectName.DataBind();

        bool _Selected = false;

        if (_SelectValue.Trim().Length > 0)
        {
            foreach (System.Web.UI.WebControls.ListItem SelItem in _ObjectName.Items)
            {
                if (SelItem.Value.Trim() == _SelectValue.Trim())
                {
                    SelItem.Selected = true;

                    _Selected = true;

                    break;
                }
            }
        }

        System.Web.UI.WebControls.ListItem FirstItem = new System.Web.UI.WebControls.ListItem();

        FirstItem.Text = _Head;

        FirstItem.Value = "";

        _ObjectName.Items.Insert(0, FirstItem);

        if (!_Selected)
        {
            FirstItem.Selected = true;
        }
    }
    #endregion

    #region 绑定下拉列表控件
    /// <summary>
    /// 绑定下拉列表控件
    /// </summary>
    /// <param name="_ObjectName">控件ID</param>
    /// <param name="_dt">进行绑定的数据表</param>
    /// <param name="_ValueField">值字段</param>
    /// <param name="_TextField">显示字段</param>
    /// <param name="_SelectValue">选中的值</param>
    public static void DropDownListBind(System.Web.UI.WebControls.DropDownList _ObjectName, DataTable _dt, string _ValueField,
        string _TextField, string _SelectValue)
    {
        _ObjectName.DataSource = _dt;

        _ObjectName.DataTextField = _TextField;

        _ObjectName.DataValueField = _ValueField;

        _ObjectName.DataBind();

        if (_SelectValue.Trim().Length > 0)
        {
            foreach (System.Web.UI.WebControls.ListItem SelItem in _ObjectName.Items)
            {
                if (SelItem.Value.Trim() == _SelectValue.Trim())
                {
                    SelItem.Selected = true;
                }
            }
        }
    }
    #endregion

    #region 绑定RadioButtonList控件
    /// <summary>
    /// 绑定RadioButtonList控件
    /// </summary>
    /// <param name="_ObjectName">控件ID</param>
    /// <param name="_dt">进行绑定的数据表</param>
    /// <param name="_ValueField">值字段</param>
    /// <param name="_TextField">显示字段</param>
    /// <param name="_SelectValue">选中的值</param>
    public static void RadioButtonListBind(System.Web.UI.WebControls.RadioButtonList _ObjectName, DataTable _dt, string _ValueField,
        string _TextField, string _SelectValue)
    {
        _ObjectName.DataSource = _dt;

        _ObjectName.DataTextField = _TextField;

        _ObjectName.DataValueField = _ValueField;

        _ObjectName.DataBind();

        if (_SelectValue.Trim().Length > 0)
        {
            foreach (System.Web.UI.WebControls.ListItem SelItem in _ObjectName.Items)
            {
                if (SelItem.Value.Trim() == _SelectValue.Trim())
                {
                    SelItem.Selected = true;
                }
            }
        }
    }
    #endregion


    #region 绑定CheckBoxList控件
    /// <summary>
    /// 绑定CheckBoxList控件
    /// </summary>
    /// <param name="_ObjectName">控件ID</param>
    /// <param name="_dt">进行绑定的数据表</param>
    /// <param name="_ValueField">值字段</param>
    /// <param name="_TextField">显示字段</param>
    /// <param name="_SelectValue">选中的值</param>
    public static void CheckBoxListBind(System.Web.UI.WebControls.CheckBoxList _ObjectName, DataTable _dt, string _ValueField,
        string _TextField, string _SelectValue)
    {
        _ObjectName.DataSource = _dt;

        _ObjectName.DataTextField = _TextField;
        _ObjectName.DataValueField = _ValueField;

        _ObjectName.DataBind();

        string[] selectValues = _SelectValue.Split('|');
        if (selectValues.Length > 0)
        {
            foreach (System.Web.UI.WebControls.ListItem SelItem in _ObjectName.Items)
            {
                foreach (string s in selectValues)
                {
                    if (SelItem.Value.Trim() == s.Trim())
                    {
                        SelItem.Selected = true;
                    }
                }
            }
        }
    }
    #endregion

    /// <summary>
    /// 判断当前页面是否接收到了Post请求
    /// </summary>
    /// <returns>是否接收到了Post请求</returns>
    public static bool IsPost()
    {
        return HttpContext.Current.Request.HttpMethod.Equals("POST");
    }

    /// <summary>
    /// 判断当前页面是否接收到了Get请求
    /// </summary>
    /// <returns>是否接收到了Get请求</returns>
    public static bool IsGet()
    {
        return HttpContext.Current.Request.HttpMethod.Equals("GET");
    }

    /// <summary>
    /// 返回上一个页面的地址
    /// </summary>
    /// <returns>上一个页面的地址</returns>
    public static string GetUrlReferrer()
    {
        string retVal = null;

        try
        {
            retVal = HttpContext.Current.Request.UrlReferrer.ToString();
        }
        catch { }

        if (retVal == null)
            return "";

        return retVal;
    }

    /// <summary>
    /// 得到当前完整主机头
    /// </summary>
    /// <returns></returns>
    public static string GetCurrentFullHost()
    {
        HttpRequest request = System.Web.HttpContext.Current.Request;
        if (!request.Url.IsDefaultPort)
            return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());

        return request.Url.Host;
    }

    /// <summary>
    /// 得到主机头
    /// </summary>
    /// <returns></returns>
    public static string GetHost()
    {
        return HttpContext.Current.Request.Url.Host;
    }


    /// <summary>
    /// 获取当前请求的原始 URL(URL 中域信息之后的部分,包括查询字符串(如果存在))
    /// </summary>
    /// <returns>原始 URL</returns>
    public static string GetRawUrl()
    {
        return HttpContext.Current.Request.RawUrl;
    }


    /// <summary>
    /// 获得当前完整Url地址
    /// </summary>
    /// <returns>当前完整Url地址</returns>
    public static string GetUrl()
    {
        return HttpContext.Current.Request.Url.ToString();
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
  
    /// <summary>
    /// 获得当前页面的名称
    /// </summary>
    /// <returns>当前页面的名称</returns>
    public static string GetPageName()
    {
        string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
        return urlArr[urlArr.Length - 1].ToLower();
    }

    /// <summary>
    /// 返回表单或Url参数的总个数
    /// </summary>
    /// <returns></returns>
    public static int GetParamCount()
    {
        return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
    }


    /// <summary>
    /// 获得指定表单参数的值
    /// </summary>
    /// <param name="strName">表单参数</param>
    /// <returns>表单参数的值</returns>
    public static string GetFormString(string strName)
    {
        if (HttpContext.Current.Request.Form[strName] == null)
            return "";

        return HttpContext.Current.Request.Form[strName];
    }

    /// <summary>
    /// 获得Url或表单参数的值, 先判断Url参数是否为空字符串, 如为True则返回表单参数的值
    /// </summary>
    /// <param name="strName">参数</param>
    /// <returns>Url或表单参数的值</returns>
    public static string GetString(string strName)
    {
        if ("".Equals(GetQueryString(strName)))
            return GetFormString(strName);
        else
            return GetQueryString(strName);
    }


    /// <summary>
    /// 获得指定Url参数的int类型值
    /// </summary>
    /// <param name="strName">Url参数</param>
    /// <param name="defValue">缺省值</param>
    /// <returns>Url参数的int类型值</returns>
    public static int GetQueryInt(string strName, int defValue)
    {
        return StrToInt(HttpContext.Current.Request.QueryString[strName], defValue);
    }


    /// <summary>
    /// 获得指定表单参数的int类型值
    /// </summary>
    /// <param name="strName">表单参数</param>
    /// <param name="defValue">缺省值</param>
    /// <returns>表单参数的int类型值</returns>
    public static int GetFormInt(string strName, int defValue)
    {
        return StrToInt(HttpContext.Current.Request.Form[strName], defValue);
    }

    /// <summary>
    /// 获得指定Url或表单参数的int类型值, 先判断Url参数是否为缺省值, 如为True则返回表单参数的值
    /// </summary>
    /// <param name="strName">Url或表单参数</param>
    /// <param name="defValue">缺省值</param>
    /// <returns>Url或表单参数的int类型值</returns>
    public static int GetInt(string strName, int defValue)
    {
        if (GetQueryInt(strName, defValue) == defValue)
            return GetFormInt(strName, defValue);
        else
            return GetQueryInt(strName, defValue);
    }

    /// <summary>
    /// 将对象转换为Int32类型
    /// </summary>
    /// <param name="strValue">要转换的字符串</param>
    /// <param name="defValue">缺省值</param>
    /// <returns>转换后的int类型结果</returns>
    public static int ObjectToInt(object expression, int defValue)
    {
        if (expression != null)
            return StrToInt(expression.ToString(), defValue);

        return defValue;
    }

    /// <summary>
    /// 将对象转换为Int32类型
    /// </summary>
    /// <param name="str">要转换的字符串</param>
    /// <param name="defValue">缺省值</param>
    /// <returns>转换后的int类型结果</returns>
    public static int StrToInt(string str, int defValue)
    {
        if (string.IsNullOrEmpty(str) || str.Trim().Length >= 11 || !Regex.IsMatch(str.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
            return defValue;

        int rv;
        if (Int32.TryParse(str, out rv))
            return rv;

        return Convert.ToInt32(StrToFloat(str, defValue));
    }

    /// <summary>
    /// string型转换为float型
    /// </summary>
    /// <param name="strValue">要转换的字符串</param>
    /// <param name="defValue">缺省值</param>
    /// <returns>转换后的int类型结果</returns>
    public static float StrToFloat(string strValue, float defValue)
    {
        if ((strValue == null) || (strValue.Length > 10))
            return defValue;

        float intValue = defValue;
        if (strValue != null)
        {
            bool IsFloat = Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
            if (IsFloat)
                float.TryParse(strValue, out intValue);
        }
        return intValue;
    }

    #region 获取签名图片地址

    /// <summary>
    /// 获取签名图片是否存在
    /// </summary>
    /// <param name="employeeid"></param>
    /// <returns></returns>
    public static bool CheckGIFIsExist(string employeeid)
    {
        bool result = false;
        WebResponse response = null;
        try
        {
            WebRequest req = WebRequest.Create(SignImageURL + employeeid + ".gif");
            response = req.GetResponse();
            result = response == null ? false : true;
        }
        catch (Exception ex)
        {
            result = false;
        }
        finally
        {
            if (response != null)
            {
                response.Close();
            }
        }
        return result;
    }

    /// <summary>
    /// 获取签名图片地址
    /// </summary>
    /// <param name="employeeid"></param>
    /// <returns></returns>
    public static string GetGIF(string employeeid)
    {
        return CheckGIFIsExist(employeeid) ? employeeid : "none";
    }

    #endregion

    #region 下载

    /// <summary>
    /// 对于多个文件进行打包压缩下载
    /// </summary>
    /// <param name="files">文件路径集合</param>
    /// <param name="zipFileName">压缩包名</param>
    public void Download(IEnumerable<string> files, string zipFileName)
    {
        //根据所选文件打包下载
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        byte[] buffer = null;

        using (ICSharpCode.SharpZipLib.Zip.ZipFile file = ICSharpCode.SharpZipLib.Zip.ZipFile.Create(ms))
        {
            file.BeginUpdate();
            file.NameTransform = new MyNameTransfom();//通过这个名称格式化器，可以将里面的文件名进行一些处理。默认情况下，会自动根据文件的路径在zip中创建有关的文件夹。

            foreach (string item in files)
            {
                file.Add(System.Configuration.ConfigurationManager.AppSettings["UploadPath"] + item);
            }

            file.CommitUpdate();

            buffer = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(buffer, 0, buffer.Length);
        }

        Response.AddHeader("content-disposition", "attachment;filename=" + zipFileName);
        Response.BinaryWrite(buffer);
        Response.Flush();
        Response.End();
    }

    #endregion
}    