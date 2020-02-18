using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stotify.Data;
using Stotify.Models;

namespace Stotify.Controllers
{
    public class SongController : Controller
    {
        private StotifyContext db = new StotifyContext();
        // GET: Song/List
        public ActionResult List()
        {
            List<Song> songs = db.Songs.SqlQuery("SELECT * FROM Songs").ToList();
            return View(songs);
        }

        // GET: Song/New
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Create(Song song)
        {
            db.Songs.Add(song);
            db.SaveChanges();

            return RedirectToAction("List", "Song");
        }

        public ActionResult Show(int id)
        {
            string query = "select * from Songs where SongID = @id";
            var param = new SqlParameter("@id", id);
            Song selectedSong = db.Songs.SqlQuery(query, param).FirstOrDefault();
            
            
            return View(selectedSong);
        }

        //This is to GET action  to retrieve the song data
        public ActionResult Edit(int id)
        {
            string query = "select * from Songs where SongID = @id";
            var param = new SqlParameter("@id", id);
            Song song = db.Songs.SqlQuery(query, param).FirstOrDefault();

            return View(song);
        }

        [HttpPost]
        public ActionResult Edit(int id, Song song)
        {
            db.Entry(song).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            string query = "select * from Songs where SongID = @id";
            var param = new SqlParameter("@id", id);
            Song song = db.Songs.SqlQuery(query, param).FirstOrDefault();

            return View(song);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Song song = db.Songs.Where(l => l.SongID == id).FirstOrDefault();
            db.Songs.Remove(song);
            db.SaveChanges();

            return RedirectToAction("List");
        }

    }
}