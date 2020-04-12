using ContactTracingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.PersonProcessor;

namespace ContactTracingApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewPeople()
        {
            ViewBag.Message = "Person List";

            var data = LoadPeople();

            List<Person> people = new List<Person>();
            foreach(var row in data)
            {
                people.Add(new Person
                {
                    FName = row.FName,
                    LName = row.LName,
                    Phone = row.Phone,
                    Email = row.Email,
                    Dob = row.Dob
                });
            }
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
    }
}