//using Microsoft.AspNet.Identity;
//using Sangha.Models.TalkModels;
//using Sangha.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace SanghaMVC.Controllers
//{
//    public class TalkController : Controller
//    {
//        // GET: Talk
//        public ActionResult Index()
//        {
//            var userId = Guid.Parse(User.Identity.GetUserId());
//            var service = new TalkService(userId);
//            var model = service.GetTalks();
//            return View(model);
//        }

//        // GET: Talk/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: Talk/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Talk/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(TalkCreate model)
//        {

//            // TODO: Add insert logic here
//            if (!ModelState.IsValid) return View(model);

//            var service = CreateTalkService();
//            if (service.CreateTalk(model))
//            {
//                TempData["SaveResult"] = "Your talk was created.";
//                return RedirectToAction("Index");
//            }
//            ModelState.AddModelError("", "Talk could not be created.");
//            return View(model);



//        }

//        // GET: Talk/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: Talk/Edit/5
//        [HttpPost]
//        public ActionResult Edit(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add update logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Talk/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: Talk/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        private TalkService CreateTalkService()
//        {
//            var userId = Guid.Parse(User.Identity.GetUserId());
//            var service = new TalkService(userId);
//            return service;
//        }
//    }
//}
