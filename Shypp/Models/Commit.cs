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

        //https://www.asp.net/mvc/overview/older-versions/using-the-html5-and-jquery-ui-datepicker-popup-calendar-with-aspnet-mvc/using-the-html5-and-jquery-ui-datepicker-popup-calendar-with-aspnet-mvc-part-4
        [Required]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }

        // ----------------------------------------

        [Required]
        [Display(Name = "Duration (minutes)")]
        [Range(1, 1000)]
        public int DurationMinutes { get; set; }

        // ----------------------------------------

        [Required]
        [Display(Name = "Price (Euros)")]
        [Range(1, 1000)]
        public float PriceEuros { get; set; }

        // ----------------------------------------

        public int DeliveryId { get; set; }

        /*
         * ----------------------------------------
         * Nav Props
         * ----------------------------------------
         */

        [ForeignKey("CourierId")]
        public virtual ApplicationUser Courier { get; set; }

        // ----------------------------------------

        public virtual Request Request { get; set; }

        // ----------------------------------------

        public virtual Delivery Delivery { get; set; }

    }
}