using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
	public class T_OfficeAutomation_Document_HoldCoisn
	{
        /// <summary>
        /// ����
        /// </summary>
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_HoldCoisn_ID { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public Guid OfficeAutomation_Document_HoldCoisn_MainID { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_Apply { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public DateTime OfficeAutomation_Document_HoldCoisn_ApplyDate { get; set; }

        /// <summary>
        /// �ɽ����
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_ApplyID { get; set; }

        /// <summary>
        /// ���У����
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_Department { get; set; }

        /// <summary>
        /// ��
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_Area { get; set; }

        /// <summary>
        /// ӪҵԱ
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_Clerk { get; set; }

        /// <summary>
        /// �ɽ�����
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_DealDate { get; set; }

        /// <summary>
        /// ��ַ
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_Address { get; set; }

        /// <summary>
        /// ԭ��
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_Reason { get; set; }

        /// <summary>
        /// �������ת�����ʱ��
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_TurnDate { get; set; }

        /// <summary>
        /// ����ԭ��
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_OtherReason { get; set; }

        /// <summary>
        /// ԭ������,|�ָ�
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_ReasonType { get; set; }

        /// <summary>
        /// ��hold������0�����а죬1���а�
        /// </summary>
        public string OfficeAutomation_Document_HoldCoisn_Condition { get; set; }

	}
}