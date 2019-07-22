using CA.WebUI.Controllers;
using Ninject;
using Repository.Abstract;

namespace CA.WebUI.Areas.Default.Controllers
{
    public class DefaultController : BaseController
    {
        [Inject]
        public IUserRepository UserRepository { protected get; set; }

        [Inject] public IMessageRepository MessageRepository { protected get; set; }
    }
}