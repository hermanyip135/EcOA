using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.Json.CCES.JsonOutEstateList
{
    /// <summary>
    /// 输出楼盘列表
    /// </summary>
    public class JsonOut
    {
        public string Code { get; set; }
        public string Mes { get; set; }
        public Obj Obj;
    }

    public class Obj
    {
        public string total { get; set; }
        public List<rows> rows;     //数组处理
    }

    public class rows
    {
        public string rowId { get; set; }
        public string EstateID { get; set; }
        public string EstateName { get; set; }
        public string EstateName2 { get; set; }
    }
}
