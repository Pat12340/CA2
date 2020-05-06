using ContactTracingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ContactTracingApp.Controllers
{
    [RoutePrefix("api/Contacts")]
    public class WebController : ApiController
    {
        private PersonDBContext db = new PersonDBContext();

        [HttpGet]
        [Route("GetContacts")]
        public List<Contact> GetContacts()
        {
            var contact = db.Contacts.ToList();
            return contact;
        }

        [HttpGet]
        [Route("GetContactsById")]
        public List<Contact> GetContactsById(int id)
        {
            var contact = db.Contacts.ToList().Where(c => c.Id == id).ToList();
            return contact;
        }

        [HttpPost]
        [Route("AddContact")]
        public Contact AddContact(Contact contact)
        {
            var newcontact = new Contact
            {
                Id = contact.Id,
                ContactId = contact.ContactId,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                DateMet = contact.DateMet,
                PersonId = contact.PersonId,
                Mobile = contact.Mobile,
                Email = contact.Email,
                DistanceKept = contact.DistanceKept,
                TimeSpent = contact.TimeSpent
            };
            var contactEntity = db.Contacts.Add(newcontact);
            db.SaveChanges();
            return newcontact;
        }

    }

}
