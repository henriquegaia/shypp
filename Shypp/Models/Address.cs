using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Shypp.Models
{
    public class Address
    {
        public int Id { get; set; }

        /*
         * ----------------------------------------
         * city
         * ----------------------------------------
         */
        [Required]
        public string City { get; set; }

        /*
         * ----------------------------------------
         * User
         * ----------------------------------------
         */

        public string ApplicationUserId { get; set; }

        /*
         * ----------------------------------------
         * Nav Props
         * ----------------------------------------
         */
        public virtual ApplicationUser User { get; set; }

        // ----------------------------------------

        [InverseProperty("AddressOrigin")]
        public virtual ICollection<Request> RequestsOrigin { get; set; }

        // ----------------------------------------

        [InverseProperty("AddressDestiny")]
        public virtual ICollection<Request> RequestsDestiny { get; set; }
    }
}