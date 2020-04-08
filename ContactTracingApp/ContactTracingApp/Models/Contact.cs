using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactTracingApp.Models
{
    public class Contact
    {
        [Key]
        public string ContactId { get; set; }

        public DateTime DateMet { get; set; }
        [Required]
        public string PersonId { get; set; }
        [Required]
        public string ContactFName { get; set; }
        [Required]
        public string ContactLName { get; set; }
        [Required]
        public string ContactMobile { get; set; }
        public string ContactEmail { get; set; }
        public string LastDateContacted { get; set; }
        public int DistanceKept { get; set; }
        public int TimeSpent { get; set;  }

    }

}