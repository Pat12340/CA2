using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> Dob { get; set; }
    }
}
