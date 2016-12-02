using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Shypp.Models;

namespace Shypp.Services
{
    public class RequestService
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Request> getAllExceptFromLoggedUser(bool userIsAuth, string userId)
        {

            List<Request> requests = new List<Request>();
            if (userIsAuth == false)
            {
                requests = db.Requests.ToList();
            }
            else
            {
                requests = db.Requests.Where(r => r.ApplicationUserId != userId).ToList();
            }
            return requests;
        }

        public string getUserIdFromRequestId(int requestId)
        {

            var userId = db.Requests.Where(r => r.Id == requestId).First().ApplicationUserId.ToString();

            return userId;
        }
    }
}