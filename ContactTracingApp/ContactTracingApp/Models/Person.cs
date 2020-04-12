using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ContactTracingApp.Models
{
    public class Person
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Required]
        [Range(1, 1000000000, ErrorMessage ="The Phone number must be at least 9 digits.")]
        public int Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email{ get; set; }

        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "The Email and Confirm Email must match")]

        // Check if ConfirmEmailAddress matches Emials
        // Or we can remove this field
        public string ConfirmEmailAddress { get; set; }


        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{Dob:dd/MM/yyyy}")]
        public Nullable<System.DateTime> Dob { get; set; }

        //comment
        // should we add in a password field for login purposes?
        //

    }
}