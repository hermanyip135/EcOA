using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ECOA.Common;

/// <summary>
/// TypeUnit 的摘要说明
/// </summary>
public static class TypeUnit
{
    internal static List<T> ToList<T>(this DataTable dt) where T : new()
    {
        if (dt == null || dt.Rows.Count == 0)
        {
            return null;
        }
        return ECOA.Common.SerializationHelper.GetEntities<T>(dt).ToList();
    }
}