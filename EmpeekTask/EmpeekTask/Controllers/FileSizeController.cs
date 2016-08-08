using System;
using System.IO;
using System.Net;
using System.Net.Http;
using EmpeekTask.Helpers.Abstract;
using EmpeekTask.Helpers.Entities;
using System.Web.Http;


namespace EmpeekTask.Controllers
{
    public class FileSizeController : ApiController
    {
        #region Private Fields
        private IBrowserHelper helper;
        #endregion

        #region Constructors
        public FileSizeController(IBrowserHelper helperParam)
        {
            helper = helperParam;
        }
        #endregion

        #region Web Api Methods
        [HttpGet]
        public HttpResponseMessage SortFiles(string basePath, string selectedItem)
        {
            try
            {
                string path = basePath == null ? selectedItem : Path.Combine(basePath, selectedItem);

                int smallFiles = helper.GetCountOfFiles(path, size => size <= 10);
                int mediumFiles = helper.GetCountOfFiles(path, size => size > 10 && size <= 50);
                int largeFiles = helper.GetCountOfFiles(path, size => size >= 100);

                FileSizeInfo fzInfo = new FileSizeInfo
                {
                    SmallFiles = smallFiles,
                    MediumFiles = mediumFiles,
                    LargeFiles = largeFiles
                };

                return Request.CreateResponse(HttpStatusCode.OK, fzInfo);
            }
            catch(UnauthorizedAccessException)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Can't calculate size of some files, probably you have no access to some directories or files. ");
            }
            catch(IOException)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Can't calculate size of some files, probably you have no access to some directories or files. ");
            }
        }
        #endregion
    }
}
