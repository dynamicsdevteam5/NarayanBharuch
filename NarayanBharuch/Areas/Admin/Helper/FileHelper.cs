using System.Collections.Generic;
using System.Web;
using System.IO;

namespace NarayanBharuch.Areas.Admin.Helper
{
    public static class FileHelper
    {
        /// <summary>
        /// Make Temp folder empty once all files are copied to destination folder.
        /// </summary>
        public static void RemoveFiles(string menu)
        {
            string sourcePath = HttpContext.Current.Server.MapPath("~/Photos/" + menu + "/Temp/");
            string[] files = Directory.GetFiles(sourcePath);
            foreach (string file in files)
            {
                if (File.Exists(Path.Combine(sourcePath, file)))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch { }
                }
            }
        }

        public static List<string> GetFilesFromFolder(string menu, int id)
        {
            List<string> list = new List<string>();
            string basePath = "/Photos/" + menu + "/" + id + "/";
            string sourcePath = HttpContext.Current.Server.MapPath("~" + basePath);
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);
                foreach (string file in files)
                {
                    if (File.Exists(Path.Combine(sourcePath, file)))
                    {
                        list.Add(basePath + Path.GetFileName(file));
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// This method is used to move files from Temp folder to Destinatin folder.
        /// </summary>
        /// <returns></returns>
        public static void SaveToMainFolder(string menu, string files, long id)
        {
            if (!string.IsNullOrEmpty(files))
            {
                string fileName = "";
                string destFile = "";
                string sourcePath = HttpContext.Current.Server.MapPath("~/Photos/" + menu + "/Temp/");
                string targetPath = HttpContext.Current.Server.MapPath("~/Photos/" + menu + "/" + id + "/");
                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }
                files = files.TrimEnd(',');
                foreach (var file in files.Split(','))
                {
                    if (Directory.Exists(sourcePath))
                    {
                        // Copy the files. 
                        string fileWithPath = HttpContext.Current.Server.MapPath("~" + file);
                        fileName = Path.GetFileName(fileWithPath);
                        destFile = Path.Combine(targetPath, fileName);
                        if(fileWithPath != destFile)
                        {
                            File.Copy(fileWithPath, destFile, true);
                        }
                    }
                }
                RemoveFiles(menu);
            }
        }
    }
}