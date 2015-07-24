namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Liters = c.Double(nullable: false),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Weight = c.Double(nullable: false),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Movie_Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Name)
                .Index(t => t.Movie_Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Movie_Name", "dbo.Movies");
            DropIndex("dbo.Tickets", new[] { "Movie_Name" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Movies");
            DropTable("dbo.Foods");
            DropTable("dbo.Drinks");
        }
    }
}
