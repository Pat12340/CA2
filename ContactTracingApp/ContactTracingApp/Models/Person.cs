using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Diagnostics;

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
        [NotMapped]
        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "The Email and Confirm Email must match")]
        public string ConfirmEmailAddress { get; set; }


        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{Dob:dd/MM/yyyy}")]
        public Nullable<System.DateTime> Dob { get; set; }

        



        //comment
        // should we add in a password field for login purposes?
        //
        /*
                [Display(Name ="Password")]
                [Required(ErrorMessage ="You must have a password")]
                [DataType(DataType.Password)]
                [StringLength(100, MinimumLength =10, ErrorMessage ="You must provide a long enough password.")]
                public string Password { get; set; }

                [Display(Name ="Confirm Password")]
                [DataType(DataType.Password)]
                [Compare("Password", ErrorMessage ="Your passwords do not match")]
                public string ConfirmPassword { get; set; }*/

    }
    public class PersonDBContext : DbContext
    {
        public PersonDBContext(): base("ContacttracingDb") { }
        public DbSet<Person> Person { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            base.OnModelCreating(modelBuilder);
        }
    }
}