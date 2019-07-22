using CA.Domain.Entities;
using System.Web.Mvc;

namespace CA.WebUI.Areas.Default.Controllers
{
    public class MessageController : DefaultController
    {
        // GET: Default/Message
        public ActionResult Index(Message message)
        {
            ViewBag.Username = CurrentUser.Name;

            return PartialView("_Index", message);
        }

        public ActionResult Delete(int id)
        {
            Message message = MessageRepository.Get(id);
            MessageRepository.Remove(message);

            return RedirectToAction("Index", "Chat");
        }
    }
}