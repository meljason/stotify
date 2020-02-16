namespace Stotify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSongs : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Songs (SongName, ArtistName, SongYear, HasPic, PicExtension) VALUES ('Grenade', 'Bruno Mars', 2003, 1, 'jpeg')");
            Sql("INSERT INTO Songs (SongName, ArtistName, SongYear, HasPic, PicExtension) VALUES ('Circles', 'Post Malone', 2018, 1, 'jpeg')");
            Sql("INSERT INTO Songs (SongName, ArtistName, SongYear, HasPic, PicExtension) VALUES ('Ariana Grande', 'God is a woman', 2017, 1, 'jpeg')");
            Sql("INSERT INTO Songs (SongName, ArtistName, SongYear, HasPic, PicExtension) VALUES ('Bad', 'Michael Jackson', 1997, 1, 'jpeg')");
            Sql("INSERT INTO Songs (SongName, ArtistName, SongYear, HasPic, PicExtension) VALUES ('Home With You', 'Madison Beer', 2017, 1, 'jpeg')");
            Sql("INSERT INTO Songs (SongName, ArtistName, SongYear, HasPic, PicExtension) VALUES ('Without Me', 'Halsey', 2017, 1, 'jpeg')");
            Sql("INSERT INTO Songs (SongName, ArtistName, SongYear, HasPic, PicExtension) VALUES ('Secrets', 'The Weeknd', 2018, 1, 'jpeg')");
            Sql("INSERT INTO Songs (SongName, ArtistName, SongYear, HasPic, PicExtension) VALUES ('Yesterday', 'The Beetles', 1998, 1, 'jpeg')");
            Sql("INSERT INTO Songs (SongName, ArtistName, SongYear, HasPic, PicExtension) VALUES ('Sweet Child o Mine', 'Guns and Roses', 1989, 1, 'jpeg')");
            Sql("INSERT INTO Songs (SongName, ArtistName, SongYear, HasPic, PicExtension) VALUES ('Perfect', 'Ed Sheeran', 2018, 1, 'jpeg')");
            Sql("INSERT INTO Songs (SongName, ArtistName, SongYear, HasPic, PicExtension) VALUES ('Psycho', 'Post Malone', 2018, 1, 'jpeg')");
            Sql("INSERT INTO Songs (SongName, ArtistName, SongYear, HasPic, PicExtension) VALUES ('Better', 'Khalid', 2018, 1, 'jpeg')");
            Sql("INSERT INTO Songs (SongName, ArtistName, SongYear, HasPic, PicExtension) VALUES ('Halo', 'Beyonce', 2008, 1, 'jpeg')");
            Sql("INSERT INTO Songs (SongName, ArtistName, SongYear, HasPic, PicExtension) VALUES ('Do You Mean', 'Bulow', 2018, 1, 'jpeg')");
            Sql("INSERT INTO Songs (SongName, ArtistName, SongYear, HasPic, PicExtension) VALUES ('Not a love Song', 'Bulow', 2018, 1, 'jpeg')");
        }
        
        public override void Down()
        {
        }
    }
}
