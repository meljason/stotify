using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Stotify.Data;
using Stotify.Models;
using Stotify.ViewModels;
using System.Data.Entity;

namespace Stotify.Controllers
{
    public class ListenerController : Controller
    {
        private StotifyContext db = new StotifyContext();
        // GET: Listener/List
        public ActionResult List()
        {
            List<Listener> listeners = db.Listeners.SqlQuery("SELECT * from Listeners").ToList();
            return View(listeners);

        }

        public ActionResult New()
        {
            var playlistList = db.Playlists.ToList();
            var viewModel = new NewListenerViewModel()
            {
                Playlists = playlistList
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Listener listener)
        {
            db.Listeners.Add(listener);
            db.SaveChanges();

            return RedirectToAction("List", "Listener");
        }

        public ActionResult Show(int id)
        {
            var listener = db.Listeners.Include(l=>l.Playlist).SingleOrDefault(l => l.ListenerID == id);

            if (listener == null)
            {
                return HttpNotFound();
            }

            return View(listener);
        }
    }
}