using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace DataEntity
{
    public class T_OfficeAutomation_Log : DBInteractionBase
    {
        #region Class Member Declarations
        private SqlDateTime _officeAutomation_Log_OperateTime;
        private SqlInt32 _officeAutomation_Log_OperateModuleID, _officeAutomation_Log_OperateID;
        private SqlString _officeAutomation_Log_EmployeeID, _officeAutomation_Log_EmployeeName, _officeAutomation_Log_OperateDesc;
        private SqlGuid _officeAutomation_Log_ID, _officeAutomation_Log_OperateModuleMainID;
        #endregion

        #region Class Property Declarations
        public SqlGuid OfficeAutomation_Log_ID
        {
            get
            {
                return _officeAutomation_Log_ID;
            }
            set
            {
                _officeAutomation_Log_ID = value;
            }
        }


        public SqlString OfficeAutomation_Log_EmployeeID
        {
            get
            {
                return _officeAutomation_Log_EmployeeID;
            }
            set
            {
                SqlString officeAutomation_Log_EmployeeIDTmp = (SqlString)value;
                if (officeAutomation_Log_EmployeeIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("OfficeAutomation_Log_EmployeeID", "OfficeAutomation_Log_EmployeeID can't be NULL");
                }
                _officeAutomation_Log_EmployeeID = value;
            }
        }


        public SqlString OfficeAutomation_Log_EmployeeName
        {
            get
            {
                return _officeAutomation_Log_EmployeeName;
            }
            set
            {
                SqlString officeAutomation_Log_EmployeeNameTmp = (SqlString)value;
                if (officeAutomation_Log_EmployeeNameTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("OfficeAutomation_Log_EmployeeName", "OfficeAutomation_Log_EmployeeName can't be NULL");
                }
                _officeAutomation_Log_EmployeeName = value;
            }
        }


        public SqlDateTime OfficeAutomation_Log_OperateTime
        {
            get
            {
                return _officeAutomation_Log_OperateTime;
            }
            set
            {
                SqlDateTime officeAutomation_Log_OperateTimeTmp = (SqlDateTime)value;
                if (officeAutomation_Log_OperateTimeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("OfficeAutomation_Log_OperateTime", "OfficeAutomation_Log_OperateTime can't be NULL");
                }
                _officeAutomation_Log_OperateTime = value;
            }
        }


        public SqlInt32 OfficeAutomation_Log_OperateModuleID
        {
            get
            {
                return _officeAutomation_Log_OperateModuleID;
            }
            set
            {
                SqlInt32 officeAutomation_Log_OperateModuleIDTmp = (SqlInt32)value;
                if (officeAutomation_Log_OperateModuleIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("OfficeAutomation_Log_OperateModuleID", "OfficeAutomation_Log_OperateModuleID can't be NULL");
                }
                _officeAutomation_Log_OperateModuleID = value;
            }
        }


        public SqlGuid OfficeAutomation_Log_OperateModuleMainID
        {
            get
            {
                return _officeAutomation_Log_OperateModuleMainID;
            }
            set
            {
                SqlGuid officeAutomation_Log_OperateModuleMainIDTmp = (SqlGuid)value;
                if (officeAutomation_Log_OperateModuleMainIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("OfficeAutomation_Log_OperateModuleMainID", "OfficeAutomation_Log_OperateModuleMainID can't be NULL");
                }
                _officeAutomation_Log_OperateModuleMainID = value;
            }
        }


        public SqlInt32 OfficeAutomation_Log_OperateID
        {
            get
            {
                return _officeAutomation_Log_OperateID;
            }
            set
            {
                SqlInt32 officeAutomation_Log_OperateIDTmp = (SqlInt32)value;
                if (officeAutomation_Log_OperateIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("OfficeAutomation_Log_OperateID", "OfficeAutomation_Log_OperateID can't be NULL");
                }
                _officeAutomation_Log_OperateID = value;
            }
        }


        public SqlString OfficeAutomation_Log_OperateDesc
        {
            get
            {
                return _officeAutomation_Log_OperateDesc;
            }
            set
            {
                SqlString officeAutomation_Log_OperateDescTmp = (SqlString)value;
                if (officeAutomation_Log_OperateDescTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("OfficeAutomation_Log_OperateDesc", "OfficeAutomation_Log_OperateDesc can't be NULL");
                }
                _officeAutomation_Log_OperateDesc = value;
            }
        }
        #endregion
    }
}
