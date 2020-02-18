using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stotify.Models;

namespace Stotify.ViewModels
{
    public class ShowListenerViewModel
    {
        public IEnumerable<Playlist> Playlists { get; set; }

        public Listener Listener { get; set; }

    }
}