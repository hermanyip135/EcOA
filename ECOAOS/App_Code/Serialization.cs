using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class CommonSerialization
{
    /// <summary>
    /// HttpRequest to T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request"></param>
    /// <returns></returns>
    public static T ReqDeserilizeAnEntity<T>(System.Web.HttpRequest request)
    {
        var obj = Activator.CreateInstance(typeof(T));

        if (request.Params == null)
        {
            return default(T);
        }

        var properties = obj.GetType().GetProperties();
        foreach (var property in properties)
        {
            if (request.Params[property.Name] != null && !string.IsNullOrEmpty(request.Params[property.Name].ToString()))
            {
                string value = request.Params[property.Name].ToString();
                try
                {
                    if (!property.PropertyType.IsGenericType)
                    {
                        //非泛型
                        property.SetValue(obj, Convert.ChangeType(value, property.PropertyType), null);
                    }
                    else
                    {
                        Type genericTypeDefinition = property.PropertyType.GetGenericTypeDefinition();
                        if (genericTypeDefinition == typeof(Nullable<>))
                        {
                            property.SetValue(obj, string.IsNullOrEmpty(value) ? null : Convert.ChangeType(value, Nullable.GetUnderlyingType(property.PropertyType)), null);
                        }
                    }
                }
                catch
                {
                    property.SetValue(obj, null, null);
                }
            }
        }
        return (T)obj;
    }

    /// <summary>
    /// DataTable转List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static List<T> DataTableDeserilizeToList<T>(DataTable dt)
    {
        var obj = Activator.CreateInstance(typeof(T));
        List<T> list = new List<T>();
        if (dt == null || dt.Rows.Count == 0)
        {
            return null;
        }
        var properties = obj.GetType().GetProperties();

        foreach (DataRow dr in dt.Rows)
        {
            list.Add(CreateItem<T>(dr));
        }

        return list;
    }

    private static T CreateItem<T>(DataRow row)
    {
        T obj = default(T);
        if (row != null)
        {
            obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in row.Table.Columns)
            {
                PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                try
                {
                    string value = row[column.ColumnName].ToString();
                    if (!prop.PropertyType.IsGenericType)
                    {
                        //非泛型
                        prop.SetValue(obj, Convert.ChangeType(value, prop.PropertyType), null);
                    }
                    else
                    {
                        Type genericTypeDefinition = prop.PropertyType.GetGenericTypeDefinition();
                        if (genericTypeDefinition == typeof(Nullable<>))
                        {
                            prop.SetValue(obj, string.IsNullOrEmpty(value) ? null : Convert.ChangeType(value, Nullable.GetUnderlyingType(prop.PropertyType)), null);
                        }
                    }
                }
                catch
                {
                    throw;//prop.SetValue(obj, null, null);
                }
            }
        }
        return obj;
    }

    public static void BindObjectToControl(string tablename, object obj, Control container)
    {
        if (obj == null) return;
        Type objType = obj.GetType();
        PropertyInfo[] objPropertiesArray = objType.GetProperties();
        string PropertyName = "";
        tablename = tablename.Substring(2,tablename.Length - 2);
        foreach (PropertyInfo objProperty in objPropertiesArray)
        {
            PropertyName = objProperty.Name;
            PropertyName = PropertyName.Replace(tablename + "_", "");
            Control control = container.FindControl(PropertyName);
            if (control != null)
            {
                // 处理控件 ...
                //if (control is ListControl)
                //{
                //    ListControl listControl = (ListControl)control;
                //    string propertyValue = objProperty.GetValue(obj, null).ToString();
                //    ListItem listItem = listControl.Items.FindByValue(propertyValue);
                //    if (listItem != null) listItem.Selected = true;
                //}
                if (control is CheckBox)
                {
                    if (objProperty.PropertyType == typeof(bool))
                        ((CheckBox)control).Checked = (bool)objProperty.GetValue(obj, null);
                }
                else if (control is Calendar)
                {
                    if (objProperty.PropertyType == typeof(DateTime))
                        ((Calendar)control).SelectedDate = (DateTime)objProperty.GetValue(obj, null);
                }
                else if (control is TextBox)
                {
                    ((TextBox)control).Text = objProperty.GetValue(obj, null) == null ? "" : objProperty.GetValue(obj, null).ToString();
                }
                else if (control is DropDownList)
                {
                    ((DropDownList)control).SelectedValue = objProperty.GetValue(obj, null) == null ? "" : objProperty.GetValue(obj, null).ToString();
                }
                else if (control is HiddenField)
                {
                    ((HiddenField)control).Value = objProperty.GetValue(obj, null) == null ? "" : objProperty.GetValue(obj, null).ToString();
                }
                else if (control is Label)
                {
                    ((Label)control).Text = objProperty.GetValue(obj, null) == null ? "" : objProperty.GetValue(obj, null).ToString();
                }
                else if (control is Literal)
                {
                    //... 等等。还可用于标签等属性。
                }
            }
        }
    }

    /// <summary>
    /// form转实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="tablename">表名</param>
    /// <param name="container">container</param>
    /// <returns></returns>
    public static T ReqDeserilizeAnEntity<T>(string tablename,Control container)
    {
        var obj = Activator.CreateInstance(typeof(T));

        var properties = obj.GetType().GetProperties();
        Control control;
        var propertyname = "";
        tablename = tablename.Substring(2, tablename.Length - 2);        //去表名的"t_"
        foreach (var property in properties)
        {
            string val = null;
            propertyname = property.Name.Replace(tablename + "_", "");
            control = container.FindControl(propertyname);
            //目前只用到TextBox、HiddenField、DropDownList
            if (control != null)
            {
                if (control is TextBox)
                {
                    val = ((TextBox)control).Text;
                }
                else if (control is HiddenField)
                {
                    val = ((HiddenField)control).Value;
                }
                else if (control is DropDownList)
                {
                    val = ((DropDownList)control).SelectedValue;
                }
                else if (control is Label)
                {
                    val = ((Label)control).Text;
                }
            }
            try
            {
                if (!property.PropertyType.IsGenericType)
                {
                    //非泛型
                    property.SetValue(obj, Convert.ChangeType(val, property.PropertyType), null);
                }
                else
                {
                    Type genericTypeDefinition = property.PropertyType.GetGenericTypeDefinition();
                    if (genericTypeDefinition == typeof(Nullable<>))
                    {
                        property.SetValue(obj, string.IsNullOrEmpty(val) ? null : Convert.ChangeType(val, Nullable.GetUnderlyingType(property.PropertyType)), null);
                    }
                }
            }
            catch
            {
                property.SetValue(obj, null, null);
            }
        }
        return (T)obj;
    }
}
