using System.Web.Mvc;

namespace EmpeekTask.Controllers
{
    public class HomeController : Controller
    {
        #region Action Methods
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        #endregion
    }
}