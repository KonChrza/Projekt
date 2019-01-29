using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Autofac.Extras.Moq;
using Moq;
using NUnit.Framework;
using Projekt.Controllers;
using Projekt.Models;
using System.Data.Entity;

namespace Projekt.Tests
{
    [TestFixture]
    public class AlbumsControllerTest : Controller
    {
        private List<Album> fakeDB()
        {
            List<Album> albumsSearchedTest = new List<Album>();
            albumsSearchedTest.Add(new Album()
            {
                AlbumID = 34,
                Genere = "Rap",
                Artist = "Kanye West",
                Title = "My Beatifull Dark Twisted Fantasy"

            });
            albumsSearchedTest.Add(new Album()
            {
                AlbumID = 37,
                Genere = "Rap",
                Artist = "Kids See Ghost",
                Title = "KIDS SEE GHOST"

            });
            return albumsSearchedTest;
        }
        [Test]
        public void IsAlbumsSerchedInstanceOfList()
        {
            AlbumsController controller = new AlbumsController();
            ViewResult result = controller.AlbumsSearched("Rap") as ViewResult;
            var xd = (List<Album>)result.Model;
            var xd1 = xd[0];
            Assert.IsInstanceOf(typeof(List<Album>), result.Model);
        }

        [Test]
        public void AlbumsSearchedTest_SearchingAlbumThatExists_CaseSensitive()
        {
            AlbumsController controller = new AlbumsController();
            var result = controller.AlbumsSearched("Rap") as ViewResult;
            var restultCastedToList = (List<Album>)result.Model;
            Assert.AreEqual(fakeDB()[0].Genere, restultCastedToList[0].Genere);
            Assert.AreEqual(fakeDB()[0].Artist, restultCastedToList[0].Artist);
            Assert.AreEqual(fakeDB()[0].Title, restultCastedToList[0].Title);
            Assert.AreEqual(fakeDB()[1].Genere, restultCastedToList[1].Genere);
            Assert.AreEqual(fakeDB()[1].Artist, restultCastedToList[1].Artist);
            Assert.AreEqual(fakeDB()[1].Title, restultCastedToList[1].Title);
            Assert.AreEqual(fakeDB().Count, restultCastedToList.Count);

        }
        [Test]
        public void AlbumsSearchedTest_SearchingAlbumThatExists_CaseInsensitive()
        {
            AlbumsController controller = new AlbumsController();
            var result = controller.AlbumsSearched("rap") as ViewResult;
            var restultCastedToList = (List<Album>)result.Model;
            Assert.AreEqual(fakeDB()[0].Genere, restultCastedToList[0].Genere);
            Assert.AreEqual(fakeDB()[0].Artist, restultCastedToList[0].Artist);
            Assert.AreEqual(fakeDB()[0].Title, restultCastedToList[0].Title);
            Assert.AreEqual(fakeDB()[1].Genere, restultCastedToList[1].Genere);
            Assert.AreEqual(fakeDB()[1].Artist, restultCastedToList[1].Artist);
            Assert.AreEqual(fakeDB()[1].Title, restultCastedToList[1].Title);
            Assert.AreEqual(fakeDB().Count, restultCastedToList.Count);

        }
        [Test]
        public void AlbumsSearchedTest_SearchingAlbumThatDoesntExists()
        {
            AlbumsController controller = new AlbumsController();
            var result = controller.AlbumsSearched("XXXXXXXXXXXXXXX") as ViewResult;
            var restultCastedToList = (List<Album>)result.Model;
            Assert.IsEmpty(restultCastedToList);

        }
        [Test]
        public void IsIndexNotNull()
        {
            // Arrange
            AlbumsController controller = new AlbumsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            
        }
        [Test]
        public void IsModelDetailsIsInstanceOfAlbum()
        {
            // Arrange
            AlbumsController controller = new AlbumsController();
            
            // Act
            ViewResult result = controller.Details(37) as ViewResult;
            Album xd = (Album)result.Model;
           
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(Album), result.Model);

        }
       




    }
    
}
