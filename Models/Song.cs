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
        public string SongName { get; set; }
        public string ArtistName { get; set; }
        public int SongYear { get; set; }
        public int HasPic { get; set; }
        public string PicExtension { get; set; }

        //representing many to many playlist
        public ICollection<Playlist> Playlists { get; set; }
    }
}