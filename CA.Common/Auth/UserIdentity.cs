using CA.Domain.Entities;
using Ninject;
using Repository.Abstract;
using System.Security.Principal;

namespace CA.Common.Auth
{
    public class UserIndentity : IIdentity, IUserProvider
    {

        [Inject]
        public IAuthentication Auth { private get; set; }

        public User CurrentUser
        {
            get
            {
                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        }

        public User User { get; set; }

        public string AuthenticationType
        {
            get
            {
                return typeof(User).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.Name;
                }

                return "anonym";
            }
        }

        public void Init(string name, IUserRepository userRepository)
        {
            if (!string.IsNullOrEmpty(name))
            {
                int userId = userRepository.GetIdByName(name);
                User = userRepository.Get(userId);
            }
        }
    }
}
