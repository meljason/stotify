using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stotify.Data;
using Stotify.Models;
using System.Data.Entity;
using Stotify.ViewModels;

namespace Stotify.Controllers
{
    public class PlaylistController : Controller
    {
        private StotifyContext db = new StotifyContext();
        // GET: Playlist/List
        public ActionResult List(string search)
        {
            //List<Playlist> playlists = db.Playlists.SqlQuery("SELECT * from Playlists").ToList();
            //return View(playlists);
            return View(db.Playlists.Where(p => p.PlaylistName.Contains(search) 
                                                || search == null).ToList());
        }

        //add song to playlist of playlist id = ?
        public ActionResult PlaylistSong(int id)
        {
            string query =
                "select * Songs inner join SongPlaylists on " +
                "Songs.SongID = SongPlaylists.Song_SongID " +
                "where Playlist_PlaylistID = @id";
            
            SqlParameter param = new SqlParameter("@id", id);
            List<Song> playlistSongs = db.Songs.SqlQuery(query, param).ToList();
            

            ShowPlaylistViewModel viewModel = new ShowPlaylistViewModel();
            viewModel.songs = playlistSongs;

            return View(viewModel);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Create(Playlist playlist)
        {
            db.Playlists.Add(playlist);
            db.SaveChanges();

            return RedirectToAction("List", "Playlist");
        }

        public ActionResult Show(int id)
        {
            string query = "select * from Playlists where PlaylistID = @id";
            var param = new SqlParameter("@id", id);
            Playlist selectedPlaylist = db.Playlists.SqlQuery(query, param).FirstOrDefault();

            return View(selectedPlaylist);
        }

        //This is to GET action  to retrieve the playlist data
        public ActionResult Edit(int id)
        {
            string query = "select * from Playlists where PlaylistID = @id";
            var param = new SqlParameter("@id", id);
            Playlist playlist = db.Playlists.SqlQuery(query, param).FirstOrDefault();

            return View(playlist);
        }

        [HttpPost]
        public ActionResult Edit(int id, Playlist playlist)
        {
            db.Entry(playlist).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            string query = "select * from Playlists where PlaylistID = @id";
            var param = new SqlParameter("@id", id);
            Playlist playlist = db.Playlists.SqlQuery(query, param).FirstOrDefault();

            return View(playlist);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Playlist playlist = db.Playlists.Where(l => l.PlaylistID == id).FirstOrDefault();
            db.Playlists.Remove(playlist);
            db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}