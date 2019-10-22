using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SqlDatabase
{
    /// <summary>
    /// û���κ��쳣
    /// </summary>
    public enum DBError
    {
        AllOk
    }

    /// <summary>
    /// ������ӿ�
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
