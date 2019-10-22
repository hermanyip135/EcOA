using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlTypes;

namespace DataEntity
{
    public class T_OfficeAutomation_Agent
    {
        private int officeAutomation_Agent_ID;

        public int OfficeAutomation_Agent_ID
        {
            get { return officeAutomation_Agent_ID; }
            set { officeAutomation_Agent_ID = value; }
        }

        private string officeAutomation_Agent_Auditor;

        public string OfficeAutomation_Agent_Auditor
        {
            get { return officeAutomation_Agent_Auditor; }
            set { officeAutomation_Agent_Auditor = value; }
        }

        private string officeAutomation_Agent_AuditorID;

        public string OfficeAutomation_Agent_AuditorID
        {
            get { return officeAutomation_Agent_AuditorID; }
            set { officeAutomation_Agent_AuditorID = value; }
        }

        private string officeAutomation_Agent_Agent;

        public string OfficeAutomation_Agent_Agent
        {
            get { return officeAutomation_Agent_Agent; }
            set { officeAutomation_Agent_Agent = value; }
        }

        private string officeAutomation_Agent_AgentID;

        public string OfficeAutomation_Agent_AgentID
        {
            get { return officeAutomation_Agent_AgentID; }
            set { officeAutomation_Agent_AgentID = value; }
        }

        private DateTime officeAutomation_Agent_Start;

        public DateTime OfficeAutomation_Agent_Start
        {
            get { return officeAutomation_Agent_Start; }
            set { officeAutomation_Agent_Start = value; }
        }

        private DateTime officeAutomation_Agent_End;

        public DateTime OfficeAutomation_Agent_End
        {
            get { return officeAutomation_Agent_End; }
            set { officeAutomation_Agent_End = value; }
        }
        private bool officeAutomation_Agent_IsEnable;

        public bool OfficeAutomation_Agent_IsEnable
        {
            get { return officeAutomation_Agent_IsEnable; }
            set { officeAutomation_Agent_IsEnable = value; }
        }

        private DateTime officeAutomation_Agent_CreateTime;

        public DateTime OfficeAutomation_Agent_CreateTime
        {
            get { return officeAutomation_Agent_CreateTime; }
            set { officeAutomation_Agent_CreateTime = value; }
        }
    }
}
