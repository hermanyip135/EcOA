using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;


public partial class Common_FlowShow : System.Web.UI.UserControl
{
    public List<DataEntity.Model.FLowShowEntity> FlowShowList { get; set; }
    public bool ShowEditBtn { get; set; }
    public Common_FlowShow()
    { }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.hidFlowjson.Value = JsonConvert.SerializeObject(FlowShowList);
            this.plEidtBtn.Visible = ShowEditBtn;
        }
    }
}