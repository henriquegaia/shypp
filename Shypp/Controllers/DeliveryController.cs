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
    public class DeliveryController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Delivery
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();

            List<Delivery> deliveries = db.Deliveries.Where(d=>d.Commit.CourierId == userId).ToList();

            return View(deliveries);
        }

        // GET: Delivery/Details/5
        public ActionResult Details(int id)
        {
            Delivery delivery = db.Deliveries.Find(id);

            return View(delivery);
        }

        // GET: Delivery/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Delivery/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            int commitId = int.Parse(Request["CommitId"]);

            var CommitService = new CommitService();

            try
            {
                Delivery delivery = new Delivery()
                {
                    CommitId = commitId
                };

                db.Deliveries.Add(delivery);

                db.SaveChanges();

                // get requestId

                CommitService.setCommitExecuted(commitId);

                // Set Request as Executed

                TempData["DeliveryMsg"] = "Successfully informed about delivery!";
            }
            catch
            {
                TempData["DeliveryMsg"] = "You have already informed about this delivery!";
            }

            return RedirectToAction("Details/" + commitId, "Commit");
        }

        // GET: Delivery/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Delivery/Edit/5
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

        // GET: Delivery/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Delivery/Delete/5
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
