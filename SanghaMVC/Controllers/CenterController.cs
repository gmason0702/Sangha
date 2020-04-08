using Microsoft.AspNet.Identity;
using Sangha.Models.CenterModels;
using Sangha.Models.RatingModels.Center;
using Sangha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanghaMVC.Controllers
{
    public class CenterController : Controller
    {
        // GET: Center
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CenterService(userId);
            var model = service.GetCenters();
            return View(model);
        }

        //GET:Create Center
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CenterCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCenterService();

            if (service.CreateCenter(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCenterService();
            var model = svc.GetCenterById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCenterService();
            var detail = service.GetCenterById(id);
            var model =
                new CenterEdit
                {
                    CenterId = detail.CenterId,
                    Name = detail.Name,
                    City = detail.City,
                    State=detail.State
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CenterEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CenterId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCenterService();
            if (service.UpdateCenter(model))
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
            var svc = CreateCenterService();
            var model = svc.GetCenterById(id);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCenterService();
            service.DeleteCenter(id);
            TempData["SaveResult"] = "Your note was deleted.";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Rate(int id)
        {
            var service = CreateCenterService();
            ViewBag.Detail = service.GetCenterById(id);

            var model = new CenterRatingCreate { CenterId = id };
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rate(CenterRatingCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new RatingService(Guid.Parse(User.Identity.GetUserId()));

            if (service.CreateCenterRating(model))
            {
                TempData["SaveResult"] = "Your rating was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Rating could not be added.");
            return View(model);
        }

        private CenterService CreateCenterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CenterService(userId);
            return service;
        }
    }
}