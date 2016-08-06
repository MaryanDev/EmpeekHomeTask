using EmpeekTask.Helpers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpeekTask.Helpers.Abstract
{
    public interface IBrowserHelper
    {
        PageInfo GetLogicalDrives();
        PageInfo GetItemsForSelectedPath(string path);
        int GetCountOfFiles(string path, Func<long, bool> criteria);
    }
}
