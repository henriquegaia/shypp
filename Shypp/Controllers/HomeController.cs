using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Shypp.Models;
using Shypp.Services;

namespace Shypp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            RequestService requestService = new RequestService();
            bool userIsAuth = User.Identity.IsAuthenticated;
            var userId = User.Identity.GetUserId();
            List<Request> requests = requestService.getAllExceptFromLoggedUser(userIsAuth, userId);
            ViewData["requests"] = requests;
            return View(requests);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}