using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stotify.Models
{
    public class Playlist
    {
        [Key]
        public int PlaylistID { get; set; }
        [Display(Name = "Playlist Name")]
        public string PlaylistName { get; set; }

        //representing many to many to songs
        public ICollection<Song> Songs { get; set; }
        //representing many to many to listeners
        public ICollection<Listener> Listeners { get; set; }
    }
}