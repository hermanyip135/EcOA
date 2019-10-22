using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlTypes;

namespace DataEntity
{
    public class T_OfficeAutomation_Attach
    {
        private Guid officeAutomation_Attach_ID;

        public Guid OfficeAutomation_Attach_ID
        {
            get { return officeAutomation_Attach_ID; }
            set { officeAutomation_Attach_ID = value; }
        }

        private Guid officeAutomation_Attach_MainID;

        public Guid OfficeAutomation_Attach_MainID
        {
            get { return officeAutomation_Attach_MainID; }
            set { officeAutomation_Attach_MainID = value; }
        }

        private string officeAutomation_Attach_Name;

        public string OfficeAutomation_Attach_Name
        {
            get { return officeAutomation_Attach_Name; }
            set { officeAutomation_Attach_Name = value; }
        }
        private string officeAutomation_Attach_Path;

        public string OfficeAutomation_Attach_Path
        {
            get { return officeAutomation_Attach_Path; }
            set { officeAutomation_Attach_Path = value; }
        }
    }
}
