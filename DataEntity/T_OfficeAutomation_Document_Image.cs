using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
   public class T_OfficeAutomation_Document_Image
    {
        /// <summary>
        /// 
        /// </summary>
           [CProperty("Key")]
        public Guid? OfficeAutomation_Document_Image_ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? OfficeAutomation_Document_Image_MainID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Image_Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? OfficeAutomation_Document_Image_CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeAutomation_Document_Image_IsDelete { get; set; }

    }
}
