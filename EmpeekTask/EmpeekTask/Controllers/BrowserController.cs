using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Web.Mvc;

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

            return Request.CreateResponse(HttpStatusCode.OK, logicalDrivesNames);
        }
                
    }
}
