using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
	public class T_OfficeAutomation_Document_Print
	{
		/// <summary>
		/// ����
		/// </summary>
		[CProperty("Key")]
		public Guid OfficeAutomation_Document_Print_ID { get; set; }

		/// <summary>
		/// ��������
		/// </summary>
		public Guid OfficeAutomation_Document_Print_MainID { get; set; }

		/// <summary>
		/// ������
		/// </summary>
		public string OfficeAutomation_Document_Print_Apply { get; set; }

		/// <summary>
		/// ��������
		/// </summary>
		public DateTime OfficeAutomation_Document_Print_ApplyDate { get; set; }

		/// <summary>
		/// ����
		/// </summary>
		public string OfficeAutomation_Document_Print_Department { get; set; }

		/// <summary>
		/// ��ע
		/// </summary>
		public string OfficeAutomation_Document_Print_Remark { get; set; }

	}
}
