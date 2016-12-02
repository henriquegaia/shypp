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
        public int Id { get; set; }

        // ----------------------------------------

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime Start { get; set; }

        // ----------------------------------------

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime End { get; set; }

        // ----------------------------------------

        public int CommitId { get; set; }

        /*
         * ----------------------------------------
         * Nav Props
         * ----------------------------------------
         */

        public virtual Commit Commit { get; set; }


    }
}