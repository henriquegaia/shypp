using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Shypp.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        /*
         * ----------------------------------------
         * Brand
         * ----------------------------------------
         */
        [Required]
        public string Brand { get; set; }
        /*
         * ----------------------------------------
         * User
         * ----------------------------------------
         */
        [Required]
        public string ApplicationUserId { get; set; }

        /*
         * ----------------------------------------
         * Nav Props
         * ----------------------------------------
         */
        public virtual ApplicationUser User { get; set; }
    }
}