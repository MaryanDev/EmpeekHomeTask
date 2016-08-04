using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpeekTask.Models
{
    public class PageInfo
    {
        public string CurrentPath { get; set; }

        public int SmallObjects { get; set; }
        public int MediumObjects { get; set; }
        public int LargeObjects { get; set; }

        public List<string> BrowserItems { get; set; }
    }
}