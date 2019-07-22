using CA.Common.Auth;
using CA.Domain.Entities;
using Ninject;
using System.Web.Mvc;

namespace CA.WebUI.Controllers
{
    public abstract class BaseController : Controller
    {
        #region Authentification Fields

        [Inject]
        public IAuthentication Auth { protected get; set; }

        protected User CurrentUser
        {
            get
            {
                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        }

        #endregion
    }
}