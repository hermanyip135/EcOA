using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ECOA.Common
{
    /// <summary>
    /// 事件文本日志
    /// </summary>
    public class EventTxtLog
    {
        #region 内部属性
        private string strFilePath;
        private string strFileName;
        private string strAllFilePath;
        #endregion

        #region 构造
         //<summary>
         //构造
         //</summary>
         //<param name="filepath"></param>
        public EventTxtLog(string filepath)
        {
            this.strFilePath = filepath;                                       //文件路径
            this.strFileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";     //文件名
            this.strAllFilePath = this.strFilePath + "\\" + this.strFileName;  //文件完整路径
            //生成文件夹
            if (!Directory.Exists(strFilePath))
            {
                Directory.CreateDirectory(strFilePath);
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="content">内容</param>
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
