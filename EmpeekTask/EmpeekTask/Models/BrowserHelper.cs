using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace EmpeekTask.Models
{
    public static class BrowserHelper
    {
        public static List<string> GetLogicalDrives()
        {
            DriveInfo[] logicaDrives = DriveInfo.GetDrives();
            List<string> logicalDrivesNames = new List<string>();

            foreach (var drive in logicaDrives)
            {
                if (drive.DriveType.ToString() == "Fixed")
                    logicalDrivesNames.Add(drive.Name);
            }

            return logicalDrivesNames;
        }

        public static List<string> GetItemsForSelectedPath(string path)
        {
            DirectoryInfo dInfo = new DirectoryInfo(path);
            List<string> itemsList = new List<string>();
            var objInfo = dInfo.GetFileSystemInfos();

            foreach (var item in objInfo)
            {
                itemsList.Add(item.Name);
            }

            return itemsList;
        }

        public static int GetCountOfFiles(string path, Func<long, bool> criteria)
        {
            string[] fileNames = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            int count = 0;

            foreach(var fileName in fileNames)
            {
                FileInfo fileInfo = new FileInfo(fileName);
                if(criteria(fileInfo.Length / 1024 / 1024))
                {
                    count++;
                }
            }

            return count;
        }
    }
}