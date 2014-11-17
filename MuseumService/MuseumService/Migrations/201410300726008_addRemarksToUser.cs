namespace MuseumService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRemarksToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Remarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Remarks");
        }
    }
}
