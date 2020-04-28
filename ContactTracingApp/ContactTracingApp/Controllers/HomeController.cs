using ContactTracingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.PersonProcessor;
using static DataLibrary.BusinessLogic.ContactProcessor;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using DataLibrary.DataAccess;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ContactTracingApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private PersonDBContext db = new PersonDBContext();
        private ApplicationDbContext dbapp = new ApplicationDbContext();

        public ActionResult Index()
        {
            if (ModelState.IsValid)
            {
                var currentUserId = User.Identity.GetUserId();
                var user = dbapp.Users.FirstOrDefault(p => p.Id == currentUserId);
                var pOne = db.Persons.FirstOrDefault(p => p.Email == user.Email);
                ViewBag.Name = pOne.FName;
                ViewBag.LName = pOne.LName;
                ViewBag.Dob = pOne.Dob;
                
                
            }
            return View();
        }
        [Authorize(Roles ="Admin")]
        public ActionResult ViewPeople()
        {
            ViewBag.Message = "Person List";

            //var data = LoadPeople();

            //List<Person> people = new List<Person>();
            //foreach(var row in data)
            //{
            //    people.Add(new Person
            //    {
            //        FName = row.FName,
            //        LName = row.LName,
            //        Phone = row.Phone,
            //        Email = row.Email,
            //        Dob = row.Dob
            //    });
            //}
            var people = db.Persons.ToList();
            return View(people);
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "User Sign Up";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Person model)
        {
            if (ModelState.IsValid)
            {
                int recordCreated = CreatePerson(model.FName, model.LName, model.Phone, model.Email, model.Dob);
                return RedirectToAction("Index");
            }
            return View();

        }
        [Authorize]
        public ActionResult addNewContacts()
        {
            ViewBag.Message = "Add a new contact.";

            return View();
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult addNewContacts(Contact model)
        {
            if (ModelState.IsValid)
            {
               int recordsCreated = CreateContact(model.ContactId,
                    model.FirstName, 
                    model.LastName, 
                    model.DateMet, 
                    model.PersonId, 
                    model.Mobile, 
                    model.Email, 
                    model.DistanceKept, 
                    model.TimeSpent);

                return RedirectToAction("MyContacts");
            }

            return View();
        }
        
        public ActionResult MyContacts()
        {
            ViewBag.Message = "My Contacts List";

            var data = LoadContact();

            List<Contact> contacts = new List<Contact>();
            foreach(var row in data)
            {
                contacts.Add(new Contact
                {
                    ContactId = row.ContactId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    PersonId = row.PersonId,
                    DateMet = row.DateMet,
                    Mobile = row.Mobile,
                    Email = row.Email,
                    DistanceKept = row.DistanceKept,
                    TimeSpent = row.TimeSpent
                });
            }

            return View(contacts);
        }


    }
}