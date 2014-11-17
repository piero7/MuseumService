namespace MuseumService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addWatchTimesToPlace : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "WatchTimes", c => c.Int(nullable: true, defaultValue: 0));
        }

        public override void Down()
        {
            DropColumn("dbo.Places", "WatchTimes");
        }
    }
}
