using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using EmpeekTask.Models;

namespace EmpeekTask.Controllers
{
    public class BrowserController : ApiController
    {
        public HttpResponseMessage GetDrives()
        {
            DriveInfo[] logicaDrives = DriveInfo.GetDrives();
            List<string> logicalDrivesNames = new List<string>();

            foreach (var drive in logicaDrives)
            {
                if (drive.DriveType.ToString() == "Fixed")
                    logicalDrivesNames.Add(drive.Name);
            }

            PageInfo pageInfo = new PageInfo
            {
                CurrentPath = "",
                SmallObjects = 0,
                MediumObjects = 0,
                LargeObjects = 0,
                BrowserItems = logicalDrivesNames
            };
            return Request.CreateResponse(HttpStatusCode.OK, pageInfo);
        }
                
    }
}
