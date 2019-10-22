using System;
using System.Collections.Generic;
using System.Web;

using System.IO;

using ICSharpCode.SharpZipLib.Zip;

/// <summary>
///MyNameTransfom 的摘要说明
/// </summary>
public class MyNameTransfom : ICSharpCode.SharpZipLib.Core.INameTransform
{
    #region INameTransform 成员

    public string TransformDirectory(string name)
    {
        return null;
    }

    public string TransformFile(string name)
    {
        return Path.GetFileName(name);
    }

    #endregion
}
