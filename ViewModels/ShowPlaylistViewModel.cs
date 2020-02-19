using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stotify.Models;

namespace Stotify.ViewModels
{
    public class ShowPlaylistViewModel
    {
        public virtual Playlist playlist { get; set; }
        public List<Song> songs { get; set; }
    }
}