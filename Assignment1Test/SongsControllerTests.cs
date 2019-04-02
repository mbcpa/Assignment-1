using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment1;
using Assignment1.Controllers;
using Assignment1.Models;
using Moq;

namespace Assignment1Test
{
    [TestClass]
    public class SongsControllerTests
    {
        //MOQ Database
        SongsController songController;
        BandsController bandController;
        Mock<IMoqSongs> moq;
        List<Song> songs;
        List<Band> band;

        //Initialize Method
        [TestInitialize]
        public void TestInitialize()
        {
            //Fake band and fake song lists
            band = new List<Band>
            {
                new Band {BandId = 900, Name = "Band1", Genre = "Genre1", YearFormed = "YearFormed1"},
                new Band {BandId = 901, Name = "Band2", Genre = "Genre2", YearFormed = "YearFormed2"},
                new Band {BandId = 902, Name = "Band3", Genre = "Genre3", YearFormed = "YearFormed3"}
            };

            songs = new List<Song>
            {
                new Song {SongId = 900, Name = "Song1", Length = "1", Rating = "1"},
                new Song {SongId = 901, Name = "Song2", Length = "2", Rating = "2"},
                new Song {SongId = 902, Name = "Song3", Length = "3", Rating = "3"},
                new Song {SongId = 903}
            };

            //Mock object for controller
            moq = new Mock<IMoqSongs>();
            moq.Setup(s => s.Songs).Returns(songs.AsQueryable());

            //inject moq object
            songController = new SongsController(moq.Object);
        }


        /* SONG CONTROLLER UNIT TESTS */
        [TestMethod]
        public void ContructorLoads()
        {
            SongsController test = new SongsController();

            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void IndexViewLoads()
        {
   
            //Act
            ViewResult result = songController.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Index", result.ViewName);

        }

        [TestMethod]
        public void DetailsViewNullValue()
        {

            //Act
            RedirectToRouteResult result = songController.Details(null) as RedirectToRouteResult;
            var resArray = result.RouteValues.ToArray();

            //Assert
            Assert.AreEqual("Error", resArray[0].Value);
        }

        [TestMethod]
        public void DetailsViewNotNullValue()
        {
            //Act
            ViewResult result = songController.Details(900) as ViewResult;

            //Assert
            Assert.AreEqual("Detail", result.ViewName);
        }

        [TestMethod]
        public void DetailsViewSong()
        {
            //Act
            var result = ((ViewResult)songController.Details(900)).Model;

            //Assert
            Assert.AreEqual(songs.SingleOrDefault(s => s.SongId == 900), result);
        }

        [TestMethod]
        public void DetailsViewEqualReturns()
        {
            //Act
            ViewResult result = songController.Details(867) as ViewResult;
            ViewResult result_2 = songController.Details(null) as ViewResult;

            //Assert
            Assert.AreEqual(result, result_2);
        }

        [TestMethod]
        public void CreateViewLoads()
        {
            //Act
            ViewResult result = songController.Create() as ViewResult;

            //Assert
            Assert.AreEqual("Create",result.ViewName);
        }

        [TestMethod]
        public void CreateViewNullValue()
        {
            songController.ModelState.AddModelError("Key Name", "900");
            //Act
            ViewResult result = songController.Create() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateViewPassValue()
        {
            //Act
            RedirectToRouteResult result = songController.Create(songs[0]) as RedirectToRouteResult;
            var resArray = result.RouteValues.ToArray();

            //Assert
            Assert.AreEqual("Index", resArray[0].Value);
        }

        [TestMethod]
        public void CreateViewPassValueError()
        {
            //Act
            songController.ModelState.AddModelError("Key Name", "123");
            ViewResult result = songController.Create(songs[0]) as ViewResult;

            //Assert
            Assert.AreEqual("Create",result.ViewName);
        }

        [TestMethod]
        public void DeleteViewLoads()
        {
            //Act
            ViewResult result = songController.Delete(900) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteViewNullValue()
        {
            //Act
            ViewResult result = songController.Delete(null) as ViewResult;

            //Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteViewUnlistedId()
        {
            //Act
            ViewResult result = songController.Delete(867) as ViewResult;

            //Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedLoads()
        {
            RedirectToRouteResult result = songController.DeleteConfirmed(900) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteConfirmedRouteValueCheck()
        {
            RedirectToRouteResult result = songController.DeleteConfirmed(900) as RedirectToRouteResult;
            var resArray = result.RouteValues.ToArray();

            //Assert
            Assert.AreEqual("Index", resArray[0].Value);
        }

        [TestMethod]
        public void EditViewLoads()
        {
            //Act
            ViewResult result = songController.Edit(900) as ViewResult;

            //Assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditViewNullIdentifier()
        {
            //Act - NULLABLE INT
            int? mynum = null;
            RedirectToRouteResult result = songController.Edit(mynum) as RedirectToRouteResult;

            //Array of RouteValues from result
            var resArray = result.RouteValues.ToArray();

            //Assert
            Assert.AreEqual("Error", resArray[0].Value);
        }

        [TestMethod]
        public void EditViewPassSong()
        {
            //Act
            RedirectToRouteResult result = songController.Edit(songs[0]) as RedirectToRouteResult;
            var resArray = result.RouteValues.ToArray();

            //Assert
            Assert.AreEqual("Index", resArray[0].Value);
        }

        [TestMethod]
        public void EditViewPassSongError()
        {
            //Act
            songController.ModelState.AddModelError("Key Name", "900");
            ViewResult result = songController.Edit(songs[0]) as ViewResult;

            //Assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditViewNullSong()
        {
            //Act
            RedirectToRouteResult result = songController.Edit(1234) as RedirectToRouteResult;
            var resArray = result.RouteValues.ToArray();

            //Assert
            Assert.AreEqual("Error", resArray[0].Value);
        }

        [TestMethod]
        public void DisposingTest()
        {
            //Act
            songController.Dispose();

            //Useless unit test? *66.67% covered method
        }
        

    }
}
