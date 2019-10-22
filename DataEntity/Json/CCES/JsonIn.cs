using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity.Json.CCES
{
    /// <summary>
    /// 输入
    /// </summary>
    public class JsonIn
    {
        public string PageIndex { get; set; }
        public string PageSize { get; set; }
        public List<QueryWhere> QueryWhere = new List<QueryWhere>();     //数组处理 
    }

    public class QueryWhere
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Rel { get; set; }
        public string Logic { get; set; }
    }
}
