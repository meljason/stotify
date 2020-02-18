using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stotify.Models
{
    public class Song
    {
        [Key]
        public int SongID { get; set; }
        [Display(Name = "Song Name")]
        public string SongName { get; set; }
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }
        [Display(Name = "Song Release Year")]
        public int SongYear { get; set; }
        public int HasPic { get; set; }
        public string PicExtension { get; set; }

        //representing many to many playlist
        public ICollection<Playlist> Playlists { get; set; }
    }
}