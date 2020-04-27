using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class PersonProcessor
    {
        public static int CreatePerson(string FirstName, string LastName, int PhoneNo, string EmailAddress, Nullable<System.DateTime> dob)
        {
            PersonModel data = new PersonModel
            {
                FName = FirstName,
                LName = LastName,
                Phone = PhoneNo,
                Email = EmailAddress,
                Dob = dob
            };
            string sql = @"INSERT INTO dbo.person(FName, LName, Phone, Email, Dob)
                            values(@FName, @LName, @Phone, @Email, @Dob);";
            return SqlDataAccess.SaveData(sql, data);
        }
        public static List<PersonModel> LoadPeople()
        {
            string sql = @"select Id, FName, LName, Phone, Email, Dob
                            from dbo.person;";
            return SqlDataAccess.LoadData<PersonModel>(sql);
        }
    }
}
