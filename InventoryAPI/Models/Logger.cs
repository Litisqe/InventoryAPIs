using System;
using System.Configuration;
using System.IO;

namespace InventoryAPI.Models
{
    public class Logger
    {
        private static string CreateFolder(string sFilePath)
        {
            string sFolderName = string.Empty;
            string sFolderType = string.Empty;
            try
            {
                sFolderType = "Logs";
                if (!string.IsNullOrEmpty(sFolderType))
                {
                    if (!Directory.Exists(string.Concat(sFilePath, sFolderType)))
                    {
                        Directory.CreateDirectory(string.Concat(sFilePath, sFolderType));
                    }

                    sFolderName = sFolderType + "\\" + DateTime.Now.ToString("dd-MM-yyyy");
                    if (!Directory.Exists(string.Concat(sFilePath, sFolderName)))
                    {
                        Directory.CreateDirectory(string.Concat(sFilePath, sFolderName));
                    }
                }
            }
            catch
            {
            }
            return sFolderName;
        }

        public static void WriteToFile(string sMsg)
        {
            FileStream objFileStream;
            StreamWriter objSW;
            string LogFileName;
            string LogFolder;
            try
            {
                LogFolder = string.Concat(AppDomain.CurrentDomain.BaseDirectory, CreateFolder(AppDomain.CurrentDomain.BaseDirectory));
                LogFileName = ConfigurationManager.AppSettings["LogFileName"].ToString();
                LogFileName = LogFolder + "\\" + LogFileName;

                objFileStream = File.Open(LogFileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                objSW = new StreamWriter(objFileStream);

                objSW.WriteLine(DateTime.Now.ToString() + " : " + sMsg);
                objSW.WriteLine("");
                objSW.Flush();
                objFileStream.Close();
            }
            catch { }
        }
    }
}