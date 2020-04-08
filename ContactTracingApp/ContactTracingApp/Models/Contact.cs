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
        public string PersonId { get; set; }
        public string ContactFName { get; set; }
        public  string ContactMobile { get; set; }
        public string ContactEmail { get; set; }
        public string LastDateContacted { get; set; }
        public int DistanceKept { get; set; }
        public int TimeSpent { get; set;  }

    }

}