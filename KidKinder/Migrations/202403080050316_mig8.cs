namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassRooms", "BlogRating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClassRooms", "BlogRating");
        }
    }
}
