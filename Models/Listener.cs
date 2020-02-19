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

        [Display(Name = "First Name")]
        public string ListenerFname { get; set; }

        [Display(Name = "Last Name")]
        public string ListenerLname { get; set; }
        [Display(Name = "Gender")]
        public string ListenerGender { get; set; }

        [Display(Name = "Email")]
        public string ListenerEmail { get; set; }

        //representing many to many to playlist
        public ICollection<Playlist> Playlists { get; set; }
    }
}