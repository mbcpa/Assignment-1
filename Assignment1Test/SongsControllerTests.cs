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
                new Band {BandId = 1000, Name = "Band1", Genre = "Genre1", YearFormed = "YearFormed1"},
                new Band {BandId = 1001, Name = "Band2", Genre = "Genre2", YearFormed = "YearFormed2"},
                new Band {BandId = 1002, Name = "Band3", Genre = "Genre3", YearFormed = "YearFormed3"}
            };

            songs = new List<Song>
            {
                new Song {SongId = 900, Name = "Song1", Length = "1", Rating = "1"},
                new Song {SongId = 901, Name = "Song2", Length = "2", Rating = "2"},
                new Song {SongId = 902, Name = "Song3", Length = "3", Rating = "3"}
            };

            //Mock object for controller
            moq = new Mock<IMoqSongs>();
            moq.Setup(s => s.Songs).Returns(songs.AsQueryable());

            //inject moq object
            songController = new SongsController(moq.Object);
        }


        /* SONG CONTROLLER UNIT TESTS */
        [TestMethod]
        public void IndexViewLoad()
        {
   
            //Act
            ViewResult result = songController.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Index", result.ViewName);

        }
    }
}
