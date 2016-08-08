using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using EmpeekTask.Helpers.Abstract;
using EmpeekTask.Helpers.Entities;

namespace EmpeekTask.Controllers
{
    public class BrowserController : ApiController
    {
        #region Private fields
        private IBrowserHelper helper;
        #endregion

        #region Constructors
        public BrowserController(IBrowserHelper helperParam)
        {
            helper = helperParam;
        }
        #endregion

        #region Web Api Methods
        public HttpResponseMessage GetDrives()
        {
            PageInfo pageInfo = helper.GetLogicalDrives();
            return Request.CreateResponse(HttpStatusCode.OK, pageInfo);
        }

        public HttpResponseMessage GetObjects(string basePath, string selectedItem)
        {     
            PageInfo pageInfo;
            try
            {
                if (basePath != null)
                {
                    //Checking for return logical drives instead some folders. If basePath is something like C:\ or D:\ and we want to go back then we need to return list of logical drives
                    if (CheckPathToReturnDrives(basePath, selectedItem))
                    {
                        pageInfo = helper.GetLogicalDrives();

                        return Request.CreateResponse(HttpStatusCode.OK, pageInfo);
                    }
                }
                string path = basePath == null ? selectedItem : Path.Combine(basePath, selectedItem);

                pageInfo = helper.GetItemsForSelectedPath(path);

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
        #endregion

        #region Helpers
        private bool CheckPathToReturnDrives(string basePath, string selectedItem)
        {
            return basePath.EndsWith(@":\") && basePath.Length == 3 && selectedItem == "..";
        }
        #endregion
    }
}
