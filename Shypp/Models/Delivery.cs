using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shypp.Models
{
    public class Delivery
    {

        [Key, ForeignKey("Commit")]
        public int CommitId { get; set; }

        // ----------------------------------------

        /*
         * ----------------------------------------
         * Nav Props
         * ----------------------------------------
         */

        public virtual Commit Commit { get; set; }


    }
}