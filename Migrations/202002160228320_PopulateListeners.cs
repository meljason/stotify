namespace Stotify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateListeners : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Listeners (ListenerFname, ListenerLname, ListenerEmail) VALUES ('Sarah', 'Prisman', 'sarapris@hotmail.com')");
            Sql("INSERT INTO Listeners (ListenerFname, ListenerLname, ListenerEmail) VALUES ('Jason', 'Chong', 'jasonchong@hotmail.com')");
            Sql("INSERT INTO Listeners (ListenerFname, ListenerLname, ListenerEmail) VALUES ('Maisie', 'Williams', 'maisiewilliams@thenorth.com')");
        }
        
        public override void Down()
        {
        }
    }
}
