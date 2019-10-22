using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// ECOAws 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
// [System.Web.Script.Services.ScriptService]
public class ECOAws : System.Web.Services.WebService {

    public ECOAws () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod(Description = "输入文档的申请表名和申请日期，获得“文档访问地址|F_Model”")]
    public string GetDocumentLink(string DocumentName, string ApplyDate)
    {
        return Common.getDocumentLink(DocumentName, ApplyDate);
    }
    
}
