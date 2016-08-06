using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpeekTask.Helpers.Abstract
{
    public interface IBrowserHelper
    {
        List<string> GetLogicalDrives();
        List<string> GetItemsForSelectedPath(string path);
        int GetCountOfFiles(string path, Func<long, bool> criteria);
    }
}
