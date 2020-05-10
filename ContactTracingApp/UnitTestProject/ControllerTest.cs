using System;
using ContactTracingApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using ContactTracingApp;
using ContactTracingApp.Controllers;



namespace UnitTestProject
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void Index()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void ViewPeople()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.ViewPeople() as ViewResult;

            //Assert
            Assert.AreEqual("Person List", result.ViewBag.Message);

        }

    }
}
