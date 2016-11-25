using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Shypp.Models
{
    public class Request
    {
        public int Id { get; set; }

        /*
         * ----------------------------------------
         * MaxTimeResponse
         * ----------------------------------------
         */

        [Required]
        [Display(Name = "Maximum Days For Response")]
        [Range(1, 365)]
        public int MaxDaysResponse { get; set; }

        /*
         * ----------------------------------------
         * PriceEuros
         * ----------------------------------------
         */

        [Required]
        [Display(Name = "Price (Euros)")]
        [Range(1, 1000)]
        public float PriceEuros { get; set; }

        /*
         * ----------------------------------------
         * User
         * ----------------------------------------
         */

        [Required]
        public string ApplicationUserId { get; set; }

        /*
         * ----------------------------------------
         * Origin
         * ----------------------------------------
         */

        [Required]
        public int AddressOriginId { get; set; }

        /*
         * ----------------------------------------
         * Destiny
         * ----------------------------------------
         */

        [Required]
        public int AddressDestinyId { get; set; }

        /*
         * ----------------------------------------
         * Nav Props
         * ----------------------------------------
         */

        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ApplicationUser User { get; set; }

        // ----------------------------------------

        [ForeignKey("AddressOriginId")]
        public virtual Address AddressOrigin { get; set; }

        // ----------------------------------------

        [ForeignKey("AddressDestinyId")]
        public virtual Address AddressDestiny { get; set; }

        // ----------------------------------------

        public virtual ICollection<Commit> Commits { get; set; }

    }
}