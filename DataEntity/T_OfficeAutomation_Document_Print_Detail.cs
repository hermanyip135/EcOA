using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
	public class T_OfficeAutomation_Document_Print_Detail
	{
		/// <summary>
		/// 主键
		/// </summary>
		[CProperty("Key")]
		public Guid OfficeAutomation_Document_Print_Detail_ID { get; set; }

		/// <summary>
		/// 主表ID
		/// </summary>
		public Guid OfficeAutomation_Document_Print_Detail_MainID { get; set; }

		/// <summary>
		/// 上传的图片地址(相对地址)
		/// </summary>
		public string OfficeAutomation_Document_Print_Detail_Url { get; set; }

		/// <summary>
		/// 图片描述(待定)
		/// </summary>
		public string OfficeAutomation_Document_Print_Detail_Alt { get; set; }

		/// <summary>
		/// 录入时间
		/// </summary>
		public DateTime? OfficeAutomation_Document_Print_Detail_Addtime { get; set; }

		/// <summary>
		/// 排序
		/// </summary>
		public int OfficeAutomation_Document_Print_Detail_Sort { get; set; }

	}
}
