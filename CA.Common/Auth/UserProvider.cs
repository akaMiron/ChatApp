using Repository.Abstract;
using System.Security.Principal;

namespace CA.Common.Auth
{
    public class UserProvider : IPrincipal
    {
        private UserIndentity UserIdentity { get; set; }

        public UserProvider(string name, IUserRepository userRepository)
        {
            UserIdentity = new UserIndentity();
            UserIdentity.Init(name, userRepository);
        }

        #region IPrincipal Members

        public bool IsInRole(string role)
        {
            if (UserIdentity.User == null)
            {
                return false;
            }

            return UserIdentity.User.InRoles(role);
        }

        public IIdentity Identity
        {
            get { return UserIdentity; }
        }

        #endregion

        public override string ToString()
        {
            return UserIdentity.Name;
        }

    }
}
