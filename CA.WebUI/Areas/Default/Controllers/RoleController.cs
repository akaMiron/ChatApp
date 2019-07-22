using Ninject;
using Repository.Abstract;
using System.Web.Mvc;

namespace CA.WebUI.Areas.Default.Controllers
{
    public class RoleController : DefaultController
    {
        #region Repositories

        [Inject]
        public IRoleRepository RoleRepository { private get; set; }

        #endregion

        #region Public methods

        // GET: Role list
        public ActionResult Index()
        {
            var roles = RoleRepository;

            return View(roles);
        }

        #endregion
    }
}