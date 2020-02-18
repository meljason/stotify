using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stotify.Models;

namespace Stotify.ViewModels
{
    public class ShowListenerViewModel
    {
        public virtual Listener listener { get; set; }

        public List<Playlist> playlists { get; set; }


    }
}