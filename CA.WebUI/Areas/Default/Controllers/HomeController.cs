using CA.WebUI.Controllers;
using System.Web.Mvc;

namespace CA.WebUI.Areas.Default.Controllers
{
    public class HomeController : BaseController
    {
        #region Public methods

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }

        public ActionResult Header()
        {
            return PartialView("_MainHeader");
        }

        public ActionResult Footer()
        {
            return PartialView("_MainFooter");
        }

        #endregion
    }
}