using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public interface IDal<TEntity> where TEntity : class
    {
        DataSet SelectAll();
        DataSet Where(string where);

        bool Exist(string where);

        TEntity GetModel<TEntity>(string key) where TEntity : new();

        TEntity Add(TEntity t);

        TEntity Edit(TEntity t);

        void Del(TEntity t);

        //bool Del(string MainID);

        bool DelByMainID(string MainID);

        DataSet SelectByMainID(string MainID);

        bool Delete(string MainID);
    }
}
