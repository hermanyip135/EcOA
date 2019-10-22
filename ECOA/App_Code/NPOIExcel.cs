using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Collections;

using NPOI;
using NPOI.POIFS;
using NPOI.HSSF;
using NPOI.Util;
using NPOI.XSSF;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

using System.Reflection;
using System.ComponentModel;
using NPOI.SS.Util;


    public class NPOIExcel
    {
        #region 把DataTable的数据写入Excel
        /// <summary>
        /// 把DataTable的数据写入Excel
        /// </summary>
        /// <param name="dt">表数据</param>
        /// <param name="FileSavePath">导出的文件存放位置</param>
        /// <param name="HeadName">首行显示的列名</param>
        /// <param name="HeadWidth">每列的宽度，单位字据</param>
        public static void NPOIExportExcel(DataTable dt, string FileSavePath, string[] HeadName, int[] HeadWidth)
        {
            if (dt == null || HeadName.Length != HeadWidth.Length || dt.Columns.Count != HeadName.Length) throw (new Exception("列值不对称"));

            //=====文件头部信息=====
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            ISheet sheet = (HSSFSheet)hssfworkbook.CreateSheet("sheet1");
            IFont font = hssfworkbook.CreateFont();
            font.FontHeightInPoints = 11;
            ICellStyle Style = hssfworkbook.CreateCellStyle();
            Style.BorderBottom = BorderStyle.Thin;
            Style.BorderLeft = BorderStyle.Thin;
            Style.BorderRight = BorderStyle.Thin;
            Style.BorderTop = BorderStyle.Thin;
            
            //Style.SetFont(font);

            var StyleDate = hssfworkbook.CreateCellStyle();
            StyleDate.BorderBottom = BorderStyle.Thin;
            StyleDate.BorderLeft = BorderStyle.Thin;
            StyleDate.BorderRight = BorderStyle.Thin;
            StyleDate.BorderTop = BorderStyle.Thin;
            var format = hssfworkbook.CreateDataFormat();//CreateDataFormat(); 
            StyleDate.DataFormat = format.GetFormat("yyyy/mm/dd");

            ICellStyle HeadStyle = hssfworkbook.CreateCellStyle();
            HeadStyle.CloneStyleFrom(Style);
            HeadStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Yellow.Index;
            HeadStyle.FillPattern = FillPattern.SolidForeground;

            NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
            for (int i = 0; i < HeadName.Length; i++)
            {
                row.CreateCell(i).SetCellValue(HeadName[i]);
                row.GetCell(i).CellStyle = HeadStyle;
                //sheet.SetColumnWidth(i, HeadWidth[i] * 256);
            }

            //=====输入table=====
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NPOI.SS.UserModel.IRow Row = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    var DataName = dt.Columns[j].ColumnName;

                    int k = 0;
                    DateTime d = new DateTime();
                    Double de = 0;
                    if (int.TryParse(dt.Rows[i][j].ToString(), out k))
                    {
                        Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("@");
                        if (DataName == "房号" || DataName == "部门编号")
                        {
                            Row.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                        }
                        else
                        {
                            Row.CreateCell(j).SetCellValue(k);
                        }
                        Row.GetCell(j).CellStyle = Style;
                    }
                    else if (DateTime.TryParse(dt.Rows[i][j].ToString(), out d))
                    {
                        Row.CreateCell(j).SetCellValue(d);
                        Row.GetCell(j).CellStyle = StyleDate;
                    }
                    else if (Double.TryParse(dt.Rows[i][j].ToString(), out de))
                    {
                        Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                        Row.CreateCell(j).SetCellValue(de);
                        Row.GetCell(j).CellStyle = Style;
                    }
                    else
                    {
                        Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("@");
                        Row.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                        Row.GetCell(j).CellStyle = Style;
                        
                    }
                }
            }

            //保存文件
            using (FileStream fStream = new FileStream(FileSavePath, FileMode.Create))
            {
                hssfworkbook.Write(fStream);
                fStream.Close();
                hssfworkbook.Clear();
            }
            //FileStream file = new FileStream(FileSavePath, FileMode.Create);
            //hssfworkbook.Write(file);
            //file.Close();
        }

        /// <summary>
        /// 把DataTable的数据写入Excel
        /// </summary>
        /// <param name="dt">表数据</param>
        /// <param name="FileSavePath">导出的文件存放位置</param>
        /// <param name="HeadName">首行显示的列名</param>
        public static void NPOIExportExcel(DataTable dt, string FileSavePath, string[] HeadName)
        {
            int columns = HeadName.Length;
            int[] HeadWidth = new int[columns];
            for (int i = 0; i < columns; i++)
            {
                HeadWidth[i] = 30;
            }
            NPOIExportExcel(dt, FileSavePath, HeadName, HeadWidth);
        }

        /// <summary>
        /// 把DataTable的数据写入Excel
        /// </summary>
        /// <param name="dt">表数据</param>
        /// <param name="FileSavePath">导出的文件存放位置</param>
        /// <param name="HeadWidth">每列的宽度，单位字据</param>
        public static void NPOIExportExcel(DataTable dt, string FileSavePath, int[] HeadWidth)
        {
            string[] HeadName = null;
            if (dt.Columns.Count > 0)
            {
                int columnNum = 0;
                columnNum = dt.Columns.Count;
                HeadName = new string[columnNum];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    HeadName[i] = dt.Columns[i].ColumnName;
                }
            }
            NPOIExportExcel(dt, FileSavePath, HeadName, HeadWidth);
        }

        /// <summary>
        /// 把DataTable的数据写入Excel
        /// </summary>
        /// <param name="dt">表数据</param>
        /// <param name="FileSavePath">导出的文件存放位置</param>
        public static void NPOIExportExcel(DataTable dt, string FileSavePath)
        {
            string[] HeadName = null;
            if (dt.Columns.Count > 0)
            {
                int columnNum = 0;
                columnNum = dt.Columns.Count;
                HeadName = new string[columnNum];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    HeadName[i] = dt.Columns[i].ColumnName;
                }
            }
            int columns = dt.Columns.Count;
            int[] HeadWidth = new int[columns];
            for (int i = 0; i < columns; i++)
            {
                HeadWidth[i] = 30;
            }
            NPOIExportExcel(dt, FileSavePath, HeadName, HeadWidth);
        }
        #endregion

        #region 读取Excel进dataTable
        /// <summary>
        ///  读取Excel进dataTable
        /// </summary>
        /// <param name="FilePath">文件的位置</param>
        /// <returns></returns>
        public static DataTable NPOIImportExcel(string FilePath)
        {
            IWorkbook _workbook;
            using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                _workbook = WorkbookFactory.Create(fs);
            }
            ISheet sheet = null;
            var data = new DataTable();
            int startRow = 0;
            try
            {
                sheet = _workbook.GetSheetAt(0);
                if (sheet != null)
                {
                    var firstRow = sheet.GetRow(0);
                    if (firstRow == null)
                        return data;
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数
                    startRow = sheet.FirstRowNum + 1;

                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                    {
                        //.StringCellValue;
                        var column = new DataColumn(Convert.ToChar(((int)'A') + i).ToString());
                        var columnName = firstRow.GetCell(i).StringCellValue;
                        column = new DataColumn(columnName);
                        data.Columns.Add(column);
                    }
                    //最后一列的标号
               
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; i++)
                    {
                        
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (j < 0)
                            { continue; }
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
                           
                        }
                   
                        data.Rows.Add(dataRow);

                    }
                }
                else throw new Exception("Don not have This Sheet");

                return data;
        }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return data;
            }
        }

        #endregion
        #region 读取Excel 多个sheet 进dataTable
        /// <summary>
        ///  读取Excel进dataTable
        /// </summary>
        /// <param name="FilePath">文件的位置</param>
        ///    /// <param name="sheet">第二个sheetNum</param>
        /// <returns></returns>
        public static DataSet NPOIImportExcels (string FilePath)
        {
            IWorkbook _workbook;
            using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                _workbook = WorkbookFactory.Create(fs);
            }
            ISheet sheet = null;
            DataSet ds = new DataSet();
           
            int startRow = 0;
            int isheets = _workbook.NumberOfSheets;
            try
            {
                for(int q=0;q<isheets;q++)
                {
                  sheet = _workbook.GetSheetAt(q);
                      if (sheet != null)
                {
                          
                    var firstRow = sheet.GetRow(0);
                    if (firstRow == null)
                        continue;
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数
                    startRow = sheet.FirstRowNum + 1;
                    var data = new DataTable();
                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                    {
                        //.StringCellValue;
                        var column = new DataColumn(Convert.ToChar(((int)'A') + i).ToString());
                        var columnName = firstRow.GetCell(i).StringCellValue;
                        column = new DataColumn(columnName);
                        data.Columns.Add(column);
                    }
                    //最后一列的标号

                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; i++)
                    {

                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (j < 0)
                            { continue; }
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();

                        }
                        data.Rows.Add(dataRow);
                    }
                          data.TableName=q.ToString();
                          ds.Tables.Add(data.Copy());
                       
                }
                     
                }
               
              

                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return ds;
            }
        }

        #endregion
        public static void NPOIExportExcel<T>(List<T> list,string[] HeadNames, string FileSavePath)
        {
            //=====文件头部信息=====
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            ISheet sheet = (HSSFSheet)hssfworkbook.CreateSheet("sheet1");
            ICellStyle Style = hssfworkbook.CreateCellStyle();
            Style.BorderBottom = BorderStyle.Thin;
            Style.BorderLeft = BorderStyle.Thin;
            Style.BorderRight = BorderStyle.Thin;
            Style.BorderTop = BorderStyle.Thin;

            //时间格式
            var StyleDate = hssfworkbook.CreateCellStyle();
            StyleDate.BorderBottom = BorderStyle.Thin;
            StyleDate.BorderLeft = BorderStyle.Thin;
            StyleDate.BorderRight = BorderStyle.Thin;
            StyleDate.BorderTop = BorderStyle.Thin;
            var format = hssfworkbook.CreateDataFormat();
            StyleDate.DataFormat = format.GetFormat("yyyy/mm/dd");

            ICellStyle HeadStyle = hssfworkbook.CreateCellStyle();
            HeadStyle.CloneStyleFrom(Style);
            HeadStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Yellow.Index;
            HeadStyle.FillPattern = FillPattern.SolidForeground;
            
            NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
          
            Type type = typeof(T);
            var Properties = type.GetProperties();
            int i = 0;
            foreach (var head in HeadNames)
            {
                var item = type.GetProperty(head);
                if (item != null)
                {
                    string des = ((DescriptionAttribute)Attribute.GetCustomAttribute(item, typeof(DescriptionAttribute))).Description;
                    des = des == null ? head : des;
                    row.CreateCell(i).SetCellValue(des);
                    row.GetCell(i).CellStyle = HeadStyle;
                }
                i++;
            }

            foreach (T item in list)
            {
                foreach (var n in HeadNames)
                {
                    var property = typeof(T).GetProperty(n);
                    property.GetValue(item, null);
                }
            }

            for (i = 0; i < list.Count; i++)
            {
                NPOI.SS.UserModel.IRow Row = sheet.CreateRow(i + 1);
                for (int j = 0; j < HeadNames.Count(); j++)
                {
                    var DataName = HeadNames[j];
                    var property = type.GetProperty(DataName);
                    var DataValue = property.GetValue(list[i], null);

                    if (!property.PropertyType.IsGenericType)
                    {
                        //非泛型
                        if (property.PropertyType == typeof(System.Decimal))
                        {
                            Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                            Row.CreateCell(j).SetCellValue(Convert.ToDouble(DataValue));
                            Row.GetCell(j).CellStyle = Style;
                        }
                        else if (property.PropertyType == typeof(System.Int32))
                        {
                            Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
                            Row.CreateCell(j).SetCellValue(Convert.ToDouble(DataValue));
                            Row.GetCell(j).CellStyle = Style;
                        }
                        else if (property.PropertyType == typeof(System.DateTime))
                        {
                            Row.CreateCell(j).SetCellValue(Convert.ToDateTime(DataValue));
                            Row.GetCell(j).CellStyle = StyleDate;
                        }
                        else if (property.PropertyType == typeof(System.Boolean))
                        {
                            Row.CreateCell(j).SetCellValue(Convert.ToBoolean(DataValue));
                            Row.GetCell(j).CellStyle = Style;
                        }
                        else
                        {
                            Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("@");
                            Row.CreateCell(j).SetCellValue(Convert.ToString(DataValue));
                            Row.GetCell(j).CellStyle = Style;
                        }
                    }
                    else
                    {
                        //泛型
                        Type genericTypeDefinition = property.PropertyType.GetGenericTypeDefinition();
                        if (genericTypeDefinition == typeof(Nullable<>))
                        {
                            //可空
                            if (DataValue == null)
                            {
                                Row.CreateCell(j).SetCellValue("");
                                Row.GetCell(j).CellStyle = Style;
                            }
                            else if (property.PropertyType == typeof(System.Nullable<DateTime>))
                            {
                                Row.CreateCell(j).SetCellValue(Convert.ToDateTime(DataValue));
                                Row.GetCell(j).CellStyle = StyleDate;
                            }
                            else if (property.PropertyType == typeof(System.Nullable<Decimal>))
                            {
                                Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                                Row.CreateCell(j).SetCellValue(Convert.ToDouble(DataValue));
                                Row.GetCell(j).CellStyle = Style;
                            }
                            else if (property.PropertyType == typeof(System.Nullable<Boolean>))
                            {
                                Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                                Row.CreateCell(j).SetCellValue(Convert.ToDouble(DataValue));
                                Row.GetCell(j).CellStyle = Style;
                            }
                            else if (property.PropertyType == typeof(System.Nullable<Int32>))
                            {
                                Row.CreateCell(j).SetCellValue(Convert.ToDouble(DataValue));
                                Row.GetCell(j).CellStyle = Style;
                            }
                        }
                    }
                }
            }

            //保存文件
            using (FileStream fStream = new FileStream(FileSavePath, FileMode.Create))
            {
                hssfworkbook.Write(fStream);
                fStream.Close();
                hssfworkbook.Clear();
            }
        }


        /// <summary>
        ///代付款导出专用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="HeadNames"></param>
        /// <param name="FileSavePath"></param>
        public static void NPOIExportExcelTitle<T>(List<T> list, string[] HeadNames, string Title, string FileSavePath)
        {
            //=====文件头部信息=====
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            ISheet sheet = (HSSFSheet)hssfworkbook.CreateSheet("sheet1");
            ICellStyle Style = hssfworkbook.CreateCellStyle();
            Style.BorderBottom = BorderStyle.Thin;
            Style.BorderLeft = BorderStyle.Thin;
            Style.BorderRight = BorderStyle.Thin;
            Style.BorderTop = BorderStyle.Thin;

            //时间格式
            var StyleDate = hssfworkbook.CreateCellStyle();
            StyleDate.BorderBottom = BorderStyle.Thin;
            StyleDate.BorderLeft = BorderStyle.Thin;
            StyleDate.BorderRight = BorderStyle.Thin;
            StyleDate.BorderTop = BorderStyle.Thin;
            var format = hssfworkbook.CreateDataFormat();
            StyleDate.DataFormat = format.GetFormat("yyyy/mm/dd");

            ICellStyle HeadStyle = hssfworkbook.CreateCellStyle();
            HeadStyle.CloneStyleFrom(Style);
            HeadStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Yellow.Index;
            HeadStyle.FillPattern = FillPattern.SolidForeground;

            NPOI.SS.UserModel.IRow rowTitle = sheet.CreateRow(0);
            rowTitle.CreateCell(0).SetCellValue(Title);
            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 6));

            NPOI.SS.UserModel.IRow row = sheet.CreateRow(1);

            Type type = typeof(T);
            var Properties = type.GetProperties();
            int i = 0;
            foreach (var head in HeadNames)
            {
                var item = type.GetProperty(head);
                if (item != null)
                {
                    string des = ((DescriptionAttribute)Attribute.GetCustomAttribute(item, typeof(DescriptionAttribute))).Description;
                    des = des == null ? head : des;
                    row.CreateCell(i).SetCellValue(des);
                    row.GetCell(i).CellStyle = HeadStyle;
                }
                i++;
            }

            foreach (T item in list)
            {
                foreach (var n in HeadNames)
                {
                    var property = typeof(T).GetProperty(n);
                    property.GetValue(item, null);
                }
            }

            for (i = 0; i < list.Count; i++)
            {
                NPOI.SS.UserModel.IRow Row = sheet.CreateRow(i + 2);
                for (int j = 0; j < HeadNames.Count(); j++)
                {
                    var DataName = HeadNames[j];
                    var property = type.GetProperty(DataName);
                    var DataValue = property.GetValue(list[i], null);
                    if (j == 0 && i != (list.Count-1))
                    {
                        DataValue = i + 1;
                    }

                    if (!property.PropertyType.IsGenericType)
                    {
                        //非泛型
                        if (property.PropertyType == typeof(System.Decimal))
                        {
                            Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                            Row.CreateCell(j).SetCellValue(Convert.ToDouble(DataValue));
                            Row.GetCell(j).CellStyle = Style;
                        }
                        else if (property.PropertyType == typeof(System.Int32))
                        {
                            Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
                            Row.CreateCell(j).SetCellValue(Convert.ToDouble(DataValue));
                            Row.GetCell(j).CellStyle = Style;
                        }
                        else if (property.PropertyType == typeof(System.DateTime))
                        {
                            Row.CreateCell(j).SetCellValue(Convert.ToDateTime(DataValue));
                            Row.GetCell(j).CellStyle = StyleDate;
                        }
                        else if (property.PropertyType == typeof(System.Boolean))
                        {
                            Row.CreateCell(j).SetCellValue(Convert.ToBoolean(DataValue));
                            Row.GetCell(j).CellStyle = Style;
                        }
                        else
                        {
                            Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("@");
                            Row.CreateCell(j).SetCellValue(Convert.ToString(DataValue));
                            Row.GetCell(j).CellStyle = Style;
                        }
                    }
                    else
                    {
                        //泛型
                        Type genericTypeDefinition = property.PropertyType.GetGenericTypeDefinition();
                        if (genericTypeDefinition == typeof(Nullable<>))
                        {
                            //可空
                            if (DataValue == null)
                            {
                                Row.CreateCell(j).SetCellValue("");
                                Row.GetCell(j).CellStyle = Style;
                            }
                            else if (property.PropertyType == typeof(System.Nullable<DateTime>))
                            {
                                Row.CreateCell(j).SetCellValue(Convert.ToDateTime(DataValue));
                                Row.GetCell(j).CellStyle = StyleDate;
                            }
                            else if (property.PropertyType == typeof(System.Nullable<Decimal>))
                            {
                                Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                                Row.CreateCell(j).SetCellValue(Convert.ToDouble(DataValue));
                                Row.GetCell(j).CellStyle = Style;
                            }
                            else if (property.PropertyType == typeof(System.Nullable<Boolean>))
                            {
                                Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                                Row.CreateCell(j).SetCellValue(Convert.ToDouble(DataValue));
                                Row.GetCell(j).CellStyle = Style;
                            }
                            else if (property.PropertyType == typeof(System.Nullable<Int32>))
                            {
                                Row.CreateCell(j).SetCellValue(Convert.ToDouble(DataValue));
                                Row.GetCell(j).CellStyle = Style;
                            }
                        }
                    }
                }
            }

            //保存文件
            using (FileStream fStream = new FileStream(FileSavePath, FileMode.Create))
            {
                hssfworkbook.Write(fStream);
                fStream.Close();
                hssfworkbook.Clear();
            }
        }


        /// <summary>
        ///代付款导出专用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="HeadNames"></param>
        /// <param name="FileSavePath"></param>
        public static void ExportToExcel<T>(List<T> list, string[] HeadNames,string [] headValueNames, string FileSavePath)
        {
            //=====文件头部信息=====
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            ISheet sheet = (HSSFSheet)hssfworkbook.CreateSheet("sheet1");
            ICellStyle Style = hssfworkbook.CreateCellStyle();
            Style.BorderBottom = BorderStyle.Thin;
            Style.BorderLeft = BorderStyle.Thin;
            Style.BorderRight = BorderStyle.Thin;
            Style.BorderTop = BorderStyle.Thin;

            //时间格式
            var StyleDate = hssfworkbook.CreateCellStyle();
            StyleDate.BorderBottom = BorderStyle.Thin;
            StyleDate.BorderLeft = BorderStyle.Thin;
            StyleDate.BorderRight = BorderStyle.Thin;
            StyleDate.BorderTop = BorderStyle.Thin;
            var format = hssfworkbook.CreateDataFormat();
            StyleDate.DataFormat = format.GetFormat("yyyy/mm/dd");

            ICellStyle HeadStyle = hssfworkbook.CreateCellStyle();
            HeadStyle.CloneStyleFrom(Style);
            HeadStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Yellow.Index;
            HeadStyle.FillPattern = FillPattern.SolidForeground;

    

            NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);

            Type type = typeof(T);
            var Properties = type.GetProperties();
            int i = 0;
            foreach (var head in HeadNames)
            {
                //var item = type.GetProperty(head);
                //if (item != null)
                //{
                //    string des = ((DescriptionAttribute)Attribute.GetCustomAttribute(item, typeof(DescriptionAttribute))).Description;
                //    des = des == null ? head : des;
                row.CreateCell(i).SetCellValue(head);
                    row.GetCell(i).CellStyle = HeadStyle;
                //}
                i++;
            }

            foreach (T item in list)
            {
                foreach (var n in headValueNames)
                {
                    var property = typeof(T).GetProperty(n);
                    property.GetValue(item, null);
                }
            }

            for (i = 0; i < list.Count; i++)
            {
                NPOI.SS.UserModel.IRow Row = sheet.CreateRow(i + 1);
                for (int j = 0; j < HeadNames.Count(); j++)
                {
                    var DataName = headValueNames[j];
                    var property = type.GetProperty(DataName);
                    var DataValue = property.GetValue(list[i], null);
                    //if (j == 0 && i != (list.Count - 1))
                    //{
                    //    DataValue = i + 1;
                    //}

                    if (!property.PropertyType.IsGenericType)
                    {
                        //非泛型
                        if (property.PropertyType == typeof(System.Decimal))
                        {
                            Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                            Row.CreateCell(j).SetCellValue(Convert.ToDouble(DataValue));
                            Row.GetCell(j).CellStyle = Style;
                        }
                        else if (property.PropertyType == typeof(System.Int32))
                        {
                            Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
                            Row.CreateCell(j).SetCellValue(Convert.ToDouble(DataValue));
                            Row.GetCell(j).CellStyle = Style;
                        }
                        else if (property.PropertyType == typeof(System.DateTime))
                        {
                            Row.CreateCell(j).SetCellValue(Convert.ToDateTime(DataValue));
                            Row.GetCell(j).CellStyle = StyleDate;
                        }
                        else if (property.PropertyType == typeof(System.Boolean))
                        {
                            Row.CreateCell(j).SetCellValue(Convert.ToBoolean(DataValue));
                            Row.GetCell(j).CellStyle = Style;
                        }
                        else
                        {
                            Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("@");
                            Row.CreateCell(j).SetCellValue(Convert.ToString(DataValue));
                            Row.GetCell(j).CellStyle = Style;
                        }
                    }
                    else
                    {
                        //泛型
                        Type genericTypeDefinition = property.PropertyType.GetGenericTypeDefinition();
                        if (genericTypeDefinition == typeof(Nullable<>))
                        {
                            //可空
                            if (DataValue == null)
                            {
                                Row.CreateCell(j).SetCellValue("");
                                Row.GetCell(j).CellStyle = Style;
                            }
                            else if (property.PropertyType == typeof(System.Nullable<DateTime>))
                            {
                                Row.CreateCell(j).SetCellValue(Convert.ToDateTime(DataValue));
                                Row.GetCell(j).CellStyle = StyleDate;
                            }
                            else if (property.PropertyType == typeof(System.Nullable<Decimal>))
                            {
                                Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                                Row.CreateCell(j).SetCellValue(Convert.ToDouble(DataValue));
                                Row.GetCell(j).CellStyle = Style;
                            }
                            else if (property.PropertyType == typeof(System.Nullable<Boolean>))
                            {
                                Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                                Row.CreateCell(j).SetCellValue(Convert.ToDouble(DataValue));
                                Row.GetCell(j).CellStyle = Style;
                            }
                            else if (property.PropertyType == typeof(System.Nullable<Int32>))
                            {
                                Row.CreateCell(j).SetCellValue(Convert.ToDouble(DataValue));
                                Row.GetCell(j).CellStyle = Style;
                            }
                        }
                    }
                }
            }

            //保存文件
            using (FileStream fStream = new FileStream(FileSavePath, FileMode.Create))
            {
                hssfworkbook.Write(fStream);
                fStream.Close();
                hssfworkbook.Clear();
            }
        }
    }
