using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shypp.Controllers
{
    public class DeliveryController : Controller
    {
        // GET: Delivery
        public ActionResult Index()
        {
            return View();
        }

        // GET: Delivery/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

            return Content(commitId.ToString());
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
