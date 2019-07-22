using CA.Common.ViewModels;
using CA.Resources;
using System.Web.Mvc;

namespace CA.WebUI.Areas.Default.Controllers
{
    public class LoginController : DefaultController
    {
        #region Public methods

        // GET: Login View Form
        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginView());
        }

        // POST: Login View Data
        [HttpPost]
        public ActionResult Index(LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                var user = Auth.Login(loginView.Name, loginView.Password, loginView.IsPersistent);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState["Password"].Errors.Add(ChatResources.DifferentPasswords);
            }

            return View(loginView);
        }

        // GET: Logout
        public ActionResult Logout()
        {
            Auth.LogOut();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult LoginAjax()
        {
            return View(new LoginView());
        }

        [HttpPost]
        public ActionResult LoginAjax(LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                var user = Auth.Login(loginView.Name, loginView.Password, loginView.IsPersistent);
                if (user != null)
                {
                    return View("_Ok");
                }
                ModelState["Password"].Errors.Add("Пароли не совпадают");
            }
            return View(loginView);
        }

        #endregion
    }
}