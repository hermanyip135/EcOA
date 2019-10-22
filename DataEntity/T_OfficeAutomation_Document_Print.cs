using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
	public class T_OfficeAutomation_Document_Print
	{
		/// <summary>
		/// 主键
		/// </summary>
		[CProperty("Key")]
		public Guid OfficeAutomation_Document_Print_ID { get; set; }

		/// <summary>
		/// 主表主键
		/// </summary>
		public Guid OfficeAutomation_Document_Print_MainID { get; set; }

		/// <summary>
		/// 申请人
		/// </summary>
		public string OfficeAutomation_Document_Print_Apply { get; set; }

		/// <summary>
		/// 申请日期
		/// </summary>
		public DateTime OfficeAutomation_Document_Print_ApplyDate { get; set; }

		/// <summary>
		/// 部门
		/// </summary>
		public string OfficeAutomation_Document_Print_Department { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string OfficeAutomation_Document_Print_Remark { get; set; }

	}
}
