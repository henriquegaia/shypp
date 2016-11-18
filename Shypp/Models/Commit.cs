using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Shypp.Models;

namespace Shypp.Models
{
    public class Commit
    {
        public int Id { get; set; }

        // ----------------------------------------

        public string CourierId { get; set; }

        // ----------------------------------------

        public int RequestId { get; set; }

        // ----------------------------------------

        public bool Executed { get; set; }

        // ----------------------------------------

        public bool Accepted { get; set; }

        // ----------------------------------------

        [Required]
        public int DistanceToOriginKm { get; set; }

        // ----------------------------------------

        [Required]
        public int ExpectedDurationMin { get; set; }

        // ----------------------------------------

        [Required]
        public float Price { get; set; }

        /*
         * ----------------------------------------
         * Nav Props
         * ----------------------------------------
         */

        [ForeignKey("CourierId")]
        public virtual ApplicationUser Courier { get; set; }

        // ----------------------------------------

        public virtual Request Request { get; set; }

    }
}