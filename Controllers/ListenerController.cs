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
using System.Data.Entity.Infrastructure;

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
            var viewModel = new ListenerFormViewModel()
            {
                Playlists = playlistList
            };
            return View("New", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Listener listener)
        {
            if (listener.ListenerID == 0)
            {
                db.Listeners.Add(listener);
            }
            else
            {
                var listenerInDb = db.Listeners.Single(l => l.ListenerID == listener.ListenerID);

                listenerInDb.ListenerFname = listener.ListenerFname;
                listenerInDb.ListenerLname = listener.ListenerLname;
                listenerInDb.ListenerEmail = listener.ListenerEmail;
                listenerInDb.Playlists = listener.Playlists;
            }
            
            db.SaveChanges();

            return RedirectToAction("List", "Listener");
        }

        public ActionResult Show(int id)
        {
            string mainQuery = "SELECT * FROM Listeners WHERE ListenerID = @id";
            var pk_param = new SqlParameter("@id", id);
            Listener Listener = db.Listeners.SqlQuery(mainQuery, pk_param).FirstOrDefault();

            string asideQuery = "SELECT * FROM Playlists INNER JOIN " +
                                "PlaylistListeners on " +
                                "Playlists.PlaylistID = PlaylistListeners.Playlist_PlaylistID " +
                                "WHERE PlaylistListeners.Listener_ListenerID=@id";
            var fk_param = new SqlParameter("@id", id);
            List<Playlist> ListenedPlaylists = db.Playlists.SqlQuery(asideQuery, fk_param).ToList();

            ShowListenerViewModel viewModel = new ShowListenerViewModel();
            viewModel.listener = Listener;
            viewModel.playlists = ListenedPlaylists;

            return View(viewModel);
        }

        //This is to GET action  to retrieve the listener data
        public ActionResult Edit(int id)
        {
            string query = "select * from Listeners where ListenerID = @id";
            var param = new SqlParameter("@id", id);
            Listener listener = db.Listeners.SqlQuery(query, param).FirstOrDefault();

            return View(listener);
        }

        [HttpPost]
        public ActionResult Edit(int id, Listener listener)
        {
            db.Entry(listener).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            string query = "select * from Listeners where ListenerID = @id";
            var param = new SqlParameter("@id", id);
            Listener listener = db.Listeners.SqlQuery(query, param).FirstOrDefault();

            return View(listener);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Listener listener = db.Listeners.Where(l => l.ListenerID == id).FirstOrDefault();
            db.Listeners.Remove(listener);
            db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}