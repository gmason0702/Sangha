using Microsoft.AspNet.Identity;
using Sangha.Models.RetreatModels;
using Sangha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanghaMVC.Controllers
{
    public class RetreatController : Controller
    {
        // GET: Retreat
        public ActionResult Index(string searchString)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RetreatService(userId);
            var model = service.GetRetreats();
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(s => s.RetreatName.Contains(searchString));
            }
            return View(model);
        }

        //GET:Create Retreat
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RetreatCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRetreatService();

            if (service.CreateRetreat(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRetreatService();
            var model = svc.GetRetreatById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRetreatService();
            var detail = service.GetRetreatById(id);
            var model =
                new RetreatEdit
                {
                    RetreatName = detail.RetreatName,
                    RetreatDate = detail.RetreatDate,
                    RetreatLength = detail.RetreatLength
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RetreatEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RetreatId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateRetreatService();
            if (service.UpdateRetreat(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRetreatService();
            var model = svc.GetRetreatById(id);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRetreatService();
            service.DeleteRetreat(id);
            TempData["SaveResult"] = "Your note was deleted.";

            return RedirectToAction("Index");
        }


        private RetreatService CreateRetreatService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RetreatService(userId);
            return service;
        }
    }
}