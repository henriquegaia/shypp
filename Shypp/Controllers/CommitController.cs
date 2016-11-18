using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shypp.Models;
using Microsoft.AspNet.Identity;

namespace Shypp.Controllers
{
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

        // GET: Commit/Create/5
        public ActionResult Create(int requestId)
        {
            return Content(requestId.ToString());
            return View();
        }

        // POST: Commit/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
