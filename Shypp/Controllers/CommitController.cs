using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shypp.Models;
using Microsoft.AspNet.Identity;

namespace Shypp.Controllers
{
    [Authorize]
    public class CommitController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Commit
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var commits = db.Commits.Where(c => c.CourierId == userId);
            return View(commits.ToList());
        }

        // GET: Commit/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Commit/Add/5
        [Route("commit/add/{requestId}")]
        public ActionResult Add(int requestId)
        {
            TempData["requestId"] = requestId;
            return View();
        }

        // POST: Commit/Add
        [Route("commit/add/{requestId}")]
        [HttpPost]
        public ActionResult Add(Commit commit)
        {
            if (!ModelState.IsValid)
            {
                return Content("model not valid");
                ViewData["Errors"] = "All the fields are required!";
                return RedirectToAction("Add");
            }

            var rRequestId = Request["requestId"];

            var rStart = Request["Start"];

            var rDurationMinutes = Request["DurationMinutes"];

            var rPriceEuros = Request["PriceEuros"];

            if (rStart == "" || rDurationMinutes == "" || rPriceEuros == "")
            {
                ViewData["Errors"] = "All the fields are required!";
                return RedirectToAction("Add");
            }

            DateTime rStartDate = DateTime.Parse(rStart);

            if (rStartDate < DateTime.Now)
            {
                ViewData["Errors"] = "Invalid date!";
                return RedirectToAction("Add");
            }

            ViewData["Success"] = "Invalid date!";
            return RedirectToAction("Add");

        }

        // GET: Commit/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Commit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Commit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Commit/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
