using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
	public class T_OfficeAutomation_Document_Print_Detail
	{
		/// <summary>
		/// ����
		/// </summary>
		[CProperty("Key")]
		public Guid OfficeAutomation_Document_Print_Detail_ID { get; set; }

		/// <summary>
		/// ����ID
		/// </summary>
		public Guid OfficeAutomation_Document_Print_Detail_MainID { get; set; }

		/// <summary>
		/// �ϴ���ͼƬ��ַ(��Ե�ַ)
		/// </summary>
		public string OfficeAutomation_Document_Print_Detail_Url { get; set; }

		/// <summary>
		/// ͼƬ����(����)
		/// </summary>
		public string OfficeAutomation_Document_Print_Detail_Alt { get; set; }

		/// <summary>
		/// ¼��ʱ��
		/// </summary>
		public DateTime? OfficeAutomation_Document_Print_Detail_Addtime { get; set; }

		/// <summary>
		/// ����
		/// </summary>
		public int OfficeAutomation_Document_Print_Detail_Sort { get; set; }

	}
}
