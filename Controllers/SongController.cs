using System;
using System.Collections.Generic;
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
    }
}