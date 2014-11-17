namespace MuseumService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Codes", "TwoDCodeContent", c => c.String());
            DropColumn("dbo.Codes", "TowDCodeContent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Codes", "TowDCodeContent", c => c.String());
            DropColumn("dbo.Codes", "TwoDCodeContent");
        }
    }
}
