using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ECOA.Common
{
    public class SerializationHelper
    {
        public static T GetEntity<T>(DataTable table) where T : new()
        {
            T entity = new T();
            foreach (DataRow row in table.Rows)
            {
                foreach (var item in entity.GetType().GetProperties())
                {
                    if (row.Table.Columns.Contains(item.Name))
                    {
                        if (DBNull.Value != row[item.Name])
                        {
                            if (!item.PropertyType.IsGenericType)
                            {
                                item.SetValue(entity, Convert.ChangeType(row[item.Name], item.PropertyType), null);
                            }
                            else
                            {
                                //泛型Nullable<>
                                Type genericTypeDefinition = item.PropertyType.GetGenericTypeDefinition();
                                if (genericTypeDefinition == typeof(Nullable<>))
                                {
                                    item.SetValue(entity, row[item.Name] == null ? null : Convert.ChangeType(row[item.Name], Nullable.GetUnderlyingType(item.PropertyType)), null);

                                }
                            }
                        }

                    }
                }
            }

            return entity;
        }

        public static IList<T> GetEntities<T>(DataTable table) where T : new()
        {
            IList<T> entities = new List<T>();
            foreach (DataRow row in table.Rows)
            {
                T entity = new T();
                foreach (var item in entity.GetType().GetProperties())
                {
                    if (table.Columns.Contains(item.Name))
                    {

                        string value = row[item.Name].ToString();
                        try
                        {
                            if (!item.PropertyType.IsGenericType)
                            {
                                //非泛型
                                if (item.PropertyType == typeof(System.Guid))
                                {
                                    item.SetValue(entity, Convert.ChangeType(new Guid(value), item.PropertyType), null);
                                }
                                else
                                {
                                    item.SetValue(entity, Convert.ChangeType(value, item.PropertyType), null);
                                }
                            }
                            else
                            {
                                Type genericTypeDefinition = item.PropertyType.GetGenericTypeDefinition();
                                if (genericTypeDefinition == typeof(Nullable<>))
                                {
                                    item.SetValue(entity, string.IsNullOrEmpty(value) ? null : Convert.ChangeType(value, Nullable.GetUnderlyingType(item.PropertyType)), null);
                                }
                            }
                        }
                        catch
                        {
                            item.SetValue(entity, null, null);
                        }

                        //item.SetValue(entity, Convert.ChangeType(row[item.Name], item.PropertyType), null);
                    }
                }
                entities.Add(entity);
            }
            return entities;
        }

        #region 实体类转table

        /// <summary>
        /// 实体类转换成DataTable
        /// </summary>
        /// <param name="modelList">实体类列表</param>
        /// <returns></returns>
        public static DataSet FillDataTable<T>(List<T> modelList)
        {
            if (modelList == null || modelList.Count == 0)
            {
                return null;
            }
            DataSet ds = new DataSet();
            DataTable dt = CreateDataTable<T>(modelList[0]);

            foreach (T model in modelList)
            {
                DataRow dataRow = dt.NewRow();
                foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                {
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(model, null);
                }
                dt.Rows.Add(dataRow);
            }

            ds.Tables.Add(dt);
            ds.AcceptChanges();
            return ds;
        }

        /// <summary>
        /// 根据实体类得到表结构
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        public static DataTable CreateDataTable<T>(T model)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                dataTable.Columns.Add(new DataColumn(propertyInfo.Name));
            }
            return dataTable;
        }
        #endregion
    }
}
