namespace Stotify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePlaylist : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Playlists (PlaylistName) VALUES ('Coding Music')");
            Sql("INSERT INTO Playlists (PlaylistName) VALUES ('Romance')");
            Sql("INSERT INTO Playlists (PlaylistName) VALUES ('Sleep Music')");
            Sql("INSERT INTO Playlists (PlaylistName) VALUES ('Korean')");
            Sql("INSERT INTO Playlists (PlaylistName) VALUES ('Funky Music')");
            Sql("INSERT INTO Playlists (PlaylistName) VALUES ('Back to childhood')");
        }
        
        public override void Down()
        {
        }
    }
}
