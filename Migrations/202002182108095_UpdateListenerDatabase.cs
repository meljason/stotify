namespace Stotify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateListenerDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listeners", "ListenerGender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Listeners", "ListenerGender");
        }
    }
}
