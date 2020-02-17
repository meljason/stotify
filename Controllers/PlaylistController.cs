using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stotify.Data;
using Stotify.Models;

namespace Stotify.Controllers
{
    public class PlaylistController : Controller
    {
        private StotifyContext db = new StotifyContext();
        // GET: Playlist/List
        public ActionResult List()
        {
            List<Playlist> playlists = db.Playlists.SqlQuery("SELECT * from Playlists").ToList();
            return View(playlists);
        }
    }
}