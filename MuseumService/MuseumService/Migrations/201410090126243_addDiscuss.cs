namespace MuseumService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDiscuss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discusses",
                c => new
                    {
                        DiscussId = c.Int(nullable: false, identity: true),
                        OpenId = c.String(),
                        Content = c.String(),
                        CreateTime = c.DateTime(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.DiscussId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Discusses", "UserId", "dbo.Users");
            DropIndex("dbo.Discusses", new[] { "UserId" });
            DropTable("dbo.Discusses");
        }
    }
}
