namespace Stotify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyTypoCorrectionToTableSong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "ArtistName", c => c.String());
            DropColumn("dbo.Songs", "ArttistName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "ArttistName", c => c.String());
            DropColumn("dbo.Songs", "ArtistName");
        }
    }
}
