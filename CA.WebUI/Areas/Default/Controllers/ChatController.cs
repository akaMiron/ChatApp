using CA.Common.ViewModels;
using CA.Domain.Entities;
using System;
using System.Linq;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace CA.WebUI.Areas.Default.Controllers
{
    [Authorize]
    public class ChatController : DefaultController
    {
        // GET: Default/Chat
        public ActionResult Index(int? page)
        {

            var messages = MessageRepository.GetAll().Reverse(); 
            
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(messages.ToPagedList(pageNumber, pageSize));
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

            return RedirectToAction("Index", "Chat");
        }


        [HttpGet]
        public ActionResult InputAjax()
        {
            return View(new MessageView());
        }

        [HttpPost]
        public ActionResult InputAjax(MessageView messageView)
        {
            if (ModelState.IsValid)
            {
                var message = AutoMapper.Mapper.Map<MessageView, Message>(messageView);

                message.PostedTime = DateTime.Now;
                message.UserId = CurrentUser.UserId;

                MessageRepository.Add(message);

                return View("_Ok");
            }

            return RedirectToAction("Index", "Chat");

        }
    }
}