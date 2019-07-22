using CA.Common.ViewModels;
using CA.Domain.Entities;
using System;
using System.Web.Mvc;

namespace CA.WebUI.Areas.Default.Controllers
{
    [Authorize]
    public class ChatController : DefaultController
    {
        // GET: Default/Chat
        public ActionResult Index()
        {
            ChatView viewData = new ChatView
            {
                PageSize = 10, 
                Messages = MessageRepository.GetAll()
            };

            return View(viewData);
        }

        [HttpGet]
        public ActionResult Input()
        {
            MessageView newMessageView = new MessageView();

            return PartialView("_Input", newMessageView);
        }

        [HttpPost]
        public ActionResult Input(MessageView messageView)
        {
            if (ModelState.IsValid)
            {
                var message = AutoMapper.Mapper.Map<MessageView, Message>(messageView);

                message.PostedTime = DateTime.Now;
                message.UserId = CurrentUser.UserId;

                MessageRepository.Add(message);
            }
            else
            {
                return RedirectToAction("Index", "Chat");
            }

            return RedirectToAction("Index", "Chat");
        }
    }
}