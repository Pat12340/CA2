using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class ContactProcessor
    {
        public static int CreateContact(int contactId, string firstName, 
            string lastName, DateTime dateMet, int personId, string mobile, 
            string email, int distanceKept, int timeSpent)
        {
            ContactModel data = new ContactModel
            {
                ContactId = contactId,
                FirstName = firstName,
                LastName = lastName,
                DateMet = dateMet,
                PersonId = personId,
                Mobile = mobile,
                Email = email,
                DistanceKept = distanceKept,
                TimeSpent = timeSpent
            };
            string sql = @"insert into dbo.Contact (ContactId, FirstName, Lastname, DateMet, PersonId, Mobile, Email, DistanceKept, TimeSpent)
                        values (@ContactId, @FirstName, @Lastname, @DateMet, @PersonId, @Mobile, @Email, @DistanceKept, @TimeSpent)";

            return SqlDataAccess.SaveData(sql, data);

        }

        public static List<ContactModel> LoadContact()
        {
            string sql = @"select Id, ContactId, FirstName, Lastname, DateMet, PersonId, Mobile, Email, DistanceKept, TimeSpent
                        from dbo.Contact;";

            return SqlDataAccess.LoadData<ContactModel>(sql);
        }
    }
}
