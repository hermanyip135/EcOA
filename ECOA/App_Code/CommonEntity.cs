using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonEntity
{
    /// <summary>
    /// 资产实体（资产调动表使用）
    /// </summary>
    public class AssetTransferZC
    {
        public string AssetNo { get; set; }
        public string ImportDepartment { get; set; }
        public string ImportPlace { get; set; }
        public string Classes { get; set; }
        public string TS { get; set; }
        public string RecordedTime { get; set; }
    }

    public class ScrapAsset
    {
        public string AssetID { get; set; }
        public string AssetType { get; set; }
        public string AssetClasses { get; set; }
        public string AssetAssetNo { get; set; }
        public string AssetTS { get; set; }
        public string AssetRecordedTime { get; set; }
        public string AssetSurplusValue { get; set; }
        public string AssetNumber { get; set; }
    }

    public class FlowEntity
    {
        public string Idx { get; set; }
        public string Auditor { get; set; }
        public string AuditorID { get; set; }
    }
}