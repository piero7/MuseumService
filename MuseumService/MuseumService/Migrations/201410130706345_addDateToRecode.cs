namespace MuseumService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDateToRecode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recodes", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recodes", "Date");
        }
    }
}
