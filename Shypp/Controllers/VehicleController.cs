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
    public class VehicleController : Controller
    {
        // ---------------------------------------------------------------------------------------

        private ApplicationDbContext db = new ApplicationDbContext();

        // ---------------------------------------------------------------------------------------

        // GET: Vehicle
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var vehicles = db.Vehicles.Where(v => v.ApplicationUserId == userId).ToList();
            return View(vehicles);
        }

        // ---------------------------------------------------------------------------------------

        // GET: Vehicle/Details/5
        public ActionResult Details(int id)
        {
            var vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return RedirectToAction("Index");
            }
            var userIdLogged = User.Identity.GetUserId();
            var vehicleUserId = vehicle.ApplicationUserId;
            if (userIdLogged != vehicleUserId)
            {
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // ---------------------------------------------------------------------------------------

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            return View();
        }

        // ---------------------------------------------------------------------------------------

        // POST: Vehicle/Create
        [HttpPost]
        public ActionResult Create(Vehicle v)
        {
            try
            {
                var brand = v.Brand;
                var userId = User.Identity.GetUserId();
                var vehicle = new Vehicle()
                {
                    Brand = brand,
                    ApplicationUserId = userId
                };
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // ---------------------------------------------------------------------------------------

        // GET: Vehicle/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // ---------------------------------------------------------------------------------------

        // POST: Vehicle/Edit/5
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

        // GET: Vehicle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // ---------------------------------------------------------------------------------------

        // POST: Vehicle/Delete/5
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
