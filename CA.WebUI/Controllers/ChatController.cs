using System.Collections.Generic;
using System.Web.Mvc;
using Repository.Abstract;

namespace CA.WebUI.Controllers
{
    public class ChatController : Controller
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;

        public ChatController(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            this._messageRepository = messageRepository;
            this._userRepository = userRepository;
        }

        // GET: Chat
        public ActionResult Index()
        {
            _messageRepository.GetAll();

            return View();
        }
    }
}