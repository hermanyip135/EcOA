using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 通知信息表
    /// </summary>
    public class T_OfficeAutomation_Message
    {
        private int officeAutomation_Message_ID;
        /// <summary>
        /// 通知信息主键
        /// </summary>
        public int OfficeAutomation_Message_ID
        {
            get { return officeAutomation_Message_ID; }
            set { officeAutomation_Message_ID = value; }
        }
        private string officeAutomation_Message_Title;
        /// <summary>
        /// 标题
        /// </summary>
        public string OfficeAutomation_Message_Title
        {
            get { return officeAutomation_Message_Title; }
            set { officeAutomation_Message_Title = value; }
        }
        private string officeAutomation_Message_Body;
        /// <summary>
        /// 内容
        /// </summary>
        public string OfficeAutomation_Message_Body
        {
            get { return officeAutomation_Message_Body; }
            set { officeAutomation_Message_Body = value; }
        }

        private string officeAutomation_Message_MessBody;
        /// <summary>
        /// 内M内容
        /// </summary>
        public string OfficeAutomation_Message_MessBody
        {
            get { return officeAutomation_Message_MessBody; }
            set { officeAutomation_Message_MessBody = value; }
        }
        private string officeAutomation_Message_ToEmail;
        /// <summary>
        /// 发送至地址
        /// </summary>
        public string OfficeAutomation_Message_ToEmail
        {
            get { return officeAutomation_Message_ToEmail; }
            set { officeAutomation_Message_ToEmail = value; }
        }
        private bool officeAutomation_Message_HtmlFlag;
        /// <summary>
        /// 是否HTML标识
        /// </summary>
        public bool OfficeAutomation_Message_HtmlFlag
        {
            get { return officeAutomation_Message_HtmlFlag; }
            set { officeAutomation_Message_HtmlFlag = value; }
        }
        private bool officeAutomation_Message_PostFlag;
        /// <summary>
        /// 是否发送成功标识
        /// </summary>
        public bool OfficeAutomation_Message_PostFlag
        {
            get { return officeAutomation_Message_PostFlag; }
            set { officeAutomation_Message_PostFlag = value; }
        }
        private DateTime officeAutomation_Message_PostDate;
        /// <summary>
        /// 发送日期
        /// </summary>
        public DateTime OfficeAutomation_Message_PostDate
        {
            get { return officeAutomation_Message_PostDate; }
            set { officeAutomation_Message_PostDate = value; }
        }

        private bool officeAutomation_Message_CreateDate;
        /// <summary>
        /// 创建日期
        /// </summary>
        public bool OfficeAutomation_Message_CreateDate
        {
            get { return officeAutomation_Message_CreateDate; }
            set { officeAutomation_Message_CreateDate = value; }
        }
    }
}
