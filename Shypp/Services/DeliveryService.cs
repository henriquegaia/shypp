using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shypp.Models;

namespace Shypp.Services
{
    public class DeliveryService
    {

        ApplicationDbContext db = new ApplicationDbContext();

        public List<int> getCommitsIdsIfCourierDelivered(List<Commit> commits)
        {
            List<int> commitsIds = new List<int>();

            foreach (Commit commit in commits)
            {
                var delivery = db.Deliveries.Where(d => d.CommitId == commit.Id).FirstOrDefault();

                if (delivery != null)
                {
                    commitsIds.Add(commit.Id);
                }
            }

            return commitsIds;
        }
    }
}