using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// FFCircle 的摘要说明
/// </summary>
public class FFCircle
{
	public FFCircle()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static bool PushMessage(string isa, string mail)
    {
        string[] employnames;
        string apply, employname, si;

        employname = CommonConst.EMP_GMO_NAME;
        employnames = employname.Split(',');

        if (isa == "1")
            si = "同意";
        else if (isa == "0")
            si = "不同意";
        else
            si = "其它意见";

        for (int i = 0; i < employnames.Length; i++)
        {
            apply = employnames[i];
            Common.SendMessageEX(false, apply, si, mail, mail);
        }

        return true;
    }
}