using Microsoft.AspNet.Identity;
using Sangha.Models.SitTrackerModels;
using Sangha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanghaMVC.Controllers
{
    public class SitTrackerController : Controller
    {
        // GET: SitTracker
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SitTrackerService(userId);
            var model = service.GetSits();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SitTrackerCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateSitService();
            if (service.CreateSit(model))
            {
                TempData["SaveResult"] = "Your sit was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Sit could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSitService();
            var model = svc.GetSitById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSitService();
            var detail = service.GetSitById(id);
            var model =
                new SitTrackerEdit
                {
                    SitDate = detail.SitDate,
                    SitLength = detail.SitLength,
                    Note = detail.Note,
                    TypeOfSit = detail.TypeOfSit,
                    SitLink = detail.SitLink
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SitTrackerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SitId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateSitService();
            if (service.UpdateSit(model))
            {
                TempData["SaveResult"] = "Your sit was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your sit could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSitService();
            var model = svc.GetSitById(id);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSitService();
            service.DeleteSit(id);
            TempData["SaveResult"] = "Your sit was deleted.";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Timer()
        {
            return View();

        }
        private SitTrackerService CreateSitService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SitTrackerService(userId);
            return service;
        }
    }
}