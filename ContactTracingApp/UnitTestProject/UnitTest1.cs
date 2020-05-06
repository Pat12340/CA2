using System;
using ContactTracingApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Contact contact = new Contact();
            contact.PersonId = null;

        }
    }
}
