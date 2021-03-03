using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.Utils
{
    public static class FilesUtils
    {
        private static readonly string downloadFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
        public static bool IfFileDownloaded(string fileName)
        {
            
            var fullPath = downloadFolderPath + @"\" + fileName;
            bool exist = false;

            exist = CheckDirectory(fullPath);
            if (exist)
            {
                return true;
            }
            else
            {
                return CheckDirectory(fullPath);
            }

        }
        private static bool CheckDirectory(string file)
        {

            if (File.Exists(file))
            {
                File.Delete(file);
                return true;
            }
            else
                return false;

        }
        private  static void DeleteDownloadedFileIfExsist(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            else
            {
                try
                {
                    File.Delete(path);
                }
                catch
                {
                    Exception e;
                }
            }
        }
        public static void DeleteFileIfExist(string file)
        {
            var fullPath = downloadFolderPath + @"\" + file;
            DeleteDownloadedFileIfExsist(fullPath);
        }

    }
}
