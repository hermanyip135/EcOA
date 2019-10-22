
namespace DataEntity
{
    /// <summary>
    /// 公文名称表
    /// </summary>
    public class T_Dic_OfficeAutomation_Document
    {
        private int officeAutomatifon_Document_ID;
        /// <summary>
        /// 公文名称主键
        /// </summary>
        public int OfficeAutomatifon_Document_ID
        {
            get { return officeAutomatifon_Document_ID; }
            set { officeAutomatifon_Document_ID = value; }
        }
        private string officeAutomation_Document_Name;
        /// <summary>
        /// 公文名称
        /// </summary>
        public string OfficeAutomation_Document_Name
        {
            get { return officeAutomation_Document_Name; }
            set { officeAutomation_Document_Name = value; }
        }
        private string officeAutomation_Document_TableName;
        /// <summary>
        /// 公文对应主表
        /// </summary>
        public string OfficeAutomation_Document_TableName
        {
            get { return officeAutomation_Document_TableName; }
            set { officeAutomation_Document_TableName = value; }
        }
        
    }
}
