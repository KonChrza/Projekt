using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projekt.Models;

namespace Projekt.Controllers
{
    public class AlbumsController : Controller, IAlbumControler
    {
        private AlbumDB db = new AlbumDB();

        public ActionResult AlbumsSearched(string searched)
        {
            
            List<Album> albumsSearched = new List<Album>();
            foreach (Album album in db.Albums)
            {
                if (album.Genere.ToLower().Contains(searched.ToLower()) ||
                            album.Title.ToLower().Contains(searched.ToLower()) ||
                                    album.Artist.ToLower().Contains(searched.ToLower()))
                {
                    albumsSearched.Add(album);
                }
            }

            ViewBag.Message = "Wyszukane Albumy";
        
            return View(albumsSearched);
        }

        public ActionResult GetAlbums()
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\konch\source\repos\Projekt\Projekt\Album.txt"))
            {
                String line = sr.ReadToEnd().Replace(System.Environment.NewLine,"");

                string[] rows = line.Split(';');

                for (int i = 0; i < rows.Length; i++)
                {
                    string[] columns = rows[i].Split('#');
                    db.Albums.Add(new Album()
                    {
                        Genere = columns[0],
                        Artist = columns[1],
                        Title = columns[2]
                    });
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDatabase()
        {
            foreach (Album album in db.Albums)
            {
                db.Albums.Remove(album);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Albums
        public ActionResult Index()
        {
            return View(db.Albums.ToList());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumID,Genere,Artist,Title")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(album);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumID,Genere,Artist,Title")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
    }
}
