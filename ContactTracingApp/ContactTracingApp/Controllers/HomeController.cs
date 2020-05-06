﻿using ContactTracingApp.Models;
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
    public class HomeController : Controller
    {
        private PersonDBContext db = new PersonDBContext();
        private ApplicationDbContext dbapp = new ApplicationDbContext();

        public ActionResult Index()
        {
            if (ModelState.IsValid)
            {
                
            
            }
            return View();
        }

        [Authorize]
        //[Authorize(Roles ="Admin")]
        public ActionResult ViewPeople()
        {
            
            ViewBag.Message = "Person List";
            var people = db.Persons.ToList();
            return View(people);

        }

        [Authorize]
        public ActionResult ViewPerson()
        {

            var currentUserId = User.Identity.GetUserId();
            var user = dbapp.Users.FirstOrDefault(p => p.Id == currentUserId);
            var pOne = db.Persons.FirstOrDefault(p => p.Email == user.Email);
            return View(pOne);
        }
        /*
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

            */
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
                Random random = new Random();
                int num = random.Next(1000000);

                var currentUserId = User.Identity.GetUserId();
                var user = dbapp.Users.FirstOrDefault(p => p.Id == currentUserId);
                var pOne = db.Persons.FirstOrDefault(p => p.Email == user.Email);
                var personId = pOne.id;

                var contact = new Contact
                {
                    Id = num,
                    ContactId = num,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateMet = model.DateMet,
                    PersonId = personId,
                    Mobile = model.Mobile,
                    Email = model.Email,
                    DistanceKept = model.DistanceKept,
                    TimeSpent = model.TimeSpent
                };
                var contactEntity = db.Contacts.Add(contact);
                db.SaveChanges();

                return RedirectToAction("MyContacts");
            }
            return View();
        }

        [Authorize]
        public ActionResult MyContacts()
        {
            ViewBag.Message = "My Contacts List";

            var currentUserId = User.Identity.GetUserId();
            var user = dbapp.Users.FirstOrDefault(p => p.Id == currentUserId);
            var pOne = db.Persons.FirstOrDefault(p => p.Email == user.Email);
            var personId = pOne.id;

            var contact = db.Contacts.ToList().Where(c => c.PersonId == personId);

            return View(contact);

        }



        [Authorize]
        public ActionResult EditContacts()
        {
            ViewBag.Message = "Edit Contact.";

            return View();
        }


        [HttpPut]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EditContacts(Contact model)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = User.Identity.GetUserId();
                var user = dbapp.Users.FirstOrDefault(p => p.Id == currentUserId);
                var pOne = db.Persons.FirstOrDefault(p => p.Email == user.Email);
                var personId = pOne.id;
                var contact1 = db.Contacts.SingleOrDefault(c => c.ContactId == personId);

                var contact = new Contact
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateMet = model.DateMet,
                    PersonId = personId,
                    Mobile = model.Mobile,
                    Email = model.Email,
                    DistanceKept = model.DistanceKept,
                    TimeSpent = model.TimeSpent
                };
                var contactEntity = db.Contacts.Add(contact);
                db.SaveChanges();

                return RedirectToAction("MyContacts");
            }
            return View();
        }
    }
}