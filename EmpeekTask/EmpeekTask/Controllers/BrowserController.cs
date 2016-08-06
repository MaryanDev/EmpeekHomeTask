using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using EmpeekTask.Helpers.Abstract;
using EmpeekTask.Helpers.Concrete;
using EmpeekTask.Helpers.Entities;

namespace EmpeekTask.Controllers
{
    public class BrowserController : ApiController
    {
        private IBrowserHelper helper;

        public BrowserController(IBrowserHelper helperParam)
        {
            helper = helperParam;
        }
        public HttpResponseMessage GetDrives()
        {
            List<string> logicalDrives = helper.GetLogicalDrives();

            PageInfo pageInfo = new PageInfo
            {
                CurrentPath = "",
                BrowserItems = logicalDrives
            };
            return Request.CreateResponse(HttpStatusCode.OK, pageInfo);
        }

        public HttpResponseMessage GetObjects(string basePath, string selectedItem)
        {     
            PageInfo pageInfo;
            try
            {
                if (basePath != null)
                    //Checking for return logical drives instead some folders. If basePath is something like C:\ or D:\ and we want to go back then we need to return list of logical drives
                    if (basePath.EndsWith(@":\") && basePath.Length == 3 && selectedItem == "..")
                    {
                        List<string> logicalDrives = helper.GetLogicalDrives();
                        pageInfo = new PageInfo
                        {
                            CurrentPath = "",
                            BrowserItems = logicalDrives
                        };

                        return Request.CreateResponse(HttpStatusCode.OK, pageInfo);
                    }
                string path = basePath == null ? selectedItem : Path.Combine(basePath, selectedItem);

                List<string> itemsList = helper.GetItemsForSelectedPath(path);
                pageInfo = new PageInfo
                {
                    CurrentPath = new DirectoryInfo(path).FullName,
                    BrowserItems = itemsList
                };

                return Request.CreateResponse(HttpStatusCode.OK, pageInfo);
            }
            catch (IOException)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Wrong directory name, or you try to access some file. ");
            }
            catch (UnauthorizedAccessException)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error! Probably you have no access to some directories or files. ");
            }
            catch (NullReferenceException)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid Path. ");
            }
        }

    }
}
