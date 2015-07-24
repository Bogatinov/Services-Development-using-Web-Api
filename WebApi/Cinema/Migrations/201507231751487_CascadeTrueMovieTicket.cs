namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeTrueMovieTicket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Movie_Name", "dbo.Movies");
            AddForeignKey("dbo.Tickets", "Movie_Name", "dbo.Movies", "Name", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Movie_Name", "dbo.Movies");
            AddForeignKey("dbo.Tickets", "Movie_Name", "dbo.Movies", "Name");
        }
    }
}
