using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shypp.Models;
using Shypp.Services;
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
            Commit commit = db.Commits.Where(c =>
                c.Id == id)
                .FirstOrDefault();

            var commitService = new CommitService();

            bool requestHasAcceptedCommit = commitService.checkRequestHasAcceptedCommit(commit.RequestId);

            string loggedUserId = User.Identity.GetUserId();

            ViewData["userOwnsRequest"] = false;

            ViewData["requestHasAcceptedCommit"] = requestHasAcceptedCommit;

            if (commit.Request.User.Id == loggedUserId)
            {
                ViewData["userOwnsRequest"] = true;
            }

            return View(commit);
        }

        // GET: Commit/Add/5
        [Route("commit/add/{requestId}")]
        public ActionResult Add(int requestId)
        {
            string userIdLogged = User.Identity.GetUserId();

            var requestService = new RequestService();

            string userIdRequest = requestService.getUserIdFromRequestId(requestId);

            // redirect if user trying to commit to his own request

            if (userIdLogged == userIdRequest)
            {
                return RedirectToAction("Index", "Home");
            }

            // redirect if user has already commited to this request

            Commit commitOnDb = db.Commits.Where(co =>
                    co.RequestId == requestId &&
                    co.CourierId == userIdLogged)
                    .FirstOrDefault();

            if (commitOnDb != null)
            {
                return RedirectToAction("Details", new { id = commitOnDb.Id });
            }

            // Render View

            TempData["requestId"] = requestId;

            return View();
        }

        // POST: Commit/Add
        [Route("commit/add/{requestId}")]
        [HttpPost]
        public ActionResult Add(Commit commit)
        {
            // Validations

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = "All the fields are required !!";
                return RedirectToAction("Add");
            }

            var rRequestId = Request["requestId"];

            var rStart = Request["Start"];

            var rDurationMinutes = Request["DurationMinutes"];

            var rPriceEuros = Request["PriceEuros"];

            if (int.Parse(rDurationMinutes) <= 0 || int.Parse(rPriceEuros) <= 0)
            {
                TempData["Errors"] = "Negative values are not allowed.";
                return RedirectToAction("Add");
            }

            // Validate Date

            DateTime rStartDate = DateTime.Parse(rStart);

            if (rStartDate < DateTime.Now)
            {
                TempData["Errors"] = "Invalid date!";
                return RedirectToAction("Add");
            }

            // Store

            string CourierId = User.Identity.GetUserId();

            Commit c = new Commit();

            c.CourierId = CourierId;

            c.RequestId = int.Parse(rRequestId);

            c.Executed = false;

            c.Accepted = false;

            c.Start = rStartDate;

            c.DurationMinutes = int.Parse(rDurationMinutes);

            c.PriceEuros = float.Parse(rPriceEuros);

            db.Commits.Add(c);

            db.SaveChanges();

            TempData["Success"] = "You have successfully created a commit!";

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

        //public ActionResult Accept(int id)
        //{
        //    Commit commit = db.Commits.Find(id);

        //    commit.Accepted = true;

        //    db.SaveChanges();

        //    return RedirectToAction("Details", new { id = id });
        //}

        public ActionResult AcceptOrDecline(int id, bool accepted)
        {
            Commit commit = db.Commits.Find(id);

            if (commit.Accepted != accepted)
            {
                commit.Accepted = accepted;

                db.SaveChanges();
            }

            return RedirectToAction("Details", new { id = id });
        }
    }
}
