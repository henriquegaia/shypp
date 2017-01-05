using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shypp.Models;

namespace Shypp.ViewModels
{
    public class RequestCommit
    {
        public List<Request> Requests { get; set; }

        public List<Commit> Commits { get; set; }

        public Commit Commit { get; set; }

        public Request Request { get; set; }

    }
}