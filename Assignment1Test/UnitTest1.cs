﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment1;
using Assignment1.Controllers;

namespace Assignment1Test
{
    [TestClass]
    public class UnitTest1
    {
        /*  DEV NOTE
         * 
         * ARRANGE
         *  - Setup variables and thing we need to actually create the test
         * ACT
         *  - Call the methods we need to check if they break or not
         * ASSERT
         *  - Assume that something should be a certain way (return value usually)
         * 
         */
        [TestMethod]
        public void Index()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Index",result.ViewName);
        }

        [TestMethod]
        public void About()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.About() as ViewResult;

            //Assert
            Assert.AreEqual("About", result.ViewBag.Message);
        }

        [TestMethod]
        public void AboutLoads()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.About() as ViewResult;

            //Assert
            Assert.AreEqual("About", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.Contact() as ViewResult;

            //Assert
            Assert.AreEqual("Your contact page.", result.ViewBag.Message);
        }
    }
}
