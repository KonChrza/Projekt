using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using Projekt;
using Projekt.Controllers;
using Projekt.Models;

namespace Projekt.Tests
{
    [TestFixture]
    public class AlbumsControllerTest
    {
        [Test]
        public void AlbumsSearchedTest_SearchingAlbumThatExists_CaseSensitive()
        {
            AlbumsController controllerTest = new AlbumsController();
            string test = "Rap";
            List<Album> albumsSearchedTest = new List<Album>();
            albumsSearchedTest.Add(new Album()
            {
                AlbumID = 1,
                Genere = "Rap",
                Artist = "Kanye West",
                Title = "My Beatifull Dark Twisted Fantasy"

            });
            albumsSearchedTest.Add(new Album()
            {
                AlbumID = 1,
                Genere = "Rap",
                Artist = "Kids See Ghost",
                Title = "KIDS SEE GHOST"

            });
            ViewResult result = controllerTest.AlbumsSearched(test) as ViewResult;
            Assert.AreEqual(result, albumsSearchedTest);
        }
    }
}
