namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Charts",
                c => new
                    {
                        ChartId = c.Int(nullable: false, identity: true),
                        ChartUrl = c.String(),
                    })
                .PrimaryKey(t => t.ChartId);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        GalleryId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        IsTrue = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GalleryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Galleries");
            DropTable("dbo.Charts");
        }
    }
}
