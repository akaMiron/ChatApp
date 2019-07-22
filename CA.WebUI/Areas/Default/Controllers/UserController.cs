using CA.Common.ViewModels;
using CA.Domain.Entities;
using CA.Resources;
using System.Linq;
using System.Web.Mvc;

namespace CA.WebUI.Areas.Default.Controllers
{
    public class UserController : DefaultController
    {
        #region Repositories

        #endregion

        #region Public methods

        // GET: User list
        public ActionResult Index()
        {
            var users = UserRepository.GetAll().ToList();

            return View(users);
        }

        // GET: Register Form View
        [HttpGet]
        public ActionResult Register()
        {
            var newUserView = new UserView();

            return View(newUserView);
        }

        // POST: Register Form Data
        [HttpPost]
        public ActionResult Register(UserView userView)
        {
            var anyUser = UserRepository.GetAll().Any(p => string.CompareOrdinal(p.Name, userView.Name) == 0);
            if (anyUser)
            {
                ModelState.AddModelError("Name", ChatResources.LoginTaken);
            }

            if (ModelState.IsValid)
            {
                var user = AutoMapper.Mapper.Map<UserView, User>(userView);
                UserRepository.Add(user);

                return RedirectToAction("Index");
            }

            return View(userView);
        }

        public ActionResult Account()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RegisterAjax()
        {
            return View(new UserView());
        }

        [HttpPost]
        public ActionResult RegisterAjax(UserView userView)
        {
            if (ModelState.IsValid)
            {
                var anyUser = UserRepository.GetAll().Any(p => string.CompareOrdinal(p.Name, userView.Name) == 0);
                if (anyUser)
                {
                    ModelState.AddModelError("Name", ChatResources.LoginTaken);
                }

                if (ModelState.IsValid)
                {
                    var user = AutoMapper.Mapper.Map<UserView, User>(userView);
                    UserRepository.Add(user);

                    return View("_Ok");
                }
            }

            return View(userView);
        }

        #endregion
    }
}
