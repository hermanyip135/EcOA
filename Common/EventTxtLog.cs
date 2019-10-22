using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ECOA.Common
{
    /// <summary>
    /// �¼��ı���־
    /// </summary>
    public class EventTxtLog
    {
        #region �ڲ�����
        private string strFilePath;
        private string strFileName;
        private string strAllFilePath;
        #endregion

        #region ����
         //<summary>
         //����
         //</summary>
         //<param name="filepath"></param>
        public EventTxtLog(string filepath)
        {
            this.strFilePath = filepath;                                       //�ļ�·��
            this.strFileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";     //�ļ���
            this.strAllFilePath = this.strFilePath + "\\" + this.strFileName;  //�ļ�����·��
            //�����ļ���
            if (!Directory.Exists(strFilePath))
            {
                Directory.CreateDirectory(strFilePath);
            }
        }
        #endregion

        #region ����
        /// <summary>
        /// д����־
        /// </summary>
        /// <param name="content">����</param>
        public void WriteLog(string content)
        {
            StreamWriter fileWriter;
            try
            {
                fileWriter = File.AppendText(strAllFilePath);
                fileWriter.WriteLine(DateTime.Now.ToString("HHmmfff").ToString()+":"+content);
                fileWriter.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                fileWriter = null;
            }
        }
        #endregion


    }
}
