using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Shypp.Models
{
    public class Photo
    {
        public int Id { get; set; }
        /*
         * ----------------------------------------
         * FileName
         * ----------------------------------------
         */

        [Required]
        public string FileName { get; set; }

        /*
         * ----------------------------------------
         * RequestId
         * ----------------------------------------
         */

        public int RequestId { get; set; }

        /*
         * ----------------------------------------
         * Nav Props
         * ----------------------------------------
         */

        public virtual Request Request { get; set; }

        


    }
}