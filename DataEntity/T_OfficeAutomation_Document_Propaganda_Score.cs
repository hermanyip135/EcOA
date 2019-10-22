using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
   public class T_OfficeAutomation_Document_Propaganda_Score
    {
        [CProperty("Key")]
        public Guid OfficeAutomation_Document_Propaganda_Score_ID {get;set;}
        public Guid OfficeAutomation_Document_Propaganda_Score_MainID {get;set;}
        public int OfficeAutomation_Document_Propaganda_Score_DesignScore1  {get;set;}
        public string OfficeAutomation_Document_Propaganda_Score_DesignScore1Remarks { get; set; }
        //public int OfficeAutomation_Document_Propaganda_Score_DesignScore2  {get;set;}
        //public string OfficeAutomation_Document_Propaganda_Score_DesignScore2Remarks { get; set; }
        //public int OfficeAutomation_Document_Propaganda_Score_DesignScore3  {get;set;}
        //public string OfficeAutomation_Document_Propaganda_Score_DesignScore3Remarks { get; set; }
        public string OfficeAutomation_Document_Propaganda_Score_DesignScoreTime { get; set; }
        public int OfficeAutomation_Document_Propaganda_Score_AccepterScore1 { get; set; }
        public int OfficeAutomation_Document_Propaganda_Score_AccepterScore2 { get; set; }
        public int OfficeAutomation_Document_Propaganda_Score_AccepterScore3 { get; set; }
        public string OfficeAutomation_Document_Propaganda_Score_AccepterScoreTime { get; set; }
    }
}
