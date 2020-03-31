//using Microsoft.AspNet.Identity;
//using Sangha.Models.TeacherModels;
//using Sangha.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace SanghaMVC.Controllers
//{
//    public class TeacherController : Controller
//    {
//        // GET: Teacher
//        public ActionResult Index()
//        {
//            var userId = Guid.Parse(User.Identity.GetUserId());
//            var service = new TeacherService(userId);
//            var model = service.GetTeachers();
//            return View(model);
//        }
//        //GET:Create Teacher
//        public ActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(TeacherCreate model)
//        {
//            if (!ModelState.IsValid) return View(model);

//            var service = CreateTeacherService();

//            if (service.CreateTeacher(model))
//            {
//                TempData["SaveResult"] = "Your note was created.";
//                return RedirectToAction("Index");
//            };

//            ModelState.AddModelError("", "Note could not be created.");
//            return View(model);
//        }





//        private TeacherService CreateTeacherService()
//        {
//            var userId = Guid.Parse(User.Identity.GetUserId());
//            var service = new TeacherService(userId);
//            return service;
//        }
//    }
//}