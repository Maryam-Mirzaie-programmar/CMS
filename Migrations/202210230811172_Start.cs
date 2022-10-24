namespace MyCms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageComments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        PageId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        Email = c.String(maxLength: 200),
                        Comment = c.String(nullable: false, maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Pages", t => t.PageId, cascadeDelete: true)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 250),
                        ShortDescription = c.String(nullable: false, maxLength: 350),
                        Text = c.String(nullable: false),
                        Tags = c.String(maxLength: 350),
                        ImageName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Visits = c.Int(nullable: false),
                        ShowInSlider = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PageId)
                .ForeignKey("dbo.PageGroups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.PageGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupTitle = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "GroupId", "dbo.PageGroups");
            DropForeignKey("dbo.PageComments", "PageId", "dbo.Pages");
            DropIndex("dbo.Pages", new[] { "GroupId" });
            DropIndex("dbo.PageComments", new[] { "PageId" });
            DropTable("dbo.PageGroups");
            DropTable("dbo.Pages");
            DropTable("dbo.PageComments");
        }
    }
}
