using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Data;
using System.Collections;

/// <summary>
/// AssetMethod 的摘要说明
/// </summary>
public class AssetMethod
{
	public AssetMethod()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static string GetScrapAsset(string mid)
    {
        var tempfilepath = CommonConst.GetTempXmlPath(mid);
        string json = "";
        //临时xml文件(优先读)
        if (File.Exists(tempfilepath))
        {
            var list = XmlHelper.XmlDeserializeFromFile<List<CommonEntity.ScrapAsset>>(tempfilepath, Encoding.UTF8);   //反序列化xml
            json = JsonConvert.SerializeObject(list);
        }
        else
        {
            var DetailBLL = new DataAccess.Operate.DA_OfficeAutomation_Document_Scrap_Detail_Inherit();
            var ds = DetailBLL.SelectByMainID(mid);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                List<CommonEntity.ScrapAsset> list = new List<CommonEntity.ScrapAsset>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new CommonEntity.ScrapAsset
                    {
                        AssetAssetNo = dr["OfficeAutomation_Document_Scrap_Detail_AssetTag"].ToString(),
                        AssetClasses = dr["OfficeAutomation_Document_Scrap_Detail_AssetName"].ToString(),
                        AssetID = dr["OfficeAutomation_Document_Scrap_Detail_AssetAID"].ToString(),
                        AssetRecordedTime = dr["OfficeAutomation_Document_Scrap_Detail_BuyDate"].ToString(),
                        AssetTS = dr["OfficeAutomation_Document_Scrap_Detail_Model"].ToString(),
                        AssetType = dr["OfficeAutomation_Document_Scrap_Detail_PlaceRec"].ToString(),
                        AssetSurplusValue = dr["OfficeAutomation_Document_Scrap_Detail_SurplusValue"].ToString(),
                        AssetNumber = dr["OfficeAutomation_Document_Scrap_Detail_Number"].ToString()
                    });
                }
                json = JsonConvert.SerializeObject(list);
            }
        }
        return json;
    }
}