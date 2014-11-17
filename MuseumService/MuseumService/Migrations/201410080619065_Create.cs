namespace MuseumService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessTokens",
                c => new
                    {
                        AcceccTokenId = c.Int(nullable: false, identity: true),
                        Token = c.String(),
                        GetTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.AcceccTokenId);

            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        TwoDCodePath = c.String(),
                        EventNumber = c.String(),
                        PlaceId = c.Int(),
                        LastPalceStr = c.String(),
                        LastData = c.DateTime(),
                        IsNeedSkip = c.Boolean(nullable: false, defaultValue: false),
                        TotalUseTimes = c.Int(),
                        CardNumber = c.String(),
                    })
                .PrimaryKey(t => t.CardId)
                .ForeignKey("dbo.Places", t => t.PlaceId)
                .Index(t => t.PlaceId);

            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Codes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TwoDCodePath = c.String(),
                        EventNumber = c.String(),
                        TowDCodeContent = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Recodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PlaceId = c.Int(nullable: false),
                        CardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: false)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.PlaceId)
                .Index(t => t.CardId);

            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        OpenId = c.String(),
                        CardId = c.Int(),
                        NickName = c.String(),
                        subscribe = c.Boolean(nullable: false, defaultValue: false),
                        Sex = c.Int(nullable: false, defaultValue: 0),
                        City = c.String(),
                        Country = c.String(),
                        Province = c.String(),
                        Language = c.String(),
                        SubscribeTime = c.DateTime(),
                        Headimgurl = c.String(),
                        Level = c.Int(),
                        WatchTime = c.Int(),
                        IsNeedRedirect = c.Boolean(nullable: false, defaultValue: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Cards", t => t.CardId)
                .Index(t => t.CardId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Recodes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "CardId", "dbo.Cards");
            DropForeignKey("dbo.Recodes", "PlaceId", "dbo.Places");
            DropForeignKey("dbo.Recodes", "CardId", "dbo.Cards");
            DropForeignKey("dbo.Cards", "PlaceId", "dbo.Places");
            DropIndex("dbo.Users", new[] { "CardId" });
            DropIndex("dbo.Recodes", new[] { "CardId" });
            DropIndex("dbo.Recodes", new[] { "PlaceId" });
            DropIndex("dbo.Recodes", new[] { "UserId" });
            DropIndex("dbo.Cards", new[] { "PlaceId" });
            DropTable("dbo.Users");
            DropTable("dbo.Recodes");
            DropTable("dbo.Codes");
            DropTable("dbo.Places");
            DropTable("dbo.Cards");
            DropTable("dbo.AccessTokens");
        }
    }
}
