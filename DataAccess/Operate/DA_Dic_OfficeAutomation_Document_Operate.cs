using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace DataAccess.Operate
{
    public class DA_Dic_OfficeAutomation_Document_Operate : SqlInteractionBase
    {
        public override DataSet SelectAll()
        {
            string sql = "SELECT [OfficeAutomation_Document_ID]"
                            + "      ,[OfficeAutomation_Document_Name]"
                            + "      ,[OfficeAutomation_Document_TableName]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_Document]";

            return RunSQL(sql);
        }

        /// <summary>
        /// 获得所有公文及其类别
        /// </summary>
        /// <returns></returns>
        public DataSet SelectAllWithType()
        {
            string sql = "SELECT [OfficeAutomation_Document_ID],[OfficeAutomation_Document_Name],[OfficeAutomation_DocumentType_Name]"
                          + " FROM   [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_Document] d"
                          + "             LEFT JOIN [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_DocumentType] dt"
                          + "                    ON d.OfficeAutomation_Document_DocumentTypeID = dt.OfficeAutomation_DocumentType_ID"
                          + " WHERE  OfficeAutomation_DocumentType_OrderID != 0"
                          + "              AND OfficeAutomation_Document_OrderID != 0"
                          + " ORDER  BY cast(OfficeAutomation_DocumentType_OrderID as int ),"
                          + "                  OfficeAutomation_Document_OrderID ";

            return RunSQL(sql);
        }
    }
}
