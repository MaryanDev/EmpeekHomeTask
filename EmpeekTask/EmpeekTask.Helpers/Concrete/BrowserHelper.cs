using System;
using System.Collections.Generic;
using EmpeekTask.Helpers.Abstract;
using EmpeekTask.Helpers.Entities;
using System.IO;

namespace EmpeekTask.Helpers.Concrete
{
    public class BrowserHelper : IBrowserHelper
    {
        #region Public Methods
        public PageInfo GetLogicalDrives()
        {
            PageInfo result;
            DriveInfo[] logicaDrives = DriveInfo.GetDrives();
            List<string> logicalDrivesNames = new List<string>();

            foreach (var drive in logicaDrives)
            {
                if (drive.DriveType.ToString() == "Fixed")
                    logicalDrivesNames.Add(drive.Name);
            }
            result = new PageInfo
            {
                CurrentPath = String.Empty,
                BrowserItems = logicalDrivesNames
            };

            return result;
        }

        public PageInfo GetItemsForSelectedPath(string path)
        {
            PageInfo result;
            DirectoryInfo dInfo = new DirectoryInfo(path);
            List<string> itemsList = new List<string>();
            var objInfo = dInfo.GetFileSystemInfos();

            foreach (var item in objInfo)
            {
                itemsList.Add(item.Name);
            }

            result = new PageInfo
            {
                CurrentPath = new DirectoryInfo(path).FullName,
                BrowserItems = itemsList
            };

            return result;
        }

        public int GetCountOfFiles(string path, Func<long, bool> criteria)
        {
            string[] fileNames = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            int count = 0;

            foreach (var fileName in fileNames)
            {
                FileInfo fileInfo = new FileInfo(fileName);
                if (criteria(fileInfo.Length / 1024 / 1024))
                {
                    count++;
                }
            }

            return count;
        }
        #endregion
    }
}
