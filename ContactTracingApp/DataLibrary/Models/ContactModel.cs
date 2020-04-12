using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateMet { get; set; }
        public int PersonId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int DistanceKept { get; set; }
        public int TimeSpent { get; set; }


    }
}
