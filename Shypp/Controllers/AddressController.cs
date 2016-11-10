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
    public class AddressController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Address
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            List<Address> addresses = db.Addresses.Where(a => a.ApplicationUserId == userId).ToList();
            return View(addresses);
        }

        // ---------------------------------------------------------------------------------------

        // GET: Address/Details/5
        public ActionResult Details(int id)
        {
            var address = db.Addresses.Find(id);
            if (address == null)
            {
                return RedirectToAction("Index");
            }
            var userIdLogged = User.Identity.GetUserId();
            var addressUserId = address.ApplicationUserId;
            if (userIdLogged != addressUserId)
            {
                return RedirectToAction("Index");
            }
            return View(address);
        }

        // ---------------------------------------------------------------------------------------

        // GET: Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // ---------------------------------------------------------------------------------------


        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(Address a)
        {
            try
            {
                var city = a.City;
                var userId = User.Identity.GetUserId();
                var address = new Address()
                {
                    City = city,
                    ApplicationUserId = userId
                };
                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // ---------------------------------------------------------------------------------------


        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // ---------------------------------------------------------------------------------------


        // POST: Address/Edit/5
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


        // GET: Address/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // ---------------------------------------------------------------------------------------


        // POST: Address/Delete/5
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
