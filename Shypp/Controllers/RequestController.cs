using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shypp.Models;
using Microsoft.AspNet.Identity;
using Shypp.Services;
using System.IO;


namespace Shypp.Controllers
{
    [Authorize]
    public class RequestController : Controller
    {
        // ---------------------------------------------------------------------------------------

        private ApplicationDbContext db = new ApplicationDbContext();

        // ---------------------------------------------------------------------------------------

        // GET: Request
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            List<Request> requests = db.Requests.Where(r => r.ApplicationUserId == userId).ToList();
            return View(requests);
        }

        // ---------------------------------------------------------------------------------------

        // GET: Request/Details/5
        public ActionResult Details(int id)
        {
            var request = db.Requests.Find(id);
            var photoService = new PhotoService();
            var photos = photoService.getPhotosByRequest(id);
            ViewBag.photos = photos;
            if (request == null)
            {
                return RedirectToAction("Index");
            }
            var requestUserId = request.ApplicationUserId;
            var loggedUserId = User.Identity.GetUserId();
            //if (requestUserId != loggedUserId)
            //{
            //    return RedirectToAction("Index");
            //}
            return View(request);
        }

        // ---------------------------------------------------------------------------------------

        // GET: Request/Create
        public ActionResult Create()
        {
            if (TempData["Errors"] != null)
            {
                ViewBag.Errors = TempData["Errors"].ToString();
            }

            if (TempData["Success"] != null)
            {
                ViewBag.Success = TempData["Success"].ToString();
            }

            var userId = User.Identity.GetUserId();
            //TODO: Should be a call to a service
            List<Address> addresses = db.Addresses.Where(a => a.ApplicationUserId == userId).ToList();
            ViewBag.Addresses2 = new SelectList(addresses, "Id", "City");
            ViewBag.Addresses = addresses;
            return View();
        }

        // ---------------------------------------------------------------------------------------

        // POST: Request/Create
        [HttpPost]
        public ActionResult Create(IEnumerable<HttpPostedFileBase> Files)
        {
            var errorMsgs = new List<string>();
            var rMaxDaysResponse = Request["MaxDaysResponse"];
            var rAddressOriginId = Request["Address.Origin.Id"];
            var rAddressDestinyId = Request["Address.Destiny.Id"];
            var rPriceEuros = Request["PriceEuros"];
            var photoService = new PhotoService();

            List<string> errorMsgsAddresses = validateAddressesOnCreate(rAddressOriginId, rAddressDestinyId);
            errorMsgs.AddRange(errorMsgsAddresses);

            List<string> errorMsgsPhotos = validatePhotosOnCreate(Files);
            errorMsgs.AddRange(errorMsgsPhotos);

            if (errorMsgs.Count != 0)
            {
                var errorMsgToString = String.Join(System.Environment.NewLine, errorMsgs);
                TempData["Errors"] = errorMsgToString;
                return RedirectToAction("Create");
            }



            string userId = User.Identity.GetUserId().ToString();
            int maxDaysResponse = Convert.ToInt32(rMaxDaysResponse);
            int addressOriginId = int.Parse(rAddressOriginId);
            int addressDestinyId = int.Parse(rAddressDestinyId);
            float priceEuros = int.Parse(rPriceEuros);

            try
            {
                if (Store(Files, userId, maxDaysResponse, addressOriginId, addressDestinyId, priceEuros) == true)
                {
                    TempData["Success"] = "Successfully created request!";
                }
                else
                {
                    TempData["Errors"] = "Failed to save files!";
                }

                return RedirectToAction("Create");
            }
            catch
            {
                TempData["Errors"] = "Something went wrong creating the request!";
                return RedirectToAction("Create");
            }

        }


        // ---------------------------------------------------------------------------------------

        // GET: Request/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // ---------------------------------------------------------------------------------------

        // POST: Request/Edit/5
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

        // GET: Request/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // ---------------------------------------------------------------------------------------

        // POST: Request/Delete/5
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
        // ---------------------------------------------------------------------------------------
        // Helpers
        // ---------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------

        private List<string> validatePhotosOnCreate(IEnumerable<HttpPostedFileBase> Files)
        {
            var errorMsg = "";
            var errorMsgs = new List<string>();
            var photoService = new PhotoService();

            if (photoService.ValidNumberFilesPosted(Files) == false)
            {
                errorMsg = "Number of files to upload has to be smaller of equal to " + photoService.GetMaxFilesUpload().ToString() + "!";
                errorMsgs.Add(errorMsg);
            }

            if (photoService.ValidFilesExtensions(Files) == false)
            {
                errorMsg = "File(s) with invalid extension! Accepts: " + photoService.GetAcceptedExtensionsToString() + ".";
                errorMsgs.Add(errorMsg);
            }
            return errorMsgs;

        }

        // ---------------------------------------------------------------------------------------

        private List<string> validateAddressesOnCreate(string OriginId, string DestinyId)
        {
            var errorMsg = "";
            var errorMsgs = new List<string>();

            if (OriginId == DestinyId)
            {
                errorMsg = "Origin has to be different than Destiny.";
                errorMsgs.Add(errorMsg);
            }

            return errorMsgs;
        }

        // ---------------------------------------------------------------------------------------

        private bool Store(IEnumerable<HttpPostedFileBase> Files, string userId, int maxDaysResponse, int addressOriginId, int addressDestinyId, float priceEuros)
        {
            var photoService = new PhotoService();
            var req = new Request();

            req.MaxDaysResponse = maxDaysResponse;
            req.ApplicationUserId = userId;
            req.AddressOriginId = addressOriginId;
            req.AddressDestinyId = addressDestinyId;
            req.PriceEuros = priceEuros;

            db.Requests.Add(req);
            db.SaveChanges();

            Request requestOnDB = db.Requests
                .Where(r =>
                r.ApplicationUserId == userId &&
                r.AddressOriginId == addressOriginId &&
                r.AddressDestinyId == addressDestinyId &&
                r.MaxDaysResponse == maxDaysResponse)
                .ToList()
                .FirstOrDefault();

            int requestId = requestOnDB.Id;

            return photoService.SaveFiles(Files, Server, requestId);

        }

    }
}
