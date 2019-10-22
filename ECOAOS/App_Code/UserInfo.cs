using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Script.Serialization;

/// <summary>
/// UserInfo 的摘要说明
/// </summary>
public class UserInfo
{
    public string EmpID { get; set; }
    public string EmpName { get; set; }
    public string UnitID { get; set; }
    public string Unit { get; set; }
    public int LoginID { get; set; }
    public bool IsBusiness { get;set; }
    public string Purview { get; set; }
    public bool AdminSearch { get; set; }
    public bool AdminDel { get; set; }
    public string DocIDs { get; set; }
    public List<Agent> Agents { get; set; }
    public bool KeyWordAllTB { get; set; }

    // 如果还有其它的用户信息，可以继续添加。
    public override string ToString()
    {
        return string.Format("EmpID:{0},EmpName:{1},UnitID:{2},Unit:{3},LoginID:{4},IsBusiness:{5},Purview:{6}",
            EmpID, EmpName, UnitID, Unit, LoginID.ToString(), IsBusiness.ToString(), Purview);
    }

    #region IPrincipal Members

    //[ScriptIgnore]
    //public IIdentity Identity
    //{
    //    get { throw new NotImplementedException(); }
    //}
    #endregion
}

public class Agent
{
    public string AgentEmpID { get; set; }
    public string AgentEmpName { get; set; }
}