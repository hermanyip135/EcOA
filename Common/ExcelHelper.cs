using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace ECOA.Common
{
    public class ExcelHelper
    {
        public static DataSet ReadExcel(string path, string sheetname)
        {
            try
            {
                OleDbConnection ImportConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; " + "data source=" + path + "; " + "Extended Properties='Excel 8.0;HDR=1; IMEX=1;'");               
                OleDbDataAdapter ImportCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + sheetname + "$]", ImportConnection);
                DataSet ds = new DataSet();
                ImportCommand.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  List<string> fnGetSheetNamesByExcel(string sPath)
        {
            string strConn = fnGetStringConn(sPath);
            List<string> tableName = new List<string>();

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                if (schemaTable != null && schemaTable.Rows.Count > 0)
                {
                    foreach (DataRow row in schemaTable.Rows)
                    {
                        string n = row["TABLE_NAME"].ToString().Trim();

                        if (n.EndsWith("$"))
                        {
                            n = n.Substring(0, n.Length - 1);
                            tableName.Add(n);
                        }
                    }
                }
                conn.Close();
            }
            return tableName;
        }
        /// <summary>
        /// 将文件读取到DataSet
        /// </summary>
        /// <param name="sPath">文件路径,包含文件名,服务器路径</param>
        /// <param name="sTableName">要查询的表的名字</param>
        /// <returns></returns>
        public  DataSet fnGetDataSetByExcel(string sPath, string sSheetName)
        {
            string sConn = fnGetStringConn(sPath);
            string sSql = "select * from [" + sSheetName + "$]";
            DataSet ds = new DataSet();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(sSql, sConn);
            myCommand.Fill(ds, "table1");
            myCommand.Dispose();

            return ds;
        }
        #region fnGetStringConn 根据文件扩展名获取连接字符串
        /// <summary>
        /// 根据文件扩展名获取连接字符串
        /// </summary>
        /// <param name="sPath"></param>
        /// <returns></returns>
        public static string fnGetStringConn(string sPath)
        {
            //string strConn = "",
            //       sType = sPath.Substring(sPath.LastIndexOf('.') + 1); //文件名扩展名

            //switch (sType)
            //{
            //    case "xls":
            //        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sPath + ";Extended Properties=Excel 8.0;";
            //        break;
            //    case "xlsx":
            //        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sPath + ";Extended Properties=Excel 12.0;";
            //        break;
            //}

            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sPath + ";Extended Properties=Excel 12.0;";

            return strConn;
        }
        #endregion

    }
}
