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
    public class PhotoController : Controller
    {
        // ---------------------------------------------------------------------------------------

        private ApplicationDbContext db = new ApplicationDbContext();

        // ---------------------------------------------------------------------------------------

        // GET: Photo
        public ActionResult Index()
        {
            return View();
        }

        // ---------------------------------------------------------------------------------------

        // GET: Photo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // ---------------------------------------------------------------------------------------

        // GET: Photo/Create
        public ActionResult Create()
        {
            return View();
        }

        // ---------------------------------------------------------------------------------------

        // POST: Photo/Create
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

        // ---------------------------------------------------------------------------------------

        // GET: Photo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // ---------------------------------------------------------------------------------------

        // POST: Photo/Edit/5
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

        // ---------------------------------------------------------------------------------------

        // GET: Photo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // ---------------------------------------------------------------------------------------

        // POST: Photo/Delete/5
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

        // ---------------------------------------------------------------------------------------
    }
}
