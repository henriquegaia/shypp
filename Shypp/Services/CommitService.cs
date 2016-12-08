using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shypp.Models;

namespace Shypp.Services
{
    public class CommitService
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Commit> getCommitsByRequests(List<Request> Requests)
        {
            List<Commit> commits = new List<Commit>();

            foreach (Request request in Requests)
            {
                Commit commit = db.Commits.Where(c => c.RequestId == request.Id).FirstOrDefault();

                if (commit != null)
                {
                    commits.Add(commit);
                }
            }

            return commits;

        }
    }
}