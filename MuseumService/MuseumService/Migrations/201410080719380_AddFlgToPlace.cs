namespace MuseumService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddFlgToPlace : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "IsNeedRedirect", c => c.Boolean(nullable: false, defaultValue: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Places", "IsNeedRedirect");
        }
    }
}
