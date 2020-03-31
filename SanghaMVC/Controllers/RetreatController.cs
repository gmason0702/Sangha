//using Microsoft.AspNet.Identity;
//using Sangha.Models.RetreatModels;
//using Sangha.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace SanghaMVC.Controllers
//{
//    public class RetreatController : Controller
//    {
//        // GET: Retreat
//        public ActionResult Index()
//        {
//            var userId = Guid.Parse(User.Identity.GetUserId());
//            var service = new RetreatService(userId);
//            var model = service.GetRetreats();
//            return View(model);
//        }

//        //GET:Create Retreat
//        public ActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(RetreatCreate model)
//        {
//            if (!ModelState.IsValid) return View(model);

//            var service = CreateRetreatService();

//            if (service.CreateRetreat(model))
//            {
//                TempData["SaveResult"] = "Your note was created.";
//                return RedirectToAction("Index");
//            };

//            ModelState.AddModelError("", "Note could not be created.");
//            return View(model);
//        }

//        public ActionResult Details(int id)
//        {
//            var svc = CreateRetreatService();
//            var model = svc.GetRetreatById(id);

//            return View(model);
//        }


//        private RetreatService CreateRetreatService()
//        {
//            var userId = Guid.Parse(User.Identity.GetUserId());
//            var service = new RetreatService(userId);
//            return service;
//        }
//    }
//}