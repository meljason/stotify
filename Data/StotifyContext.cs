using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Stotify.Models;

namespace Stotify.Data
{
    public class StotifyContext : DbContext
    {
        public StotifyContext()
        {

        }

        public DbSet<Listener> Listeners { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }

    }
}