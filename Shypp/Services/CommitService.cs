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
                List<Commit> commitsByRequest = db.Commits.Where(c => c.RequestId == request.Id).ToList();

                if (commitsByRequest != null)
                {
                    commits.AddRange(commitsByRequest);
                }
            }

            return commits;

        }

        public bool checkRequestHasAcceptedCommit(int requestId)
        {

            Commit commit = db.Commits.Where(c =>
            c.RequestId == requestId &&
            c.Accepted == true
            ).FirstOrDefault();

            if (commit == null)
            {
                return false;
            }

            return true;
        }
    }
}