using Microsoft.AspNet.Identity;
using Sangha.Models.TeacherModels;
using Sangha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanghaMVC.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index(string sortOrder, string teacherSearch)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeacherService(userId);
            var model = service.GetTeachers();
            ViewBag.FirstNameSort = sortOrder == "firstNameSort_desc" ? "firstNameSort" : "firstNameSort_desc";
            ViewBag.LastNameSort = sortOrder == "lastNameSort_desc" ? "lastNameSort" : "lastNameSort_desc";
            if (!String.IsNullOrEmpty(teacherSearch))
            {
                model = model.Where(s => s.FullName.Contains(teacherSearch));
            }

            switch (sortOrder)
            {
                case "firstNameSort":
                    model = model.OrderBy(s => s.FirstName);
                    break;
                case "firstNameSort_desc":
                    model = model.OrderByDescending(s => s.FirstName);
                    break;
                case "lastNameSort":
                    model = model.OrderBy(s => s.LastName);
                    break;
                case "lastNameSort_desc":
                    model = model.OrderByDescending(s => s.LastName);
                    break;
                default:
                    break;
            }
            return View(model);
        }
        //GET:Create Teacher
        public ActionResult Create()
        {
            return View();
        }

        //POST:Teacher/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherCreate model)
        {

            if (!ModelState.IsValid) return View(model);

            var service = CreateTeacherService();
            ViewBag.Teachers = service.GetTeachers();

            if (service.CreateTeacher(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateTeacherService();
            var model = svc.GetTeacherById(id);

            return View(model);
        }
        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateTeacherService();
            var detail = service.GetTeacherById(id);
            var model =
                new TeacherEdit
                {
                    TeacherId = detail.TeacherId,
                    FirstName=detail.FirstName,
                    LastName=detail.LastName
                };
            return View(model);
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TeacherEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TeacherId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateTeacherService();
            if (service.UpdateTeacher(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        // GET: Teacher/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTeacherService();
            var model = svc.GetTeacherById(id);

            return View(model);
        }

        // POST: Talk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTeacherService();
            service.DeleteTeacher(id);
            TempData["SaveResult"] = "Your note was deleted.";

            return RedirectToAction("Index");
        }

        private TeacherService CreateTeacherService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeacherService(userId);
            return service;
        }
    }
}