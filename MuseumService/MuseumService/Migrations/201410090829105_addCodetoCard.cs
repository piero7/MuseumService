namespace MuseumService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCodetoCard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cards", "CodeId", c => c.Int(nullable: true));
            CreateIndex("dbo.Cards", "CodeId");
            AddForeignKey("dbo.Cards", "CodeId", "dbo.Codes", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "CodeId", "dbo.Codes");
            DropIndex("dbo.Cards", new[] { "CodeId" });
            DropColumn("dbo.Cards", "CodeId");
        }
    }
}
