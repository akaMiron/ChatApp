using CA.Domain.Entities;
using Ninject;
using Repository.Abstract;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace CA.Common.Auth
{
    public class CustomAuthentication :  IAuthentication
    {
        private const string CookieName = "__AUTH_COOKIE";

        public HttpContext HttpContext { get; set; }

        [Inject] private IUserRepository _userRepository;

        public CustomAuthentication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #region IAuthentication Members

        public User Login(string userName, string password, bool isPersistent)
        {
            User retUser = _userRepository.Login(userName, password);
            if (retUser != null)
            {
                CreateCookie(userName, isPersistent);
            }

            return retUser;
        }

        public User Login(string userName)
        {
            User retUser = _userRepository.Find(p => string.CompareOrdinal(userName, p.Name) == 0).FirstOrDefault();
            if (retUser != null)
            {
                CreateCookie(userName);
            }

            return retUser;
        }

        private void CreateCookie(string userName, bool isPersistent = false)
        {
            var ticket = new FormsAuthenticationTicket(
                  1,
                  userName,
                  DateTime.Now,
                  DateTime.Now.Add(FormsAuthentication.Timeout),
                  isPersistent,
                  string.Empty,
                  FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            var encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            var authCookie = new HttpCookie(CookieName)
            {
                Value = encTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };
            HttpContext.Response.Cookies.Set(authCookie);
        }

        public void LogOut()
        {
            var httpCookie = HttpContext.Response.Cookies[CookieName];
            if (httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }
        }

        private IPrincipal _currentUser;

        public IPrincipal CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    try
                    {
                        HttpCookie authCookie = HttpContext.Request.Cookies.Get(CookieName);
                        if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
                        {
                            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                            if (ticket != null) _currentUser = new UserProvider(ticket.Name, _userRepository);
                        }
                        else
                        {
                            _currentUser = new UserProvider(null, null);
                        }
                    }
                    catch (Exception)
                    {
                        _currentUser = new UserProvider(null, null);
                    }
                }

                return _currentUser;
            }
        }

        #endregion
    }

}
