using CA.Domain.Entities;
using System.Security.Principal;
using System.Web;

namespace CA.Common.Auth
{
    public interface IAuthentication
    {
        HttpContext HttpContext { get; set; }

        User Login(string login, string password, bool isPersistent);

        User Login(string login);

        void LogOut();

        IPrincipal CurrentUser { get; }
    }
}
