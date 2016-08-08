using EmpeekTask.Helpers.Entities;
using System;

namespace EmpeekTask.Helpers.Abstract
{
    public interface IBrowserHelper
    {
        #region Methods
        PageInfo GetLogicalDrives();
        PageInfo GetItemsForSelectedPath(string path);
        int GetCountOfFiles(string path, Func<long, bool> criteria);
        #endregion
    }
}
