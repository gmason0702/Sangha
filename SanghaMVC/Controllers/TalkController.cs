using Microsoft.AspNet.Identity;
using Sangha.Models.TalkModels;
using Sangha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanghaMVC.Controllers
{
    public class TalkController : Controller
    {

        // GET: Talk
        public ActionResult Index(string sortOrder, string searchString)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TalkService(userId);
            var model = service.GetTalks();
            ViewBag.TopicSort = sortOrder == "topic_desc" ? "topic" : "topic_desc";
            ViewBag.TeacherSort = sortOrder == "teacher_desc" ? "teacher" : "teacher_desc";
            ViewBag.Name = sortOrder == "name_desc" ? "name" : "name_desc";
            ViewBag.IsGuided = sortOrder == "isGuided_desc" ? "isGuided" : "isGuided_desc";
            ViewBag.TalkLength = sortOrder == "talkLength_desc" ? "talkLength" : "talkLength_desc";
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(s => s.Name.Contains(searchString) || s.Topic == searchString);
            }
            //if (!String.IsNullOrEmpty(topicSearch))
            //{
            //    model = model.Where(s => s.Topic==topicSearch);
            //}

            switch (sortOrder)
            {
                case "topic":
                    model = model.OrderBy(s => s.Topic);
                    break;
                case "teacher":
                    model = model.OrderBy(s => s.Teacher);
                    break;
                case "name":
                    model = model.OrderBy(s => s.Name);
                    break;
                case "isGuided":
                    model = model.OrderBy(s => s.isGuided);
                    break;
                case "talkLength":
                    model = model.OrderBy(s => s.TalkLength);
                    break;
                default:
                    break;
            }

            return View(model);
        }

        // GET: Talk/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateTalkService();
            var model = svc.GetTalkById(id);

            return View(model);
        }

        // GET: Talk/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Talk/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TalkCreate model)
        {

            // TODO: Add insert logic here
            if (!ModelState.IsValid) return View(model);

            var service = CreateTalkService();
            if (service.CreateTalk(model))
            {
                TempData["SaveResult"] = "Your talk was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Talk could not be created.");
            return View(model);
        }

        // GET: Talk/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateTalkService();
            var detail = service.GetTalkById(id);
            var model =
                new TalkEdit
                {
                    TalkId = detail.TalkId,
                    Name = detail.Name,
                    Teacher = detail.Teacher,
                    Topic = detail.Topic,
                    TalkLength=detail.TalkLength,
                    TalkDate=detail.TalkDate,
                    IsGuided=detail.IsGuided
                };
            return View(model);
        }

        // POST: Talk/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TalkEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TalkId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateTalkService();
            if (service.UpdateTalk(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        // GET: Talk/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTalkService();
            var model = svc.GetTalkById(id);

            return View(model);
        }

        // POST: Talk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTalkService();
            service.DeleteTalk(id);
            TempData["SaveResult"] = "Your note was deleted.";

            return RedirectToAction("Index");
        }

        private TalkService CreateTalkService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TalkService(userId);
            return service;
        }
    }
}
