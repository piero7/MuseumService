namespace MuseumService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adIsLimit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Codes", "IsLimit", c => c.Boolean(nullable: false,defaultValue:false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Codes", "IsLimit");
        }
    }
}
