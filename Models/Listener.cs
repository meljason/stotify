using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stotify.Models
{
    public class Listener
    {
        [Key]
        public int ListenerID { get; set; }
        public string ListenerFname { get; set; }
        public string ListenerLname { get; set; }
        public char ListenerGender { get; set; }
        public string ListenerEmail { get; set; }

        //representing many to many to playlist
        public ICollection<Playlist> Playlists { get; set; }
    }
}