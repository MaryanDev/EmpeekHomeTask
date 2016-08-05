using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmpeekTask.Controllers
{
    public class FileSizeController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage SortFiles(string basePath, string selectedItem)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
