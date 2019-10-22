using System;
using System.Data;

namespace DataAccess
{
    /// <summary>
    /// 没有任何异常
    /// </summary>
    public enum DBError
    {
        AllOk
    }

    /// <summary>
    /// 操作类接口
    /// </summary>
    public interface ICommonDBAccess
    {
        bool Insert(object obj);
        bool Update(object obj);
        bool Delete(object obj);
        object SelectOne(object obj);
        DataSet SelectAll();
    }
}
