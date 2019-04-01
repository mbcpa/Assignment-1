using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment1.Models;
using Moq;

namespace Assignment1.Controllers
{
    public class SongsController : Controller
    {
        //NEW DB CONNECTION SYSTEM
        IMoqSongs db;
        //private DbModel db = new DbModel();


        //Controller for real data
        public SongsController()
        {
            this.db = new MoqData();
        }

        //Controller for mock data being passed.
        public SongsController(IMoqSongs moqDb)
        {
            this.db = moqDb;
        }

        // GET: Songs
        public ActionResult Index()
        {
            var songs = db.Songs.Include(s => s.Band);
            return View("Index",songs.ToList());
        }

        // GET: Songs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            Song song = db.Songs.SingleOrDefault(s => s.SongId == id);
            if (song == null)
            {
                return RedirectToAction("Error");
            }
            return View("Detail",song);
        }

        // GET: Songs/Create
        public ActionResult Create()
        {
            ViewBag.Fk_BandId = new SelectList(db.Bands, "BandId", "Name");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SongId,Name,Length,Rating,Fk_BandId")] Song song)
        {
            if (ModelState.IsValid)
            {
                //db.Songs.Add(song);
                //db.SaveChanges();

                db.Save(song);
                return RedirectToAction("Index");
            }

            ViewBag.Fk_BandId = new SelectList(db.Bands, "BandId", "Name", song.Fk_BandId);
            return View("Create",song);
        }

        // GET: Songs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.SingleOrDefault(s => s.SongId == id);
            if (song == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fk_BandId = new SelectList(db.Bands, "BandId", "Name", song.Fk_BandId);
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SongId,Name,Length,Rating,Fk_BandId")] Song song)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(song).State = EntityState.Modified;
                //db.SaveChanges();

                db.Save(song);
                return RedirectToAction("Index");
            }
            ViewBag.Fk_BandId = new SelectList(db.Bands, "BandId", "Name", song.Fk_BandId);
            return View(song);
        }

        // GET: Songs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.SingleOrDefault(s => s.SongId == id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Song song = db.Songs.SingleOrDefault(s => s.SongId == id);
            
            //db.Songs.Remove(song);
            //db.SaveChanges();

            db.Delete(song);
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
