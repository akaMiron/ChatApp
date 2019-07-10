using AutoMapper;
using CA.Common.ViewModels;
using CA.Domain.Entities;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CA.WebUI.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            this._messageRepository = messageRepository;
        }

        // GET: Messages
        public ActionResult List()
        {
            //IEnumerable<MessageViewModel> viewData = new List<MessageViewModel>();

            var data = _messageRepository.GetMessagesWithAuthors(1).ToList();
            var viewData = Mapper.Map<List<Message>, List<MessageViewModel>>(data);

            return PartialView(viewData);
        }

        // GET: Messages/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Message message = db.Message.Find(id);
        //    if (message == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(message);
        //}

        // GET: Messages/Create
        public ActionResult Create()
        {
            //ViewBag.UserId = new SelectList(db.User, "UserId", "Name");
            // todo: userId from cookie

            return View();
        }

        //// POST: Messages/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MessageId,Message1,UserId")] Message message)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Message.Add(message);
        //        db.SaveChanges();

        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.UserId = new SelectList(db.User, "UserId", "Name", message.UserId);

        //    return View(message);
        //}

        //// GET: Messages/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Message message = db.Message.Find(id);
        //    if (message == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.UserId = new SelectList(db.User, "UserId", "Name", message.UserId);

        //    return View(message);
        //}

        //// POST: Messages/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "MessageId,Message1,UserId")] Message message)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(message).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.UserId = new SelectList(db.User, "UserId", "Name", message.UserId);

        //    return View(message);
        //}

        //// GET: Messages/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Message message = db.Message.Find(id);
        //    if (message == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(message);
        //}

        //// POST: Messages/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Message message = db.Message.Find(id);
        //    if (message != null) db.Message.Remove(message);
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
