namespace Stotify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Listeners",
                c => new
                    {
                        ListenerID = c.Int(nullable: false, identity: true),
                        ListenerFname = c.String(),
                        ListenerLname = c.String(),
                        ListenerEmail = c.String(),
                    })
                .PrimaryKey(t => t.ListenerID);
            
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        PlaylistID = c.Int(nullable: false, identity: true),
                        PlaylistName = c.String(),
                    })
                .PrimaryKey(t => t.PlaylistID);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongID = c.Int(nullable: false, identity: true),
                        SongName = c.String(),
                        ArttistName = c.String(),
                        SongYear = c.Int(nullable: false),
                        HasPic = c.Int(nullable: false),
                        PicExtension = c.String(),
                    })
                .PrimaryKey(t => t.SongID);
            
            CreateTable(
                "dbo.PlaylistListeners",
                c => new
                    {
                        Playlist_PlaylistID = c.Int(nullable: false),
                        Listener_ListenerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Playlist_PlaylistID, t.Listener_ListenerID })
                .ForeignKey("dbo.Playlists", t => t.Playlist_PlaylistID, cascadeDelete: true)
                .ForeignKey("dbo.Listeners", t => t.Listener_ListenerID, cascadeDelete: true)
                .Index(t => t.Playlist_PlaylistID)
                .Index(t => t.Listener_ListenerID);
            
            CreateTable(
                "dbo.SongPlaylists",
                c => new
                    {
                        Song_SongID = c.Int(nullable: false),
                        Playlist_PlaylistID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Song_SongID, t.Playlist_PlaylistID })
                .ForeignKey("dbo.Songs", t => t.Song_SongID, cascadeDelete: true)
                .ForeignKey("dbo.Playlists", t => t.Playlist_PlaylistID, cascadeDelete: true)
                .Index(t => t.Song_SongID)
                .Index(t => t.Playlist_PlaylistID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SongPlaylists", "Playlist_PlaylistID", "dbo.Playlists");
            DropForeignKey("dbo.SongPlaylists", "Song_SongID", "dbo.Songs");
            DropForeignKey("dbo.PlaylistListeners", "Listener_ListenerID", "dbo.Listeners");
            DropForeignKey("dbo.PlaylistListeners", "Playlist_PlaylistID", "dbo.Playlists");
            DropIndex("dbo.SongPlaylists", new[] { "Playlist_PlaylistID" });
            DropIndex("dbo.SongPlaylists", new[] { "Song_SongID" });
            DropIndex("dbo.PlaylistListeners", new[] { "Listener_ListenerID" });
            DropIndex("dbo.PlaylistListeners", new[] { "Playlist_PlaylistID" });
            DropTable("dbo.SongPlaylists");
            DropTable("dbo.PlaylistListeners");
            DropTable("dbo.Songs");
            DropTable("dbo.Playlists");
            DropTable("dbo.Listeners");
        }
    }
}
