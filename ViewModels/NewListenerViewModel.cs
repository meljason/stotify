using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Stotify.Models;

namespace Stotify.ViewModels
{
    public class NewListenerViewModel
    {
        [Display(Name = "Playlist that you like")]
        public IEnumerable<Playlist> Playlists { get; set; }
        public Listener listener { get; set; }
    }
}