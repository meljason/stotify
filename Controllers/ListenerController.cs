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
using System.Diagnostics;

namespace Stotify.Controllers
{
    public class ListenerController : Controller
    {
        private StotifyContext db = new StotifyContext();
        // GET: Listener/List
        public ActionResult List(string search)
        {
            //List<Listener> listeners = db.Listeners.SqlQuery("SELECT * from Listeners").ToList();
            //return View(listeners);
            //Add search functionality...
            return View(db.Listeners.Where(l => l.ListenerFname.Contains(search) 
                                                || l.ListenerLname.Contains(search) 
                                                || l.ListenerEmail.Contains(search)
                                                || l.ListenerGender.Contains(search)
                                                || search == null).ToList());
        }

        //adding playlist to listeners for listeners of id = ?
        public ActionResult ListenerPlaylist(int id)
        {
            string query =
                "select * from Playlists inner join PlaylistListeners on " +
                "Playlists.PlaylistID = PlaylistListeners.Playlist_PlaylistID " +
                "where Listener_ListenerID = @id";
            SqlParameter param = new SqlParameter("@id", id);
            List<Playlist> listenerPlaylists = db.Playlists.SqlQuery(query, param).ToList();

            ShowListenerViewModel viewModel = new ShowListenerViewModel();
            viewModel.playlists = listenerPlaylists;

            return View(viewModel);
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
                listenerInDb.ListenerGender = listener.ListenerGender;
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

            string asideQuery = "select * from Playlists inner join PlaylistListeners on " +
                                "Playlists.PlaylistID = PlaylistListeners.Playlist_PlaylistID " +
                                "where Listener_ListenerID = @id";

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

        [HttpPost]
        public ActionResult AttachPlaylist(int id, int PlaylistID)
        {
            Debug.WriteLine("Listener id is" + id+"and playlistID is" + PlaylistID);

            string check_query =
                "select * from Playlists inner join PlaylistListeners on " +
                "PlaylistListeners.Playlist_PlaylistID = Playlists.PlaylistID " +
                "where Playlist_PlaylistID=@PlaylistID and Listener_ListenerID=@id";
            SqlParameter[] check_params = new SqlParameter[2];
            check_params[0] = new SqlParameter("@id", id);
            check_params[1] = new SqlParameter("@PlaylistID", PlaylistID);
            List<Playlist> playlists = db.Playlists.SqlQuery(check_query, check_params).ToList();

            if (playlists.Count <= 0)
            {
                string query =
                    "insert into PlaylistListeners (Playlist_PlaylistID, Listener_ListenerID) " +
                    "values (@PlaylistID, @id)";
                SqlParameter[] sqlparams = new SqlParameter[2];
                sqlparams[0] = new SqlParameter("@id", id);
                sqlparams[1] = new SqlParameter("@PlaylistID", PlaylistID);

                db.Database.ExecuteSqlCommand(query, sqlparams);
            }

            return RedirectToAction("ListenerPlaylist/" + id);
        }
    }
}