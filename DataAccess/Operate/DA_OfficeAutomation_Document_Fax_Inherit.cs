using DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Fax_Inherit : DA_OfficeAutomation_Document_Fax_Operate
    {
        public DataSet SelectByMainID(string mainID)
        {
            string sql = @"SELECT  
                                     todi.*
                                    ,toam.OfficeAutomation_SerialNumber
                                     ,tdoad.OfficeAutomation_Document_Name
                                      ,toam.OfficeAutomation_Main_FlowStateID
                                      ,toam.OfficeAutomation_Main_Creater
                            FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Fax] todi
                           LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi.OfficeAutomation_Document_Fax_MainID
                            LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID
                            WHERE OfficeAutomation_Document_Fax_MainID='" + mainID + "'";

            return OperationSQL(sql);
        }
        public T_OfficeAutomation_Document_Fax GetEntity(string MainID)
        {
            string sWhereSql = " OfficeAutomation_Document_Fax_MainID = '" + MainID+"'";
            return  GetModel(sWhereSql);
        }
        //public DataSet SelectByMainID(string MainID)
        //{
        //    string sql = "";
        //  return  OperationSQL(sql);
        //}
    }
}
