using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;

namespace ECOA.Common
{
    public class PDFHelper
    {
        public bool WordToPDF(string sourcePath, string targetPath)
        {
            return Convert(sourcePath, targetPath, Word.WdExportFormat.wdExportFormatPDF);
        }

        public bool ExcelToPDF(string sourcePath, string targetPath)
        {
            return Convert(sourcePath, targetPath, XlFixedFormatType.xlTypePDF);
        }

        //将word文档转换成PDF格式
        private bool Convert(string sourcePath, string targetPath, Word.WdExportFormat exportFormat)
        {
            bool result;
            object paramMissing = Type.Missing;
            Word.ApplicationClass wordApplication = new Word.ApplicationClass();
            Word.Document wordDocument = null;
            try
            {
                object paramSourceDocPath = sourcePath;
                string paramExportFilePath = targetPath;

                Word.WdExportFormat paramExportFormat = exportFormat;
                bool paramOpenAfterExport = false;
                Word.WdExportOptimizeFor paramExportOptimizeFor =
                        Word.WdExportOptimizeFor.wdExportOptimizeForPrint;
                Word.WdExportRange paramExportRange = Word.WdExportRange.wdExportAllDocument;
                int paramStartPage = 0;
                int paramEndPage = 0;
                Word.WdExportItem paramExportItem = Word.WdExportItem.wdExportDocumentContent;
                bool paramIncludeDocProps = true;
                bool paramKeepIRM = true;
                Word.WdExportCreateBookmarks paramCreateBookmarks =
                        Word.WdExportCreateBookmarks.wdExportCreateWordBookmarks;
                bool paramDocStructureTags = true;
                bool paramBitmapMissingFonts = true;
                bool paramUseISO19005_1 = false;
                object isVisible = false;
                object isRevert = false;
                //wordApplication.Documents.CheckOut(paramSourceDocPath);
                wordDocument = wordApplication.Documents.Open(
                        ref paramSourceDocPath, ref paramMissing, ref paramMissing,
                        ref paramMissing, ref paramMissing, ref paramMissing,
                        ref isRevert, ref paramMissing, ref paramMissing,
                        ref paramMissing, ref paramMissing, ref isVisible,
                        ref paramMissing, ref paramMissing, ref paramMissing,
                        ref paramMissing);
                if (wordDocument.HasPassword)
                    return true;
                if (wordDocument != null)
                    wordDocument.ExportAsFixedFormat(paramExportFilePath,
                            paramExportFormat, paramOpenAfterExport,
                            paramExportOptimizeFor, paramExportRange, paramStartPage,
                            paramEndPage, paramExportItem, paramIncludeDocProps,
                            paramKeepIRM, paramCreateBookmarks, paramDocStructureTags,
                            paramBitmapMissingFonts, paramUseISO19005_1,
                            ref paramMissing);
                result = true;
            }
            finally
            {
                if (wordDocument != null)
                {
                    wordDocument.Close(ref paramMissing, ref paramMissing, ref paramMissing);
                    wordDocument = null;
                }
                if (wordApplication != null)
                {
                    wordApplication.Quit(ref paramMissing, ref paramMissing, ref paramMissing);
                    wordApplication = null;
                }
                //GC.Collect();
                //GC.WaitForPendingFinalizers();
            }
            return result;
        }

        //将excel文档转换成PDF格式
        private bool Convert(string sourcePath, string targetPath, XlFixedFormatType targetType)
        {
            bool result;
            object missing = Type.Missing;
            Excel.ApplicationClass application = null;
            Workbook workBook = null;
            try
            {
                application = new Excel.ApplicationClass();
                object target = targetPath;
                object type = targetType;
                workBook = application.Workbooks.Open(sourcePath, missing, missing, missing, missing, missing,
                        missing, missing, missing, missing, missing, missing, missing, missing, missing);

                workBook.ExportAsFixedFormat(targetType, target, XlFixedFormatQuality.xlQualityStandard, true, false, missing, missing, missing, missing);
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (workBook != null)
                {
                    workBook.Close(true, missing, missing);
                    workBook = null;
                }
                if (application != null)
                {
                    application.Quit();
                    application = null;
                }
                //GC.Collect();
                //GC.WaitForPendingFinalizers();
            }
            return result;
        }

    }
}
